using Project_Manager.Services.BO;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Project_Manager.Services.DAO
{
	public class TblAdministradorDAO
	{
		SqlConnection con = new SqlConnection();
		SqlCommand cmd = new SqlCommand();
		Conexion con2 = new Conexion();
		string sql;

		public int Crear(object obj)
		{

			TblAdministradorBO datos = (TblAdministradorBO)obj;
			cmd.Connection = con2.establecerconexion();
			con2.AbrirConexion();
			string sql = "Insert into TblAdministrador(NombreAdmin,ApellidoPAdmin,ApellidoMAdmin,FKUsuario) Values(@NombreAdmin,@ApellidoPAdmin,@ApellidoMAdmin,@FKUsuario)";

			cmd.Parameters.AddWithValue("@NombreAdmin", datos.NombreAdmin);
			cmd.Parameters.AddWithValue("@ApellidoPAdmin", datos.ApellidoPAdmin);
			cmd.Parameters.AddWithValue("@ApellidoMAdmin", datos.ApellidoMAdmin);
			cmd.Parameters.AddWithValue("@FKUsuario", datos.FKUsuario);

			cmd.CommandText = sql;
			int i = cmd.ExecuteNonQuery();
			cmd.Parameters.Clear();

			if (i <= 0)
			{
				return 0;
			}
			return 1;
		}

		public List<TblAdministradorBO> ListarTabla()
		{
			List<TblAdministradorBO> lista = new List<TblAdministradorBO>();
			sql = "SELECT b.*, a.Correo, a.Rol, a.Contra FROM tblCuenta a INNER JOIN TblAdministrador b ON a.Usuario = b.FKUsuario WHERE b.Estatus = 0;";
			SqlDataAdapter da = new SqlDataAdapter(sql, con2.establecerconexion());
			DataTable tabla = new DataTable();
			da.Fill(tabla);
			if (tabla.Rows.Count > 0)
			{
				foreach (DataRow row in tabla.Rows)
				{
					TblAdministradorBO obj = new TblAdministradorBO();
					obj.IDAdmin = int.Parse(row["IDAdmin"].ToString());
					obj.NombreAdmin = row["NombreAdmin"].ToString();
					obj.ApellidoPAdmin = row["ApellidoPAdmin"].ToString();
					obj.ApellidoMAdmin = row["ApellidoMAdmin"].ToString();
					obj.Estatus = int.Parse(row["Estatus"].ToString());
					obj.FKUsuario = row["FKUsuario"].ToString();
					obj.CorreoAdmin = row["Correo"].ToString();
					obj.ContraAdmin = row["Contra"].ToString();
					obj.FKRol = row["Rol"].ToString();
					lista.Add(obj);
				}
			}
			return lista;
		}

		public int Eliminar(int id, int status)
		{
			cmd.Connection = con2.establecerconexion();
			con2.AbrirConexion();
			sql = "UPDATE TblAdministrador SET Estatus = @Estatus WHERE IDAdmin = @IDAdmin;";
			cmd.Parameters.AddWithValue("@Estatus", status);
			cmd.Parameters.AddWithValue("@IDAdmin", id);
			cmd.CommandText = sql;

			int i = cmd.ExecuteNonQuery();
			cmd.Parameters.Clear();

			if (i <= 0)
			{
				return 0;
			}
			return 1;
		}



		public int Modificar(TblAdministradorBO datos)
		{
			cmd.Connection = con2.establecerconexion();
			con2.AbrirConexion();
			sql = "UPDATE TblAdministrador SET NombreAdmin=@NombreAdmin WHERE IDAdmin=@IDAdmin";
			cmd.Parameters.AddWithValue("@IDAdmin", datos.IDAdmin);
			cmd.Parameters.AddWithValue("@NombreAdmin", datos.NombreAdmin);
			cmd.CommandText = sql;

			int i = cmd.ExecuteNonQuery();
			con2.CerrarConexion();
			cmd.Parameters.Clear();

			if (i <= 0)
			{
				return 0;
			}
			return 1;
		}

		public DataSet devuelveAlumno(object obj)
		{
			string cadenaWhere = "";
			bool edo = false;
			TblAdministradorBO data = (TblAdministradorBO)obj;
			SqlCommand cmd = new SqlCommand();
			DataSet ds = new DataSet();
			SqlDataAdapter da = new SqlDataAdapter();
			cmd.Connection = con2.establecerconexion();
			con2.AbrirConexion();


			if (edo == true)
			{
				cadenaWhere = " WHERE " + cadenaWhere.Remove(cadenaWhere.Length - 3, 3);
			}
			sql = "SELECT * FROM TblAdministrador" + cadenaWhere;
			cmd.CommandText = sql;
			da.SelectCommand = cmd;
			da.Fill(ds);
			con2.CerrarConexion();
			return ds;
		}
	}
}
