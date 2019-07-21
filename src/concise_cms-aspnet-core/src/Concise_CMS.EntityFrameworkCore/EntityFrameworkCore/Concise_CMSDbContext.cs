using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using Concise_CMS.Authorization.Roles;
using Concise_CMS.Authorization.Users;
using Concise_CMS.MultiTenancy;

namespace Concise_CMS.EntityFrameworkCore
{
    public class Concise_CMSDbContext : AbpZeroDbContext<Tenant, Role, User, Concise_CMSDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public Concise_CMSDbContext(DbContextOptions<Concise_CMSDbContext> options)
            : base(options)
        {
        }
    }
}
