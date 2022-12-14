using Project_Manager.Services.BO;
using Project_Manager.Services.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Manager.Services.Services
{
    public class TblProyectoEmpleadoCTRL
    {
        TblProyectoEmpleadoDAO metodo = new TblProyectoEmpleadoDAO();
        public List<TblProyectoEmpleadoBO> GetProyectoAEmpleado(string folio) 
        {
            List<TblProyectoEmpleadoBO> datos = new List<TblProyectoEmpleadoBO>();
            datos = metodo.GetEmpleadoPro(folio); 
            return datos;
        }
        public int Alta(object obj)
        {
            int resultado = 0;
            resultado = metodo.Crear(obj);
            return resultado;
        }
    }
}
