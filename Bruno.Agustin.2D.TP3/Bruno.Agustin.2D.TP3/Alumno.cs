using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace Bruno.Agustin._2D.TP3
{
    public enum EClases
    {
        Programacion,
        Laboratorio
    }

    public enum EEstadoCuenta
    {
        Becado,
        Deudor,
        AlDia
    }

    public class Alumno:Universitario
    {
        private EClases _calsesQueToma;
        private EEstadoCuenta _estadoCuenta;


        public Alumno() { }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, EClases clasesQueToma)
            :base(id,nombre,apellido,dni,nacionalidad)
        {
            this._calsesQueToma = clasesQueToma;
        }
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, EClases clasesQueToma, EEstadoCuenta estadoCuenta)
            :this(id,nombre,apellido,dni,nacionalidad,clasesQueToma)
        {
            this._estadoCuenta = estadoCuenta;
        }
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine("Estado Cuenta: " + this._estadoCuenta.ToString());
            Console.WriteLine(sb);

            return sb.ToString();
        }
        public static bool operator ==(Alumno a, EClases clase)
        {

            return (a._calsesQueToma.Equals(clase) && !(a._estadoCuenta.Equals(EEstadoCuenta.Deudor)));
        }
        public static bool operator !=(Alumno a, EClases clase)
        {
            return !(a == clase);
        }
        public override string ParticipaEnClase()
        {
            return "Toma clase de: " + this._calsesQueToma;
        }
        public override string ToString()
        {
            return this.MostrarDatos();
        }
    }
}
