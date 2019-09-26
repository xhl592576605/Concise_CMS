using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Concise_CMS.AsyncRouters.Dto
{
    [AutoMap(typeof(AsyncRouterMap))]
    public class AsyncRouterMapDto : EntityDto
    {
        /// <summary>
        /// 路由器名称，小写，且唯一
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// 路由顺序
        /// </summary>
        [Required]
        public int Order { get; set; }

        public List<string> Roles
        {
            get; set;
        }
    }
}