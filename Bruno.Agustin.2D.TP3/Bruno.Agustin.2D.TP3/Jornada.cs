using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bruno.Agustin._2D.TP3
{
    public class Jornada:Texto
    {
        private List<Alumno> _alumnos;
        private EClases _clase;
        private Profesor _instructor;

        public List<Alumno> Alumnos
        {
            get { return _alumnos; }
            set { _alumnos = value; }
        }

        public EClases Clase
        {
            get { return _clase; }
            set { _clase = value; }
        }

        public Profesor Instructor
        {
            get { return _instructor; }
            set { _instructor = value; }
        }

        private Jornada()
        {
            this._alumnos = new List<Alumno>();
        }

        public Jornada(EClases clase, Profesor instructor)
            : this()
        {
            this.Clase = clase;
            this.Instructor = instructor;
        }

        public string Leer()
        {
            string a = "";
            Texto.leer(AppDomain.CurrentDomain.BaseDirectory + "Jornada.txt", out a);

            return a;
        }

        public static bool Guardar(Jornada jornada)
        {
            return Texto.guardar(AppDomain.CurrentDomain.BaseDirectory + "Jornada.txt", jornada.ToString());
        }

        public static bool operator ==(Jornada j, Alumno a)
        {
            foreach (Alumno alumno in j._alumnos)
            {
                if (alumno == a)
                    return true;
            }
            return false;
        }

        public static bool operator !=(Jornada g, Alumno a)
        {
            return !(g == a);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Clase de: " + this._clase.ToString());
            sb.AppendLine(this._instructor.ToString());
            sb.AppendLine("Alumnos");
            foreach (Alumno item in this._alumnos)
            {
             
                    sb.AppendLine(item.ToString());
              
            }

            return base.ToString();
        }
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
                j.Alumnos.Add(a);
            return j;
        }

    }
}
