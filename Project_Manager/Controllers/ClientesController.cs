using Newtonsoft.Json;
using Project_Manager.Services.BO;
using Project_Manager.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_Manager.Controllers
{
    public class ClientesController : Controller
    {
        TblClienteCTRL Client = new TblClienteCTRL();
        TblCuentaCTRL Login = new TblCuentaCTRL();
        // GET: Clientes
        public ActionResult Index()
        {
            if (Session["Rol"] != null)
            {
                if ((Session["Rol"]).ToString() == "Administrador")
                {
                    ViewBag.EmpleadoList = Client.GetAll();
                    return View(); ;
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
                    return View(); ;
                }
                else
                    return RedirectToAction("../Home/Error");
            }
            else
                return RedirectToAction("../Login/UserLogin");
        }
        public int New()
        {
            string correo = Request.Form.Get("CorreoEmpleado");
            string contraseña = Request.Form.Get("ContraEmpleado");
            string data = Request.Form.Get("dataCliente");
            TblClienteBO cliente = JsonConvert.DeserializeObject<TblClienteBO>(data);
            TblCuentaBO login = new TblCuentaBO();
            login.Correo = correo;
            login.Contra = contraseña;
            login.Usuario = cliente.FKUsuario;
            login.Rol = "Cliente";
            login.Estatus = 0;


            try
            {
                int res = 0;
                res = Login.Alta(login);
                res = 0;
                res = Client.Alta(cliente);
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
            string apellidop = Request.Form.Get("apellidop");
            string apellidom = Request.Form.Get("apellidom");
            string telefono = Request.Form.Get("telefono");
            string correo = Request.Form.Get("correo");
            int id = int.Parse(Request.Form.Get("id"));
            string usuario = Request.Form.Get("usuario");

            TblClienteBO data = new TblClienteBO();
            TblCuentaBO login = new TblCuentaBO();

            data.NombreRepresentante = nombre;
            data.ApellidoPRepresentante = apellidop;
            data.ApellidoMRepresentante = apellidom;
            data.TelefonoRepresentante = telefono;
            data.FKUsuario = usuario;
            data.IDCliente = id;
            login.Usuario = usuario;
            login.Correo = correo;
            try
            {
                int res = 0;
                res = Login.Cambio(login);
                res = 0;
                res = Client.Cambio(data);
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
                int res = Client.Baja(id, estatus);
                return res;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}