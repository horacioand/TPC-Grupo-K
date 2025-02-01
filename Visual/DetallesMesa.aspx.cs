using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;
namespace Visual
{
    public partial class DetallesMesa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] == null)
            {
                Response.Redirect("Default.aspx");
            }
            else
            {
                var id = Request.QueryString["id"];
                List<Pedido> listaPedidos = new PedidoDB().listarMesa(id);
                dgvPedidos.DataSource = listaPedidos;
                dgvPedidos.DataBind();
            }

        }
    }
}