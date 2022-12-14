using Project_Manager.Services.BO;
using Project_Manager.Services.DAO;
using System.Collections.Generic;
using System.Data;

namespace Project_Manager.Services.Services
{
	public class TblClienteCTRL
	{
		TblClienteDAO metodo = new TblClienteDAO();
		public int Alta(object obj)
		{
			int resultado = 0;
			resultado = metodo.Crear(obj);
			return resultado;
		}


		public int Baja(int id, int status)
		{
			int resultado = 0;
			resultado = metodo.Eliminar(id, status);
			return resultado;
		}


		public int Cambio(object obj)
		{
			int resultado = 0;
			resultado = metodo.Modificar(obj);
			return resultado;
		}


		//public DataSet devuelveAlu(object obj)
		//{
		//	DataSet ds = new DataSet(); ;
		//	ds = metodo.devuelveAlumno(obj);
		//	return ds;
		//}


		public List<TblClienteBO> GetAll()
		{
			List<TblClienteBO> datos = new List<TblClienteBO>(); //Invoca una lista del objeto TblEmpleadoBO
			datos = metodo.ListarTabla(); //Llena la lista con la consulta, hubicada en Project_Manager.Services.DAO.TblEmpleadoDAO
			return datos;
		}
		public List<TblClienteBO> TraerClienteiD()  //Trae todos los empleados con estatus 0 
		{
			List<TblClienteBO> datos = new List<TblClienteBO>();
			datos = metodo.TraerIDCliente();
			return datos;
		}
	}
}

