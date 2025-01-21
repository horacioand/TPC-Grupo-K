using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Visual
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            if (tbPassword.Text.Length == 0 || tbUsuario.Text.Length == 0)
            {
                lblError.Text = "Ingrese todos los datos";
                lblError.ForeColor = System.Drawing.Color.Red;
                return;
            }
            UsuarioDB usuarioDB = new UsuarioDB();
            Usuario user = usuarioDB.loginUsuario(tbUsuario.Text, tbPassword.Text);
            if (user.Id == 0)
            {
                lblError.Text = "Datos incorrectos";
                lblError.ForeColor= System.Drawing.Color.Red;
                return;
            }else
            {
                Session.Add("usuario", user);
            }

        }
    }
}