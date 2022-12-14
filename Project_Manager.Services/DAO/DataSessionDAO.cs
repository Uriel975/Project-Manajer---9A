using Project_Manager.Services.BO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Manager.Services.DAO
{
    public class DataSessionDAO
    {
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        Conexion con2 = new Conexion();
        string sql;

        //public int IDO { get; private set; }

        public List<DataSessionBO > CargarDatos(object obj)
        {
            string Rol = String.Empty;
            TblCuentaBO datos = (TblCuentaBO)obj;
            List<DataSessionBO> lista = new List<DataSessionBO>();
            cmd.Connection = con2.establecerconexion();
            con2.AbrirConexion();
            sql = ("SELECT * FROM TblCuenta WHERE Usuario='" + datos.Usuario + "' AND Contra='" + datos.Contra + "' AND ESTATUS=0");

            SqlDataAdapter da = new SqlDataAdapter(sql, con2.establecerconexion());
            DataTable tabla = new DataTable();
            da.Fill(tabla);
            if (tabla.Rows.Count > 0)
            {
                foreach(DataRow row in tabla.Rows)
                {
                    Rol = row["Rol"].ToString();
                }
                sql = null;
                switch (Rol)
                {
                    case "Administrador":
                        sql = ("SELECT IDAdmin, NombreAdmin, ApellidoPAdmin, ApellidoMAdmin, FKUsuario, Contra, Rol FROM TblAdministrador, tblCuenta WHERE FKUsuario='" + datos.Usuario + "' AND Contra='" + datos.Contra + "' AND Rol='Administrador'");
                        SqlDataAdapter daSA = new SqlDataAdapter(sql, con2.establecerconexion());
                        DataTable tablaSA = new DataTable();
                        daSA.Fill(tablaSA);
                        if (tablaSA.Rows.Count > 0)
                        {
                            foreach(DataRow rowsa in tablaSA.Rows)
                            {
                                DataSessionBO bo = new DataSessionBO();
                                bo.ID = int.Parse(rowsa["IDAdmin"].ToString());
                                bo.Nombre = rowsa["NombreAdmin"].ToString();
                                bo.Apellido1 = rowsa["ApellidoPAdmin"].ToString();
                                bo.Apellido2 = rowsa["ApellidoMAdmin"].ToString();
                                bo.Contraseña = rowsa["Contra"].ToString();
                                bo.Usuario = rowsa["FKUsuario"].ToString();
                                bo.Rol = rowsa["Rol"].ToString();
                                lista.Add(bo);
                            }
                        }
                        break;
                    case "Empleado":
                        sql = ("SELECT IDEmpleado, NombreEmpleado, ApellidoPEmpleado, ApellidoMEmpleado, FKUsuario, Contra, Rol FROM tblEmpleado, tblCuenta WHERE FKUsuario = '" + datos.Usuario + "' AND Contra = '" + datos.Contra + "' AND Rol = 'Empleado'");

                        SqlDataAdapter daSE = new SqlDataAdapter(sql, con2.establecerconexion());
                        DataTable tablaSE = new DataTable();
                        daSE.Fill(tablaSE);
                        if (tablaSE.Rows.Count > 0)
                        {
                            foreach (DataRow rowse in tablaSE.Rows)
                            {
                                DataSessionBO bo = new DataSessionBO();
                                bo.ID = int.Parse(rowse["IDEmpleado"].ToString());
                                bo.Nombre = rowse["NombreEmpleado"].ToString();
                                bo.Apellido1 = rowse["ApellidoPEmpleado"].ToString();
                                bo.Apellido2 = rowse["ApellidoMEmpleado"].ToString();
                                bo.Contraseña = rowse["Contra"].ToString();
                                bo.Usuario = rowse["FKUsuario"].ToString();
                                bo.Rol = rowse["Rol"].ToString();
                                lista.Add(bo);
                            }
                        }
                        break;
                    case "Cliente":
                        sql = "SELECT IDCliente, NombreRepresentante, ApellidoPRepresentante, ApellidoMRepresentante, FKUsuario, Contra, Rol FROM tblClientes, tblCuenta WHERE FKUsuario= '" + datos.Usuario + "' AND Contra='" + datos.Contra + "'AND Rol='Cliente' GROUP BY IDCliente, NombreRepresentante, ApellidoPRepresentante, ApellidoMRepresentante, FKUsuario, Contra, Rol";

                        SqlDataAdapter daSC = new SqlDataAdapter(sql, con2.establecerconexion());
                        DataTable tablaSC = new DataTable();
                        daSC.Fill(tablaSC);
                        if (tablaSC.Rows.Count > 0)
                        {
                            foreach (DataRow rowse in tablaSC.Rows)
                            {
                                DataSessionBO bo = new DataSessionBO();
                                bo.ID = int.Parse(rowse["IDCliente"].ToString());
                                bo.Nombre = rowse["NombreRepresentante"].ToString();
                                bo.Apellido1 = rowse["ApellidoPRepresentante"].ToString();
                                bo.Apellido2 = rowse["ApellidoMRepresentante"].ToString();
                                bo.Usuario = rowse["FKUsuario"].ToString();
                                bo.Contraseña = rowse["Contra"].ToString();
                                bo.Rol = rowse["Rol"].ToString();
                                lista.Add(bo);
                            }
                        }
                        break;
                }
            }
            return lista;
        }

    }
}
