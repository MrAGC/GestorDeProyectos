using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDeProyectos
{
    internal class Usuario
    {
        public string NombreUsuario { get; set; }
        public string Contraseña { get; set; }
        public bool EsDesarrolador { get; set; } // Cambiado a tipo bool
    }
}
