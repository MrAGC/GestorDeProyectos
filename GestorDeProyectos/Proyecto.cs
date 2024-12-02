using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDeProyectos
{
    internal class Proyecto
    {
        public string NombreProyecto {  get; set; }
        public List<string> Tareas { get; set; }
        public List<string> Subtareas { get; set; }
        public List<string> Usuarios { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
    }
}
