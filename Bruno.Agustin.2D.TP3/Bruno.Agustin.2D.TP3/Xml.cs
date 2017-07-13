using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace Bruno.Agustin._2D.TP3
{
    public class Xml<T> :IArchivo<T>
    {
        public bool guardar(string archivo, T datos)
        {
            StreamWriter stw = new StreamWriter(archivo,false);
            XmlSerializer xml = new XmlSerializer(typeof(T));

            try
            {
                xml.Serialize(stw, datos);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                stw.Close();
            }

            return true;
        }
        public bool leer(string archivo, out T datos)
        {
            datos = default(T); 
            return true;
        }
    }
}
