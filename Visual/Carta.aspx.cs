﻿using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Visual
{
    public partial class Carta : System.Web.UI.Page
    {
        List<Producto> productos = new List<Producto>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["cantidad"] = 1;
                CantidadProductos.Visible = false;
            }
            else
            {
                lblCantidad.Text = ViewState["cantidad"].ToString();
            }
            ProductosDB productosDB = new ProductosDB();
            productos = productosDB.listarProductos();
            cargarMenu();
        }
        protected void cargarMenu()
        {
            foreach (var item in productos)
            {
                Button btn = new Button
                {
                    Text = item.Nombre,
                    ID = "btn" + item.Id.ToString(),
                };
                if (Session["MesaSeleccionada"] != null)
                {
                    btn.Click += (sender, e) => Btn_click(sender, e, item.Id);
                }
                btn.CssClass = "btn btn-warning margen";
                carta.Controls.Add(btn);
            }
        }
        protected void Btn_click(object sender, EventArgs e, int productId)
        {
            CantidadProductos.Visible = true;
            ViewState["cantidad"] = 1;
            lblCantidad.Text = ViewState["cantidad"].ToString();
            Producto aux = productos.Find(a => a.Id == productId);
            lblProducto.Text = aux.Nombre;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            CantidadProductos.Visible=false;
            ViewState["cantidad"] = 1;
        }

        protected void btnMenos_Click(object sender, EventArgs e)
        {
            int cantidad = (int)ViewState["cantidad"];
            if (cantidad == 1)
            {
                return;
            }
            else
            {
                cantidad--;
                ViewState["cantidad"] = cantidad;
                lblCantidad.Text = cantidad.ToString();
            }
        }

        protected void btnMas_Click(object sender, EventArgs e)
        {
            int cantidad = (int)ViewState["cantidad"];
            cantidad++;
            ViewState["cantidad"] = cantidad;
            lblCantidad.Text = cantidad.ToString();
        }
    }
}