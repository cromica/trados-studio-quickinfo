using System;
using System.Collections.Generic;
using Sdl.Desktop.IntegrationApi;
using Sdl.Desktop.IntegrationApi.Extensions;
using Sdl.TellMe.ProviderApi;
using Sdl.TranslationStudioAutomation.IntegrationApi;
using Sdl.TranslationStudioAutomation.IntegrationApi.Extensions;

namespace TradosStudioQuickInfo
{
    [TellMeSearchProvider]
    public class QuickInfoProvider : ITellMePluginLoader
    {
        public ISearchDataProvider InitializeProvider()
        {
            var quickInfoSearchDataProvider = new QuickInfoSearchDataProvider();
            return quickInfoSearchDataProvider;
        }
    }
}
