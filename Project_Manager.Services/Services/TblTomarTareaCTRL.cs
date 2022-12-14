using Project_Manager.Services.BO;
using Project_Manager.Services.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Manager.Services.Services
{
    public class TblTomarTareaCTRL
    {
        TblTomarTareaDAO metodo = new TblTomarTareaDAO();

        public List<TblTomarTareaBO> GetDetallesTareas(string fkfolio, string id)
        {
            List<TblTomarTareaBO> ListaDTareas = new List<TblTomarTareaBO>();
            ListaDTareas = metodo.TraerDetallesTareas(fkfolio, id);
            return ListaDTareas;
        }
    }
}
