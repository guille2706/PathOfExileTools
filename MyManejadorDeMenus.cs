using System;

using CefSharp;
using EasyTabs;
using System.Windows.Forms;




namespace SandBox
{
    public  class MyManejadorDeMenus : IContextMenuHandler
    {

        public void OnBeforeContextMenu(IWebBrowser browserControl, IBrowser browser, IFrame frame, IContextMenuParams parameters, IMenuModel model)
        {

            if (model.Count > 0)
            {
                model.AddSeparator();

            }
            //borrar evento
            
            model.Remove((CefMenuCommand)100);
            model.Remove((CefMenuCommand)101);

            // agregar nuevo item
            model.AddSeparator();
            model.AddItem((CefMenuCommand)113, "Copy");
            model.AddSeparator();
            model.AddItem((CefMenuCommand)26501, "Mostrar Dev Tools");
            model.AddItem((CefMenuCommand)26502, "Cerrar Dev Tools");
            model.AddSeparator();
            model.AddItem((CefMenuCommand)26503, "Copiar Enlace...");





        }

        

        public bool OnContextMenuCommand(IWebBrowser browserControl, IBrowser browser, IFrame frame, IContextMenuParams parameters, CefMenuCommand commandId, CefEventFlags eventFlags)
        {
            // reaccionar al primer ID y hacer algo
            if (commandId == (CefMenuCommand)26501)
            {
                browser.GetHost().ShowDevTools();
                return true;

            }
            // reaccionar al segundo Id
            if (commandId == (CefMenuCommand)26502)
            {
                browser.GetHost().CloseDevTools();
                return true;

            }
            // reaccionar al tercer id

            if (commandId == (CefMenuCommand)26503)

                try
                {
                    Clipboard.SetText(parameters.LinkUrl);


                    return true;

                }


                catch (Exception exepcion)

                {
                    MessageBox.Show("¡¡ Error.. no se pudo copiar " + exepcion.Message);
                }
                       
           

            return false;


        }

        public void OnContextMenuDismissed(IWebBrowser browserControl, IBrowser browser, IFrame frame)
        {

        }

        public bool RunContextMenu(IWebBrowser browserControl, IBrowser browser, IFrame frame, IContextMenuParams parameters, IMenuModel model, IRunContextMenuCallback callback)
        {
            return false;
        }
    }

}

