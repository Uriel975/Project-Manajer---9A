using System;

namespace Project_Manager.Services.BO
{
	public class TblEmpleadoBO
	{
		
		public string NombreEmpleado { get; set; }
		public string ApellidoPEmpleado { get; set; }
		public string ApellidoMEmpleado { get; set; }
		public string TelefonoEmpleado { get; set; }
		public string Nacimiento { get; set; }
		public string GeneroEmpleado { get; set; }
		public string FKUsuario { get; set; }
		public int IDEmpleado { get; set; }
		public int Estatus { get; set; }
		public int Conproyecto { get; set; }

		//====================================TABLAS TEMPORALES DE CONSULTA=========================================
		public string correo { get; set; }
	}
}
