using Project_Manager.Services.DAO;
using System.Data;

namespace Project_Manager.Services.Services
{
    public class TblAsignacionCTRL
	{
		TblAsignacionDAO metodo = new TblAsignacionDAO();
			public int Alta(object obj)
		{
			int resultado = 0;
			resultado = metodo.Crear(obj);
			return resultado;
		}


			public int Baja(object obj)
		{
			int resultado = 0;
			resultado = metodo.Eliminar(obj);
			return resultado;
		}


			public int Cambio(object obj)
		{
			int resultado = 0;
			resultado = metodo.Modificar(obj);
			return resultado;
		}


			public DataSet devuelveAlu(object obj)
		{
			DataSet ds = new DataSet();;
			ds = metodo.devuelveAlumno(obj);
			return ds;
		}


			public DataTable Ver()
		{
			DataTable datos = new DataTable();;
			datos = metodo.ListarTabla();
			return datos;
		}


	}
}

