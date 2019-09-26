using Abp.Application.Services;
using Concise_CMS.AsyncRouters.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Concise_CMS.AsyncRouters
{
    public interface IAsyncRouterMapService : IAsyncCrudAppService<AsyncRouterMapDto, int>
    {
        Task UpdateAsyncRoutersMapOrder(List<AsyncRouterMapOrderDto> orderDto);
    }
}