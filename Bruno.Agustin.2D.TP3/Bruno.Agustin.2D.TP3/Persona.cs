using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace EntidadesAbstractas
{
    public enum ENacionalidad
    {
        Argentino,
        Extrangero
    }

  public abstract class Persona
    {
      protected string _apellido;
      protected int _dni;
      protected ENacionalidad _nacionalidada;
      protected string _nombre;

      public string Apellido
      {
          get
          {
              return this._apellido;
          }

          set
          {
              if (ValidarNombreApellido(value) != null)
                  this._apellido = value;
          }
      }

      public int Dni
      {
          get
          {
              return this._dni;
          }
          set
          {
              this._dni = ValidarDni(Nacionalidad, value);
          }
      }

      public ENacionalidad Nacionalidad
      {
          get
          {
              return this._nacionalidada;
          }
          set
          {
              this._nacionalidada = value;
          }
      }

      public string Nombre
      {
          get
          {
              return this._nombre;
          }
          set
          {
              if (ValidarNombreApellido(value) != null)
                  this._nombre = value;
          }
      }

      public string StingToDNI
      {
          set
          {
              this._dni = ValidarDni(Nacionalidad, value);
          }
      }

      public Persona() { }


      public Persona(string nombre, string apellido, ENacionalidad nacionalidad):this()
      {
          this._apellido = apellido;
          this._nombre = nombre;
          this._nacionalidada = nacionalidad;
      }

      public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
          : this(nombre, apellido, nacionalidad)
      {
          this._dni = dni;
      }

      public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
          : this(nombre, apellido,nacionalidad)
      {
          this.StingToDNI = dni;
      }

      public override string ToString()
      {
          StringBuilder sb = new StringBuilder();
          sb.AppendLine("Nombre: " + this._nombre);
          sb.AppendLine("Apellido: "  + this._apellido);
          sb.AppendLine("Nacionalidad " + this._nacionalidada.ToString());
          sb.AppendLine("DNI: " + this._dni);
          Console.WriteLine(sb);

          return sb.ToString();
      }
      
      private int ValidarDni(ENacionalidad nacionalidad,int dato)
      {
          if (((nacionalidad.Equals(ENacionalidad.Argentino)) && (dato < 0 || dato > 90000000)))
          {
              throw new DniInvalidoException();
          }
          if (((nacionalidad.Equals(ENacionalidad.Extrangero)) && (dato < 90000000)))
          {
              throw new NacionalidadInvalidaException();
          }

          return dato; ;
      }
      private int ValidarDni(ENacionalidad nacionaliada,string dato )
      {
          return ValidarDni(nacionaliada, int.Parse(dato)); 
      }
      private string ValidarNombreApellido(string dato)
      {
          if (System.Text.RegularExpressions.Regex.IsMatch(dato, @"^[a-zA-Z]+$"))
              return dato;
          else
              return null;
      }
          
    }
}
