using Abp.Application.Services;
using Concise_CMS.MultiTenancy.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Concise_CMS.MultiTenancy
{
    public interface ITenantRegistrationAppService: IApplicationService
    {
        Task<TenantDto> RegisterTenant(CreateTenantDto input);
    }
}
