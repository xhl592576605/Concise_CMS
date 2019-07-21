using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Concise_CMS.MultiTenancy.Dto;

namespace Concise_CMS.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

