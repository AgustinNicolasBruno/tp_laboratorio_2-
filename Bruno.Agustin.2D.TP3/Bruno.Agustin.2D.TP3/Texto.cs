using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Bruno.Agustin._2D.TP3
{
    public class Texto
    {
        public static bool guardar(string archivo, string datos)
        {
            StreamWriter stw = new StreamWriter(archivo, false);

            try
            {
                stw.Write(datos);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                stw.Close();
            }

            return true;
        }

        public static bool leer(string archivo, out string datos)
        {
            StreamReader str = new StreamReader(archivo,false);

            datos = str.ReadToEnd();
            str.Close();

            return true;
        }
    }
}
