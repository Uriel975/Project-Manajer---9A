using Project_Manager.Services.BO;
using Project_Manager.Services.DAO;
using System.Collections.Generic;
using System.Data;

namespace Project_Manager.Services.Services
{
	public class TblEmpleadoCTRL
	{
		TblEmpleadoDAO metodo = new TblEmpleadoDAO();
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


		public int Cambio(TblEmpleadoBO obj)
		{
			int resultado = 0;
			resultado = metodo.Modificar(obj);
			return resultado;
		}

		public List<TblEmpleadoBO> GetAll()
		{
			List<TblEmpleadoBO> datos = new List<TblEmpleadoBO>(); 
			datos = metodo.ListarTabla(); 
			return datos;
		}
		public List<TblEmpleadoBO> TraerEmpleadosAsignacion()
		{
			List<TblEmpleadoBO> datos = new List<TblEmpleadoBO>();
			datos = metodo.GetAsignacionEmpleado();
			return datos;
		}
	}
}

