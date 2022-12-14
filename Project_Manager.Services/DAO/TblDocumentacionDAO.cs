using Project_Manager.Services.BO;
using System.Data;
using System.Data.SqlClient;

namespace Project_Manager.Services.DAO
{
    public class TblDocumentacionDAO
{
	SqlConnection con = new SqlConnection();
	SqlCommand cmd = new SqlCommand();
	Conexion con2 = new Conexion();
	string sql;

		public int Crear(object obj)
	{

		TblDocumentacionBO datos = (TblDocumentacionBO)obj;
		cmd.Connection = con2.establecerconexion();
		con2.AbrirConexion();
		sql = "Insert into TblDocumentacion(TituloDocumentacion ,DescripcionDocumentacion ,EstimacionDocumentacion ,FechaDocumentacion ,FKAsignacion ,FKEmpleado)"+
		"Values(@TituloDocumentacion ,@DescripcionDocumentacion ,@EstimacionDocumentacion ,@FechaDocumentacion ,@FKAsignacion ,@FKEmpleado)";
		cmd.Parameters.Add("@IDDocumentacion", SqlDbType.Int);
		cmd.Parameters.Add("@TituloDocumentacion", SqlDbType.VarChar);
		cmd.Parameters.Add("@DescripcionDocumentacion", SqlDbType.VarChar);
		cmd.Parameters.Add("@EstimacionDocumentacion", SqlDbType.DateTime);
		cmd.Parameters.Add("@FechaDocumentacion", SqlDbType.DateTime);
		cmd.Parameters.Add("@FKAsignacion", SqlDbType.Int);
		cmd.Parameters.Add("@FKEmpleado", SqlDbType.Int);

		cmd.Parameters["@IDDocumentacion"].Value = datos.IDDocumentacion;
		cmd.Parameters["@TituloDocumentacion"].Value = datos.TituloDocumentacion;
		cmd.Parameters["@DescripcionDocumentacion"].Value = datos.DescripcionDocumentacion;
		cmd.Parameters["@EstimacionDocumentacion"].Value = datos.EstimacionDocumentacion;
		cmd.Parameters["@FechaDocumentacion"].Value = datos.FechaDocumentacion;
		cmd.Parameters["@FKAsignacion"].Value = datos.FKAsignacion;
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

		TblDocumentacionBO datos = (TblDocumentacionBO)obj;
		cmd.Connection = con2.establecerconexion();
		con2.AbrirConexion();
		sql = "update TblDocumentacion"+
		" set "+
		"TituloDocumentacion = @TituloDocumentacion,"+
		"DescripcionDocumentacion = @DescripcionDocumentacion,"+
		"EstimacionDocumentacion = @EstimacionDocumentacion,"+
		"FechaDocumentacion = @FechaDocumentacion,"+
		"FKAsignacion = @FKAsignacion,"+
		"FKEmpleado = @FKEmpleado"+
		" where IDDocumentacion = @IDDocumentacion";

		cmd.Parameters.Add("@IDDocumentacion", SqlDbType.Int);
		cmd.Parameters.Add("@TituloDocumentacion", SqlDbType.VarChar);
		cmd.Parameters.Add("@DescripcionDocumentacion", SqlDbType.VarChar);
		cmd.Parameters.Add("@EstimacionDocumentacion", SqlDbType.DateTime);
		cmd.Parameters.Add("@FechaDocumentacion", SqlDbType.DateTime);
		cmd.Parameters.Add("@FKAsignacion", SqlDbType.Int);
		cmd.Parameters.Add("@FKEmpleado", SqlDbType.Int);

		cmd.Parameters["@IDDocumentacion"].Value = datos.IDDocumentacion;
		cmd.Parameters["@TituloDocumentacion"].Value = datos.TituloDocumentacion;
		cmd.Parameters["@DescripcionDocumentacion"].Value = datos.DescripcionDocumentacion;
		cmd.Parameters["@EstimacionDocumentacion"].Value = datos.EstimacionDocumentacion;
		cmd.Parameters["@FechaDocumentacion"].Value = datos.FechaDocumentacion;
		cmd.Parameters["@FKAsignacion"].Value = datos.FKAsignacion;
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
		TblDocumentacionBO datos = (TblDocumentacionBO)obj;
		cmd.Connection = con2.establecerconexion();
		con2.AbrirConexion();
		sql = "DELETE FROM TblDocumentacion where IDDocumentacion = @IDDocumentacion";
		cmd.Parameters.Add("@IDDocumentacion", SqlDbType.Int);
		cmd.Parameters["@IDDocumentacion"].Value = datos.IDDocumentacion;
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
		TblDocumentacionBO data = (TblDocumentacionBO)obj;
		SqlCommand cmd = new SqlCommand();
		DataSet ds = new DataSet();
		SqlDataAdapter da = new SqlDataAdapter();
		cmd.Connection = con2.establecerconexion();
		con2.AbrirConexion();

		if (data.IDDocumentacion > 0)
		{
			cadenaWhere = cadenaWhere + " IDDocumentacion = @IDDocumentacion and";
			cmd.Parameters.Add("@IDDocumentacion", SqlDbType.Int);
			cmd.Parameters["@IDDocumentacion"].Value = data.IDDocumentacion;
			edo = true;
		}
		if (data.TituloDocumentacion !=null)
		{
			cadenaWhere = cadenaWhere + " TituloDocumentacion = @TituloDocumentacion and";
			cmd.Parameters.Add("@TituloDocumentacion", SqlDbType.VarChar);
			cmd.Parameters["@TituloDocumentacion"].Value = data.TituloDocumentacion;
			edo = true;
		}
		if (data.DescripcionDocumentacion !=null)
		{
			cadenaWhere = cadenaWhere + " DescripcionDocumentacion = @DescripcionDocumentacion and";
			cmd.Parameters.Add("@DescripcionDocumentacion", SqlDbType.VarChar);
			cmd.Parameters["@DescripcionDocumentacion"].Value = data.DescripcionDocumentacion;
			edo = true;
		}
		if (data.EstimacionDocumentacion.ToString() !="01/01/0001 12:00:00 a. m.")
		{
			cadenaWhere = cadenaWhere + " EstimacionDocumentacion = @EstimacionDocumentacion and";
			cmd.Parameters.Add("@EstimacionDocumentacion", SqlDbType.DateTime);
			cmd.Parameters["@EstimacionDocumentacion"].Value = data.EstimacionDocumentacion;
			edo = true;
		}
		if (data.FechaDocumentacion.ToString() !="01/01/0001 12:00:00 a. m.")
		{
			cadenaWhere = cadenaWhere + " FechaDocumentacion = @FechaDocumentacion and";
			cmd.Parameters.Add("@FechaDocumentacion", SqlDbType.DateTime);
			cmd.Parameters["@FechaDocumentacion"].Value = data.FechaDocumentacion;
			edo = true;
		}
		if (data.FKAsignacion > 0)
		{
			cadenaWhere = cadenaWhere + " FKAsignacion = @FKAsignacion and";
			cmd.Parameters.Add("@FKAsignacion", SqlDbType.Int);
			cmd.Parameters["@FKAsignacion"].Value = data.FKAsignacion;
			edo = true;
		}

		if (edo == true)
		{
			 cadenaWhere = " WHERE " +cadenaWhere.Remove(cadenaWhere.Length - 3, 3);
		}
		sql = "SELECT * FROM TblDocumentacion"  + cadenaWhere;
		cmd.CommandText = sql;
		da.SelectCommand = cmd;
		da.Fill(ds);
		con2.CerrarConexion();
		return ds;
	}


		public DataTable ListarTabla()
	{
		sql = "Select * from TblDocumentacion";
		SqlDataAdapter da = new SqlDataAdapter(sql, con2.establecerconexion());
		DataTable tabla = new DataTable();
		da.Fill(tabla);
		return tabla;
	}

	}
}
