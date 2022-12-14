namespace Project_Manager.Services.BO
{
	public class TblClienteBO
	{
		public string NombreEmpresa { get; set;}
		public string NombreRepresentante { get; set;}
		public string ApellidoMRepresentante { get; set;}
		public string ApellidoPRepresentante { get; set;}
		public string TelefonoRepresentante { get; set;}
		public string FKUsuario { get; set;}
		public int IDCliente { get; set;}
		public int Estatus { get; set; }
		//====================================TABLAS TEMPORALES DE CONSULTA==================================== =====

		public string correo { get; set; }

	}
}
