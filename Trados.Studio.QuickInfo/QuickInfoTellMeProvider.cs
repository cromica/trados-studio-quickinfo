using Sdl.TellMe.ProviderApi;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradosStudioQuickInfo
{
    [TellMeProvider]
    public class QuickInfoTellMeProvider : ITellMeProvider
    {
       
        public string Name => "QuickInfo tell me provider";

        public AbstractTellMeAction[] ProviderActions => new QuickInfoTellMeAction[]
        {
            new QuickInfoTellMeAction
                        {
                            Keywords = new string[] { "quick", "info", "quickinfo" }
                        }
        };
    }

    public class QuickInfoTellMeAction : AbstractTellMeAction
    {

        public QuickInfoTellMeAction()
        {
            Name = "QuickInfo action";

        }
        public override bool IsAvailable => true;

        public override string Category => "QuickInfo results";


        public override Icon Icon => PluginResources.info_1930258;



        public override void Execute()
        {
            Process.Start("https://appstore.sdl.com/language/app/sdl-quickinfo/938/");
        }
    }
}
