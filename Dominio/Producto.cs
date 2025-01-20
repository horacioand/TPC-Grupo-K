﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public string Imagen { get; set; }

        // Relación: Un producto puede estar en varios ítems de pedido
        public ICollection<ItemPedido> ItemsPedido { get; set; }
    }
}
