using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Concise_CMS.AsyncRouters.Dto
{
    [AutoMap(typeof(Meta))]
    public class MetaDto
    {
        /// <summary>
        /// 页面标题
        /// </summary>
        [DisplayName("页面标题")]
        public string Title { get; set; }

        /// <summary>
        /// 菜单图标
        /// </summary>
        [DisplayName("菜单图标")]
        public string Icon { get; set; }

        public List<string> Roles
        {
            get; set;
        }

        /// <summary>
        /// 页面缓存
        /// </summary>
        [DisplayName("页面缓存")]
        public bool NoCache { get; set; }
    }
}