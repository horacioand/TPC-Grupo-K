using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;
using System.Web.Services.Description;
namespace Visual
{
    public partial class DetallesMesa : System.Web.UI.Page
    {
        Mesa mesaSeleccionada = new Mesa();
        protected void Page_Load(object sender, EventArgs e)
        {
            alert.Visible = false;
            //Si no viene el id de la mesa redirige al inicio
            if (Request.QueryString["id"] == null)
            {
                Response.Redirect("Default.aspx");
                return;
            }
            // Buscar la mesa seleccionada por su ID
            var id = Request.QueryString["id"];
            List<Mesa> listaMesa = (List<Mesa>)Session["ListaMesas"];
            mesaSeleccionada = listaMesa.FirstOrDefault(m => m.Id.ToString() == id);
            if (mesaSeleccionada != null)
            {
                //Si la mesa esta abierta trae los productos 
                if (mesaSeleccionada.Estado)
                {
                    PedidoDB pedidoDb = new PedidoDB();
                    mesaSeleccionada.Pedidos = pedidoDb.listarItems(mesaSeleccionada.IdPedido);
                    //Trae los productos del pedido y valida si hay productos agregados 
                    if (mesaSeleccionada.Pedidos.Count() == 0)
                    {
                        alert.Visible = true;
                    }
                    else
                    {
                        //Asigna los valores a la tabla y labels
                        dgvPedidos.DataSource = mesaSeleccionada.Pedidos;
                        dgvPedidos.DataBind();
                        if (!IsPostBack)
                        {
                            lblCantidad.Text += contarProductos(mesaSeleccionada.Pedidos).ToString();
                            lblTotal.Text += sumarTotal(mesaSeleccionada.Pedidos).ToString();
                        }
                    }
                }
                else
                {
                    alert.Visible = true;
                    alert.InnerText = "Agrega productos para crear un pedido...";
                    CerrarMesa.Visible = false;
                }
            }
            else //Si la mesa no existe o no esta asignada al usuario manda al inicio
            {
                Response.Redirect("Default.aspx");
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
            Response.Redirect("Carta.aspx?idPedido=" + mesaSeleccionada.IdPedido.ToString() + "&idMesa=" + mesaSeleccionada.Id.ToString());
        }

        protected int contarProductos(ICollection<ItemPedido> lista)
        {
            //suma la cantidad de los productos
            int contador = 0;
            foreach (var item in lista)
            {
                contador += item.Cantidad;
            }
            return contador;
        }

        protected decimal sumarTotal(ICollection<ItemPedido> lista)
        {
            //suma el total de los productos
            decimal total = 0;
            foreach (var item in lista)
            {
                total += item.Subtotal;
            }
            return total;
        }

        protected void btnCerrarMesa_Click(object sender, EventArgs e)
        {
            //Muestra la confirmacion de cerrar mesa
            Confirmar.Visible = true;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            //oculta la confirmacion de cerrar mesa y deja el campo contraseña en blanco
            Confirmar.Visible= false;
            tbContraseña.Text = string.Empty;
            incorrecta.Visible = false;
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            Usuario usuario = (Usuario)Session["usuario"];
            //Se confirma que la contraseña sea correcta
            if (tbContraseña.Text != usuario.Contrasena)
            {
                //Si es incorrecta muestra error y limpia el campo contraseña
                tbContraseña.Text = string.Empty;
                incorrecta.Visible = true;
                return;
            }
            //Cierra la mesa y el pedido 
            PedidoDB pedidoDB = new PedidoDB();
            pedidoDB.cerrarPedido(mesaSeleccionada.Id, sumarTotal(mesaSeleccionada.Pedidos));
            MesaDB mesa = new MesaDB();
            mesa.cerrarMesa(mesaSeleccionada.Id);
            Response.Redirect("Default.aspx");
            //Aqui se podria agregar el tema de imprimir el ticket...
        }

        protected void dgvPedidos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Accion")
            {
                int index = Convert.ToInt32(e.CommandArgument);  // Obtiene el índice del registro actual             
                GridViewRow row = dgvPedidos.Rows[index]; // Obtiene la fila del GridView
                int idItemPedido = int.Parse(row.Cells[0].Text); //Obtiene el id del item pedido 
                //Lo borramos de la db
                ItemPedidoDB itemPedido = new ItemPedidoDB();
                itemPedido.borrarItem(idItemPedido);
                //Recargamos la pagina para que muestre los cambios
                Response.Redirect("DetallesMesa.aspx?id=" + mesaSeleccionada.Id.ToString()); 
            }
        }

    }
}