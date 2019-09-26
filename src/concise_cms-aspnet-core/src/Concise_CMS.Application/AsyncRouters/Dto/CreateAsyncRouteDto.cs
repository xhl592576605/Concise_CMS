using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Concise_CMS.AsyncRouters.Dto
{
    [AutoMap(typeof(AsyncRoute))]
    public class CreateAsyncRouteDto
    {
        /// <summary>
        /// 路由名称
        /// </summary>
        [Required]
        [DisplayName("路由名称")]
        public string Name { get; set; }

        /// <summary>
        /// 路由地址
        /// </summary>
        [Required]
        [DisplayName("路由地址")]
        public string Path { get; set; }

        /// <summary>
        /// 组件地址
        /// </summary>
        [Required]
        [DisplayName("组件地址")]
        public string Component { get; set; }

        /// <summary>
        /// 回调地址
        /// </summary>
        [DisplayName("回调地址")]
        public string Redirect { get; set; }

        /// <summary>
        /// 是否隐藏
        /// </summary>
        [DisplayName("是否隐藏")]
        public bool Hidden { get; set; }

        /// <summary>
        /// 是否一直显示
        /// </summary>
        [DisplayName("是否一直显示")]
        public bool AlwaysShow { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        [DisplayName("排序")]
        public int Order { get; set; }

        /// <summary>
        /// 路由信息
        /// </summary>
        //[ForeignKey("MetaId")]
        [DisplayName("路由信息")]
        public virtual MetaDto Meta { get; set; }

        /// <summary>
        /// 父ID
        /// </summary>
        [DisplayName("父路由id")]
        public long? ParentId { get; set; }
    }
}