using Sdl.TellMe.ProviderApi;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TradosStudioQuickInfo
{
    public class QuickInfoAction : ITellMeAction
    {
        private readonly object resultNode;

        public QuickInfoAction(string processorName, string text)
        {
            this.Description = $"Results from {processorName}";
            this.Name = text;
        }

        public string Name { get; set; } = "QuickInfo link";

        public string Category => "QuickInfo results";

        public string Description { get; set; } = "Opens a link returned in a quick info search";

        public Icon Icon => PluginResources.info_1930258;

        public bool IsAvailable => true;

        public void Execute()
        {
            Clipboard.SetText(Name);
        }
    }
}
