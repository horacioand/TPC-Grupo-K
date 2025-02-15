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
    public partial class InformesVentas : System.Web.UI.Page
    {
        List<Venta> list = new List<Venta>();
        protected void Page_Load(object sender, EventArgs e)
        {
            //Traemos todas las ventas
            VentasDB ventasDB = new VentasDB();
            list = ventasDB.listarVentas(DateTime.Now);
            if (!IsPostBack)
            {
                ValidarRol();
                gdwVentas.DataSource = list;
                gdwVentas.DataBind();
            }
        }

        public bool ValidarRol()
        {
            bool validacion = true;
            Usuario user = (Usuario)Session["usuario"];
            if (user == null || !user.Rol)
            {
                // Evitamos que entren mediante la URL si el usuario no tiene el rol
                Response.Redirect("Login.aspx");
                Response.End(); // Detenemos la ejecución del código
                validacion = false;
            }
            return validacion;
        }

        protected void gdwVentas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Ver")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gdwVentas.Rows[index];
                string idPedido = row.Cells[4].Text;
                PedidoDB PedidoDB = new PedidoDB();
                List<ItemPedido> items = PedidoDB.listarItems(int.Parse(idPedido));
                dgvItems.DataSource = items;
                dgvItems.DataBind();
                dgvItems.Visible = true;
            }
        }

        protected void busquedaDia(string fecha)
        {
            //Se busca en el array de todas las ventas 
            List<Venta> result = list.FindAll(a => a.Fecha.Date.ToString("yyyy-MM-dd") == fecha);
            gdwVentas.DataSource= result;
            gdwVentas.DataBind();
            dgvItems.Visible = false;
            if (result.Count == 0)
            {
                info.Visible = true;
            }
            else
            {
                info.Visible = false;
            }
            return;
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            DateTime dateSelect = Calendar1.SelectedDate;
            busquedaDia(dateSelect.ToString("yyyy-MM-dd"));
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            dgvItems.Visible = false;
            gdwVentas.DataSource = list;
            gdwVentas.DataBind();
            info.Visible = false;
        }
    }
}