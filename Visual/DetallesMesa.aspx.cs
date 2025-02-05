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
        Mesa mesaSeleccionada = new Mesa();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] == null)
            {
                Response.Redirect("Default.aspx");
            }
            else
            {
                var id = Request.QueryString["id"];
                List<Mesa> listaMesa = (List<Mesa>)Session["ListaMesas"];

                // Buscar la mesa seleccionada por su ID
                mesaSeleccionada = listaMesa.FirstOrDefault(m => m.Id.ToString() == id);
                if (mesaSeleccionada != null)
                {
                    PedidoDB pedidoDb = new PedidoDB();
                    mesaSeleccionada.Pedidos = pedidoDb.listarPedidosDia(mesaSeleccionada.Id);
                    dgvPedidos.DataSource = mesaSeleccionada.Pedidos;
                    dgvPedidos.DataBind();
                }
                else
                {
                    Response.Redirect("Default.aspx");
                }
            }

        }

        protected void btnAgregarPedido_Click(object sender, EventArgs e)
        {
            if (mesaSeleccionada.Estado)
            {
                Response.Redirect("Carta.aspx?idPedido=" + mesaSeleccionada.IdPedido.ToString());
            }else
            {
                //La mesa no esta abierta por lo que no tiene pedido, aqui crearle un pedido
                //Y asiganrlo para poder pasarlo a la carta 
            }
        }
    }
}