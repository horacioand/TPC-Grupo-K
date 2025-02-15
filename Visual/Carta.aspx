<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Carta.aspx.cs" Inherits="Visual.Carta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .cantidadProductos {
            display: flex;
            flex-direction: column;
            align-items: center;
            margin: 15px;
            width: 350px;
            justify-content: center;
            background: white;
            border-radius: 8px;
        }

        .divCentrar {
            display: flex;
            flex-direction: column;
            align-items: center;
        }

        .titulo {
            display: flex;
            justify-content: center;
            margin-top: 10px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MasterSite" runat="server">
    <div class="divCentrar">
        <div class="row mt-5 justify-content-md-center">
            <div class="accordion" id="accordionPanelsStayOpenExample">
                <div class="accordion-item">
                    <h2 class="titulo">Menu
                    </h2>
                    <div class="accordion-collapse collapse show">
                        <div class="accordion-body" id="Bebidas" runat="server">
                            <h4>Bebidas</h4>
                            <!-- Aqui se generan las bebidas -->
                        </div>
                        <div class="accordion-body" id="Comidas" runat="server">
                            <h4>Comidas</h4>
                            <!-- Aqui se generan las comidas -->
                        </div>
                        <div class="accordion-body" id="Postres" runat="server">
                            <h4>Postres</h4>
                            <!-- Aqui se generan los postres -->
                        </div>
                    </div>
                </div>
            </div>

            <!-- Seccion de agregar productos -->
        </div>
        <div runat="server" id="CantidadProductos" class="cantidadProductos">
            <asp:Label ID="Label1" runat="server" CssClass="h5 margen" Text="Cantidad"></asp:Label>
            <div>
                <asp:Label ID="lblProducto" CssClass="form-label" runat="server" Text="Producto"></asp:Label>
                <div>
                    <asp:Button ID="btnMenos" CssClass="btn btn-warning" runat="server" OnClick="btnMenos_Click" Text="-" />
                    <asp:Label ID="lblCantidad" runat="server" Text="1"></asp:Label>
                    <asp:Button ID="btnMas" CssClass="btn btn-warning" runat="server" OnClick="btnMas_Click" Text="+" />
                </div>
            </div>
            <div>
                <asp:Button ID="btnAgregar" CssClass="btn btn-warning margen" OnClick="btnAgregar_Click" runat="server" Text="Agregar" />
                <asp:Button ID="btnCancelar" CssClass="btn btn-warning margen" OnClick="btnCancelar_Click" runat="server" Text="Cancelar" />
            </div>
        </div>
        <div>
            <asp:Button ID="btnRegresar" CssClass="btn btn-warning margen" runat="server" OnClick="btnRegresar_Click" Visible="false" Text="Regresar" />
        </div>
        <div id="alert" class="alert alert-success margen" role="alert" runat="server">
            ¡Agregado correctamente!
        </div>
    </div>
</asp:Content>
