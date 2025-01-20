using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Pedido
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public bool Estado { get; set; } // true = Abierto, false = Cerrado
        public decimal Total { get; set; }

        // Relación: Un pedido pertenece a una mesa
        public int IdMesa { get; set; }
        public Mesa Mesa { get; set; }

        // Relación: Un pedido tiene varios ítems
        public ICollection<ItemPedido> ItemsPedido { get; set; }
    }
}
