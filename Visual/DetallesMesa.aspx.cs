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
            alert.Visible = false;
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
                    mesaSeleccionada.Pedidos = pedidoDb.listarItems(mesaSeleccionada.IdPedido);
                    if (mesaSeleccionada.Pedidos.Count() == 0)
                    {
                        alert.Visible = true;
                    }
                    else
                    {
                        dgvPedidos.DataSource = mesaSeleccionada.Pedidos;
                        dgvPedidos.DataBind();
                    }
                }
                else
                {
                    Response.Redirect("Default.aspx");
                }
            }

        }

        protected void btnAgregarPedido_Click(object sender, EventArgs e)
        {
            if (!mesaSeleccionada.Estado)
            {
                //La mesa no esta abierta por lo que no tiene pedido
                PedidoDB pedidoDB = new PedidoDB();
                //Se le crea un pedido
                mesaSeleccionada.IdPedido = pedidoDB.crearPedido(mesaSeleccionada.Id);
                mesaSeleccionada.Estado = true;
                //Se actualiza la lista mesas de la sesion para agregarle el id pedido
                List<Mesa> listaMesa = (List<Mesa>)Session["ListaMesas"];
                int indexMesa = listaMesa.FindIndex(m => m.Id == mesaSeleccionada.Id);
                listaMesa[indexMesa] = mesaSeleccionada;
                Session["ListaMesas"] = listaMesa;
            }
            //Se pasa el id pedido a la carta para poder agregar  items
            Response.Redirect("Carta.aspx?idPedido=" + mesaSeleccionada.IdPedido.ToString());
        }
    }
}