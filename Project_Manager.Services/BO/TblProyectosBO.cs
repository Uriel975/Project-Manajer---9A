using System;

namespace Project_Manager.Services.BO
{
	public class TblProyectosBO
	{
		public string NombreProyecto { get; set; }
		public string Prioridad { get; set;}
		public string Descripcion { get; set;}
		public string FechaLimite { get; set;}
		public string FechaInicio { get; set;}
		public string FechaEntrega { get; set;}
		public int Estatus { get; set;}
        public string Folio { get; set; }
		public int FKCliente { get; set; }
        public int Limite { get; set; }
        public int Actual { get; set; }
        public int Tareas { get; set; }

        //======================= COLUMNAS TEMPORALES ==============================
        public string NombreEmpresa { get; set; }
        public int Pendiente { get; set; }

    }
}
