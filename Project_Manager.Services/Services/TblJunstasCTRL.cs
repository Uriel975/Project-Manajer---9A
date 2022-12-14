using Project_Manager.Services.BO;
using Project_Manager.Services.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Manager.Services.Services
{
	public class TblJunstasCTRL
	{
		TblJuntasDAO metodo = new TblJuntasDAO();

		public int Alta(object obj)
		{
			int resultado = 0;
			resultado = metodo.Crear(obj);
			return resultado;
		}
		public int LeidoCliente(int id)
		{
			int resultado = 0;
			resultado = metodo.LeidoCliente(id);
			return resultado;
		}

		public int actualizarFecha(int id, string fecha, string hora)
		{
			int resultado = 0;
			resultado = metodo.actualizarFecha(id, fecha, hora);
			return resultado;
		}
		public int confirmarJunta(int id)
		{
			int resultado = 0;
			resultado = metodo.confirmarJunta(id);
			return resultado;
		}

		public List<TblProyectosBO> GetAllProjects(int id)
		{
			List<TblProyectosBO> datos = new List<TblProyectosBO>();
			datos = metodo.TraerProyectoCliente(id);
			return datos;
		}
		public List<TblJuntasBO> GetMyMeetings(int id)
		{
			List<TblJuntasBO> datos = new List<TblJuntasBO>();
			datos = metodo.GetMyMeetings(id);
			return datos;
		}
		public List<TblJuntasBO> MisJuntas(int id)
		{
			List<TblJuntasBO> datos = new List<TblJuntasBO>();
			datos = metodo.MisJuntas(id);
			return datos;
		}
		public TblJuntasBO GetAMeet(int id)
		{
			TblJuntasBO data = new TblJuntasBO();
			data = metodo.GetAMeet(id);
			return data;
		}
	}
}
