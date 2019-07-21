using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Concise_CMS.Configuration;
using Concise_CMS.Web;

namespace Concise_CMS.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class Concise_CMSDbContextFactory : IDesignTimeDbContextFactory<Concise_CMSDbContext>
    {
        public Concise_CMSDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<Concise_CMSDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            Concise_CMSDbContextConfigurer.Configure(builder, configuration.GetConnectionString(Concise_CMSConsts.ConnectionStringName));

            return new Concise_CMSDbContext(builder.Options);
        }
    }
}
