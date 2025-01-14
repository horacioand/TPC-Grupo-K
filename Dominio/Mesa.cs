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
        public  int Personas { get; set; }
        public int Mesero { get; set; }
        public List<Platillo> Consumo { get; set; }

    }
}
