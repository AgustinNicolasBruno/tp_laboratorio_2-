using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp1_lab2
{
    public class Calculadora
    {
        public double operar(Numero numero1, Numero numero2, string operador)
        {
//Calculadora: La misma tiene por propósito operar matemáticamente dos
//objetos del tipo Numero según se le indique.
//i. Generar un método de clase llamado operar que reciba dos objetos
//del tipo Numero llamador numero1 y numero2, y un String llamado
//operador. Su valor de retorno será del tipo double. Si no puede operar
//(división por 0), retornará 0.
//ii. Codificar un método de clase llamado validarOperador(string) : string.
//Validará que el operador sea un caracter válido, caso contrario
//retornará “+”.
            double resultado = 0;

            if (operador == "+")
            {
                return resultado = numero1.getNumero() + numero2.getNumero();
            }
            if (operador == "*")
            {
                return resultado = numero1.getNumero() * numero2.getNumero();
            }
            if (operador == "-")
            {
                return resultado = numero1.getNumero() - numero2.getNumero();
            }
            if (operador == "/")
            {
                if (numero2.getNumero() == 0 || numero1.getNumero() == 0)
                {
                    return 0;
                }
                return resultado = numero1.getNumero() / numero2.getNumero();
            }
            return resultado;
        }

        public string validarOperador(string operador)
        {
            if (operador == "+" || operador == "-" || operador == "/" || operador == "*")
            {
                return operador;
            } return "+";
 
        }
    }
}
