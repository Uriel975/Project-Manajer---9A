using Project_Manager.Services.BO;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Project_Manager.Services.DAO
{
	public class TblEmpleadoDAO
	{
		SqlConnection con = new SqlConnection();
		SqlCommand cmd = new SqlCommand();
		Conexion con2 = new Conexion();
		string sql;

		public int Crear(object obj)
		{

			TblEmpleadoBO datos = (TblEmpleadoBO)obj;
			cmd.Connection = con2.establecerconexion();
			con2.AbrirConexion();
			sql = "Insert into TblEmpleado(NombreEmpleado ,ApellidoPEmpleado ,ApellidoMEmpleado, TelefonoEmpleado  ,Nacimiento ,GeneroEmpleado ,FKUsuario)" +
			"Values(@NombreEmpleado ,@ApellidoPEmpleado, @ApellidoMEmpleado ,@TelefonoEmpleado ,@Nacimiento ,@GeneroEmpleado ,@FKUsuario)";

			cmd.Parameters.AddWithValue("@NombreEmpleado", datos.NombreEmpleado);
			cmd.Parameters.AddWithValue("@ApellidoPEmpleado", datos.ApellidoPEmpleado);
			cmd.Parameters.AddWithValue("@TelefonoEmpleado", datos.TelefonoEmpleado);
			cmd.Parameters.AddWithValue("@Nacimiento", datos.Nacimiento);
			cmd.Parameters.AddWithValue("@GeneroEmpleado", datos.GeneroEmpleado);
			cmd.Parameters.AddWithValue("@FKUsuario", datos.FKUsuario);
			cmd.Parameters.AddWithValue("@ApellidoMEmpleado", datos.ApellidoMEmpleado);
			cmd.CommandText = sql;
			int i = cmd.ExecuteNonQuery();
			cmd.Parameters.Clear();

			if (i <= 0)
			{
				return 0;
			}
			return 1;
		}


		public int Modificar(TblEmpleadoBO datos)
		{
			cmd.Connection = con2.establecerconexion();
			con2.AbrirConexion();
			sql = "update TblEmpleado set NombreEmpleado = @NombreEmpleado ,TelefonoEmpleado = @TelefonoEmpleado where IDEmpleado = @IDEmpleado;";
			cmd.Parameters.AddWithValue("@IDEmpleado", datos.IDEmpleado);
			cmd.Parameters.AddWithValue("@NombreEmpleado", datos.NombreEmpleado);
			cmd.Parameters.AddWithValue("@TelefonoEmpleado", datos.TelefonoEmpleado);
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


        public int Eliminar(int id, int status)
        {
            cmd.Connection = con2.establecerconexion();
            con2.AbrirConexion();
			sql = "update TblEmpleado set Estatus = @Estatus where IDEmpleado = @IDEmpleado;";
			cmd.Parameters.AddWithValue("@Estatus", status);
			cmd.Parameters.AddWithValue("@IDEmpleado", id);
			cmd.CommandText = sql;

            int i = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();

            if (i <= 0)
            {
                return 0;
            }
            return 1;
        }



		public List<TblEmpleadoBO> ListarTabla()
		{
			List<TblEmpleadoBO> lista = new List<TblEmpleadoBO>();
			sql = "select a.*, b.Correo from tblEmpleado as a inner Join tblCuenta as b on a.FKUsuario = b.Usuario where a.Estatus = 0;";
			SqlDataAdapter da = new SqlDataAdapter(sql, con2.establecerconexion());
			DataTable tabla = new DataTable();
			da.Fill(tabla);
			if (tabla.Rows.Count > 0)
            {
				foreach (DataRow row in tabla.Rows)
				{
					TblEmpleadoBO obj = new TblEmpleadoBO();
					obj.IDEmpleado = int.Parse(row["IDEmpleado"].ToString());
					obj.NombreEmpleado = row["NombreEmpleado"].ToString();
					obj.ApellidoPEmpleado = row["ApellidoPEmpleado"].ToString();
					obj.ApellidoMEmpleado = row["ApellidoMEmpleado"].ToString();
					obj.TelefonoEmpleado = row["TelefonoEmpleado"].ToString();
					obj.Nacimiento = row["Nacimiento"].ToString();
					obj.Estatus = int.Parse(row["Estatus"].ToString());
					obj.GeneroEmpleado = row["GeneroEmpleado"].ToString();
					obj.FKUsuario = row["FKUsuario"].ToString();
					obj.correo = row["Correo"].ToString();
					lista.Add(obj);
				}				
			}
			return lista;
		}

		public List<TblEmpleadoBO> GetAsignacionEmpleado()
		{
			List<TblEmpleadoBO> lista = new List<TblEmpleadoBO>();
			sql = "Select NombreEmpleado, ApellidoPEmpleado, ApellidoMEmpleado, TelefonoEmpleado, IDEmpleado FROM tblEmpleado where Estatus = 0;";
			SqlDataAdapter da = new SqlDataAdapter(sql, con2.establecerconexion());
			DataTable tabla = new DataTable();
			da.Fill(tabla);
			if (tabla.Rows.Count > 0)
			{
				foreach (DataRow row in tabla.Rows)
				{
					TblEmpleadoBO obj = new TblEmpleadoBO();
					obj.NombreEmpleado = row["NombreEmpleado"].ToString();
					obj.ApellidoPEmpleado = row["ApellidoPEmpleado"].ToString();
					obj.ApellidoMEmpleado = row["ApellidoMEmpleado"].ToString();
					obj.TelefonoEmpleado = row["TelefonoEmpleado"].ToString();
					obj.IDEmpleado = int.Parse(row["IDEmpleado"].ToString());
					lista.Add(obj);
				}
			}
			return lista;
		}
		public TblEmpleadoBO TraerUnEmpleado(int id)
		{
			TblEmpleadoBO dato = new TblEmpleadoBO();
			sql = "SELECT b.FKUsuario,b.NombreEmpleado, a.Correo FROM tblCuenta a INNER JOIN tblEmpleado b ON a.Usuario = b.FKUsuario WHERE b.IDEmpleado = " +id+ ";";
			SqlDataAdapter da = new SqlDataAdapter(sql, con2.establecerconexion());
			DataTable tabla = new DataTable();
			da.Fill(tabla);
			if (tabla.Rows.Count > 0)
			{
				foreach (DataRow row in tabla.Rows)
				{
					dato.FKUsuario = row["FKUsuario"].ToString();
					dato.NombreEmpleado = row["NombreEmpleado"].ToString();
					dato.correo = row["Correo"].ToString();
				}
			}
			return dato;
		}

	}
}
