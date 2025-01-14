using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Usuario
    {
        public string Nombre { get; set; }
        public int Legajo { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Rol { get; set; }
    }
}
//Tambien podemos hacer uso de herencia:
//Usuario > Gerente     (con acceso completo)
//        > Mesero      
//Pero quizas es mas conveniente hacer uso de roles, ya que un usuario puede tener mas de un rol.(por ejemplo agregar un rol de Cajero)
//Y de ahí que si un usuario tiene el rol de Gerente, entonces tiene acceso completo.