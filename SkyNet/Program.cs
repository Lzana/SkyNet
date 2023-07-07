using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SkyNet
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            while (Menu()) ;
        }

        static bool Menu()
        {
            Console.WriteLine("****************Bienvenido*********************");

            bool ok = true;
            Console.WriteLine("1. Ingresar ");
            Console.WriteLine("2. Buscar ");
            Console.WriteLine("3. Mostrar ");
            Console.WriteLine("4. Destruir SkyNet\n");
            Console.WriteLine("***********************************************");

           
            switch (Console.ReadLine().Trim())
            {
                case "1":
                    Ingresar();
                    break;
                case "2":
                    Buscar();
                    break;
                case "3":
                    Mostrar();
                    break;
                case "4":
                    Eliminar();
                    break;
                default:
                    Console.WriteLine("Ingrese una opción válida\n");
                    break;
            }

            return ok;

        }

      
    }
}
