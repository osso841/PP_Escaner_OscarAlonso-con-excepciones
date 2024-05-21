using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Entidades.Excepciones;

namespace Test
{
    public class Program
    {
        static void Main(string[] args)
        {

            ////PRUEBA DE EXCEPCIONES LIBROS
            Console.WriteLine("\nPRUEBA DE EXCEPCIONES LIBROS **************\n");
            try
            {
                Libro l200 = new Libro("Vivir Sin Anciedad", "pepe", 2021, "825-2352", "76454223836", 234); // LIBRO DE PRUEBA
                Console.WriteLine("cargado con exito");
            }
            catch (DocumentoIncompletoException ex)
            {
                Console.WriteLine($"Errores Encontrados:\n{ex.ErrorCodigo}");
                Console.WriteLine($"tipo de excepcion interna: {ex.InnerException?.GetType()} ");

            }
            catch (LibroIncompletoException lex)
            {
                Console.WriteLine($"Errores Encontrados: \n{lex.ErrorCodigo}");
                Console.WriteLine($"tipo de excepcion interna: {lex.InnerException?.GetType()}");
            }


            //PRUEBA DE EXCEPCIONES MAPAS
            Console.WriteLine("\nPRUEBA DE EXCEPCIONES MAPAS **************\n");
            try
            {
                Mapa m200 = new Mapa("c# para no programadores", "romero", 2000, "3258-2385", "3481538", 400, 300); //MAPA DE PRUEBA
                Console.WriteLine("carga exitosa");
            }
            catch (DocumentoIncompletoException ex)
            {
                Console.WriteLine($"Errores Encontrados:\n{ex.ErrorCodigo}");
                Console.WriteLine($"tipo de excepcion interna: {ex.InnerException?.GetType()} ");
            }
            catch (MapaIncompletoException mex)
            {
                Console.WriteLine($"Errores Encontrados: \n{mex.ErrorCodigo}");
                Console.WriteLine($"tipo de excepcion interna: {mex.InnerException?.GetType()}");
            }


            //PRUEBA DE EXCEPCIONES ESCANER
            Console.WriteLine("\nPRUEBA DE EXCEPCIONES ESCANER **************\n");
            try
            {
                Escaner eMapa = new Escaner("exo", Escaner.TipoDoc.mapa);
                Escaner eLibro = new Escaner("samsung", Escaner.TipoDoc.libro);
                Console.WriteLine("carga exitosa");
            }
            catch (EscanerIncompletoException esEx)
            {
                Console.WriteLine($"Errores Encontrados:\n{esEx.ErrorCodigo}");
                Console.WriteLine($"tipo de excepcion interna: {esEx.InnerException?.GetType()} ");
            }



            //PRUEBA DE CARGA DE LIBROS
            Console.WriteLine("\nPRUEBA DE EXCEPCIONES CARGA DE LIBRO **************\n");
            try
            {
                Escaner escanerLibro = new Escaner("samsung", Escaner.TipoDoc.libro); //informacion completa
                Escaner escanerMapa = new Escaner("exo", Escaner.TipoDoc.mapa); //informacion completa
                Libro l1 = new Libro("la odisea", "homero", 2000, "859239", "9323742738", 300); //informacion completa
                Mapa m1 = new Mapa("cordoba", "julio pintor", 1950, "243-2352", "3892532238", 123, 20);//informacion completa

                bool ingresarDocumento = escanerLibro + l1; //sobrecarga del operador + en escaner
                Console.WriteLine("carga exitosa");
            }
            catch (ArgumentException arEx)
            {
                Console.WriteLine($"Mensaje: {arEx.Message}");
            }


            //PRUEBA CAMBIAR ESTADO DOCUMENTO
            Console.WriteLine("\nPRUEBA DE EXCEPCIONES CAMBIAR ESTADO DOCUMENTO **************\n");
            try
            {
                Escaner escanerLibro = new Escaner("samsung", Escaner.TipoDoc.libro); //informacion completa
                Libro l2 = new Libro("la odxseas", "hOMERO", 2000, "859239", "9323742738", 300);//informacion completa (titulo y autor mal escrito)
                Libro l1 = new Libro("la odisea", "homero", 2000, "859239", "9323742738", 300); //informacion completa
                Mapa m1 = new Mapa("cordoba", "julio pintor", 1950, "243-2352", "3892532238", 123, 20);//informacion completa
                //VERIFICAR
                bool cargarLibro = escanerLibro + l1;
                Console.WriteLine(escanerLibro.CambiarEstadoDocumento(l2));
                Console.WriteLine(escanerLibro.CambiarEstadoDocumento(m1));// ArgumentException. cambiar el estado de un mapa en escaner
                Console.WriteLine("carga exitosa");
            }
            catch (ArgumentException arEx)
            {
                Console.WriteLine($"Mensaje: {arEx.Message}");
            }


            Console.ReadKey();
        }
    }
}