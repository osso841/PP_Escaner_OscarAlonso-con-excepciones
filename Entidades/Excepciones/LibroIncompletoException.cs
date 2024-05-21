using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Excepciones
{
    /// <summary>
    /// Representa una excepción que se lanza cuando un libro está incompleto.
    /// </summary>
    public class LibroIncompletoException : Exception
    {
        private int numPaginas;
        private string numNormalizado;

        /// <summary>
        /// Obtiene un mensaje de error que describe los parámetros que son inválidos.
        /// </summary>
        public string ErrorCodigo
        {
            get
            {
                StringBuilder mensajeSalida = new StringBuilder();
                if (this.numPaginas <= 0)
                {
                    mensajeSalida.AppendLine("Parametro numPaginas tiene que ser mayor o igual a 0.");
                    mensajeSalida.AppendLine($"Dato Insertado: {this.numPaginas}");
                }
                if (string.IsNullOrEmpty(numNormalizado))
                {
                    mensajeSalida.AppendLine("Parametro numNormalizado no tiene que ser una cadena vacia o null");
                    mensajeSalida.AppendLine($"Dato Insertado: {(this.numNormalizado is null? "Null" : "cadena vacia")}");
                }
                return mensajeSalida.ToString();
            }
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase LibroIncompletoException con un mensaje de error especificado,
        /// el valor de los parámetros que causaron la excepción y una referencia a la excepción interna que es la causa de esta excepción.
        /// </summary>
        /// <param name="mensaje">El mensaje que describe el error.</param>
        /// <param name="numPaginas">El número de páginas del libro que causó la excepción.</param>
        /// <param name="numNormalizado">El número normalizado del libro que causó la excepción.</param>
        /// <param name="innerException">La excepción que es la causa de la excepción actual.</param>
        public LibroIncompletoException(string mensaje, int numPaginas, string numNormalizado, Exception innerException)
            : base(mensaje, innerException)
        {
            this.numPaginas = numPaginas;
            this.numNormalizado = numNormalizado;
        }
    }
}
