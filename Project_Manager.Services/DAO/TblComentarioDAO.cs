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
    public class TblComentarioDAO
    {
		SqlConnection con = new SqlConnection();
		SqlCommand cmd = new SqlCommand();
		Conexion con2 = new Conexion();
		string sql;

		public int AgregarComentario(TblComentarioBO datos)
        {
			cmd.Connection = con2.establecerconexion();
			con2.AbrirConexion();

            string sql = "EXEC RealizarComentario '"+ datos.FKProyecto + "', '"+ datos.FKTarea + "', '"+ datos.FKUsuario + "', '"+ datos.Comentario + "'";

			cmd.CommandText = sql;
			int i = cmd.ExecuteNonQuery();

			if (i <= 0)
			{
				return 0;
			}
			return 1;
		}

        public List<TblComentarioBO> TraerComentarios(string folio, string tarea)
        {
            List<TblComentarioBO> lista = new List<TblComentarioBO>();
            sql = "SELECT * FROM tblComentario WHERE FKProyecto='"+folio+"' AND FKTarea='"+tarea +"'";
            SqlDataAdapter da = new SqlDataAdapter(sql, con2.establecerconexion());
            DataTable table = new DataTable();
            da.Fill(table);
            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    TblComentarioBO obj = new TblComentarioBO();
                    obj.FKProyecto = row["FKProyecto"].ToString();
                    obj.FKUsuario = row["FKUsuario"].ToString();
                    obj.Comentario = row["Comentario"].ToString();
                    obj.Tiempo = row["Tiempo"].ToString();
                    lista.Add(obj);
                }
            }
            return lista;
        }
    }
}
