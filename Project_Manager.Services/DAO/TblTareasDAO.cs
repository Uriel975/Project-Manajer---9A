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
    public class TblTareasDAO
    {
		SqlConnection con = new SqlConnection();
		SqlCommand cmd = new SqlCommand();
		Conexion con2 = new Conexion();
		string sql;
		public int Crear(object obj)
		{

			TblTareasBO datos = (TblTareasBO)obj;
			cmd.Connection = con2.establecerconexion();
			con2.AbrirConexion();
			sql = "Insert into TblTareas(Titulo ,Descripcion, FKProyecto) Values(@Titulo ,@Descripcion ,@FKProyecto)";

			cmd.Parameters.AddWithValue("@Titulo", datos.Titulo);
			cmd.Parameters.AddWithValue("@Descripcion", datos.Descripcion);
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

		public List<TblTareasBO> GetAll(string folio)
		{
			List<TblTareasBO> lista = new List<TblTareasBO>();
			sql = "SELECT * FROM TblTareas WHERE FKProyecto = '" + folio + "';";
			SqlDataAdapter da = new SqlDataAdapter(sql, con2.establecerconexion());
			DataTable tabla = new DataTable();
			da.Fill(tabla);
			if (tabla.Rows.Count > 0)
			{
				foreach (DataRow row in tabla.Rows)
				{
					TblTareasBO obj = new TblTareasBO();
					obj.ID = int.Parse(row["ID"].ToString());
					obj.Titulo = row["Titulo"].ToString();
					obj.Descripcion = row["Descripcion"].ToString();
					obj.FKProyecto = row["FKProyecto"].ToString();
					obj.Estado = int.Parse(row["Estado"].ToString());
					lista.Add(obj);
				}
			}
			return lista;
		}
		public int Eliminar(int id)
		{
			TblTareasBO datos = new TblTareasBO();
			cmd.Connection = con2.establecerconexion();
			con2.AbrirConexion();
			sql = "DELETE FROM TblTareas WHERE ID = " + id + ";";
			cmd.CommandText = sql;
			int i = cmd.ExecuteNonQuery();
			cmd.Parameters.Clear();

			if (i <= 0)
			{
				return 0;
			}
			return 1;
		}
		public int TomarTarea(object obj)
		{

			TblTomarTareaBO datos = (TblTomarTareaBO)obj;
			cmd.Connection = con2.establecerconexion();
			con2.AbrirConexion();
			sql = "INSERT INTO TblTomarTarea(FKEmpleado,FKTarea,FechaToma) VALUES(@FKEmpleado,@FKTarea,@FechaToma);";

			cmd.Parameters.AddWithValue("@FKEmpleado", datos.FKEmpleado);
			cmd.Parameters.AddWithValue("@FKTarea", datos.FKTarea);
			cmd.Parameters.AddWithValue("@FechaToma", datos.FechaToma);

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
