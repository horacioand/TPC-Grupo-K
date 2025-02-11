<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="DetallesMesa.aspx.cs" Inherits="Visual.DetallesMesa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .contenedor2 {
            display: flex;
            flex-direction: column;
            align-items: center;
            color: #ffc107;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MasterSite" runat="server">
    <div class="contenedor margen">
        <asp:GridView runat="server" ID="dgvPedidos" CssClass="table table-striped" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="Producto.Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Producto.Precio" HeaderText="Precio" />
                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                <asp:BoundField DataField="Subtotal" HeaderText="Subtotal" />
            </Columns>
        </asp:GridView>
        <div id="alert" class="alert alert-danger contenedor" role="alert" runat="server">
            Aun no hay ningun producto agregado...
        </div>
    </div>
    <div class="contenedor2">
        <asp:Label ID="lblCantidad" runat="server" Text="Cantidad productos: "></asp:Label>
        <asp:Label ID="lblTotal" runat="server" Text="Total: "></asp:Label>
    </div>
    <div class="d-grid gap-2 col-6 mx-auto">
        <asp:Button ID="btnAgregarPedido" CssClass="btn btn-warning m-2" Text="Agregar" runat="server" OnClick="btnAgregarPedido_Click" />
    </div>
</asp:Content>
