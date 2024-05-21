using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Excepciones
{
    /// <summary>
    /// Representa una excepción que se lanza cuando un escáner está incompleto.
    /// </summary>
    public class EscanerIncompletoException : Exception
    {
        private string marca;

        /// <summary>
        /// Obtiene un mensaje de error que describe que la marca del escáner no puede ser una cadena vacía o nula.
        /// </summary>
        public string ErrorCodigo
        {
            get
            {
                StringBuilder mensajeSalida = new StringBuilder();
                mensajeSalida.AppendLine("La marca del escaner no puede ser una cadena vacia o null!!");
                mensajeSalida.AppendLine($"valor pasado: '{(this.marca is null? "Null" : "Cadena Vacia")}'.");
                return mensajeSalida.ToString();
            }
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase EscanerIncompletoException" con un mensaje de error especificado,
        /// </summary>
        /// <param name="mensaje">El mensaje que describe el error.</param>
        /// <param name="marca">La marca del escáner que causó la excepción.</param>
        /// <param name="innerException">La excepción que es la causa de la excepción actual.</param>
        public EscanerIncompletoException(string mensaje, string marca, Exception innerException)
            : base(mensaje, innerException)
        {
            this.marca = marca;
        }
    }
}
