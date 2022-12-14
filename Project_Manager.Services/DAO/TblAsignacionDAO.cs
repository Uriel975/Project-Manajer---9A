using Project_Manager.Services.BO;
using System.Data;
using System.Data.SqlClient;

namespace Project_Manager.Services.DAO
{
    public class TblAsignacionDAO
{
	SqlConnection con = new SqlConnection();
	SqlCommand cmd = new SqlCommand();
	Conexion con2 = new Conexion();
	string sql;

		public int Crear(object obj)
	{

		TblAsignacionBO datos = (TblAsignacionBO)obj;
		cmd.Connection = con2.establecerconexion();
		con2.AbrirConexion();
		sql = "Insert into TblAsignacion(EstadoAsignacion ,FKEmpleado ,FKProblemas)"+
		"Values(@EstadoAsignacion ,@FKEmpleado ,@FKProblemas)";
		cmd.Parameters.Add("@IDAsignacion", SqlDbType.Int);
		cmd.Parameters.Add("@EstadoAsignacion", SqlDbType.VarChar);
		cmd.Parameters.Add("@FKEmpleado", SqlDbType.Int);
		cmd.Parameters.Add("@FKProblemas", SqlDbType.Int);

		cmd.Parameters["@IDAsignacion"].Value = datos.IDAsignacion;
		cmd.Parameters["@EstadoAsignacion"].Value = datos.EstadoAsignacion;
		cmd.Parameters["@FKProblemas"].Value = datos.FKProblemas;
		cmd.Parameters["@FKEmpleado"].Value = datos.OTblEmpleadoBO.IDEmpleado;
		cmd.CommandText = sql;


		int i = cmd.ExecuteNonQuery();
		cmd.Parameters.Clear();

		if(i <= 0)
		{
			return 0;
		}
		return 1;
	}


		public int Modificar(object obj)
	{

		TblAsignacionBO datos = (TblAsignacionBO)obj;
		cmd.Connection = con2.establecerconexion();
		con2.AbrirConexion();
		sql = "update TblAsignacion"+
		" set "+
		"EstadoAsignacion = @EstadoAsignacion,"+
		"FKEmpleado = @FKEmpleado,"+
		"FKProblemas = @FKProblemas"+
		" where IDAsignacion = @IDAsignacion";

		cmd.Parameters.Add("@IDAsignacion", SqlDbType.Int);
		cmd.Parameters.Add("@EstadoAsignacion", SqlDbType.VarChar);
		cmd.Parameters.Add("@FKEmpleado", SqlDbType.Int);
		cmd.Parameters.Add("@FKProblemas", SqlDbType.Int);

		cmd.Parameters["@IDAsignacion"].Value = datos.IDAsignacion;
		cmd.Parameters["@EstadoAsignacion"].Value = datos.EstadoAsignacion;
		cmd.Parameters["@FKProblemas"].Value = datos.FKProblemas;
		cmd.Parameters["@FKEmpleado"].Value = datos.OTblEmpleadoBO.IDEmpleado;

		cmd.CommandText = sql;

		int i = cmd.ExecuteNonQuery();
		cmd.Parameters.Clear();

		if(i <= 0)
		{
			return 0;
		}
		return 1;
	}


		public int Eliminar(object obj)
	{
		TblAsignacionBO datos = (TblAsignacionBO)obj;
		cmd.Connection = con2.establecerconexion();
		con2.AbrirConexion();
		sql = "DELETE FROM TblAsignacion where IDAsignacion = @IDAsignacion";
		cmd.Parameters.Add("@IDAsignacion", SqlDbType.Int);
		cmd.Parameters["@IDAsignacion"].Value = datos.IDAsignacion;
		cmd.CommandText = sql;

		int i = cmd.ExecuteNonQuery();
		cmd.Parameters.Clear();

		if(i <= 0)
		{
			return 0;
		}
		return 1;
	}


		public DataSet devuelveAlumno(object obj)
	{
		string cadenaWhere = "";
		bool edo = false;
		TblAsignacionBO data = (TblAsignacionBO)obj;
		SqlCommand cmd = new SqlCommand();
		DataSet ds = new DataSet();
		SqlDataAdapter da = new SqlDataAdapter();
		cmd.Connection = con2.establecerconexion();
		con2.AbrirConexion();

		if (data.IDAsignacion > 0)
		{
			cadenaWhere = cadenaWhere + " IDAsignacion = @IDAsignacion and";
			cmd.Parameters.Add("@IDAsignacion", SqlDbType.Int);
			cmd.Parameters["@IDAsignacion"].Value = data.IDAsignacion;
			edo = true;
		}
		if (data.EstadoAsignacion !=null)
		{
			cadenaWhere = cadenaWhere + " EstadoAsignacion = @EstadoAsignacion and";
			cmd.Parameters.Add("@EstadoAsignacion", SqlDbType.VarChar);
			cmd.Parameters["@EstadoAsignacion"].Value = data.EstadoAsignacion;
			edo = true;
		}
		if (data.FKProblemas > 0)
		{
			cadenaWhere = cadenaWhere + " FKProblemas = @FKProblemas and";
			cmd.Parameters.Add("@FKProblemas", SqlDbType.Int);
			cmd.Parameters["@FKProblemas"].Value = data.FKProblemas;
			edo = true;
		}

		if (edo == true)
		{
			 cadenaWhere = " WHERE " +cadenaWhere.Remove(cadenaWhere.Length - 3, 3);
		}
		sql = "SELECT * FROM TblAsignacion"  + cadenaWhere;
		cmd.CommandText = sql;
		da.SelectCommand = cmd;
		da.Fill(ds);
		con2.CerrarConexion();
		return ds;
	}


		public DataTable ListarTabla()
	{
		sql = "Select * from TblAsignacion";
		SqlDataAdapter da = new SqlDataAdapter(sql, con2.establecerconexion());
		DataTable tabla = new DataTable();
		da.Fill(tabla);
		return tabla;
	}

	}
}
