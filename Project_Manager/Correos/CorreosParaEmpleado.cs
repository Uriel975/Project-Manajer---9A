using EASendMail;
using Project_Manager.Services.BO;
using Project_Manager.Services.DAO;
using System;

namespace Project_Manager.Correos
{
    public class CorreosParaEmpleado
    {

        public void IncorporacionProyecto(int idEmpleado, string NombreProyecto)
        {
            TblEmpleadoDAO data = new TblEmpleadoDAO();
            TblEmpleadoBO full = new TblEmpleadoBO();
            full = data.TraerUnEmpleado(idEmpleado);
            string Nombre = full.NombreEmpleado;
            string Fecha = DateTime.Now.ToString("dd/MMMM/yyyy");
            string correo = full.correo;
            string Usuario = full.FKUsuario;

            string mensaje = "Error al enviar correo.";
            try
            {
                SmtpMail objetoCorreo = new SmtpMail("TryIt");

                objetoCorreo.From = "cuentadeproyectosdsm@gmail.com";
                objetoCorreo.To = "cuentadeproyectosdsm@gmail.com";
                objetoCorreo.Subject = Usuario + " Se le ha incorporación a un nuevo proyecto del sistema";
                objetoCorreo.TextBody = "Estimado/a "+ Nombre +" Le informamos que en la fecha " + Fecha + " ,se le ha añadido al proyecto " +NombreProyecto+ ". Apartir de este momento puede visualizar toda la informacion a la que se le ha dado acceso, ingrese al sistema para más detalles";

                SmtpServer objetoServidor = new SmtpServer("smtp.gmail.com");

                objetoServidor.User = "cuentadeproyectosdsm@gmail.com";
                objetoServidor.Password = "Proyectodsm";
                objetoServidor.Port = 587;
                objetoServidor.ConnectType = SmtpConnectType.ConnectSSLAuto;

                SmtpClient objetoCliente = new SmtpClient();
                objetoCliente.SendMail(objetoServidor, objetoCorreo);
                mensaje = "Correo Enviado Correctamente.";
            }
            catch (Exception ex)
            {
                mensaje = "Error al enviar correo." + ex.Message;
            }
        }
    }
}