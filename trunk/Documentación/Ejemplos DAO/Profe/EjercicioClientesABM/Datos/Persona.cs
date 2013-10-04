using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Datos
{
    public class Persona
    {

        public string Nombre { get; set; }
        
        public Persona()
        {
        }
        public int NumeroDocumento { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Sexo { get; set; }
    }
}