using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Manager.Services
{
    public class Aleatorios
    {
        string Folio;
        public string NumFolio()
        {
            Random rdm = new Random();
            string acomulador = "";
            for(int i = 0; i < 10; i++)
            {
                int numero = rdm.Next(10);
                acomulador = acomulador + Convert.ToString(numero);
            }
            Folio = acomulador;
            return Folio;
        }
    }
}
