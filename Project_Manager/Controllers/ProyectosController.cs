 using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using Project_Manager.Correos;
using Project_Manager.Services;
using Project_Manager.Services.BO;
using Project_Manager.Services.Services;
using System;
using System.Web.Mvc;

namespace Project_Manager.Controllers
{
    public class ProyectosController : Controller
    {
        TblProyectosCTRL proyecto = new TblProyectosCTRL();
        TblClienteCTRL cliente = new TblClienteCTRL();
        TblEmpleadoCTRL Empleado = new TblEmpleadoCTRL();
        TblTareasCTRL tareas = new TblTareasCTRL();
        TblProyectoEmpleadoCTRL EmpleadoProyecto = new TblProyectoEmpleadoCTRL();
        TblTomarTareaCTRL TomaTarea = new TblTomarTareaCTRL();
        TblComentarioCTRL Comentarios = new TblComentarioCTRL();

        // GET: Proyectos
        #region Vistas
        public ActionResult Index()
        {
            if (Session["Rol"] != null)
            {
                if ((Session["Rol"]).ToString() == "Administrador")
                {
                    ViewBag.ProyectoList = proyecto.GetAll();
                    return View();
                }
                else
                    return RedirectToAction("../Home/Error");
            }
            else
                return RedirectToAction("../Home/Error");

            
        }
        public ActionResult Create()
        {
            if (Session["Rol"] != null)
            {
                if ((Session["Rol"]).ToString() == "Administrador")
                {
                    ViewBag.ClienteList = cliente.TraerClienteiD();
                    return View();
                }
                else
                    return RedirectToAction("../Home/Error");
            }
            else
                return RedirectToAction("../Login/UserLogin");
            
        }
        public ActionResult Details()
        {
            if (Session["Rol"] != null)
            {
                if ((Session["Rol"]).ToString() == "Administrador")
                {
                    string folio = "";
                    try { folio = Request.QueryString.Get("i"); } catch { }
                    ViewBag.ProyectoObj = proyecto.GetOne(folio);
                    ViewBag.proyectoaEmpleado = EmpleadoProyecto.GetProyectoAEmpleado(folio);
                    ViewBag.ProyectoList = Empleado.TraerEmpleadosAsignacion();
                    return View();
                }
                else
                    return RedirectToAction("../Home/Error");
            }
            else
                return RedirectToAction("../Login/UserLogin");

            
        }
        public ActionResult Task()
        {
            if (Session["Rol"] != null)
            {

                    string folio = "";
                    try { folio = Request.QueryString.Get("i"); } catch { }
                    ViewBag.TareasList = tareas.GetAll(folio);
                    ViewBag.ProyectoObj = proyecto.GetOne(folio);
                    return View();
            }
            else
                return RedirectToAction("../");
        }

        public ActionResult DetallesTask()
        {
            if (Session["Rol"] != null)
            {
                string fkfolio = String.Empty;
                string id = String.Empty;
                try
                {
                    fkfolio = Request.QueryString.Get("f");
                    id = Request.QueryString.Get("i");
                }
                catch { }
                ViewBag.ListDetalles = TomaTarea.GetDetallesTareas(fkfolio, id);
                ViewBag.ListaComentario = Comentarios.ListaComentario(fkfolio, id);
                return View();
            }
            else
                return RedirectToAction("../");
        }

        #endregion
        #region Metodos
        public int NewCom()
        {
            TblComentarioBO datos = new TblComentarioBO();
            TblComentarioCTRL metodo = new TblComentarioCTRL();

            datos.Comentario = Request.Form.Get("comentario");
            datos.FKTarea = Request.Form.Get("tarea");
            datos.FKProyecto = Request.Form.Get("proyecto");
            datos.FKUsuario = Session["Usuario"].ToString();

            try
            {
                return metodo.AgregarComentario(datos);
            }
            catch
            {
                return 0;
            }
        }


        public int New()
        {
            string data = Request.Form.Get("dataproyecto");
            TblProyectosBO project = JsonConvert.DeserializeObject<TblProyectosBO>(data);
            Aleatorios folio = new Aleatorios();
            project.Folio = folio.NumFolio();
            project.FechaInicio = DateTime.Now.ToString("yyyy-MM-dd");

            try
            {
                int res = 0;
                res = proyecto.Alta(project);
                return res;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public int UpdateStatus()
        {
            int newstatus = 0;
            int estatus = int.Parse(Request.Form.Get("estatus")); 
            string folio = Request.Form.Get("id");
            if(estatus != 4)
            {
                newstatus = 4;
            }
            else
            {
                newstatus = 0;
            }
            try
            {
                int res = proyecto.Baja(folio, newstatus);
                return res;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public int Update()
        {
            string nombre = Request.Form.Get("nombre");
            string descripcion = Request.Form.Get("descripcion");
            string prioridad = Request.Form.Get("prioridad");
            int limite = int.Parse(Request.Form.Get("limite"));
            string folio = Request.Form.Get("folio");

            TblProyectosBO data = new TblProyectosBO();

            data.NombreProyecto = nombre;
            data.Descripcion = descripcion;
            data.Prioridad = prioridad;
            data.Limite = limite;
            data.Folio = folio;
            try
            {
                int res = 0;

                res = proyecto.Cambio(data);
                return res;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public int NewTask()
        {
            string nombre = Request.Form.Get("Nombre");
            string descripcion = Request.Form.Get("DESCRI");
            string folio = Request.Form.Get("fkproyecto");

            TblTareasBO data = new TblTareasBO();

            data.Titulo = nombre;
            data.Descripcion = descripcion;
            data.FKProyecto = folio;
            try
            {
                int res = 0;

                res = tareas.Alta(data);
                return res;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int DeleteTask()
        {
            int id = int.Parse(Request.Form.Get("IdTarea"));
            try
            {
                int res = 0;

                res = tareas.Baja(id);
                return res;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public int TakeTask()
        {
            int tarea = int.Parse(Request.Form.Get("Id"));
            TblTomarTareaBO data = new TblTomarTareaBO();
            data.FKEmpleado = (int)Session["ID"];
            data.FKTarea = tarea;
            data.FechaToma = DateTime.Now.ToString("yyyy/MM/dd");

            try
            {
                int res = 0;

                res = tareas.Tomar(data);
                return res;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public int AsignarProyecto()
        {
            string Folio = Request.Form.Get("folioproyecto");
            int Empleado = int.Parse(Request.Form.Get("IdEmpleado"));
            int Actual   = int.Parse(Request.Form.Get("numeroActual"));
            string NombreProyecto = Request.Form.Get("projecName");
            TblProyectoEmpleadoBO data = new TblProyectoEmpleadoBO();
            data.FKEmpleado = Empleado;
            data.FKProyecto = Folio;
            data.FechaIngreso = DateTime.Now.ToString("yyyy-MM-dd");
            TblProyectosBO actual = new TblProyectosBO();
            int Actualizacion = Actual + 1;

            try
            {
                int res = 0;
                res = EmpleadoProyecto.Alta(data);
                res = 0;
                res = proyecto.AddEmpleado(Actualizacion, Folio);
                CorreosParaEmpleado correo = new CorreosParaEmpleado();
                correo.IncorporacionProyecto(Empleado, NombreProyecto);
                return res;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        #endregion
    }
}