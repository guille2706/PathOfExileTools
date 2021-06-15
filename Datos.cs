using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace SandBox
{
   public  class Datos
    {
        /*
        private string _awakened;
        public string Awakened
        {
            get { return _awakened; }
            set { _awakened = Awakened; }
        }



        private string _companion;
        public string Companion
        {
            get {return _companion;}
            set {_companion = Companion;}

        }


        private string _exilence;
        public string Exilence
        { 
            get { return _exilence; }
            set { _exilence = Exilence; }
        }

    */

        public string Awakened { get; set; }
        public string Companion { get; set; }
        public string Exilence { get; set; }

         

        public  void Save(string filename) 
        {
            using (FileStream stream = new FileStream(filename, FileMode.Create)) //.create sobreescribe si el archivo existe
            {
                XmlSerializer XML = new XmlSerializer(typeof(Datos));
                XML.Serialize(stream, this);

            }

            
        }

        public static Datos LeerArchivo(string filename) 
        {
            using (var stream = new FileStream(filename, FileMode.Open))
            {
                var XML = new XmlSerializer(typeof(Datos));
                return (Datos)XML.Deserialize(stream);
            
            }
        
        
        }




    }
}
