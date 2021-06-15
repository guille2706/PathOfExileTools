using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace SandBox
{
    public class XmlManager
    {

        public static void XmlEscribir(object obj, string filename)
        {

            XmlSerializer ser = new XmlSerializer(obj.GetType());
            TextWriter writer = new StreamWriter(filename);

            ser.Serialize(writer, obj);
            writer.Close();
        
        
        }

        public static Datos XmlLeer(string filename)
        {
            Datos obj = new Datos();
            XmlSerializer xs = new XmlSerializer(typeof(Datos));
            FileStream reader = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read);
            obj = (Datos)xs.Deserialize(reader);
            reader.Close();
            return obj;
        
        }



    }
}
