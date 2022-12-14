using Project_Manager.Services.BO;
using System.Data;
using System.Data.SqlClient;

namespace Project_Manager.Services.DAO
{
    public class TblTarjetaDAO
{
	SqlConnection con = new SqlConnection();
	SqlCommand cmd = new SqlCommand();
	Conexion con2 = new Conexion();
	string sql;

		public int Crear(object obj)
	{

		TblTarjetaBO datos = (TblTarjetaBO)obj;
		cmd.Connection = con2.establecerconexion();
		con2.AbrirConexion();
		sql = "Insert into TblTarjeta(NumeroTarjeta ,CVVTarjeta ,FechaTarjeta ,FKCliente)"+
		"Values(@NumeroTarjeta ,@CVVTarjeta ,@FechaTarjeta ,@FKCliente)";
		cmd.Parameters.Add("@IDTarjeta", SqlDbType.Int);
		cmd.Parameters.Add("@NumeroTarjeta", SqlDbType.VarChar);
		cmd.Parameters.Add("@CVVTarjeta", SqlDbType.VarChar);
		cmd.Parameters.Add("@FechaTarjeta", SqlDbType.VarChar);
		cmd.Parameters.Add("@FKCliente", SqlDbType.Int);

		cmd.Parameters["@IDTarjeta"].Value = datos.IDTarjeta;
		cmd.Parameters["@NumeroTarjeta"].Value = datos.NumeroTarjeta;
		cmd.Parameters["@CVVTarjeta"].Value = datos.CVVTarjeta;
		cmd.Parameters["@FechaTarjeta"].Value = datos.FechaTarjeta;
		cmd.Parameters["@FKCliente"].Value = datos.OTblEmpleadoBO.IDEmpleado;
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

		TblTarjetaBO datos = (TblTarjetaBO)obj;
		cmd.Connection = con2.establecerconexion();
		con2.AbrirConexion();
		sql = "update TblTarjeta"+
		" set "+
		"NumeroTarjeta = @NumeroTarjeta,"+
		"CVVTarjeta = @CVVTarjeta,"+
		"FechaTarjeta = @FechaTarjeta,"+
		"FKCliente = @FKCliente"+
		" where IDTarjeta = @IDTarjeta";

		cmd.Parameters.Add("@IDTarjeta", SqlDbType.Int);
		cmd.Parameters.Add("@NumeroTarjeta", SqlDbType.VarChar);
		cmd.Parameters.Add("@CVVTarjeta", SqlDbType.VarChar);
		cmd.Parameters.Add("@FechaTarjeta", SqlDbType.VarChar);
		cmd.Parameters.Add("@FKCliente", SqlDbType.Int);

		cmd.Parameters["@IDTarjeta"].Value = datos.IDTarjeta;
		cmd.Parameters["@NumeroTarjeta"].Value = datos.NumeroTarjeta;
		cmd.Parameters["@CVVTarjeta"].Value = datos.CVVTarjeta;
		cmd.Parameters["@FechaTarjeta"].Value = datos.FechaTarjeta;
		cmd.Parameters["@FKCliente"].Value = datos.OTblEmpleadoBO.IDEmpleado;

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
		TblTarjetaBO datos = (TblTarjetaBO)obj;
		cmd.Connection = con2.establecerconexion();
		con2.AbrirConexion();
		sql = "DELETE FROM TblTarjeta where IDTarjeta = @IDTarjeta";
		cmd.Parameters.Add("@IDTarjeta", SqlDbType.Int);
		cmd.Parameters["@IDTarjeta"].Value = datos.IDTarjeta;
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
		TblTarjetaBO data = (TblTarjetaBO)obj;
		SqlCommand cmd = new SqlCommand();
		DataSet ds = new DataSet();
		SqlDataAdapter da = new SqlDataAdapter();
		cmd.Connection = con2.establecerconexion();
		con2.AbrirConexion();

		if (data.IDTarjeta > 0)
		{
			cadenaWhere = cadenaWhere + " IDTarjeta = @IDTarjeta and";
			cmd.Parameters.Add("@IDTarjeta", SqlDbType.Int);
			cmd.Parameters["@IDTarjeta"].Value = data.IDTarjeta;
			edo = true;
		}
		if (data.NumeroTarjeta !=null)
		{
			cadenaWhere = cadenaWhere + " NumeroTarjeta = @NumeroTarjeta and";
			cmd.Parameters.Add("@NumeroTarjeta", SqlDbType.VarChar);
			cmd.Parameters["@NumeroTarjeta"].Value = data.NumeroTarjeta;
			edo = true;
		}
		if (data.CVVTarjeta !=null)
		{
			cadenaWhere = cadenaWhere + " CVVTarjeta = @CVVTarjeta and";
			cmd.Parameters.Add("@CVVTarjeta", SqlDbType.VarChar);
			cmd.Parameters["@CVVTarjeta"].Value = data.CVVTarjeta;
			edo = true;
		}
		if (data.FechaTarjeta !=null)
		{
			cadenaWhere = cadenaWhere + " FechaTarjeta = @FechaTarjeta and";
			cmd.Parameters.Add("@FechaTarjeta", SqlDbType.VarChar);
			cmd.Parameters["@FechaTarjeta"].Value = data.FechaTarjeta;
			edo = true;
		}

		if (edo == true)
		{
			 cadenaWhere = " WHERE " +cadenaWhere.Remove(cadenaWhere.Length - 3, 3);
		}
		sql = "SELECT * FROM TblTarjeta"  + cadenaWhere;
		cmd.CommandText = sql;
		da.SelectCommand = cmd;
		da.Fill(ds);
		con2.CerrarConexion();
		return ds;
	}


		public DataTable ListarTabla()
	{
		sql = "Select * from TblTarjeta";
		SqlDataAdapter da = new SqlDataAdapter(sql, con2.establecerconexion());
		DataTable tabla = new DataTable();
		da.Fill(tabla);
		return tabla;
	}

	}
}
