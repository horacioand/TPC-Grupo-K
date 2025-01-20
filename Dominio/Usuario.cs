using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string UsuarioNombre { get; set; }
        public string Contrasena { get; set; }
        public bool Rol { get; set; } // true = Gerente, false = Mesero


        // Relación: Un usuario puede estar asignado a varias mesas
        public ICollection<AsignacionMesa> AsignacionesMesas { get; set; }
        // Relación: Un usuario puede estar asociado a varias ventas
        public ICollection<Venta> Ventas { get; set; }
    }
}