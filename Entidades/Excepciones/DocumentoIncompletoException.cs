using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Excepciones
{
    /// <summary>
    /// Representa una excepcion que se lanza cuando un documento esta incompleto
    /// </summary>
    public class DocumentoIncompletoException : Exception
    {
        private string titulo;
        private string autor;
        private string barcode;

        /// <summary>
        /// Obtiene un mensaje de error que describe los parametro que estan vacios o son nulos.
        /// </summary>
        public string ErrorCodigo
        {
            get
            {
                StringBuilder mensajeSalida = new StringBuilder();
                if (string.IsNullOrEmpty(titulo)) mensajeSalida.AppendLine("Parametro 'Titulo' no puede ser una cadena vacia o nula");
                if (string.IsNullOrEmpty(autor)) mensajeSalida.AppendLine("Parametro 'Autor' no puede ser una cadena vacia o nula");
                if (string.IsNullOrEmpty(barcode)) mensajeSalida.AppendLine("Parametro 'Barcode' no puede ser una cadena vacia o nula");
                return mensajeSalida.ToString();
            }
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase DocumentoIncompletoException con un mensaje de error especificado, 
        /// </summary>
        /// <param name="mensaje">El mensaje que describe el error.</param>
        /// <param name="titulo">El título del documento que causó la excepción.</param>
        /// <param name="autor">El autor del documento que causó la excepción.</param>
        /// <param name="barcode">El código de barras del documento que causó la excepción.</param>
        /// <param name="innerException">La excepción que es la causa de la excepción actual.</param>
        public DocumentoIncompletoException(string mensaje, string titulo, string autor, string barcode, Exception innerException)
            : base(mensaje, innerException)
        {
            this.titulo = titulo;
            this.autor = autor;
            this.barcode = barcode;
        }
    }
}
