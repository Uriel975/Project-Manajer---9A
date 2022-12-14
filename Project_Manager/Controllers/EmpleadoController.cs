using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project_Manager.Services.BO;
using Project_Manager.Services.Services;
using Newtonsoft.Json;

namespace Project_Manager.Controllers
{
    public class EmpleadoController : Controller
    {
        TblEmpleadoCTRL Employees = new TblEmpleadoCTRL();
        TblCuentaCTRL Login = new TblCuentaCTRL();
        //TblProyectosCTRL Proyecto = new TblProyectosCTRL();
        // GET: Empleado
        public ActionResult Index()
        {
            if (Session["Rol"] != null)
            {
                if ((Session["Rol"]).ToString() == "Administrador")
                {
                    ViewBag.EmpleadoList = Employees.GetAll();
                    return View();
                }
                else
                    return RedirectToAction("../Home/Error");
            }
            else
                return RedirectToAction("../Login/UserLogin");
        }
        public ActionResult Create()
        {
            if (Session["Rol"] != null)
            {
                if ((Session["Rol"]).ToString() == "Administrador")
                {
                    return View();
                }
                return RedirectToAction("../Home/Error");
            }
            else
                return RedirectToAction("../Login/UserLogin");
        }

        
        #region Metodos
        public int New()
        {
            string correo = Request.Form.Get("CorreoEmpleado");
            string contraseña = Request.Form.Get("ContraEmpleado");
            string data = Request.Form.Get("dataEmpleado");
            TblEmpleadoBO empleado = JsonConvert.DeserializeObject<TblEmpleadoBO>(data);
            TblCuentaBO login = new TblCuentaBO();
            login.Correo = correo;
            login.Contra = contraseña;
            login.Usuario = empleado.FKUsuario;
            login.Rol = "Empleado";
            login.Estatus = 0;


            try
            {
                int res = 0;
                res = Login.Alta(login);
                res = 0;
                res = Employees.Alta(empleado);
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
            string telefono = Request.Form.Get("telefono");
            string correo = Request.Form.Get("correo");
            int id = int.Parse(Request.Form.Get("id"));
            string usuario = Request.Form.Get("usuario");

            TblEmpleadoBO data = new TblEmpleadoBO();
            TblCuentaBO login = new TblCuentaBO();

            data.NombreEmpleado = nombre;
            data.TelefonoEmpleado = telefono;
            data.FKUsuario = usuario;
            data.IDEmpleado = id;
            login.Usuario = usuario;
            login.Correo = correo;
            try
            {
                int res = 0;
                res = Login.Cambio(login);
                res = 0;
                res = Employees.Cambio(data);
                return res;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public int UpdateStatus()
        {
            int estatus = 1;
            int id = int.Parse(Request.Form.Get("id"));
            try
            {
                int res = Employees.Baja(id, estatus);
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