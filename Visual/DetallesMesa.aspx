<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="DetallesMesa.aspx.cs" Inherits="Visual.DetallesMesa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MasterSite" runat="server">
    <div class="container-fluid px-3 py-2">
        <asp:GridView runat="server" ID="dgvPedidos" CssClass="table table-striped table-dark w-100" AutoGenerateColumns="False" OnRowCommand="dgvPedidos_RowCommand">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Id" HeaderStyle-CssClass="visually-hidden" ItemStyle-CssClass="visually-hidden" />
                <asp:BoundField DataField="Producto.Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Producto.Precio" HeaderText="Precio" />
                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                <asp:BoundField DataField="Subtotal" HeaderText="Subtotal" />
                <asp:ButtonField Text="❌" CommandName="Accion" ControlStyle-ForeColor="Red" />
            </Columns>
        </asp:GridView>

        <div class="d-flex justify-content-center" id="contadorDiv" runat="server" visible="false">
            <div runat="server" id="CantidadPersonas" class="card bg-dark text-warning text-center p-3 w-100 w-md-50">
                <asp:Label ID="Label1" runat="server" CssClass="h5" Text="Numero de mesa"></asp:Label>
                <div>
                    <asp:Label ID="lblNumeroMesa" CssClass="form-label" runat="server" Text="Cantidad de personas:"></asp:Label>
                    <div class="d-flex justify-content-center align-items-center gap-2">
                        <asp:Button ID="btnMenos" onclick="btnMenos_Click" CssClass="btn btn-warning" runat="server" Text="-" />
                        <asp:Label ID="lblNumeroPersonas" runat="server" Text="1"></asp:Label>
                        <asp:Button ID="btnMas" OnClick="btnMas_Click" CssClass="btn btn-warning" runat="server" Text="+" />
                    </div>
                </div>
                <div class="mt-3">
                    <asp:Button ID="btnAbrirMesa" OnClick="btnAbrirMesa_Click" CssClass="btn btn-success" runat="server" Text="Abrir" />
                    <asp:Button ID="btnCancelarAbrir" CssClass="btn btn-danger" OnClick="btnCancelarAbrir_Click" runat="server" Text="Cancelar" />
                </div>
            </div>
        </div>

        <div id="alert" class="alert alert-danger text-center mt-3" role="alert" runat="server">
            Aun no hay ningun producto agregado...
        </div>

        <div class="text-center text-warning my-3" runat="server" id="contador2">
            <asp:Label ID="lblCantidad" runat="server" Text="Cantidad productos: "></asp:Label>
            <asp:Label ID="lblTotal" runat="server" Text="Total: "></asp:Label>
        </div>

        <div class="d-grid gap-2 col-12 col-md-3 mx-auto">
            <asp:Button ID="btnAgregarPedido" CssClass="btn btn-success" Text="Agregar" runat="server" OnClick="btnAgregarPedido_Click" />
        </div>

        <div id="CerrarMesa" class="d-grid gap-2 col-12 col-md-3 mx-auto mt-3" runat="server">
            <asp:Button ID="btnCerrarMesa" OnClick="btnCerrarMesa_Click" CssClass="btn btn-danger" runat="server" Text="Cerrar mesa" />
            <div id="Confirmar" class="text-center mt-3" runat="server" visible="false">
                <asp:Label ID="lblProducto" runat="server" Text=""></asp:Label>
                <asp:Label ID="lblConfirmar" runat="server" Text=""></asp:Label>
                <asp:TextBox ID="tbContraseña" type="password" class="form-control mt-2" placeholder="Ingrese su contraseña" runat="server" OnKeyPress="return disableEnterKey(event);"></asp:TextBox>
                <div class="mt-3">
                    <asp:Button ID="btnCancelar" CssClass="btn btn-warning m-2" OnClick="btnCancelar_Click" runat="server" Text="Cancelar" />
                    <asp:Button ID="btnAceptar" CssClass="btn btn-warning m-2" OnClick="btnAceptar_Click" runat="server" Text="Aceptar" />
                </div>
            </div>
            <div id="info" visible="false" class="alert alert-danger text-center mt-3" role="alert" runat="server">
            </div>
        </div>
    </div>
</asp:Content>
