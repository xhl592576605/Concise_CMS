using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace Concise_CMS.EntityFrameworkCore
{
    public static class Concise_CMSDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<Concise_CMSDbContext> builder, string connectionString)
        {
            //UseLazyLoadingProxies core2.1 不默认开始延迟加载，需要引用Microsoft.EntityFrameworkCore.Proxies，配置才能延迟加载
            builder.UseLazyLoadingProxies().UseMySql(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<Concise_CMSDbContext> builder, DbConnection connection)
        {
            builder.UseLazyLoadingProxies().UseMySql(connection);
        }
    }
}