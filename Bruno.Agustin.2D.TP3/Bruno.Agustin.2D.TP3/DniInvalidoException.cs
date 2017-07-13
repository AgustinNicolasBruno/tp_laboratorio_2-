using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bruno.Agustin._2D.TP3
{
    class DniInvalidoException:Exception
    {
        private string mensajeBase;

        public DniInvalidoException()
        { }
        public DniInvalidoException(Exception e)
        { }
        public DniInvalidoException(string messaje)
        { }
        public DniInvalidoException(string messaje, Exception e)
        { }
    }
}
