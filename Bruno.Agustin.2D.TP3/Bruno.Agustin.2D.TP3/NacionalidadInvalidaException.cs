using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bruno.Agustin._2D.TP3
{
    public class NacionalidadInvalidaException:Exception
    {
        public NacionalidadInvalidaException():base("No cocide la nacionalidad con el nomero de DNI"){ }
        public NacionalidadInvalidaException(string messaje) : base(messaje) { }
    }
}
