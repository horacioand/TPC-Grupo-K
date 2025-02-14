using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
namespace Visual
{
    public partial class CartaPublico : System.Web.UI.Page
    {
        public List<Producto> listaProductos;
        protected void Page_Load(object sender, EventArgs e)
        {
            ProductosDB productosDB = new ProductosDB();
             listaProductos = productosDB.listarProductos();
        }
    }
}