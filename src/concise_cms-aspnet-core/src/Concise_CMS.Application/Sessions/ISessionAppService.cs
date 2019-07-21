using System.Threading.Tasks;
using Abp.Application.Services;
using Concise_CMS.Sessions.Dto;

namespace Concise_CMS.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
