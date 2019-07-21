using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace Concise_CMS.EntityFrameworkCore
{
    public static class Concise_CMSDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<Concise_CMSDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<Concise_CMSDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
