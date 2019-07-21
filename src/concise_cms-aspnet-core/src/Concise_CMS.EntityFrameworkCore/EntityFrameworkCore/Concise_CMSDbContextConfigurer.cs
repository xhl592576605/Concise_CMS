using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace Concise_CMS.EntityFrameworkCore
{
    public static class Concise_CMSDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<Concise_CMSDbContext> builder, string connectionString)
        {
            builder.UseMySql(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<Concise_CMSDbContext> builder, DbConnection connection)
        {
            builder.UseMySql(connection);
        }
    }
}