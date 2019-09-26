using System;
using System.Collections.Generic;
using System.Text;

namespace Concise_CMS.AsyncRouters.Dto
{
    public class AsyncRouterMapOrderDto
    {
        public string Name { get; set; }
        public List<AsyncRouterMapOrderDto> Children { get; set; }
    }
}