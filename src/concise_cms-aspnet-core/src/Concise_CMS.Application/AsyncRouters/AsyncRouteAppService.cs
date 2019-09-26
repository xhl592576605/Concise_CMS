using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Concise_CMS.AsyncRouters.Dto;
using Concise_CMS.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Concise_CMS.AsyncRouters
{
    [AbpAuthorize(PermissionNames.Pages_AsyncRouters)]
    public class AsyncRouteAppService : AsyncCrudAppService<AsyncRoute, AsyncRouteDto, long, PagedAsyncRouteResultRequestDto, CreateAsyncRouteDto, AsyncRouteDto>, IAsyncRouteAppService
    {
        public AsyncRouteAppService(IRepository<AsyncRoute, long> repository) : base(repository)
        {
        }

        public override async Task<AsyncRouteDto> Create(CreateAsyncRouteDto input)
        {
            CheckCreatePermission();
            var asyncRoute = ObjectMapper.Map<AsyncRoute>(input);
            asyncRoute.Meta.RolesStr = string.Join(";", input.Meta.Roles.ToArray());
            asyncRoute.TenantId = AbpSession.TenantId;
            await Repository.InsertAsync(asyncRoute);
            return MapToEntityDto(asyncRoute);
        }

        [UnitOfWork]
        public override async Task Delete(EntityDto<long> input)
        {
            //UnitOfWork 保证原子性
            //级联删除

            var asyncRoute = await Repository.GetAsync(input.Id);
            foreach (var child in asyncRoute.Children)
            {
                await Delete(new EntityDto<long>() { Id = child.Id });
            }

            await base.Delete(input);
        }

        public override async Task<AsyncRouteDto> Get(EntityDto<long> input)
        {
            return await base.Get(input);
        }

        public override async Task<PagedResultDto<AsyncRouteDto>> GetAll(PagedAsyncRouteResultRequestDto input)
        {
            return await base.GetAll(input);
        }

        public override async Task<AsyncRouteDto> Update(AsyncRouteDto input)
        {
            CheckUpdatePermission();
            var asyncRoute = await Repository.GetAsync(input.Id);
            ObjectMapper.Map(input, asyncRoute);
            asyncRoute.Meta.RolesStr = string.Join(";", input.Meta.Roles.ToArray());
            await Repository.UpdateAsync(asyncRoute);
            return MapToEntityDto(asyncRoute);
        }

        [HttpGet]
        public async Task<List<AsyncRouteMenuDto>> BuildAsyncRouteMenus()
        {
            CheckGetAllPermission();
            IEnumerable<AsyncRoute> allAsyncRoutes = Repository.GetAll();
            var menuAsyncRoutes = allAsyncRoutes.Where(route => route.ParentId == null).ToList();
            return await GetSubAsyncRouteMenu(menuAsyncRoutes, allAsyncRoutes);
        }

        private async Task<List<AsyncRouteMenuDto>> GetSubAsyncRouteMenu(IEnumerable<AsyncRoute> menuAsyncRoutes, IEnumerable<AsyncRoute> allAsyncRoutes)
        {
            var result = new List<AsyncRouteMenuDto>();
            foreach (var item in menuAsyncRoutes)
            {
                var menuTmp = ObjectMapper.Map<AsyncRouteMenuDto>(item);
                menuTmp.Children = await GetSubAsyncRouteMenu(item.Children.Where(route => allAsyncRoutes.Count(ar => ar.Id == route.Id) > 0), allAsyncRoutes);
                result.Add(menuTmp);
            }
            return result;
        }

        [UnitOfWork]
        public async Task<List<AsyncRouteMenuDto>> UpdateAsyncRoutesOrder(List<AsyncRouteOrderDto> orderDto)
        {
            CheckGetAllPermission();
            IEnumerable<AsyncRoute> allAsyncRoutes = Repository.GetAll();
            if (orderDto != null)
            {
                return ObjectMapper.Map<List<AsyncRouteMenuDto>>(
                    await UpdateSubAsyncRoutes(orderDto, allAsyncRoutes));
            }
            else
            {
                return ObjectMapper.Map<List<AsyncRouteMenuDto>>(allAsyncRoutes);
            }
        }

        [UnitOfWork]
        private async Task<IEnumerable<AsyncRoute>> UpdateSubAsyncRoutes(List<AsyncRouteOrderDto> orderDto, IEnumerable<AsyncRoute> allAsyncRoutes)
        {
            List<AsyncRoute> result = new List<AsyncRoute>();
            if (orderDto != null)
            {
                int order = 1;
                foreach (var item in orderDto)
                {
                    var temAsyncRoute = allAsyncRoutes.FirstOrDefault(p => p.Id == item.Id);
                    if (temAsyncRoute != null)
                    {
                        temAsyncRoute.Order = order++;
                        temAsyncRoute.ParentId = null;
                        temAsyncRoute.Parent = null;
                        temAsyncRoute.Children.Clear();
                        foreach (var childPermission in await UpdateSubAsyncRoutes(item.children, allAsyncRoutes))
                        {
                            temAsyncRoute.Children.Add(childPermission);
                        }
                    }

                    await Repository.UpdateAsync(temAsyncRoute);
                    result.Add(temAsyncRoute);
                }
            }
            return result;
        }
    }
}