using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Usuario
    {
        public string Nombre { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool Gerente { get; set; }
    }
}