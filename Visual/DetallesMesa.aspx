<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="DetallesMesa.aspx.cs" Inherits="Visual.DetallesMesa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .contenedor2 {
            display: flex;
            flex-direction: column;
            align-items: center;
            color: #ffc107;
        }
        .Confirmar{
            display: flex;
            flex-direction: column;
            align-items: center;
            color: #ffc107;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MasterSite" runat="server">
    <div class="contenedor margen">
        <asp:GridView runat="server" ID="dgvPedidos" CssClass="table table-striped" AutoGenerateColumns="False" OnRowCommand="dgvPedidos_RowCommand">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Id" HeaderStyle-CssClass="visually-hidden" ItemStyle-CssClass="visually-hidden"/>
                <asp:BoundField DataField="Producto.Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Producto.Precio" HeaderText="Precio" />
                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                <asp:BoundField DataField="Subtotal" HeaderText="Subtotal" />
                <asp:ButtonField Text="Eliminar" CommandName="Accion" ControlStyle-ForeColor="Red"/>
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
    <div id="CerrarMesa" class="d-grid gap-2 col-6 mx-auto" runat="server">
        <asp:Button ID="btnCerrarMesa" OnClick="btnCerrarMesa_Click" CssClass="btn btn-warning m-2" runat="server" Text="Cerrar mesa" />
        <div id="Confirmar" class="Confirmar" runat="server" visible="false">
            <asp:Label ID="lblConfirmar" runat="server" Text="¿Seguro que quieres cerrar esta mesa?"></asp:Label>
            <asp:TextBox ID="tbContraseña" type="password" class="form-control" placeholder="Ingrese su contraseña" runat="server"></asp:TextBox>
            <div>
                <asp:Button ID="btnCancelar" CssClass="btn btn-warning m-2" OnClick="btnCancelar_Click" runat="server" Text="Cancelar" />
                <asp:Button ID="btnAceptar" CssClass="btn btn-warning m-2" OnClick="btnAceptar_Click" runat="server" Text="Aceptar" />
            </div>
        </div>
        <div id="incorrecta" visible="false" class="alert alert-danger contenedor" role="alert" runat="server">
            ¡Contraseña incorrecta!
        </div>
    </div>
</asp:Content>
