using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EasyTabs;
using CefSharp;
using CefSharp.WinForms;
using CefSharp.WinForms.Internals;
using System.Diagnostics;
using HtmlAgilityPack;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;
using mshtml;
using System.Net;
using System.IO;
using System.Collections;

namespace SandBox
{
    public partial class Form1 : Form
    {
        public ChromiumWebBrowser navegador;
        
        Configuracion ventanaConfig;
        Size tamaño;
        public static  PoE_Tools container = new PoE_Tools(); 
        double medida = 0.5;





        protected TitleBarTabs ParentTabs 
        {
            get 
            {
                return (ParentForm as TitleBarTabs);
                        
            }
        
        }

        public Form1()
        {
            InitializeComponent();
           

            InicializarChromium();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

       

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
         //   Cef.Shutdown();
            
             

        }

        public void InicializarChromium()

        {
            //inicializar
           

            navegador = new ChromiumWebBrowser();
            navegador.Dock = DockStyle.Fill;
            panelNavegador.Controls.Add(navegador);
            navegador.AddressChanged += Chrome_AddressChanged;

            Navegar("https://www.pathofexile.com/trade");
           

                    
           


         

            //probando evento si termino de cargar la pagina
            navegador.LoadingStateChanged += Pagina_Cargada;
           

            //agregando menu contextual

            navegador.MenuHandler = new MyManejadorDeMenus();
            




        }

        private void Pagina_Cargada(object sender, LoadingStateChangedEventArgs e)
        {
            if (e.IsLoading == false) 
            {
                QuitarPublicidad();
            }
        }

        private void Chrome_AddressChanged(object sender, AddressChangedEventArgs e) // evento que detecta los cambios en la url
        {
            this.Invoke(new MethodInvoker(() =>
           {
               textBoxNav.Text = e.Address;
               this.Text = e.Address; // ademas cambio el texto de la tab
           }));

        }


        public void  Navegar(string _text) {

            if (String.IsNullOrWhiteSpace(_text)) 
            {
                return;
            }

            if (_text.Equals("about:blank")) 
            {

                return;
            }
            if (!_text.StartsWith("http://") && !_text.StartsWith("https://" ) )
                {
                _text = "http://" + _text;
                }

                 navegador.Load(_text);
                 this.Text = _text;
                 textBoxNav.Text = _text;
                
                


            try
            {
           


                // datos ok, entonces navegar
               
                 
                navegador.Load(_text);
                this.Text = _text;
                textBoxNav.Text = _text;

                // Quitar la publicidad

                if (navegador.IsLoading == false) 
                {
                    QuitarPublicidad();
                }

                //fin de quitar la publicidad


            }
            catch (System.UriFormatException)
            {
                return;

            }


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Navegar(textBoxNav.Text);
                e.SuppressKeyPress = true;
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
             
            Navegar(textBoxNav.Text);
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            navegador.Stop();
           

        }

        private void button5_Click(object sender, EventArgs e)
        {
            navegador.Reload();
            


        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBoxNav.Text = "https://www.google.com/";
            Navegar(textBoxNav.Text);
           
        }
         

