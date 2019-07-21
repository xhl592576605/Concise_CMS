using Abp.Authorization;
using Concise_CMS.Authorization.Roles;
using Concise_CMS.Authorization.Users;

namespace Concise_CMS.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
