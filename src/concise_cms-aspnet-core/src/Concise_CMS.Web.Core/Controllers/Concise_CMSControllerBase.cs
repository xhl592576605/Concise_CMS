using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace Concise_CMS.Controllers
{
    public abstract class Concise_CMSControllerBase: AbpController
    {
        protected Concise_CMSControllerBase()
        {
            LocalizationSourceName = Concise_CMSConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
