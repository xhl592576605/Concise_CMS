using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Concise_CMS.AsyncRouters
{
    public class AsyncRouterMap : Entity, IMayHaveTenant
    {
        /// <summary>
        /// 路由器名称，小写，且唯一
        /// </summary>
        [DisplayName("路由器名称，小写，且唯一")]
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// 路由顺序
        /// </summary>
        [DisplayName("路由顺序")]
        [Required]
        public int Order { get; set; }

        /// <summary>
        /// 可以访问的角色
        /// </summary>
        [DisplayName("可以访问的角色")]
        public string RolesStr { get; set; }

        [NotMapped]
        public virtual List<string> Roles
        {
            get
            {
                return this.RolesStr.Split(';').ToList();
            }
            internal set { }
        }

        public int? TenantId { get; set; }
    }
}