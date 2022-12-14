using Project_Manager.Services.BO;
using Project_Manager.Services.DAO;
using System.Collections.Generic;
using System.Data;

namespace Project_Manager.Services.Services
{
	public class TblAdministradorCTRL
	{
		TblAdministradorDAO metodo = new TblAdministradorDAO();

		public int Alta(object obj)
		{
			int resultado = 0;
			resultado = metodo.Crear(obj);
			return resultado;
		}
		public List<TblAdministradorBO> GetAll_Administrador()
		{
			List<TblAdministradorBO> datos = new List<TblAdministradorBO>();
			datos = metodo.ListarTabla();
			return datos;
		}

		public int Baja(int id, int status)
		{
			int resultado = 0;
			resultado = metodo.Eliminar(id, status);
			return resultado;
		}


		public int Cambio(TblAdministradorBO obj)
		{
			int resultado = 0;
			resultado = metodo.Modificar(obj);
			return resultado;
		}


		public DataSet devuelveAlu(object obj)
		{
			DataSet ds = new DataSet(); ;
			ds = metodo.devuelveAlumno(obj);
			return ds;
		}


		//public DataTable Ver()
		//{
		//	DataTable datos = new DataTable(); ;
		//	datos = metodo.ListarTabla();
		//	return datos;
		//}


	}
}

