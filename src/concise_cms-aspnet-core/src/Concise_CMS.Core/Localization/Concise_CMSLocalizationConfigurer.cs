using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace Concise_CMS.Localization
{
    public static class Concise_CMSLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(Concise_CMSConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(Concise_CMSLocalizationConfigurer).GetAssembly(),
                        "Concise_CMS.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
