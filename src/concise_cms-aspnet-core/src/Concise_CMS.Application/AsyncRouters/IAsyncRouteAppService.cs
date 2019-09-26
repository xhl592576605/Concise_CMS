using Abp.Application.Services;
using Concise_CMS.AsyncRouters.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Concise_CMS.AsyncRouters
{
    public interface IAsyncRouteAppService : IAsyncCrudAppService<AsyncRouteDto, long, PagedAsyncRouteResultRequestDto, CreateAsyncRouteDto, AsyncRouteDto>
    {
        /// <summary>
        /// 创建菜单
        /// </summary>
        /// <returns></returns>
        Task<List<AsyncRouteMenuDto>> BuildAsyncRouteMenus();

        /// <summary>
        /// 更新菜单排序，并返回新的菜单
        /// </summary>
        /// <param name="orderDto"></param>
        /// <returns></returns>
        Task<List<AsyncRouteMenuDto>> UpdateAsyncRoutesOrder(List<AsyncRouteOrderDto> orderDto);
    }
}