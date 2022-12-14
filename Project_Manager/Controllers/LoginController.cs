using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project_Manager.Services.BO;
using Project_Manager.Services.Services;

namespace Project_Manager.Controllers
{
    public class LoginController : Controller
    {
        TblCuentaCTRL Cuenta = new TblCuentaCTRL();
        DataSessionCTRL Sesion = new DataSessionCTRL();

        // GET: Login
        public ActionResult UserLogin()
        {
            
            return View();
        }

        public ActionResult Cerrar()
        {
            Session["ID"] = null;
            Session["Nombre"] = null;
            Session["Apellido1"] = null;
            Session["Apellido2"] = null;
            Session["Usuario"] = null;
            Session["Contraseña"] = null;
            Session["Rol"] = null;
            return RedirectToAction("../Login/UserLogin");
        }


        public int Validar()
        {
            string usuario = Request.Form.Get("usuario");
            string contraseña = Request.Form.Get("contraseña");

            TblCuentaBO login = new TblCuentaBO();

            login.Usuario = usuario;
            login.Contra = contraseña;


            try
            {
                int res = 0;
                res = Convert.ToInt32(Cuenta.GetAll_Cuenta(login));

                List<DataSessionBO> x = Sesion.Traer(login);

                foreach (var dso in x)
                {
                    Session["ID"] = dso.ID;
                    Session["Nombre"] = dso.Nombre;
                    Session["Apellido1"] = dso.Apellido1;
                    Session["Apellido2"] = dso.Apellido2;
                    Session["Usuario"] = dso.Usuario;
                    Session["Contraseña"] = dso.Contraseña;
                    Session["Rol"] = dso.Rol;
                }

                return res;

            }
            catch (Exception ex)
            {
                return 0;
            }


        }

        public ActionResult TipoUsuario()
        {
            if ((Session["Rol"]).ToString() == "Administrador")
            {
                return RedirectToAction("../Admin/Index");
            }
            else 
            {
                if ((Session["Rol"]).ToString() == "Empleado")
                {
                    return RedirectToAction("../RolEpleado/Index");
                }
                else if ((Session["Rol"]).ToString() == "Cliente")
                {
                    return RedirectToAction("../RolCliente/Index");
                }
                
            }
            return null;
        }

    }
}

