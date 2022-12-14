using Project_Manager.Services.BO;
using System.Data;
using System.Data.SqlClient;

namespace Project_Manager.Services.DAO
{
    public class TblProblemaDAO
{
	SqlConnection con = new SqlConnection();
	SqlCommand cmd = new SqlCommand();
	Conexion con2 = new Conexion();
	string sql;

		public int Crear(object obj)
	{

		TblProblemaBO datos = (TblProblemaBO)obj;
		cmd.Connection = con2.establecerconexion();
		con2.AbrirConexion();
		sql = "Insert into TblProblema(TituloProblema ,DescripcionProblema ,FechaProblema ,FKProyecto ,FKCliente)"+
		"Values(@TituloProblema ,@DescripcionProblema ,@FechaProblema ,@FKProyecto ,@FKCliente)";
		cmd.Parameters.Add("@IDProblema", SqlDbType.Int);
		cmd.Parameters.Add("@TituloProblema", SqlDbType.VarChar);
		cmd.Parameters.Add("@DescripcionProblema", SqlDbType.VarChar);
		cmd.Parameters.Add("@FechaProblema", SqlDbType.DateTime);
		cmd.Parameters.Add("@FKProyecto", SqlDbType.Int);
		cmd.Parameters.Add("@FKCliente", SqlDbType.Int);

		cmd.Parameters["@IDProblema"].Value = datos.IDProblema;
		cmd.Parameters["@TituloProblema"].Value = datos.TituloProblema;
		cmd.Parameters["@DescripcionProblema"].Value = datos.DescripcionProblema;
		cmd.Parameters["@FechaProblema"].Value = datos.FechaProblema;
		cmd.Parameters["@FKProyecto"].Value = datos.FKProyecto;
		cmd.Parameters["@FKCliente"].Value = datos.OTblClienteBO.IDCliente;
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

		TblProblemaBO datos = (TblProblemaBO)obj;
		cmd.Connection = con2.establecerconexion();
		con2.AbrirConexion();
		sql = "update TblProblema"+
		" set "+
		"TituloProblema = @TituloProblema,"+
		"DescripcionProblema = @DescripcionProblema,"+
		"FechaProblema = @FechaProblema,"+
		"FKProyecto = @FKProyecto,"+
		"FKCliente = @FKCliente"+
		" where IDProblema = @IDProblema";

		cmd.Parameters.Add("@IDProblema", SqlDbType.Int);
		cmd.Parameters.Add("@TituloProblema", SqlDbType.VarChar);
		cmd.Parameters.Add("@DescripcionProblema", SqlDbType.VarChar);
		cmd.Parameters.Add("@FechaProblema", SqlDbType.DateTime);
		cmd.Parameters.Add("@FKProyecto", SqlDbType.Int);
		cmd.Parameters.Add("@FKCliente", SqlDbType.Int);

		cmd.Parameters["@IDProblema"].Value = datos.IDProblema;
		cmd.Parameters["@TituloProblema"].Value = datos.TituloProblema;
		cmd.Parameters["@DescripcionProblema"].Value = datos.DescripcionProblema;
		cmd.Parameters["@FechaProblema"].Value = datos.FechaProblema;
		cmd.Parameters["@FKProyecto"].Value = datos.FKProyecto;
		cmd.Parameters["@FKCliente"].Value = datos.OTblClienteBO.IDCliente;

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
		TblProblemaBO datos = (TblProblemaBO)obj;
		cmd.Connection = con2.establecerconexion();
		con2.AbrirConexion();
		sql = "DELETE FROM TblProblema where IDProblema = @IDProblema";
		cmd.Parameters.Add("@IDProblema", SqlDbType.Int);
		cmd.Parameters["@IDProblema"].Value = datos.IDProblema;
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
		TblProblemaBO data = (TblProblemaBO)obj;
		SqlCommand cmd = new SqlCommand();
		DataSet ds = new DataSet();
		SqlDataAdapter da = new SqlDataAdapter();
		cmd.Connection = con2.establecerconexion();
		con2.AbrirConexion();

		if (data.IDProblema > 0)
		{
			cadenaWhere = cadenaWhere + " IDProblema = @IDProblema and";
			cmd.Parameters.Add("@IDProblema", SqlDbType.Int);
			cmd.Parameters["@IDProblema"].Value = data.IDProblema;
			edo = true;
		}
		if (data.TituloProblema !=null)
		{
			cadenaWhere = cadenaWhere + " TituloProblema = @TituloProblema and";
			cmd.Parameters.Add("@TituloProblema", SqlDbType.VarChar);
			cmd.Parameters["@TituloProblema"].Value = data.TituloProblema;
			edo = true;
		}
		if (data.DescripcionProblema !=null)
		{
			cadenaWhere = cadenaWhere + " DescripcionProblema = @DescripcionProblema and";
			cmd.Parameters.Add("@DescripcionProblema", SqlDbType.VarChar);
			cmd.Parameters["@DescripcionProblema"].Value = data.DescripcionProblema;
			edo = true;
		}
		if (data.FechaProblema.ToString() !="01/01/0001 12:00:00 a. m.")
		{
			cadenaWhere = cadenaWhere + " FechaProblema = @FechaProblema and";
			cmd.Parameters.Add("@FechaProblema", SqlDbType.DateTime);
			cmd.Parameters["@FechaProblema"].Value = data.FechaProblema;
			edo = true;
		}
		if (data.FKProyecto > 0)
		{
			cadenaWhere = cadenaWhere + " FKProyecto = @FKProyecto and";
			cmd.Parameters.Add("@FKProyecto", SqlDbType.Int);
			cmd.Parameters["@FKProyecto"].Value = data.FKProyecto;
			edo = true;
		}

		if (edo == true)
		{
			 cadenaWhere = " WHERE " +cadenaWhere.Remove(cadenaWhere.Length - 3, 3);
		}
		sql = "SELECT * FROM TblProblema"  + cadenaWhere;
		cmd.CommandText = sql;
		da.SelectCommand = cmd;
		da.Fill(ds);
		con2.CerrarConexion();
		return ds;
	}


		public DataTable ListarTabla()
	{
		sql = "Select * from TblProblema";
		SqlDataAdapter da = new SqlDataAdapter(sql, con2.establecerconexion());
		DataTable tabla = new DataTable();
		da.Fill(tabla);
		return tabla;
	}

	}
}
