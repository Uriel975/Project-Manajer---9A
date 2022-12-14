using Project_Manager.Services.BO;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Project_Manager.Services.DAO
{
    public class TblProyectoEmpleadoDAO
    {
		SqlConnection con = new SqlConnection();
		SqlCommand cmd = new SqlCommand();
		Conexion con2 = new Conexion();
		string sql;
		public List<TblProyectoEmpleadoBO> GetEmpleadoPro(string Folio)
		{
			List<TblProyectoEmpleadoBO> lista = new List<TblProyectoEmpleadoBO>();
			sql = "SELECT b.NombreEmpleado ,a.FechaIngreso, a.EstadoEmple FROM TblProyectoEmpleado a INNER JOIN tblEmpleado b on a.FKEmpleado = b.IDEmpleado WHERE a.FKProyecto = '" + Folio  + "';";
			SqlDataAdapter da = new SqlDataAdapter(sql, con2.establecerconexion());
			DataTable tabla = new DataTable();
			da.Fill(tabla);
			if (tabla.Rows.Count > 0)
			{
				foreach (DataRow row in tabla.Rows)
				{
					TblProyectoEmpleadoBO obj = new TblProyectoEmpleadoBO();
					obj.NombreEmpleado = row["NombreEmpleado"].ToString();
					obj.FechaIngreso = row["FechaIngreso"].ToString();
					obj.EstadoEmple = int.Parse(row["EstadoEmple"].ToString());
					lista.Add(obj);
				}
			}
			return lista;
		}
		public int Crear(object obj)
		{

			TblProyectoEmpleadoBO datos = (TblProyectoEmpleadoBO)obj;
			cmd.Connection = con2.establecerconexion();
			con2.AbrirConexion();
			sql = "EXEC PA_AsignarEmpleado @FKProyecto,@FKEmpleado,@FechaIngreso";
			cmd.Parameters.AddWithValue("@FKProyecto", datos.FKProyecto);
			cmd.Parameters.AddWithValue("@FKEmpleado", datos.FKEmpleado);
			cmd.Parameters.AddWithValue("@FechaIngreso", datos.FechaIngreso);
			cmd.CommandText = sql;
			int i = cmd.ExecuteNonQuery();
			cmd.Parameters.Clear();

			if (i <= 0)
			{
				return 0;
			}
			return 1;
		}

	}
}
