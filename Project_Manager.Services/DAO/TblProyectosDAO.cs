using Project_Manager.Services.BO;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Project_Manager.Services.DAO
{
	public class TblProyectosDAO
	{
		SqlCommand cmd = new SqlCommand();
		Conexion con2 = new Conexion();
		string sql;

		public int Crear(object obj)
		{

			TblProyectosBO datos = (TblProyectosBO)obj;
			cmd.Connection = con2.establecerconexion();
			con2.AbrirConexion();
			sql = "Insert into TblProyectos (Folio,NombreProyecto,Prioridad,Descripcion,FechaLimite,FechaInicio,FKCliente,Limite)" +
									"Values (@Folio,@NombreProyecto,@Prioridad,@Descripcion,@FechaLimite,@FechaInicio,@FKCliente,@Limite)";
			cmd.Parameters.AddWithValue("@Folio", datos.Folio);
			cmd.Parameters.AddWithValue("@NombreProyecto", datos.NombreProyecto);
			cmd.Parameters.AddWithValue("@Prioridad", datos.Prioridad);
			cmd.Parameters.AddWithValue("@Descripcion", datos.Descripcion);
			cmd.Parameters.AddWithValue("@FechaLimite", datos.FechaLimite);
			cmd.Parameters.AddWithValue("@FechaInicio", datos.FechaInicio);
			cmd.Parameters.AddWithValue("@FKCliente", datos.FKCliente);
			cmd.Parameters.AddWithValue("@Limite", datos.Limite);
			cmd.CommandText = sql;


			int i = cmd.ExecuteNonQuery();
			cmd.Parameters.Clear();

			if (i <= 0)
			{
				return 0;
			}
			return 1;
		}
		public int Actualizar(TblProyectosBO datos)
		{

			cmd.Connection = con2.establecerconexion();
			con2.AbrirConexion();
			sql = "UPDATE TblProyectos set NombreProyecto = @NombreProyecto, Descripcion = @Descripcion, Prioridad = @Prioridad, Limite = @Limite WHERE Folio = @Folio;";
			cmd.Parameters.AddWithValue("@Folio", datos.Folio);
			cmd.Parameters.AddWithValue("@NombreProyecto", datos.NombreProyecto);
			cmd.Parameters.AddWithValue("@Prioridad", datos.Prioridad);
			cmd.Parameters.AddWithValue("@Descripcion", datos.Descripcion);
			cmd.Parameters.AddWithValue("@Limite", datos.Limite);
			cmd.CommandText = sql;


			int i = cmd.ExecuteNonQuery();
			cmd.Parameters.Clear();

			if (i <= 0)
			{
				return 0;
			}
			return 1;
		}
		public object TraerTodoProyecto()
		{
			List<TblProyectosBO> lista = new List<TblProyectosBO>();
			sql = "select * from TblProyectos;";
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
					obj.Prioridad = row["Prioridad"].ToString();
					obj.Descripcion = row["Descripcion"].ToString();
					obj.FechaLimite = row["FechaLimite"].ToString();
					obj.FechaInicio = row["FechaInicio"].ToString();
					obj.FechaEntrega = row["FechaEntrega"].ToString();
					obj.Estatus =  int.Parse(row["Estatus"].ToString());
					obj.FKCliente = int.Parse(row["FKCliente"].ToString());
					obj.Limite = int.Parse(row["Limite"].ToString());
					lista.Add(obj);
				}
			}
			return lista;
		}
		public List<TblProyectosBO> TraerProyecto()
		{
			List<TblProyectosBO> lista = new List<TblProyectosBO>();
			sql = "Select Folio, NombreProyecto from TblProyectos where Estatus = 0;";
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
		public int Eliminar(string Folio, int Estatus)
		{
			cmd.Connection = con2.establecerconexion();
			con2.AbrirConexion();
			sql = "update TblProyectos set Estatus = @Estatus where Folio = @Folio";
			cmd.Parameters.AddWithValue("@Estatus", Estatus);
			cmd.Parameters.AddWithValue("@Folio", Folio);
			cmd.CommandText = sql;

			int i = cmd.ExecuteNonQuery();
			cmd.Parameters.Clear();

			if (i <= 0)
			{
				return 0;
			}
			return 1;
		}
        public TblProyectosBO TraeUnProyecto(string folio)
        {
            TblProyectosBO dato = new TblProyectosBO();
			sql = "SELECT a.*, b.NombreEmpresa FROM TblProyectos a INNER JOIN TblClientes b ON a.FKCliente = IDCliente WHERE a.Folio = '" + folio + "';";
			SqlDataAdapter da = new SqlDataAdapter(sql, con2.establecerconexion());
            DataTable tabla = new DataTable();
            da.Fill(tabla);
            if (tabla.Rows.Count > 0)
            {
                foreach (DataRow row in tabla.Rows)
                {
					dato.Folio = row["Folio"].ToString();
					dato.NombreProyecto = row["NombreProyecto"].ToString();
					dato.Prioridad = row["Prioridad"].ToString();
					dato.Descripcion = row["Descripcion"].ToString();
					dato.FechaLimite = row["FechaLimite"].ToString();
					dato.FechaInicio = row["FechaInicio"].ToString();
					dato.FechaEntrega = row["FechaEntrega"].ToString();
					dato.Estatus = int.Parse(row["Estatus"].ToString());
					dato.FKCliente = int.Parse(row["FKCliente"].ToString());
					dato.Limite = int.Parse(row["Limite"].ToString());
					dato.Actual = int.Parse(row["Actual"].ToString());
					dato.NombreEmpresa = row["NombreEmpresa"].ToString();
                }
            }
            return dato;
        }
		public int AgregarEmpleado(int actual, string folio)
		{

			cmd.Connection = con2.establecerconexion();
			con2.AbrirConexion();
			sql = "UPDATE TblProyectos set Actual = " + actual + " WHERE Folio = '" + folio + "';";
			cmd.CommandText = sql;


			int i = cmd.ExecuteNonQuery();
			cmd.Parameters.Clear();

			if (i <= 0)
			{
				return 0;
			}
			return 1;
		}
		public List<TblProyectosBO> TraerTareas()
		{
			List<TblProyectosBO> lista = new List<TblProyectosBO>();
			sql = "SELECT t.FKProyecto Folio, p.NombreProyecto, COUNT(t.FKProyecto) Pendiente, p.Tareas FROM TblTareas t INNER JOIN TblProyectos p ON p.Folio=t.FKProyecto WHERE t.FKProyecto=t.FKProyecto AND Estado<2 GROUP BY t.FKProyecto, p.NombreProyecto, p.Tareas";
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
					obj.Pendiente = int.Parse(row["Pendiente"].ToString());
					obj.Tareas = int.Parse(row["Tareas"].ToString());
					lista.Add(obj);
				}
			}
			return lista;
		}
		public List<TblProyectosBO> TraerTareasCliente(int id)
		{
			List<TblProyectosBO> lista = new List<TblProyectosBO>();
			sql = "EXEC VerProyectoClientes_ID "+ id;
			SqlDataAdapter da = new SqlDataAdapter(sql, con2.establecerconexion());
			DataTable tabla = new DataTable();
			da.Fill(tabla);
			if (tabla.Rows.Count > 0)
			{
				foreach (DataRow row in tabla.Rows)
				{
					TblProyectosBO obj = new TblProyectosBO();
					obj.Folio = row["Folio"].ToString();
					obj.NombreProyecto = row["Proyecto"].ToString();
					obj.Pendiente = int.Parse(row["Pendiente"].ToString());
					obj.Tareas = int.Parse(row["Total"].ToString());
					lista.Add(obj);
				}
			}
			return lista;
		}
		public List<TblProyectosBO> TraerTareasEmpleado(int id)
		{
			List<TblProyectosBO> lista = new List<TblProyectosBO>();
			sql = "EXEC VerProyectoEmpleados_ID " + id;
			SqlDataAdapter da = new SqlDataAdapter(sql, con2.establecerconexion());
			DataTable tabla = new DataTable();
			da.Fill(tabla);
			if (tabla.Rows.Count > 0)
			{
				foreach (DataRow row in tabla.Rows)
				{
					TblProyectosBO obj = new TblProyectosBO();
					obj.Folio = row["Folio"].ToString();
					obj.NombreProyecto = row["Proyecto"].ToString();
					obj.Pendiente = int.Parse(row["Pendiente"].ToString());
					obj.Tareas = int.Parse(row["Total"].ToString());
					lista.Add(obj);
				}
			}
			return lista;
		}

	}
}
