using Project_Manager.Services.BO;
using Project_Manager.Services.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Manager.Services.Services
{
    public class TblComentarioCTRL
    {
        TblComentarioDAO metodo = new TblComentarioDAO();

        public int AgregarComentario(TblComentarioBO dato)
        {
            int resultado = 0;
            resultado = metodo.AgregarComentario(dato);
            return resultado;
        }

        public List<TblComentarioBO> ListaComentario(string folio, string tarea)
        {
            List<TblComentarioBO> ListaCom = new List<TblComentarioBO>();
            ListaCom = metodo.TraerComentarios(folio, tarea);
            return ListaCom;
        }
    }
}
