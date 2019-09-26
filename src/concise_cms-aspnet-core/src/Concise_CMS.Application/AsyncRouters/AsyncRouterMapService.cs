using Abp.Application.Services;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Concise_CMS.AsyncRouters.Dto;
using Concise_CMS.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concise_CMS.AsyncRouters
{
    [AbpAuthorize(PermissionNames.Pages_AsyncRouters)]
    public class AsyncRouterMapService : AsyncCrudAppService<AsyncRouterMap, AsyncRouterMapDto, int>, IAsyncRouterMapService
    {
        public AsyncRouterMapService(IRepository<AsyncRouterMap, int> repository) : base(repository)
        {
        }

        public override async Task<AsyncRouterMapDto> Create(AsyncRouterMapDto input)
        {
            CheckCreatePermission();
            var asyncRouteMap = ObjectMapper.Map<AsyncRouterMap>(input);
            asyncRouteMap.RolesStr = string.Join(";", input.Roles.ToArray());
            asyncRouteMap.TenantId = AbpSession.TenantId;
            await Repository.InsertAsync(asyncRouteMap);
            return MapToEntityDto(asyncRouteMap);
        }

        public override async Task<AsyncRouterMapDto> Update(AsyncRouterMapDto input)
        {
            CheckUpdatePermission();
            var asyncRoute = await Repository.GetAsync(input.Id);
            ObjectMapper.Map(input, asyncRoute);
            asyncRoute.RolesStr = string.Join(";", input.Roles.ToArray());
            await Repository.UpdateAsync(asyncRoute);
            return MapToEntityDto(asyncRoute);
        }

        [UnitOfWork]
        public async Task UpdateAsyncRoutersMapOrder(List<AsyncRouterMapOrderDto> orderDto)
        {
            CheckGetAllPermission();
            IEnumerable<AsyncRouterMap> allAsyncRoutesMap = Repository.GetAll();
            if (orderDto != null)
            {
                await UpdateSubAsyncRoutesMap(orderDto, allAsyncRoutesMap);
            }
        }

        [UnitOfWork]
        private async Task UpdateSubAsyncRoutesMap(List<AsyncRouterMapOrderDto> orderDto, IEnumerable<AsyncRouterMap> allAsyncRoutesMap)
        {
            if (orderDto != null)
            {
                int order = 1;
                foreach (var item in orderDto)
                {
                    var temAsyncRoute = allAsyncRoutesMap.FirstOrDefault(p => p.Name == item.Name);
                    if (temAsyncRoute != null)
                    {
                        temAsyncRoute.Order = order++;
                        await Repository.UpdateAsync(temAsyncRoute);
                    }
                    else
                    {
                        temAsyncRoute = MapToEntity(await Create(new AsyncRouterMapDto()
                        {
                            Name = item.Name,
                            Order = order++,
                            Roles = new List<string>()
                        }));
                    }
                    await UpdateSubAsyncRoutesMap(item.Children, allAsyncRoutesMap);
                }
            }
        }
    }
}