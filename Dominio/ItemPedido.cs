using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class ItemPedido
    {
        public int Id { get; set; }
        public int Cantidad { get; set; }
        //public decimal PrecioUnitario { get; set; }
        public decimal Subtotal => Cantidad * Producto.Precio;

        // Relación: Un ítem pertenece a un pedido
        //public int IdPedido { get; set; }
        public Pedido Pedido { get; set; }

        // Relación: Un ítem está asociado a un producto
        //public int IdProducto { get; set; }
        public Producto Producto { get; set; }
    }
}
