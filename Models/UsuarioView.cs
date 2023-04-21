using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JavieraCanalesET.Models
{
    public class UsuarioView
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        //los puse en string por un error que me quitaria tiempo
        public string Edad { get; set; }
         public string Fono { get; set;}
         public string Direccion { get; set; }
        }
    }