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
    public partial class AsignacionMesas : System.Web.UI.Page
    {
        public List<Mesa> ListaMesas { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidarRol();
            listarMesas();
            if (!IsPostBack)
            {
                //evitamos que los datos se reinicien 
                cargarMesas();
                cargarMeseros();
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

        protected void listarMesas()
        {
            //Traemos la lista de mesas
            MesaDB mesaDB = new MesaDB();
            ListaMesas = mesaDB.listar();
        }

        protected void cargarMesas()
        {
            //carga las mesas en el drop down list
            ddlMesas.DataSource = ListaMesas;
            ddlMesas.DataTextField = "Numero";
            ddlMesas.DataValueField = "Numero";
            ddlMesas.DataBind();
        }

        protected void cargarMeseros()
        {
            //carga los meseros en el drop down list
            ddlMeseros.DataSource = Session["listaUsuarios"];
            ddlMeseros.DataTextField= "Nombre";
            ddlMeseros.DataValueField = "Id";
            ddlMeseros.DataBind();
        }

        protected void btnAsignar_Click(object sender, EventArgs e)
        {
            //Guardamos los valores seleccionados de los drop down list
            int numeroMesa = int.Parse(ddlMesas.SelectedValue);
            int idMesero = int.Parse(ddlMeseros.SelectedValue);
            //Lo mandamos a la base de datos 
            MesaDB mesaDB = new MesaDB();
            mesaDB.asignarMesa(numeroMesa, idMesero);
            //Recargamos la lista de mesas para ver los cambios 
            listarMesas();
        }
    }
}