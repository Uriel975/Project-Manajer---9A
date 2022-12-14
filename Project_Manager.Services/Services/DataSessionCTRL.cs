using Project_Manager.Services.BO;
using Project_Manager.Services.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Manager.Services.Services
{
    public class DataSessionCTRL
    {
        DataSessionDAO metodo = new DataSessionDAO();

        public List<DataSessionBO> Traer(object obj)
        {
            List<DataSessionBO> datos = new List<DataSessionBO>();
            datos = metodo.CargarDatos(obj);
            return datos;
        }
    }
}
