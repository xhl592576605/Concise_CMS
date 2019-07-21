using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Concise_CMS.Roles.Dto;
using Concise_CMS.Users.Dto;

namespace Concise_CMS.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedUserResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input);
    }
}
