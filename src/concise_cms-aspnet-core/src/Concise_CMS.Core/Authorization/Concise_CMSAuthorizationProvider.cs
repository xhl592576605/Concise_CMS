using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace Concise_CMS.Authorization
{
    public class Concise_CMSAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            context.CreatePermission(PermissionNames.Pages_Users, L("Users"));
            context.CreatePermission(PermissionNames.Pages_Roles, L("Roles"));
            context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);
            context.CreatePermission(PermissionNames.Pages_AsyncRouters, L("AsyncRoutes"));
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, Concise_CMSConsts.LocalizationSourceName);
        }
    }
}