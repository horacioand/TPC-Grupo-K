using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class AsignacionMesa
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }

        // Relación: Una asignación está asociada a una mesa
        public int IdMesa { get; set; }
        public Mesa Mesa { get; set; }

        // Relación: Una asignación está asociada a un usuario
        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set; }
    }
}
