using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace datntdev.Microservices.Localization;

public static class MicroservicesLocalizationConfigurer
{
    public static void Configure(ILocalizationConfiguration localizationConfiguration)
    {
        localizationConfiguration.Sources.Add(
            new DictionaryBasedLocalizationSource(MicroservicesConsts.LocalizationSourceName,
                new XmlEmbeddedFileLocalizationDictionaryProvider(
                    typeof(MicroservicesLocalizationConfigurer).GetAssembly(),
                    "datntdev.Microservices.Localization.SourceFiles"
                )
            )
        );
    }
}
