using System.Threading.Tasks;
using Concise_CMS.Configuration.Dto;

namespace Concise_CMS.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
