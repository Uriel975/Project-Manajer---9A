using System.Data.SqlClient;

namespace Project_Manager.Services.DAO
{
    public class Conexion
	{
		SqlConnection con;
		public SqlConnection establecerconexion()
		{
			string cadena = "SERVER=LAPTOP-DF6K6;Initial Catalog=BD_APManager;Integrated Security=True";

			//string cadena = "SERVER=DESKTOP-V2J05N3\\SQLEXPRESS;Initial Catalog=BD_APManager;Integrated Security=True";

			con = new SqlConnection(cadena);
			return con;
		}
		public void AbrirConexion()
		{
			con.Open();
		}
		public void CerrarConexion()
		{
			con.Close();
		}
	}
}

