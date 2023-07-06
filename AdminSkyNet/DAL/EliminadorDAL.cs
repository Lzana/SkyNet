using AdminSkyNet.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminSkyNet.DAL
{
    public class EliminadorDAL
    {
        private static List<Eliminador> eliminadores = new List<Eliminador>();

        public void AgregarEliminador(Eliminador eliminador)
        {
            eliminadores.Add(eliminador);
        }

        public List<Eliminador> ObtenerEliminadores()
        {
            return eliminadores;
        }

        public List<Eliminador> FiltrarEliminadores(string tipo, uint fecha)
        {
            return eliminadores.FindAll(e => e.TipoEliminador.ToLower().Equals(tipo.ToLower()) && e.FechaDestino == fecha);
        }

        public void Eliminar()
        {
            eliminadores.Clear();
        }

    }
}
