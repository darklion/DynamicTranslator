﻿using System.Reflection;

using Abp.Dependency;

using DynamicTranslator.Application;
using DynamicTranslator.Bing.Configuration;
using DynamicTranslator.LanguageManagement;

namespace DynamicTranslator.Bing
{
    public class DynamicTranslatorBingModule : DynamicTranslatorModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            Configurations.ModuleConfigurations.UseBingTranslate().WithConfigurations(configuration =>
            {
                configuration.Url = "http://dictionary.cambridge.org/translate/ajax";
                configuration.SupportedLanguages = LanguageMapping.Bing.ToLanguages();
            });

            IocManager.Register<IMeanFinder, BingTranslatorFinder>(DependencyLifeStyle.Transient);
            IocManager.Register<IMeanOrganizer, BingTranslatorMeanOrganizer>(DependencyLifeStyle.Transient);
        }
    }
}