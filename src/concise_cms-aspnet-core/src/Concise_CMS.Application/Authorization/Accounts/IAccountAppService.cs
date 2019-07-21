using System.Threading.Tasks;
using Abp.Application.Services;
using Concise_CMS.Authorization.Accounts.Dto;

namespace Concise_CMS.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
