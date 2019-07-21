using Abp.Application.Features;
using Abp.Domain.Repositories;
using Abp.MultiTenancy;
using Concise_CMS.Authorization.Users;
using Concise_CMS.Editions;

namespace Concise_CMS.MultiTenancy
{
    public class TenantManager : AbpTenantManager<Tenant, User>
    {
        public TenantManager(
            IRepository<Tenant> tenantRepository, 
            IRepository<TenantFeatureSetting, long> tenantFeatureRepository, 
            EditionManager editionManager,
            IAbpZeroFeatureValueStore featureValueStore) 
            : base(
                tenantRepository, 
                tenantFeatureRepository, 
                editionManager,
                featureValueStore)
        {
        }
    }
}
