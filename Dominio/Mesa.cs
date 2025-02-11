using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Mesa
    {
        public int Id { get; set; }
        public int Numero { get; set; }
        public int Capacidad { get; set; }
        public bool Estado { get; set; } // true = Abierta, false = Cerrada
        public int IdPedido { get; set; }

        // Relación: Una mesa puede tener varios pedidos
        public ICollection<Pedido> Pedidos { get; set; }

        public Usuario Mesero { get; set; }
        // Relación: Una mesa puede estar asignada a varios usuarios
        //public ICollection<AsignacionMesa> AsignacionesMesas { get; set; }
    }
}
