using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Manager.Services.BO
{
    public class TblJuntasBO
    {
        public string NombreJuntas { get; set; }
        public string Proyecto { get; set; }
        public string FechaJunta { get; set; }
        public string HoraJunta { get; set; }
        public string Motivo { get; set; }
        public int FKEmpresa { get; set; }
        public int FKEmpleado { get; set; }
        public string FKProyecto { get; set; }
        public int Estatus { get; set; }
        public int IDJuntas { get; set; }
        public int Lectura { get; set; }

        //=============================================== TABBLAS TEMPORALES ========================================================

        public string NombreEmpleado { get; set; }
        public string TelefonoEmpleado { get; set; }
        public string Correo { get; set; }
    }
}
