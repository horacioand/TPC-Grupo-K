<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Visual.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .sin-bordes-externos {
            border: none !important;
        }

        .margen {
            margin: 10px;
            color: white;
        }

        .cantidadPersonas {
            display: flex;
            flex-direction: column;
            align-items: center;
            margin: 15px;
            width: 350px;
            color: #ffc107;
            justify-content: center;
            background-color: #212529;
            border-radius: 8px;
            border: 1px solid white;
        }

        .centrar{
            display: flex;
            justify-content:center;
        }

        .contador {
            display: flex;
            flex-direction: column;
            align-items: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MasterSite" runat="server">
    <div class="row row-cols-sm-1 row-cols-md-3 g-4 justify-content-center">
        <% foreach (Dominio.Mesa mesa in ListaMesas)
            { %>
        <div class="col d-flex justify-content-center">
            <div class="card m-3" style="width: 18rem;">
                <div class="rounded card-body text-center bg-dark">
                    <h5 class="card-title text-warning">Mesa <%: mesa.Numero %></h5>
                    <p class="card-text text-warning">Capacidad: <%: mesa.Capacidad %></p>
                    <p class="card-text text-warning">
                        <% if (mesa.IdPedido != 0)
                            {%>
                            Id de Pedido: <%: mesa.IdPedido.ToString() %>
                        <% }%>
                    </p>
                    <%if (mesa.Estado)
                        {%>
                    <a href="DetallesMesa.aspx?id=<%:mesa.Id %>" class="btn btn-warning">Ver detalles </a>
                    <%}
                        else
                        {%>
                    <a href="DetallesMesa.aspx?id=<%:mesa.Id %>" class="btn btn-warning">Abrir pedido </a>
                    <%} %>
                </div>
            </div>
        </div>
        <% } %>
    </div>
    <div class="centrar">
        <div runat="server" id="CantidadPersonas" class="cantidadPersonas">
            <asp:Label ID="Label1" runat="server" CssClass="h5 margen" Text="Numero de mesa"></asp:Label>
            <div class="contador">
                <asp:Label ID="lblNumeroMesa" CssClass="form-label" runat="server" Text="Cantidad de personas:"></asp:Label>
                <div>
                    <asp:Button ID="btnMenos" CssClass="btn btn-warning" runat="server" Text="-" />
                    <asp:Label ID="lblCantidad" runat="server" Text="1"></asp:Label>
                    <asp:Button ID="btnMas" CssClass="btn btn-warning" runat="server" Text="+" />
                </div>
            </div>
            <div>
                <asp:Button ID="btnAgregar" CssClass="btn btn-warning margen" runat="server" Text="Abrir" />
                <asp:Button ID="btnCancelar" CssClass="btn btn-warning margen" runat="server" Text="Cancelar" />
            </div>
        </div>
    </div>
    <div class="d-grid gap-2 col-6 mx-auto">
        <asp:Button ID="btnCerrarSesion" CssClass="btn btn-warning m-2" Text="Cerrar sesion" runat="server" OnClick="btnCerrarSesion_Click" />
    </div>
</asp:Content>