        private void button3_Click(object sender, EventArgs e)
        {
            if (navegador.CanGoForward) 
            {
                navegador.Forward();
               


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBoxNav.Text = navegador.Address;

            if (navegador.CanGoBack)
            {
              
                navegador.Back();
               




            }
        }

        

        private void button7_Click(object sender, EventArgs e)
        {
            ventanaConfig = new Configuracion();
            tamaño.Width = Size.Width + 20;
            tamaño.Height = Size.Height + 20;

            ventanaConfig.Size = tamaño;
          
            ventanaConfig.ShowDialog();
        }

        private void Form1_ResizeBegin(object sender, EventArgs e)
        {
           
        }

        private void btnTrade_Click(object sender, EventArgs e)
        {
            Navegar("https://www.pathofexile.com/trade/search/Expedition");
        }

        private void btnCurrency_Click(object sender, EventArgs e)
        {
            Navegar("https://www.pathofexile.com/trade/exchange/Expedition");
        }

        private void btnNinja_Click(object sender, EventArgs e)
        {
            Navegar("https://poe.ninja/");
        }

        private void btnCraft_Click(object sender, EventArgs e)
        {
            Navegar("https://www.craftofexile.com/");
        }

        private void btnDb_Click(object sender, EventArgs e)
        {
            Navegar("https://poedb.tw/us");
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            Navegar("https://siveran.github.io/calc.html");
        }

        private void btnLab_Click(object sender, EventArgs e)
        {
            Navegar("https://www.poelab.com/");
        }

        private void btnWiki_Click(object sender, EventArgs e)
        {
            Navegar("https://pathofexile.fandom.com/wiki/Vendor_recipe_system");
        }

        private void btnBuild_Click(object sender, EventArgs e)
        {
            Navegar("https://www.poebuilds.net/builds/witch/summon-reaper");
        }

        private void btnActos_Click(object sender, EventArgs e)
        {
            Navegar("https://i.imgur.com/UZuKoNu.jpeg");
        
        }

        private void btnLogros_Click(object sender, EventArgs e)
        {
           
            System.Diagnostics.Process.Start("microsoft-edge:https://docs.google.com/document/d/1cX-9i2U4rW8hwmrkoj0ZjtzI8N-XZ7dIttihNhK4WOA/edit?usp=sharing");
        }

        private void btnTab_Click(object sender, EventArgs e)
        { }

           

        private void Form1_Click(object sender, EventArgs e)
        {

        }
        //probando Evento zoom in y out 
      

        private void button8_Click(object sender, EventArgs e)
        {

            medida++;
            navegador.SetZoomLevel(medida);
        }

        private void btnNoZoom_Click(object sender, EventArgs e)
        {
            medida = 0;
            navegador.SetZoomLevel(medida);
        }

        private void btnLupaMenos_Click(object sender, EventArgs e)
        {
            medida--;
            navegador.SetZoomLevel(medida);
        }

        private void btn_Bloquear_Click(object sender, EventArgs e)
        {
            // bloquear publicidad

            QuitarPublicidad();
        }

        private void QuitarPublicidad()
        {
            try
            {

             



                //Utilizao Jquery, creo que por eso usa el signo $, lo que hago aca es cargar
                // la linea de comando en un string y luego ejecutarla (es una posibilidad de Cefsharp: executeScriptAsync
              

                String directorio = Environment.CurrentDirectory + @"\Ids.txt";
                
                string[] listado = File.ReadAllLines(directorio);


                // remover por ID

                foreach (string idtexto in listado)
                {
                    string elementobyid = "var elemento = document.getElementById('" + idtexto + "')";
                    
                    string docReadyRem = "$(document).ready(elemento.parentNode.removeChild(elemento))";
                    navegador.ExecuteScriptAsync(elementobyid);
                    navegador.ExecuteScriptAsync(docReadyRem);
                       

                }

                // remover por Class name

                String directorioclases = Environment.CurrentDirectory + @"\ClassNames.txt";
                string[] listadoClases = File.ReadAllLines(directorioclases);


                foreach (string classtexto in listadoClases)
                {
                   
                    string scriptClases = "$('." + classtexto + "').remove()";
                    //esperar que el documento este listo
                    string documentoReady = "$(document).ready("+scriptClases+")";
                    navegador.ExecuteScriptAsync(documentoReady);

                }


            }
            catch 
            {

            }

        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            //heists
            Navegar("https://drive.google.com/file/d/1Xd65g84ADLWEkXbrGv2RjWUNxzaijGPm/view?usp=sharing");


        }

        private void button9_Click(object sender, EventArgs e)
        {
            //Mafia
            Navegar("https://drive.google.com/file/d/11Uop2HWbpbTpHhihrIlPj6qcmQ7KDVa1/view?usp=sharing");
        }
    }
}
