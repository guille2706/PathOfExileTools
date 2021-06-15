using System;
using EasyTabs;

namespace SandBox
{
    public partial class PoE_Tools : TitleBarTabs
    {
        public PoE_Tools()
        {
            InitializeComponent();
            AeroPeekEnabled = true;
            TabRenderer = new ChromeTabRenderer(this);
        }

        public override TitleBarTab CreateTab()
        {
            return new TitleBarTab(this)
            {
                Content = new Form1 {Text = "Nueva Pestaña" }
            };
        }
    }
}
