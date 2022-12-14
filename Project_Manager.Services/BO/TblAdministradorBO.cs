namespace Project_Manager.Services.BO
{
	public class TblAdministradorBO
	{
        public string NombreAdmin { get; set; }
		public string ApellidoPAdmin { get; set; }
		public string ApellidoMAdmin { get; set; }
		public string FKUsuario { get; set; }
        public int IDAdmin { get; set; }
		public int Estatus { get; set; }

		//====================================TABLAS TEMPORALES DE CONSULTA==================================== =====
		public string CorreoAdmin{ get; set; }
		public string ContraAdmin { get; set; }
		public string FKRol { get; set; }
	}
}
