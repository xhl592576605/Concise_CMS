using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Concise_CMS.Configuration;

namespace Concise_CMS.Web.Host.Startup
{
    [DependsOn(
       typeof(Concise_CMSWebCoreModule))]
    public class Concise_CMSWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public Concise_CMSWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(Concise_CMSWebHostModule).GetAssembly());
        }
    }
}
