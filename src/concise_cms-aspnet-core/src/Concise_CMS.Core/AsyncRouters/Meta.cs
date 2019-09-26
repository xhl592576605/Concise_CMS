using Abp.AutoMapper;
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
    /// <summary>
    /// 路由所带信息
    /// </summary>
    [Table("concise_asyncroute_meta")]
    public class Meta : Entity<long>
    {
        /// <summary>
        /// 页面标题
        /// </summary>
        [Required]
        [DisplayName("页面标题")]
        public string Title { get; set; }

        /// <summary>
        /// 菜单图标
        /// </summary>
        [DisplayName("菜单图标")]
        public string Icon { get; set; }

        /// <summary>
        /// 可以访问的角色
        /// </summary>
        [DisplayName("可以访问的角色")]
        [Required]
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

        /// <summary>
        /// 页面缓存
        /// </summary>
        [DisplayName("页面缓存")]
        public bool NoCache { get; set; }
    }
}