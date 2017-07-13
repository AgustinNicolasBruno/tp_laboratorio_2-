using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace Bruno.Agustin._2D.TP3
{
    public class Universidad
    {
        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;

        public List<Profesor> Instructores
        {
            get { return profesores; }
            set { profesores = value; }
        }

        public List<Jornada> Jornadas
        {
            get { return jornada; }
            set { jornada = value; }
        }

        public List<Alumno> Alumnos
        {
            get { return alumnos; }
            set { alumnos = value; }
        }

        public Jornada this[int i]
        {
            get { return jornada[i]; }
            set { jornada[i] = value; }
        }

        public Universidad()
        {
            this.Jornadas = new List<Jornada>();
            this.Instructores = new List<Profesor>();
            this.Alumnos = new List<Alumno>();
        }

        public static bool Guardar(Universidad gim)
        {
            StreamWriter stw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "Universidad.xml", false);
            XmlSerializer xml = new XmlSerializer(typeof(Universidad));

            try
            {
                xml.Serialize(stw, gim);
            }
            catch (ArchivosExcepcion e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
            finally
            {
                stw.Close();
            }

            return true;
        }

        public static Universidad Leer()
        {
            StreamReader str = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "Universidad.xml");
            XmlSerializer xml = new XmlSerializer(typeof(Universidad));

            Universidad universidad = (Universidad)xml.Deserialize(str);

            str.Close();

            return universidad;
        }

        private static string MostrarDatos(Universidad gim)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Jornada: ");
            foreach (Jornada jornada in gim.jornada)
            {
                sb.Append(jornada.ToString());
            }
            return sb.ToString();
        }
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
        /// El distinto retornará el primer Profesor que no pueda dar la clase.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Profesor operator !=(Universidad g, EClases clase)
        {
            foreach (Profesor profesor in g.Instructores)
            {
                if (profesor != clase)
                    return profesor;
            }

            return null;
        }

        /// <summary>
        /// Un Universidad será igual a un Profesor si el mismo está dando clases en él.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        /// <summary>
        /// . Se agregarán Alumnos y Profesores mediante el operador +, validando que no estén previamente cargados.
        ///   Sino, lanzará la Excepción SinProfesorException.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad g, Alumno a)
        {
            if (g != a)
            {
                g.Alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException();
            }

            return g;
        }

        /// <summary>
        /// Al agregar una clase a un Universidad se deberá generar y agregar una nueva Jornada indicando la clase, 
        /// un Profesor que pueda darla (según su atributo ClasesDelDia) y la lista de alumnos que la toman 
        /// (todos los que coincidan en su campo ClaseQueToma).
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            Profesor prof = (g == clase);
            List<Alumno> alumnos = new List<Alumno>();
            Jornada jornada = null;

            if (!(Object.Equals(prof, null)))
            {
                jornada = new Jornada(clase, prof);
            }
            else
            {
                throw new SinProfesorException();
            }

            if (!(Object.Equals(jornada, null)))
            {
                foreach (Alumno al in g.Alumnos)
                {
                    if (al == clase)
                        jornada = jornada + al;
                }

                g.Jornadas.Add(jornada);
            }

            return g;
        }

        /// <summary>
        /// . Se agregarán Alumnos y Profesores mediante el operador +, validando que no estén previamente cargados.
        ///   Sino, lanzará la Excepción SinProfesorException.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad g, Profesor i)
        {
            if (g != i)
            {
                g.Instructores.Add(i);
            }
            else
            {
                throw new SinProfesorException();
            }

            return g;
        }

        /// <summary>
        /// Un Universidad será igual a un Alumno si el mismo está inscripto en él.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            foreach (Alumno alumno in g.Alumnos)
            {
                if (alumno == a)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// La igualación entre un Universidad y una Clase retornará el primer Profesor capaz de dar esa clase. 
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Profesor operator ==(Universidad g, EClases clase)
        {
            foreach (Profesor profesor in g.Instructores)
            {
                if (profesor == clase)
                    return profesor;
            }
            return null;
        }

        /// <summary>
        /// Un Universidad será igual a un Profesor si el mismo está dando clases en él.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            foreach (Profesor profesor in g.Instructores)
            {
                if (profesor == i)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Los datos del Universidad se harán públicos mediante ToString.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return MostrarDatos(this);
        }
        //public static bool operator ==(Universidad g, Alumno a)
        //{
        //    foreach (Alumno alumno in g.Alumnos)
        //    {
        //        if (alumno == a)
        //            return true;
        //    }
        //    return false;
        //}

        //public static bool operator !=(Universidad g, Alumno a)
        //{
        //    return !(g == a);
        //}

        //public static bool operator ==(Universidad g, Profesor i)
        //{
        //    foreach (Profesor profesor in g.Instructores)
        //    {
        //        if (profesor == i)
        //            return true;
        //    }
        //    return false;
        //}

        //public static bool operator !=(Universidad g, Profesor i)
        //{
        //    return !(g==i);
        //}

        //public static Profesor operator ==(Universidad g, EClases clase)
        //{
        //    foreach (Profesor profesor in g.Instructores)
        //    {
        //        if (profesor == clase)
        //            return profesor;
        //    }
        //    return null;
        //}

        //public static Profesor operator !=(Universidad g, EClases clase)
        //{
        //    foreach (Profesor profesor in g.Instructores)
        //    {
        //        if (profesor != clase)
        //            return profesor;
        //    }

        //    return null;
        //}


    }
}
