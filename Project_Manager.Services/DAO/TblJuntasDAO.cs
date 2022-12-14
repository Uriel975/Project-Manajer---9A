using Project_Manager.Services.BO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Manager.Services.DAO
{
	public class TblJuntasDAO
	{
		SqlConnection con = new SqlConnection();
		SqlCommand cmd = new SqlCommand();
		Conexion con2 = new Conexion();
		string sql;
		public int Crear(object obj)
		{

			TblJuntasBO datos = (TblJuntasBO)obj;
			cmd.Connection = con2.establecerconexion();
			con2.AbrirConexion();
			sql = "EXEC PA_Agregar_Junta @NombreJuntas ,@FechaJunta, @HoraJunta ,@Motivo ,@FKEmpleado ,@FKProyecto";

			cmd.Parameters.AddWithValue("@NombreJuntas", datos.NombreJuntas);
			cmd.Parameters.AddWithValue("@FechaJunta", datos.FechaJunta);
			cmd.Parameters.AddWithValue("@HoraJunta", datos.HoraJunta);
			cmd.Parameters.AddWithValue("@Motivo", datos.Motivo);
			cmd.Parameters.AddWithValue("@FKEmpleado", datos.FKEmpleado);
			cmd.Parameters.AddWithValue("@FKProyecto", datos.FKProyecto);
			cmd.CommandText = sql;
			int i = cmd.ExecuteNonQuery();
			cmd.Parameters.Clear();

			if (i <= 0)
			{
				return 0;
			}
			return 1;
		}
		public int actualizarFecha(int id, string fecha, string hora)
		{

			cmd.Connection = con2.establecerconexion();
			con2.AbrirConexion();
			sql = "UPDATE TblJuntas SET FechaJunta='" + fecha + "', HoraJunta= '" + hora + "', Estatus=1 WHERE IDJuntas=" + id + ";";
			cmd.CommandText = sql;
			int i = cmd.ExecuteNonQuery();
			cmd.Parameters.Clear();

			if (i <= 0)
			{
				return 0;
			}
			return 1;
		}
		public int confirmarJunta(int id)
		{

			cmd.Connection = con2.establecerconexion();
			con2.AbrirConexion();
			sql = "UPDATE TblJuntas SET Estatus=2 WHERE IDJuntas=" + id + ";";
			cmd.CommandText = sql;
			int i = cmd.ExecuteNonQuery();
			cmd.Parameters.Clear();

			if (i <= 0)
			{
				return 0;
			}
			return 1;
		}
		public List<TblProyectosBO> TraerProyectoCliente(int id)
		{
			List<TblProyectosBO> lista = new List<TblProyectosBO>();
			sql = "SELECT c.Folio, c.NombreProyecto FROM TblProyectoEmpleado a INNER JOIN  tblEmpleado b ON a.FKEmpleado = b.IDEmpleado INNER JOIN TblProyectos c ON a.FKProyecto = c.Folio WHERE b.IDEmpleado = " + id + "; ";
			SqlDataAdapter da = new SqlDataAdapter(sql, con2.establecerconexion());
			DataTable tabla = new DataTable();
			da.Fill(tabla);
			if (tabla.Rows.Count > 0)
			{
				foreach (DataRow row in tabla.Rows)
				{
					TblProyectosBO obj = new TblProyectosBO();
					obj.Folio = row["Folio"].ToString();
					obj.NombreProyecto = row["NombreProyecto"].ToString();
					lista.Add(obj);
				}
			}
			return lista;
		}
		public int LeidoCliente(int id)
		{

			cmd.Connection = con2.establecerconexion();
			con2.AbrirConexion();
			sql = "UPDATE TblJuntas SET Lectura= 2 WHERE IDJuntas=" + id + ";";
			cmd.CommandText = sql;
			int i = cmd.ExecuteNonQuery();
			cmd.Parameters.Clear();

			if (i <= 0)
			{
				return 0;
			}
			return 1;
		}
		public List<TblJuntasBO> GetMyMeetings(int id)
		{
			List<TblJuntasBO> lista = new List<TblJuntasBO>();
			sql = "SELECT a.NombreJuntas,a.Lectura ,b.NombreEmpleado, a.IDJuntas FROM TblJuntas a INNER JOIN tblEmpleado b on a.FKEmpleado=b.IDEmpleado WHERE FKEmpresa = " + id + ";";
			SqlDataAdapter da = new SqlDataAdapter(sql, con2.establecerconexion());
			DataTable tabla = new DataTable();
			da.Fill(tabla);
			if (tabla.Rows.Count > 0)
			{
				foreach (DataRow row in tabla.Rows)
				{
					TblJuntasBO obj = new TblJuntasBO();
					obj.NombreJuntas = row["NombreJuntas"].ToString();
					obj.Lectura = int.Parse(row["Lectura"].ToString());
					obj.NombreEmpleado = row["NombreEmpleado"].ToString();
					obj.IDJuntas = int.Parse(row["IDJuntas"].ToString());
					lista.Add(obj);
				}
			}
			return lista;
		}

		public TblJuntasBO GetAMeet(int id)
		{
			TblJuntasBO dato = new TblJuntasBO();
			sql = "EXEC VerDetallesJuntas " + id + ";";
			SqlDataAdapter da = new SqlDataAdapter(sql, con2.establecerconexion());
			DataTable tabla = new DataTable();
			da.Fill(tabla);
			if (tabla.Rows.Count > 0)
			{
				foreach (DataRow row in tabla.Rows)
				{
					dato.NombreJuntas = row["NombreJuntas"].ToString();
					dato.Motivo = row["Motivo"].ToString();
					dato.FechaJunta = row["FechaJunta"].ToString();
					dato.HoraJunta = row["HoraJunta"].ToString();
					dato.IDJuntas = int.Parse(row["IDJuntas"].ToString());
					dato.Estatus = int.Parse(row["Estatus"].ToString());
					dato.Lectura = int.Parse(row["Lectura"].ToString());
					dato.NombreEmpleado = row["Nombre"].ToString();
					dato.TelefonoEmpleado = row["TelefonoEmpleado"].ToString();
					dato.Correo = row["Correo"].ToString();
				}
			}
			return dato;
		}
		public List<TblJuntasBO> MisJuntas(int id)
		{
			List<TblJuntasBO> lista = new List<TblJuntasBO>();
			sql = "SELECT * FROM TblJuntas WHERE FKEmpleado = " + id + ";";
			SqlDataAdapter da = new SqlDataAdapter(sql, con2.establecerconexion());
			DataTable tabla = new DataTable();
			da.Fill(tabla);
			if (tabla.Rows.Count > 0)
			{
				foreach (DataRow row in tabla.Rows)
				{
					TblJuntasBO obj = new TblJuntasBO();
					obj.IDJuntas = int.Parse(row["IDJuntas"].ToString());
					obj.NombreJuntas = row["NombreJuntas"].ToString();
					obj.FechaJunta = row["FechaJunta"].ToString();
					obj.HoraJunta = row["HoraJunta"].ToString();
					obj.Motivo = row["Motivo"].ToString();
					obj.FKEmpleado = int.Parse(row["FKEmpleado"].ToString());
					obj.FKEmpleado = int.Parse(row["FKEmpleado"].ToString());
					obj.FKProyecto = row["FKProyecto"].ToString();
					obj.Estatus = int.Parse(row["Estatus"].ToString());
					obj.Lectura = int.Parse(row["Lectura"].ToString());
					lista.Add(obj);
				}
			}
			return lista;
		}
	}
}
