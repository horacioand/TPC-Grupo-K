<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="DetallesMesa.aspx.cs" Inherits="Visual.DetallesMesa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .contenedor2 {
            display: flex;
            flex-direction: column;
            align-items: center;
            color: #ffc107;
        }

        .Confirmar {
            display: flex;
            flex-direction: column;
            align-items: center;
            color: #ffc107;
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

        .centrar {
            display: flex;
            justify-content: center;
        }

        .contador {
            display: flex;
            flex-direction: column;
            align-items: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MasterSite" runat="server">
    <div class="contenedor margen">
        <asp:GridView runat="server" ID="dgvPedidos" CssClass="table table-striped" AutoGenerateColumns="False" OnRowCommand="dgvPedidos_RowCommand">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Id" HeaderStyle-CssClass="visually-hidden" ItemStyle-CssClass="visually-hidden" />
                <asp:BoundField DataField="Producto.Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Producto.Precio" HeaderText="Precio" />
                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                <asp:BoundField DataField="Subtotal" HeaderText="Subtotal" />
                <asp:ButtonField Text="❌" CommandName="Accion" ControlStyle-ForeColor="Red" />
            </Columns>
        </asp:GridView>
        <div class="centrar" id="contadorDiv" runat="server" visible="false">
            <div runat="server" id="CantidadPersonas" class="cantidadPersonas">
                <asp:Label ID="Label1" runat="server" CssClass="h5 margen" Text="Numero de mesa"></asp:Label>
                <div class="contador">
                    <asp:Label ID="lblNumeroMesa" CssClass="form-label" runat="server" Text="Cantidad de personas:"></asp:Label>
                    <div>
                        <asp:Button ID="btnMenos" CssClass="btn btn-warning" runat="server" Text="-" />
                        <asp:Label ID="Label2" runat="server" Text="1"></asp:Label>
                        <asp:Button ID="btnMas" CssClass="btn btn-warning" runat="server" Text="+" />
                    </div>
                </div>
                <div>
                    <asp:Button ID="btnAgregar" CssClass="btn btn-warning margen" runat="server" Text="Abrir" />
                    <asp:Button ID="Button1" CssClass="btn btn-warning margen" OnClick="btnCancelar_Click" runat="server" Text="Cancelar" />
                </div>
            </div>
        </div>
        <div id="alert" class="alert alert-danger contenedor" role="alert" runat="server">
            Aun no hay ningun producto agregado...
        </div>
    </div>
    <div class="contenedor2" runat="server" id="contador2">
        <asp:Label ID="lblCantidad" runat="server" Text="Cantidad productos: "></asp:Label>
        <asp:Label ID="lblTotal" runat="server" Text="Total: "></asp:Label>
    </div>
    <div class="d-grid gap-2 col-6 mx-auto">
        <asp:Button ID="btnAgregarPedido" CssClass="btn btn-warning m-2" Text="Agregar" runat="server" OnClick="btnAgregarPedido_Click" />
    </div>
    <div id="CerrarMesa" class="d-grid gap-2 col-6 mx-auto" runat="server">
        <asp:Button ID="btnCerrarMesa" OnClick="btnCerrarMesa_Click" CssClass="btn btn-warning m-2" runat="server" Text="Cerrar mesa" />
        <div id="Confirmar" class="Confirmar" runat="server" visible="false">
            <asp:Label ID="lblProducto" runat="server" Text=""></asp:Label>
            <asp:Label ID="lblConfirmar" runat="server" Text=""></asp:Label>
            <asp:TextBox ID="tbContraseña" type="password" class="form-control" placeholder="Ingrese su contraseña" runat="server" OnKeyPress="return disableEnterKey(event);"></asp:TextBox>
            <div>
                <asp:Button ID="btnCancelar" CssClass="btn btn-warning m-2" OnClick="btnCancelar_Click" runat="server" Text="Cancelar" />
                <asp:Button ID="btnAceptar" CssClass="btn btn-warning m-2" OnClick="btnAceptar_Click" runat="server" Text="Aceptar" />
            </div>
        </div>
        <div id="info" visible="false" class="alert alert-danger contenedor" role="alert" runat="server">
        </div>
    </div>
    <!-- Se agrego debido a que al dar enter sobre el text box redidirigia a otra pagina
         Elimina el evento al presionar la tecla enter-->
    <script type="text/javascript">
        function disableEnterKey(e) {
            var key;
            if (window.event) {
                key = window.event.keyCode; //IE
            } else {
                key = e.which; //Firefox
            }
            if (key == 13) {
                return false; //Desactivar Enter
            } else {
                return true;
            }
        }
    </script>
</asp:Content>
