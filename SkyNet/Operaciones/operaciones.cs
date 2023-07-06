using AdminSkyNet.DAL;
using AdminSkyNet.DTO;
using System;
using System.Collections.Generic;

namespace SkyNet.Operaciones
{
    public partial class operaciones
    {

        static EliminadorDAL eliminadorDAL = new EliminadorDAL();

        static void Ingresar()
        {
            string n_Serie;
            string tipoEliminador;
            int prioridad;
            string objetivo;
            uint fechaDestino;

            Eliminador eliminador = new Eliminador();

            do
            {
                Console.WriteLine("\nIngrese Número de Serie...");

                n_Serie = Console.ReadLine().Trim();
                eliminador.N_Serie = n_Serie;

                Console.WriteLine(eliminador.N_Serie.Equals(string.Empty) ? "ERROR: \nEl número se serie debe tener 7 caracteres" : "Número de serie aceptado. \nGuardando...");
            } while (eliminador.N_Serie.Equals(string.Empty));


            do
            {
                Console.WriteLine("***********************************************");
                Console.WriteLine("\nSeleccione el Tipo...");
                Console.WriteLine("(a) T-1 \n(b) T-800\n(c) T-1000\n(d) T-3000");
                Console.WriteLine("***********************************************");

                tipoEliminador = Console.ReadLine().Trim();
                eliminador.TipoEliminador = tipoEliminador;

                Console.WriteLine(eliminador.TipoEliminador.Equals("*") ? "ERROR: \nSeleccione un tipo válido" : "Tipo de Eliminador aceptado. \nGuardando...");
            } while (eliminador.TipoEliminador.Equals("*"));


            do
            {
                Console.WriteLine("***********************************************");
                Console.WriteLine("\nSeleccione prioridad ...");
                Console.WriteLine("1-5 \n999 -> Otro");
                Console.WriteLine("***********************************************");

                try { prioridad = int.Parse(Console.ReadLine().Trim()); }
                catch { prioridad = 0; }

                eliminador.Prioridad = prioridad;
                Console.WriteLine(eliminador.Prioridad > 0 && eliminador.Prioridad < 6 || eliminador.Prioridad == 999 ? "Prioridad aceptada.\nGuardando..." :
                    "ERROR: \nIngrese un valor válido");
            }
            while (eliminador.Prioridad == 0);


            do
            {
                Console.WriteLine("\nIngrese el Objetivo...");

                objetivo = Console.ReadLine().Trim();
                eliminador.Objetivo = objetivo;

                Console.WriteLine(eliminador.Objetivo.Equals(string.Empty) ? "ERROR: \nIngerse un Objetivo válido." : "Objetivo aceptado. \nGuardando...");
            } while (eliminador.Objetivo.Equals(string.Empty));


            do
            {
                Console.WriteLine("\nIngrese Año ...\n(1997-3000)");

                try { fechaDestino = uint.Parse(Console.ReadLine().Trim()); }
                catch { fechaDestino = 0000; }

                eliminador.FechaDestino = fechaDestino;

                Console.WriteLine(eliminador.FechaDestino > 1997 && eliminador.FechaDestino < 3000 ? "Año aceptado\nGuardando..." : "ERROR:\nAño no válido.");
            } while (eliminador.FechaDestino < 1997 || eliminador.FechaDestino > 3000);

            eliminadorDAL.AgregarEliminador(eliminador);
            Console.WriteLine("\nValidando datos...\nAccediendo...\nRegistrando ...\nRegistrado con Éxito.\n");
        }

        static void Mostrar()
        {
            Console.WriteLine("\nDatos Disponibles");
            List<Eliminador> eliminadores = eliminadorDAL.ObtenerEliminadores();
            eliminadores.ForEach(e => Console.WriteLine(e.ToString()));
        }

        static void Buscar()
        {
            string tipoEliminador;
            uint fechaDestino;
            List<Eliminador> eliminadores = new List<Eliminador>();

            Eliminador eliminador = new Eliminador();

            Console.WriteLine("Buscando ...");


            do
            {
                Console.WriteLine("\nSeleccione el Tipo ...");
                Console.WriteLine("(a) T-1 \n(b) T-800\n(c) T-1000\n(d) T-3000");

                tipoEliminador = Console.ReadLine().Trim();
                eliminador.TipoEliminador = tipoEliminador;

                Console.WriteLine(eliminador.TipoEliminador.Equals("*") ? "ERROR: \nSeleccione un tipo válido" : "Tipo  aceptado. \nGuardando...");
            } while (eliminador.TipoEliminador.Equals("*"));

            do
            {
                Console.WriteLine("\nIngrese Año ...\n(1997-3000)");

                try { fechaDestino = uint.Parse(Console.ReadLine().Trim()); }
                catch { fechaDestino = 0000; }

                eliminador.FechaDestino = fechaDestino;

                Console.WriteLine(eliminador.FechaDestino > 1997 && eliminador.FechaDestino < 3000 ? "Año aceptado\nGuardando..." : "ERROR:\nAño no válido.");
            } while (eliminador.FechaDestino < 1997 || eliminador.FechaDestino > 3000);

            eliminadores = eliminadorDAL.FiltrarEliminadores(eliminador.TipoEliminador, fechaDestino);

            Console.WriteLine("\nDatos Encontrados");
            eliminadores.ForEach(e => Console.WriteLine(e.ToString()));
        }

        static void Eliminar()
        {
            Console.WriteLine("Datos Eliminados");
            eliminadorDAL.Eliminar();
        }
    }



}






