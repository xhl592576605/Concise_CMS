using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Concise_CMS.Authorization;

namespace Concise_CMS
{
    [DependsOn(
        typeof(Concise_CMSCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class Concise_CMSApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<Concise_CMSAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(Concise_CMSApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddProfiles(thisAssembly)
            );
        }
    }
}
