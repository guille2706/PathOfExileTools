using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Xml;
using System.Reflection;

namespace SandBox
{
    public partial class Configuracion : Form
    {


        Datos datos = new Datos();
        public Configuracion()
        {

            InitializeComponent();
            CargarPaths();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // System.Diagnostics.Process.Start  (@"C:\Program Files\CodeAndWeb\TexturePacker\bin\TexturePackerGUI.exe"); //ejemplo de abrir un progrma iindicando el path

            try
            {
                Datos datos = Datos.LeerArchivo("datos.xml");

                System.Diagnostics.Process.Start(@datos.Awakened);
            }
            catch (Exception error) {

                MessageBox.Show("¡¡ ERROR !! " + error.Message);
            }



        }

        

        private void btnSave_Click(object sender, EventArgs e)
        {

            try
            {
                if (!String.IsNullOrEmpty(textBoxAwake.Text) &&
                    !String.IsNullOrEmpty(textBoxCompanion.Text) &&
                    !String.IsNullOrEmpty(textBoxExilence.Text)
                    )
                {
                    datos.Awakened = textBoxAwake.Text;
                    datos.Companion = textBoxCompanion.Text;
                    datos.Exilence = textBoxExilence.Text;
                    datos.Save("datos.xml");
                    MessageBox.Show("Datos Guardados Correctamente");
                }else{
                    MessageBox.Show("Complete todos los datos correctamente..");
                }

            }
            catch (Exception error)

            {
                MessageBox.Show(" ¡¡ ERROR !! " + error.Message);

            }
        
        }







        private void btn_load_Click(object sender, EventArgs e)
        {
            /*
            try
            {

                if (File.Exists("datos.xml"))
                {
                    Datos datos = Datos.LeerArchivo("datos.xml");

                    textBoxAwake.Text = datos.Awakened;
                    textBoxCompanion.Text = datos.Companion;
                    textBoxExilence.Text = datos.Exilence;


                }

            }
            catch (Exception exepcion)
            {
                MessageBox.Show("¡¡ERROR !!" + exepcion.Message);

            }
            */
        
        }

        private void btnCompanion_Click(object sender, EventArgs e)
        {
            try
            {
                Datos datos = Datos.LeerArchivo("datos.xml");

                System.Diagnostics.Process.Start(@datos.Companion);
            }
            catch (Exception exepcion)
            {

                MessageBox.Show("¡¡ ERROR !! " + exepcion.Message);
            }
        }

        private void btnExilence_Click(object sender, EventArgs e)
        {
            try
            {
                Datos datos = Datos.LeerArchivo("datos.xml");

                System.Diagnostics.Process.Start(@datos.Exilence);
            }
            catch (Exception exepcion)
            {

                MessageBox.Show("¡¡ ERROR !! " + exepcion.Message);
            }


        }

        private void CargarPaths() 
        {
            try
            {

                if (File.Exists("datos.xml"))
                {
                    Datos datos = Datos.LeerArchivo("datos.xml");

                    textBoxAwake.Text = datos.Awakened;
                    textBoxCompanion.Text = datos.Companion;
                    textBoxExilence.Text = datos.Exilence;


                }
                else 
                
                {
                    textBoxAwake.Text = "Clic en examinar para agregar la ruta del Awakened";
                    textBoxCompanion.Text = "Clic en examinar para agregar la ruta del Companion";
                    textBoxExilence.Text = "Clic en examinar para agregar la ruta del Exilence";

                }

            }
            catch (Exception exepcion)
            {
                MessageBox.Show("¡¡ERROR !!" + exepcion.Message);

            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
            
          
            string rutaArchivo = string.Empty;

            using (OpenFileDialog openFileDialog1 = new OpenFileDialog()) ;

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "Ver todos los Archivos (*.*)|*.*|Ejecutables (*.exe)|*.exe";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK) 
            {
                
                textBoxAwake.Text = openFileDialog1.FileName;


            
            }
          

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            string rutaArchivo = string.Empty;

            using (OpenFileDialog openFileDialog1 = new OpenFileDialog()) ;

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "Ver todos los Archivos (*.*)|*.*|Ejecutables (*.exe)|*.exe";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                textBoxCompanion.Text = openFileDialog1.FileName;



            }



        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string rutaArchivo = string.Empty;

            using (OpenFileDialog openFileDialog1 = new OpenFileDialog()) ;

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "Ver todos los Archivos (*.*)|*.*|Ejecutables (*.exe)|*.exe";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                textBoxExilence.Text = openFileDialog1.FileName;



            }



        }
    }
}
