using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace Bruno.Agustin._2D.TP3
{
    public sealed class Profesor:Universitario
    {
        private Queue<EClases> _clasesDelDia;
        private static Random _random;

        public Profesor()
            : base()
        {
            this._clasesDelDia = new Queue<EClases>();
            this._randomClases();
        }

        static Profesor()
        {
            _random = new Random();
        }

        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this()
        {
            this.legajo = id;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
            this.StingToDNI = dni;
        }

        private void _randomClases()
        {
            Array values = Enum.GetValues(typeof(EClases));
            for (int i = 0; i < 2; i++)
            {
                EClases randomBar = (EClases)values.GetValue(_random.Next(values.Length));
                this._clasesDelDia.Enqueue(randomBar);
            }
        }

        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine(this.ParticipaEnClase());
            Console.WriteLine(sb);

            return sb.ToString();
        }

        public override string ToString()
        {
            return this.MostrarDatos();
        }

        public override string ParticipaEnClase()
        {
            throw new NotImplementedException();
        }
    }
}
