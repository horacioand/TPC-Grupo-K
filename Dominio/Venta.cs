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
        public Usuario Mesero { get; set; }
        public int IdPedido { get; set; }
        public decimal TotalCuenta { get; set; }
        public int PlatillosConsumidos { get; set; }
        public int Personas {  get; set; }
        public int NumMesa { get; set; }
        // Relación: Una venta está asociada a un mesero (usuario)
    }
}
