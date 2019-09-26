using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Concise_CMS.AsyncRouters.Dto
{
    public class PagedAsyncRouteResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}