using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Manager.Services.BO
{
    public class TblProyectoEmpleadoBO
    {
        public int IDAsignacion { get; set; }
        public string FechaIngreso { get; set; }
        public string FKProyecto { get; set; }
        public int FKEmpleado { get; set; }
        public int EstadoEmple { get; set; }

        //======================= TABLAS TEMPORALES ============================

        public string NombreEmpleado { get; set; }
    }
}
