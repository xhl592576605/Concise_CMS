using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using Concise_CMS.Authorization.Roles;
using Concise_CMS.Authorization.Users;
using Concise_CMS.MultiTenancy;
using Concise_CMS.AsyncRouters;

namespace Concise_CMS.EntityFrameworkCore
{
    public class Concise_CMSDbContext : AbpZeroDbContext<Tenant, Role, User, Concise_CMSDbContext>
    {
        /* Define a DbSet for each entity of the application */

        public Concise_CMSDbContext(DbContextOptions<Concise_CMSDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 设置表的前缀
            modelBuilder.ChangeAbpTablePrefix<Tenant, Role, User>("concise_");

            #region 路由

            //modelBuilder.Entity<AsyncRoute>(
            //    entity =>
            //    {
            //        //.ToTable("concise_asyncroute").Property(u => u.Meta);
            //        entity.ToTable("concise_asyncroute");
            //        entity.HasOne(e => e.Meta)
            //            //.WithOne(e => e.Id)
            //            .HasForeignKey<AsyncRoute>(e => e.MetaId);
            //        //entity.HasOne(e => e.Meta)
            //        //    .WithOne(e => e.AsyncRoute)
            //        //    .HasForeignKey<Meta>(f => f.AsyncRouteId);
            //        //entity.HasOne(e => e.Parent)
            //        //    .WithMany(e => e.Children)
            //        //    .HasForeignKey(e => e.ParentId);
            //    }
            //    );
            //modelBuilder.Entity<Meta>(
            //    entity =>
            //    {
            //        entity.ToTable("concise_asyncroute_meta");
            //        //entity.HasOne(e => e.AsyncRoute)
            //        //    .WithOne(e => e.Meta);
            //    }
            //    );

            modelBuilder.Entity<AsyncRouterMap>(
                entity =>
                {
                    entity.ToTable("concise_asyncrouter_map");
                    entity.HasKey(i => i.Id);
                    entity.Property(i => i.Name).IsRequired();
                    //entity.Property(i => i.RolesStr).IsRequired();
                    //entity.HasIndex(i => i.Name).IsUnique();
                    entity.Ignore(i => i.Roles);
                });

            #endregion 路由

            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<AsyncRoute> AsyncRoutes { get; set; }
        public virtual DbSet<Meta> Metas { get; set; }
        public virtual DbSet<AsyncRouterMap> AsyncRouterMaps { get; set; }
    }
}