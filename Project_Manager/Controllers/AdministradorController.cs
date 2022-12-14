using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project_Manager.Services.BO;
using Project_Manager.Services.Services;

namespace Project_Manager.Controllers
{
    public class AdministradorController : Controller
    {
        TblAdministradorCTRL Administrador = new TblAdministradorCTRL();
        TblCuentaCTRL Login = new TblCuentaCTRL();

        public ActionResult Index()
        {
            if (Session["Rol"] != null)
            {
                if ((Session["Rol"]).ToString() == "Administrador")
                {
                    ViewBag.AdministradorList = Administrador.GetAll_Administrador();  //llena el ViewBag con el metodo GetAll hubicado en la carpeta Services
                    return View();
                }
                else
                    return RedirectToAction("../Home/Error");
            }
            else
                return RedirectToAction("../Login/UserLogin");
        }

        // GET: Administrador

        public ActionResult Create()
        {
            if (Session["Rol"] != null)
            {
                if ((Session["Rol"]).ToString() == "Administrador")
                {
                    return View();
                }
                else
                    return RedirectToAction("../Home/Error");
            }
            else
                return RedirectToAction("../Login/UserLogin");
        }

        #region Metodos
        public int New()
        {
            string nombre = Request.Form.Get("nombre");
            string apellidop = Request.Form.Get("apellidop");
            string apellidom = Request.Form.Get("apellidom");
            string correo = Request.Form.Get("correo");
            string contraseña = Request.Form.Get("contraseña");
            string usuario = Request.Form.Get("usuario");

            TblAdministradorBO data = new TblAdministradorBO();
            TblCuentaBO login = new TblCuentaBO();

            data.NombreAdmin = nombre;
            data.ApellidoPAdmin = apellidop;
            data.ApellidoMAdmin = apellidom;

            data.CorreoAdmin = correo;
            data.ContraAdmin = contraseña;
            data.FKUsuario = usuario;
            data.FKRol = "Administrador";

            login.Correo = correo;
            login.Contra = contraseña;
            login.Usuario = usuario;
            login.Rol = "Administrador";


            try
            {
                int res = 0;
                res = Login.Alta(login);
                res = 0;
                res = Administrador.Alta(data);
                return res;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        // Eliminar o mas bien desactivar... algo asi xD
        public int UpdateStatus()
        {
            int estatus = 1;
            int id = int.Parse(Request.Form.Get("id"));
            try
            {
                int res = Administrador.Baja(id, estatus);
                return res;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public int Update()
        {
            int id = int.Parse(Request.Form.Get("id"));
            string nombre = Request.Form.Get("nombre");
            string correo = Request.Form.Get("correo");
            string usuario = Request.Form.Get("usuario");

            TblAdministradorBO data = new TblAdministradorBO();
            TblCuentaBO login = new TblCuentaBO();

            data.IDAdmin = id;
            data.NombreAdmin = nombre;
            data.CorreoAdmin = correo;
            data.FKUsuario = usuario;

            login.Usuario = usuario;
            login.Correo = correo;
            try
            {
                int res = 0;
                res = Login.Cambio(login);
                res = 0;
                res = Administrador.Cambio(data);
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