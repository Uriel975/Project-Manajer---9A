using Project_Manager.Services.BO;
using Project_Manager.Services.DAO;
using System.Collections.Generic;
using System.Data;

namespace Project_Manager.Services.Services
{
    public class TblProyectosCTRL
	{
        TblProyectosDAO metodo = new TblProyectosDAO();
        public int Alta(object obj)
        {
            int resultado = 0;
            resultado = metodo.Crear(obj);
            return resultado;
        }
        public object GetAll()
        {
            List<TblProyectosBO> datos = new List<TblProyectosBO>();
            datos = (List<TblProyectosBO>)metodo.TraerTodoProyecto();
            return datos;
        }
        public List<TblProyectosBO> GetIDProyecto()
        {
            List<TblProyectosBO> datos = new List<TblProyectosBO>();
            datos = metodo.TraerProyecto();
            return datos;
        }
        public int Baja(string folio, int status)
        {
            int resultado = 0;
            resultado = metodo.Eliminar(folio, status);
            return resultado;
        }
        public TblProyectosBO GetOne(string folio)
        {
            TblProyectosBO data = new TblProyectosBO();
            data = metodo.TraeUnProyecto(folio);
            return data;
        }

        public int Cambio(TblProyectosBO obj)
        {
            int resultado = 0;
            resultado = metodo.Actualizar(obj);
            return resultado;
        }
        public int AddEmpleado(int actual, string folio)
        {
            int resultado = 0;
            resultado = metodo.AgregarEmpleado(actual,folio);
            return resultado;
        }
        public List<TblProyectosBO> TraerTareas()
        {
            List<TblProyectosBO> datos = new List<TblProyectosBO>();
            datos = metodo.TraerTareas();
            return datos;
        }
        public List<TblProyectosBO> clienteProyectos(int id)
        {
            List<TblProyectosBO> datos = new List<TblProyectosBO>();
            datos = metodo.TraerTareasCliente(id);
            return datos;
        }
        public List<TblProyectosBO> EmpleadoProyectos(int id)
        {
            List<TblProyectosBO> datos = new List<TblProyectosBO>();
            datos = metodo.TraerTareasEmpleado(id);
            return datos;
        }

    }
}

