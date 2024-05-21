using Entidades.Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Escaner
    {
        //atributos
        private List<Documento> listaDocumentos;
        private Departamento locacion;
        private string marca;
        private TipoDoc tipo;

        //propiedades
        /// <summary>
        /// Obtener Lista de Documentos
        /// </summary>
        public List<Documento> ListaDocumentos
        {
            get => this.listaDocumentos;
        }

        /// <summary>
        /// Obtener Departamento al que pertenece el escaner
        /// </summary>
        public Departamento Locacion
        {
            get => this.locacion;
        }

        /// <summary>
        /// Obtener Marca del Escaner
        /// </summary>
        public string Marca
        {
            get => this.marca;
        }

        /// <summary>
        /// Obtener el tipo de Escaner
        /// </summary>
        public TipoDoc Tipo
        {
            get => this.tipo;
        }

        //Constructores
        /// <summary>
        /// Se Crea una instancia de la Clase Escaner
        /// </summary>
        /// <param name="marca">Marca del Escaner</param>
        /// <param name="tipo">Tipo de Carga(Libro/Mapa) que realizara el escaner</param>
        /// <exception cref="ArgumentNullException">la marca no puede ser nulo</exception>
        /// <exception cref="ArgumentException">el parametro marco no puede ser una cadena vacia</exception>
        public Escaner(string marca, TipoDoc tipo)
        {
            try
            {
                if (string.IsNullOrEmpty(marca))
                {
                    throw new ArgumentException("el parametro marca no puede ser una cadena vacia o null");
                }
            }
            catch (ArgumentException ex)
            {
                throw new EscanerIncompletoException("El escaner tiene informacion incompleta!", marca, ex);
            }


            this.listaDocumentos = new List<Documento>();
            this.marca = marca;
            this.tipo = tipo;

            switch (tipo)
            {
                case TipoDoc.mapa:
                    this.locacion = Departamento.mapoteca;
                    break;
                case TipoDoc.libro:
                    this.locacion = Departamento.procesosTecnicos;
                    break;
                default:
                    this.locacion = Departamento.nulo;
                    break;
            }
        }

        //Metodos
        /// <summary>
        /// Cambia el estado de un documento en la lista de documentos asociada al escáner.
        /// </summary>
        /// <param name="d">Documento que se va a cambiar dentro de la lista de Documentos</param>
        /// <returns><c>True</c> si el estado del documento se cambió con éxito; <c>False</c> en caso contrario.</returns>
        /// <exception cref="ArgumentException">Se lanza si el documento no es compatible con el escáner.</exception>
        public bool CambiarEstadoDocumento(Documento d)
        {
            if ((this.Tipo == TipoDoc.libro && d is Mapa) || (this.tipo == TipoDoc.mapa && d is Libro))
            {
                throw new ArgumentException("escaner y documento incompatible");
            }

            bool retorno = false;
            foreach (Documento doc in this.listaDocumentos)
            {
                if ((this.Locacion == Departamento.procesosTecnicos && (Libro)d == (Libro)doc) ||
                    (this.Locacion == Departamento.mapoteca && (Mapa)d == (Mapa)doc))
                {
                    retorno = doc.AvanzarEstado();
                    break;
                }
            }
            return retorno;
        }

        //comparadores
        /// <summary>
        ///  Compara un escáner con un documento para verificar si el documento está presente en la lista de documentos del escáner.
        /// </summary>
        /// <param name="e">Escaner</param>
        /// <param name="d">El Documento A verificar</param>
        /// <returns>True si el documento está presente en la lista de documentos del escáner; de lo contrario, false.</returns>
        public static bool operator ==(Escaner e, Documento d)
        {
            bool retorno = false;
            foreach (Documento doc in e.listaDocumentos)
            {
                if ((d is Libro && doc is Libro && (Libro)d == (Libro)doc) || (d is Mapa && doc is Mapa && (Mapa)d == (Mapa)doc))
                {
                    retorno = true;
                    break;
                }
            }
            return retorno;
        }

        /// <summary>
        /// Compara un escáner con un documento para verificar si el documento no está presente en la lista de documentos del escáner.
        /// </summary>
        /// <param name="e">El escáner.</param>
        /// <param name="d">El documento a verificar.</param>
        /// <returns>True si el documento no está presente en la lista de documentos del escáner; de lo contrario, false.</returns>
        public static bool operator !=(Escaner e, Documento d)
        {
            return !(e == d);
        }

        //operadores
        /// <summary>
        /// Agrega un documento al escáner.
        /// </summary>
        /// <param name="e">El escáner.</param>
        /// <param name="d">El documento a agregar.</param>
        /// <returns>True si el documento se agregó con éxito al escáner; de lo contrario, false.</returns>
        public static bool operator +(Escaner e, Documento d)
        {
            bool retorno = false;

            if ((e.Tipo == TipoDoc.libro && d is Mapa) || (e.tipo == TipoDoc.mapa && d is Libro))
            {
                throw new ArgumentException("escaner y documento incompatible");
            }

            if (e != d && d.Estado == Documento.Paso.Inicio)
            {
                d.AvanzarEstado();
                e.listaDocumentos.Add(d);
                retorno = true;
            }
            return retorno;
        }

        //enumerados
        public enum Departamento
        {
            nulo,
            mapoteca,
            procesosTecnicos
        }

        public enum TipoDoc
        {
            libro,
            mapa,
        }
    }
}
