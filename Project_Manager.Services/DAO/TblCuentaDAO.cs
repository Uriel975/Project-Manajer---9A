using Project_Manager.Services.BO;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Project_Manager.Services.DAO
{
	public class TblCuentaDAO
	{
		SqlConnection con = new SqlConnection();
		SqlCommand cmd = new SqlCommand();
		Conexion con2 = new Conexion();
		string sql;

		public int Crear(object obj)
		{

			TblCuentaBO datos = (TblCuentaBO)obj;
			cmd.Connection = con2.establecerconexion();
			con2.AbrirConexion();
			sql = "Insert into TblCuenta(Usuario ,Contra ,Correo ,Estatus ,Rol) Values(@Usuario ,@Contra ,@Correo ,@Estatus ,@Rol);";
			cmd.Parameters.AddWithValue("@Usuario", datos.Usuario);
			cmd.Parameters.AddWithValue("@Contra", datos.Contra);
			cmd.Parameters.AddWithValue("@Correo", datos.Correo);
			cmd.Parameters.AddWithValue("@Estatus", datos.Estatus);
			cmd.Parameters.AddWithValue("@Rol", datos.Rol);
			cmd.CommandText = sql;
			int i = cmd.ExecuteNonQuery();
			cmd.Parameters.Clear();

			if (i <= 0)
			{
				return 0;
			}
			return 1;
		}

		public int Modificar(object obj)
		{

            TblCuentaBO datos = (TblCuentaBO)obj;
            cmd.Connection = con2.establecerconexion();
            con2.AbrirConexion();
            sql = "update TblCuenta set Correo = @Correo where Usuario = @Usuario";
			cmd.Parameters.AddWithValue("@Usuario", datos.Usuario);
			cmd.Parameters.AddWithValue("@Correo", datos.Correo);
			cmd.CommandText = sql;

            int i = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();

            if (i <= 0)
            {
                return 0;
            }
            return 1;
		}

		public int Eliminar(object obj)
		{
			TblCuentaBO datos = (TblCuentaBO)obj;
			cmd.Connection = con2.establecerconexion();
			con2.AbrirConexion();
			sql = "DELETE FROM TblCuenta where Usuario = @Usuario";
			cmd.Parameters.AddWithValue("@Usuario", datos.Usuario);
			cmd.CommandText = sql;

			int i = cmd.ExecuteNonQuery();
			cmd.Parameters.Clear();

			if (i <= 0)
			{
				return 0;
			}
			return 1;
		}

		public DataSet devuelveAlumno(object obj)
		{
			//string cadenaWhere = "";
			//bool edo = false;
			//TblCuentaBO data = (TblCuentaBO)obj;
			//SqlCommand cmd = new SqlCommand();
			DataSet ds = new DataSet();
			//SqlDataAdapter da = new SqlDataAdapter();
			//cmd.Connection = con2.establecerconexion();
			//con2.AbrirConexion();

			//if (data.IDCuenta > 0)
			//{
			//    cadenaWhere = cadenaWhere + " IDCuenta = @IDCuenta and";
			//    cmd.Parameters.Add("@IDCuenta", SqlDbType.Int);
			//    cmd.Parameters["@IDCuenta"].Value = data.IDCuenta;
			//    edo = true;
			//}
			//if (data.CorreoCuenta != null)
			//{
			//    cadenaWhere = cadenaWhere + " CorreoCuenta = @CorreoCuenta and";
			//    cmd.Parameters.Add("@CorreoCuenta", SqlDbType.VarChar);
			//    cmd.Parameters["@CorreoCuenta"].Value = data.CorreoCuenta;
			//    edo = true;
			//}
			//if (data.ContraCuenta != null)
			//{
			//    cadenaWhere = cadenaWhere + " ContraCuenta = @ContraCuenta and";
			//    cmd.Parameters.Add("@ContraCuenta", SqlDbType.VarChar);
			//    cmd.Parameters["@ContraCuenta"].Value = data.ContraCuenta;
			//    edo = true;
			//}

			//if (edo == true)
			//{
			//    cadenaWhere = " WHERE " + cadenaWhere.Remove(cadenaWhere.Length - 3, 3);
			//}
			//sql = "SELECT * FROM TblCuenta" + cadenaWhere;
			//cmd.CommandText = sql;
			//da.SelectCommand = cmd;
			//da.Fill(ds);
			//con2.CerrarConexion();
			return ds;
		}

		public List<TblCuentaBO> ListarTabla()
		{
			List<TblCuentaBO> lista = new List<TblCuentaBO>();
			sql = "select * from tblCuenta where Estatus = 0;";
			SqlDataAdapter da = new SqlDataAdapter(sql, con2.establecerconexion());
			DataTable tabla = new DataTable();
			da.Fill(tabla);
			if (tabla.Rows.Count > 0)
			{
				foreach (DataRow row in tabla.Rows)
				{
					TblCuentaBO obj = new TblCuentaBO();
					obj.Usuario = row["Usuario"].ToString();
					obj.Contra = row["Contra"].ToString();
					lista.Add(obj);
				}
			}
			return lista;
		}

		public int ListarTablaL(object obj)
		{
			TblCuentaBO datos = (TblCuentaBO)obj;
			List<TblCuentaBO> lista = new List<TblCuentaBO>();

			cmd.Connection = con2.establecerconexion();
			con2.AbrirConexion();
			sql = ("SELECT * FROM TblCuenta WHERE Usuario='"+datos.Usuario+"' AND Contra='"+datos.Contra+"' AND ESTATUS=0");
			cmd.CommandText = sql;
			cmd.ExecuteNonQuery();

			SqlDataAdapter da = new SqlDataAdapter(sql, con2.establecerconexion());
			SqlDataReader rd = cmd.ExecuteReader();

			if (rd.Read())
				return 1;
			else
				return 0;
		}

	}
}
