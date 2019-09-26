using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Concise_CMS.AsyncRouters.Dto
{
    public class AsyncRouteOrderDto
    {
        public long Id { get; set; }
        public List<AsyncRouteOrderDto> children { get; set; }
    }
}