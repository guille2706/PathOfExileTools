using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using EasyTabs;
using CefSharp;
using CefSharp.WinForms;


namespace SandBox
{
   public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            CefSettings settings = new CefSettings(); // solo se puede inicializar 1 vez
            Cef.Initialize(settings);

            //  AppContainer container = new AppContainer();
            PoE_Tools container1 = new PoE_Tools();

            //agrega tab inicial
            container1.Tabs.Add(
                new TitleBarTab(container1)
                {
                    Content = new Form1 
                    {
                       
                        Text = "Nueva Pestaña"
                    }

                }
                
                );

            // setear la tab inicial

            container1.SelectedTabIndex = 0;

            // crea tab y comienza la aplicacion
            TitleBarTabsApplicationContext applicationContext = new TitleBarTabsApplicationContext();
            applicationContext.Start(container1);
            Application.Run(applicationContext);

        }
    }
}
