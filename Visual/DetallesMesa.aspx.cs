using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;
using System.Web.Services.Description;
using System.Configuration;
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
                    if (!IsPostBack)
                    {
                        ViewState["personas"] = 1;
                    }
                    lblNumeroPersonas.Text = ViewState["personas"].ToString();
                    contadorDiv.Visible = true;
                    contador2.Visible = false;
                    btnAgregarPedido.Visible = false;
                    btnCerrarMesa.Visible = false;
                }
            }
            else //Si la mesa no existe o no esta asignada al usuario manda al inicio
            {
                Response.Redirect("Default.aspx");
            }
        }

        protected void btnAgregarPedido_Click(object sender, EventArgs e)
        {
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
            //Muestra la confirmacion de contraseña
            confirmarContraseña();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            //oculta la confirmacion de contraseña y deja el campo contraseña en blanco
            Confirmar.Visible= false;
            tbContraseña.Text = string.Empty;
            info.Visible = false;
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            //Validamos la contraseña
            Usuario usuario = (Usuario)Session["usuario"];
            if (tbContraseña.Text != usuario.Contrasena)
            {
                tbContraseña.Text = string.Empty;
                info.Visible = true;
                info.InnerText = "¡Contraseña incorrecta!";
                return;
            }
            tbContraseña.Text = string.Empty;
            if (lblProducto.Text == string.Empty)
            {
                /*Si viene vacio no hay ningun item producto entonces venimos del 
                 * control de cerrar mesa y se ejecuta el codigo para cerrar mesa y el pedido*/
                PedidoDB pedidoDB = new PedidoDB();
                pedidoDB.cerrarPedido(mesaSeleccionada.Id, sumarTotal(mesaSeleccionada.Pedidos));
                MesaDB mesa = new MesaDB();
                mesa.cerrarMesa(mesaSeleccionada.Id);
                Response.Redirect("Default.aspx");
                //Aqui se podria agregar el tema de imprimir el ticket...
            }
            else
            {
                // Si no es igual viene del control eliminar producto 
                ItemPedidoDB itemPedido = new ItemPedidoDB();
                itemPedido.borrarItem((int)ViewState["itemproducto"]);
                //Recargamos la pagina para que muestre los cambios
                Response.Redirect("DetallesMesa.aspx?id=" + mesaSeleccionada.Id.ToString());
            }
        }

        protected void dgvPedidos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Accion")
            {
                int index = Convert.ToInt32(e.CommandArgument);  // Obtiene el índice del registro actual             
                GridViewRow row = dgvPedidos.Rows[index]; // Obtiene la fila del GridView
                string Nombre = row.Cells[1].Text; //Obtenemos el nombre del producto
                ViewState["itemproducto"] = int.Parse(row.Cells[0].Text); //Obtenemos el id de item pedido y lo guardamos 
                confirmarContraseña(Nombre);
            }
        }

        protected void confirmarContraseña()
        {
            //muestra el campo para ingresar la contraseña 
            Confirmar.Visible = true;
            lblProducto.Text = string.Empty;
            lblConfirmar.Text = "Ingrese su contraseña para cerrar la mesa";
            info.Visible = false;
        }

        protected void confirmarContraseña(string nombre)
        {
            //muestra el campo para ingresar la contraseña 
            Confirmar.Visible = true;
            lblProducto.Text = nombre;
            lblConfirmar.Text = "Ingrese su contraseña para eliminar el producto";
            info.Visible = false;
        }

        protected void btnCancelarAbrir_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void btnMenos_Click(object sender, EventArgs e)
        {
            int cantidad = (int)ViewState["personas"];
            if (cantidad == 1)
            {
                return;
            }
            else
            {
                cantidad--;
                ViewState["personas"] = cantidad;
                lblNumeroPersonas.Text = cantidad.ToString();
            }
        }

        protected void btnMas_Click(object sender, EventArgs e)
        {
            int cantidad = (int)ViewState["personas"];
            cantidad++;
            ViewState["personas"] = cantidad;
            lblNumeroPersonas.Text = cantidad.ToString();
        }

        protected void btnAbrirMesa_Click(object sender, EventArgs e)
        {
            contadorDiv.Visible = false;
            contador2.Visible = true;
            btnAgregarPedido.Visible = true;
            btnCerrarMesa.Visible = true;
            alert.Visible = true;
            CerrarMesa.Visible = true;
            int Personas = (int)ViewState["personas"];
            //La mesa no esta abierta por lo que no tiene pedido
            PedidoDB pedidoDB = new PedidoDB();
            //Se le crea un pedido
            mesaSeleccionada.IdPedido = pedidoDB.crearPedido(mesaSeleccionada.Id, Personas);
            mesaSeleccionada.Estado = true;
            //Se actualiza la lista mesas de la sesion para agregarle el id pedido
            List<Mesa> listaMesa = (List<Mesa>)Session["ListaMesas"];
            int indexMesa = listaMesa.FindIndex(m => m.Id == mesaSeleccionada.Id);
            listaMesa[indexMesa] = mesaSeleccionada;
            Session["ListaMesas"] = listaMesa;
        }


    }
}