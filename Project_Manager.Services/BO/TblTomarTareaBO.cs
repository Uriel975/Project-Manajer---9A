using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Manager.Services.BO
{
    public class TblTomarTareaBO
    {
        public int IDToma { get; set; }
        public int FKEmpleado { get; set; }
        public int FKTarea { get; set; }
        public int Estado { get; set; }
        public string FechaToma { get; set; }
        public string FechaFinalizacion { get; set; }

        //temp table

        public string _folio { get; set; }
        public string _titulo { get; set; }
        public string _descripcion { get; set; }
        public string _empleado { get; set; }
        public string _telefono { get; set; }

    }
}
