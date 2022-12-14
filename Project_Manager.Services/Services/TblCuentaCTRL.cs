using Project_Manager.Services.BO;
using Project_Manager.Services.DAO;
using System.Collections.Generic;
using System.Data;

namespace Project_Manager.Services.Services
{
	public class TblCuentaCTRL
	{
		TblCuentaDAO metodo = new TblCuentaDAO();
		public int Alta(object obj)
		{
			int resultado = 0;
			resultado = metodo.Crear(obj);
			return resultado;
		}

		public List<TblCuentaBO> GetAll_Cuenta()
		{
			List<TblCuentaBO> datos = new List<TblCuentaBO>();
			datos = metodo.ListarTabla();
			return datos;
		}

		public int GetAll_Cuenta(object obj)
		{
			int datos = 0;
			datos = metodo.ListarTablaL(obj);

			if (datos == 1)
				return 1;
			else
				return 0;

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
			DataSet ds = new DataSet(); ;
			ds = metodo.devuelveAlumno(obj);
			return ds;
		}


		public DataTable login(string user, string contra)
		{
			DataTable datos = new DataTable(); ;
			//datos = metodo.InisiarSesion(user, contra);
			return datos;
		}


	}
}

