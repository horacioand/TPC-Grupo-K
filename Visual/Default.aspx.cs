using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;
namespace Visual
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Prueba para ver si funciona listar de user
            UsuarioDB usuarioDB = new UsuarioDB();
            List<Usuario> listaUsuario = usuarioDB.listar();
        }
    }
}