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
        public bool Estado { get; set; }
        public Mesa Mesa { get; set; }
        public List<Platillo> Platillo { get; set; }//Habria que generalizar la clase como item, para agregar platos de comida, bebidas, etc.
    }
}
