using Project_Manager.Services.BO;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Project_Manager.Services.DAO
{
    public class TblTomarTareaDAO
    {
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        Conexion con2 = new Conexion();
        string sql;

        public List<TblTomarTareaBO> TraerDetallesTareas(string fkfolio, string id)
        {
            List<TblTomarTareaBO> lista = new List<TblTomarTareaBO>();
            sql = "SELECT * FROM DetallesTareasID WHERE Folio='"+fkfolio+"' AND ID='"+id+"'";
            SqlDataAdapter da = new SqlDataAdapter(sql, con2.establecerconexion());
            DataTable table = new DataTable();
            da.Fill(table);
            if (table.Rows.Count > 0)
            {
                foreach(DataRow row in table.Rows)
                {
                    TblTomarTareaBO obj = new TblTomarTareaBO();
                    obj.IDToma = int.Parse(row["ID"].ToString());
                    obj._folio = row["Folio"].ToString();
                    obj._titulo = row["Titulo"].ToString();
                    obj._descripcion = row["Descripcion"].ToString();
                    obj._empleado = row["Empleado"].ToString();
                    obj._telefono = row["Telefono"].ToString();
                    obj.FechaToma = row["Inicio"].ToString();
                    obj.FechaFinalizacion = row["Termino"].ToString();
                    obj.Estado = int.Parse(row["Estado"].ToString());
                    lista.Add(obj);
                }
            }
            return lista;
        }
    }
}
