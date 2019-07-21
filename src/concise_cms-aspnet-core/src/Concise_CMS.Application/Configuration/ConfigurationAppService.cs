using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using Concise_CMS.Configuration.Dto;

namespace Concise_CMS.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : Concise_CMSAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
