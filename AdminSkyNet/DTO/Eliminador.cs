using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminSkyNet.DTO
{
    public class Eliminador
    {
        private string n_Serie;
        private TiposEliminadores tipoEliminador;
        private int prioridad;
        private string objetivo;
        private uint fechaDestino;

        public string N_Serie { get => n_Serie; set { if (contar(value)) { n_Serie = value; } else { n_Serie = ""; } } }
        public string TipoEliminador { get => tipoEliminador.nombreTipoEliminador; set { if (value.Equals(string.Empty) || value.Length > 1) { tipoEliminador.TIPO = "*".ToCharArray()[0]; } else { tipoEliminador.TIPO = value.ToCharArray()[0]; } } }
        public int Prioridad { get => prioridad; set { if (value > 0 && value < 6 || value == 999) { prioridad = value; } else { prioridad = 0; } } }
        public string Objetivo { get => objetivo; set => objetivo = value; }
        public uint FechaDestino { get => fechaDestino; set => fechaDestino = value; }



        private bool contar(string palabra)
        {
            return palabra.Length == 7 ? true : false;
        }


        public override string ToString()
        {
            return "*******************************************" +
                   "\nNúmero de Serie : " + n_Serie +
                   "\nTipo Eliminador : " + TipoEliminador +
                   "\nObjetivo        : " + objetivo ;
        }



    }

    public struct TiposEliminadores
    {
        public char TIPO;

        public string nombreTipoEliminador
        {
            get
            {
                switch (TIPO)
                {
                    case 'a':
                        return "T-1";
                    case 'b':
                        return "T-800";
                    case 'c':
                        return "T-1000";
                    case 'd':
                        return "T-3000";
                    default:
                        return "*";
                }
            }
        }
    }


}
