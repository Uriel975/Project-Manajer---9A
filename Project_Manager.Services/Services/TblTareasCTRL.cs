using Project_Manager.Services.BO;
using Project_Manager.Services.DAO;
using System.Collections.Generic;

namespace Project_Manager.Services.Services
{
    public class TblTareasCTRL
    {
		TblTareasDAO metodo = new TblTareasDAO();
		public int Alta(object obj)
		{
			int resultado = 0;
			resultado = metodo.Crear(obj);
			return resultado;
		}
		public List<TblTareasBO> GetAll(string folio)
		{
			List<TblTareasBO> datos = new List<TblTareasBO>();
			datos = metodo.GetAll(folio);
			return datos;
		}
		public int Baja(int id)
		{
			int resultado = 0;
			resultado = metodo.Eliminar(id);
			return resultado;
		}
		public int Tomar(object obj)
		{
			int resultado = 0;
			resultado = metodo.TomarTarea(obj);
			return resultado;
		}
	}
}
