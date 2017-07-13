using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace Bruno.Agustin._2D.TP3
{
    public abstract class Universitario:Persona
    {
        protected int legajo;

        public Universitario() { }

        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionaliada):base(nombre,apellido,dni,nacionaliada)
        {
            this.legajo = legajo;
        }

        public override bool Equals(object obj)
        {
            return (this == ((Universitario)obj));
        }
        
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("Numero Legajo: " + this.legajo);
            Console.WriteLine(sb);
            return sb.ToString();
        }

        public abstract string ParticipaEnClase();

        public static bool operator == (Universitario pg1,Universitario pg2)
        {
            if(pg1.legajo == pg2.legajo && pg1.Nombre == pg2.Nombre && pg1.Nacionalidad == pg2.Nacionalidad)
                return true;
                    return false;
        }
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }
    }
}
