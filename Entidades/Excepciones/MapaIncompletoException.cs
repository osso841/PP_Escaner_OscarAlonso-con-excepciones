using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Excepciones
{
    /// <summary>
    /// Representa una excepción que se lanza cuando un mapa está incompleto.
    /// </summary>
    public class MapaIncompletoException : Exception
    {
        private int ancho;
        private int alto;

        /// <summary>
        /// Obtiene un mensaje de error que describe los parámetros que son inválidos.
        /// </summary>
        public string ErrorCodigo
        {
            get
            {
                StringBuilder mensajeSalida = new StringBuilder();
                if (this.ancho <= 0)
                {
                    mensajeSalida.AppendLine("Parametro Ancho tiene que ser mayor o igual a 0.");
                    mensajeSalida.AppendLine($"Dato Insertado: {this.ancho}");
                }
                if (this.alto <= 0)
                {
                    mensajeSalida.AppendLine("Parametro alto tiene que ser mayor o igual a 0.");
                    mensajeSalida.AppendLine($"Dato Insertado: {this.alto}");
                }
                return mensajeSalida.ToString();
            }
        }
        /// <summary>
        /// Inicializa una nueva instancia de la clase MapaIncompletoException" con un mensaje de error especificado,
        /// el valor de los parámetros que causaron la excepción y una referencia a la excepción interna que es la causa de esta excepción.
        /// </summary>
        /// <param name="mensaje">El mensaje que describe el error.</param>
        /// <param name="ancho">El ancho del mapa que causó la excepción.</param>
        /// <param name="alto">El alto del mapa que causó la excepción.</param>
        /// <param name="innerException">La excepción que es la causa de la excepción actual.</param>
        public MapaIncompletoException(string mensaje, int ancho, int alto, Exception innerException)
            : base(mensaje, innerException)
        {
            this.ancho = ancho;
            this.alto = alto;
        }
    }
}
