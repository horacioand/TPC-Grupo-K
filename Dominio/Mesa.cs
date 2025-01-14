using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Mesa
    {
        public int NumMesa { get; set; }
        public  int Capacidad { get; set; }
        public Usuario Mesero { get; set; }
        public bool Estado { get; set; }    
        public List<Platillo> Consumo { get; set; }

    }
}
