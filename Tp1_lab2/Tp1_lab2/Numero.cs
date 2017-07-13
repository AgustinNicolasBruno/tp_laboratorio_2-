using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp1_lab2
{
    public class Numero
    {
//Número: La misma tiene por propósito de validar y contener los operandos.
//i. Declarar 3 constructores:
//● El constructor por defecto el inicializará el atributo numero en
//cero en 0
//● Otro recibirá un String que validará y cargará en número
//● Y por último uno que recibirá un double y cargará en número.
//ii. Generar un método privado y de clase llamado validarNumero(string)
//: double. Validará que se trate de un double válido, caso contrario
//retornará 0.
//iii. Contendrá un método privado del tipo setter. Este será el único lugar
//donde se podrá utilizar el método validarNumero.
        private double _numero;

        public Numero() 
        {
            this._numero = 0;
        }

        public Numero(double numero)
        {
            this._numero = numero;
        }

        public Numero(String numero)
        {
            this._numero = double.Parse(numero);
        }

        public double getNumero()
        {
            return this._numero;
        }

        private void setNumero(string numero)
        {
            Numero.ValidarNumero(numero);             
        }

        private static double ValidarNumero(string numeroString)
        {
            double x = 0;
            if (Double.TryParse(numeroString, out x))
            {
                return x;
            }
            else
            {
                return 0;
            }
        }

             
    }
}
