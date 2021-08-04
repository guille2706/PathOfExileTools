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

            
           

            //agregando menu contextual

            navegador.MenuHandler = new MyManejadorDeMenus();




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

                /*


                HtmlWeb web = new HtmlWeb();
                HtmlDocument document = web.Load("https://pathofexile.fandom.com/wiki/Vendor_recipe_system"); //carga la pagina en la variable document

                var htmlBody = document.DocumentNode.SelectSingleNode("//div[@id='ds_ad_container']");
                HtmlNode nodo = htmlBody;
                nodo.RemoveAll();

                // HtmlNode nodos = document.DocumentNode.SelectNodes("//div[@id='rail-boxad-wrapper']").First();



                */


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
            Navegar("https://www.pathofexile.com/trade/search/Ultimatum");
        }

        private void btnCurrency_Click(object sender, EventArgs e)
        {
            Navegar("https://www.pathofexile.com/trade/exchange/Ultimatum");
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
            Navegar("https://www.poebuilds.net/guest-page");
        }

        private void btnActos_Click(object sender, EventArgs e)
        {
            Navegar("https://i.imgur.com/UZuKoNu.jpeg");
        
        }

        private void btnLogros_Click(object sender, EventArgs e)
        {
           // Navegar("https://docs.google.com/document/d/1a3CzrieUslQf2LPW2iaJnJfrYrIO1bqVsvafOgyabEo/edit?ts=60a5125a#heading=h.rvzr7fdpe4xu");
            System.Diagnostics.Process.Start("microsoft-edge:https://docs.google.com/document/d/1a3CzrieUslQf2LPW2iaJnJfrYrIO1bqVsvafOgyabEo/edit?ts=60a5125a#heading=h.rvzr7fdpe4xu");
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

            InyectarJava();
        }

        private void InyectarJava()
        {
            try
            {
                //Utilizao Jquery, creo que por eso usa el signo $, lo que hago aca es cargar
                // la linea de comando en un string y luego ejecutarla (es una posibilidad de Cefsharp: executeScriptAsync
                string script = "$('.top-ads-container').remove()";
               
                // otra publicidad:
                string script1 = "$('.rail-module').remove()";
              
                string script2 = "$('.WikiaBarWrapper').remove()";
               
                string s3 = "$('.notifications-placeholder').remove()";
                string s4 = "$('.ds_hidemute').remove()";
                string s5 = "$('.mcf-wrapper').remove()";
                string id = "var el = document.getElementById('google_center_div')";
                string s6 = "$('.dm-ad-content').remove()";
                string s7 = "$('.gpt-ad hide)´.remove()";
                string s8 = "$('.mcf-en').remove()";
                string s9 = "$('.right-rail-wrapper WikiaRail').remove()";
        








                navegador.ExecuteScriptAsync(script);
                navegador.ExecuteScriptAsync(script1);
                navegador.ExecuteScriptAsync(script2);
                navegador.ExecuteScriptAsync(s3);
                navegador.ExecuteScriptAsync(s4);
                navegador.ExecuteScriptAsync(id);
                navegador.ExecuteScriptAsync("el.remove()");
                navegador.ExecuteScriptAsync(s5);
                navegador.ExecuteScriptAsync(s6);
                navegador.ExecuteScriptAsync(s7);
                navegador.ExecuteScriptAsync(s8);
                navegador.ExecuteScriptAsync(s9);
                navegador.ExecuteScriptAsync("var el = document.getElementById('ds_cpp')");
                navegador.ExecuteScriptAsync("el.remove()");




            }
            catch 
            {

            }

        }
    }
}
