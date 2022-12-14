using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Manager.Services.BO
{
    public class TblComentarioBO
    {
        public int IDComentario { get; set; }
        public string FKProyecto { get; set; }
        public string FKTarea { get; set; }
        public string FKUsuario { get; set; }
        public string Comentario { get; set; }
        public string Tiempo { get; set; }
    }
}
