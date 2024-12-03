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
        public List<Tareas> Tareas { get; set; }
        public List<string> Usuarios { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }

        public Proyecto() { }
        public Proyecto(string nombreProyecto, List<Tareas> tareas, List<string> subtareas, List<string> usuarios, DateTime fechaInicio, DateTime fechaFin)
        {
            NombreProyecto = nombreProyecto;
            Tareas = tareas;
            Usuarios = usuarios;
            FechaInicio = fechaInicio;
            FechaFin = fechaFin;
        }
    }
}
