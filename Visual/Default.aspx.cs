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

            if (Session["usuario"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                Usuario usuario = (Usuario)Session["usuario"];
                MesaDB mesaDB = new MesaDB();
                List<Mesa> listaMesa = mesaDB.listaAsignada(usuario.Id);
                dgvMesas.DataSource = listaMesa;
                dgvMesas.DataBind();
                
            }
        }

        protected void dgvMesas_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = dgvMesas.SelectedDataKey.Value.ToString();
            // Response.Redirect();
        }
    }
}