using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Venta
    {
        public int Id { get; set; }
        public int IdMesero { get; set; }
        public int IdPedido { get; set; }
        public decimal TotalCuenta { get; set; }
        public int PlatillosConsumidos { get; set; }
        // Relación: Una venta está asociada a un mesero (usuario)
    }
}
