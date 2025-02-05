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
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MasterSite" runat="server">
    <div class="divCentrar">
        <div class="row mt-5 justify-content-md-center">
            <div class="accordion col-8" id="accordionPanelsStayOpenExample">
                <div class="accordion-item">
                    <h2 class="accordion-header">
                        <button class="accordion-button" type="button" data-bs-toggle="collapse" data-bs-target="#panelsStayOpen-collapseOne" aria-expanded="true" aria-controls="panelsStayOpen-collapseOne">
                            Menu
                        </button>
                    </h2>
                    <div id="panelsStayOpen-collapseOne" class="accordion-collapse collapse show">
                        <div class="accordion-body" id="carta" runat="server">
                            <!-- Aqui iran los alimentos de la carta, la idea es generar los botones dinamicamente en base a la lectura de la db -->
                        </div>
                    </div>
                </div>
            </div>
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
                <asp:Button ID="btnAgregar" CssClass="btn btn-warning margen" runat="server" Text="Agregar" />
                <asp:Button ID="btnCancelar" CssClass="btn btn-warning margen" OnClick="btnCancelar_Click" runat="server" Text="Cancelar" />
            </div>
        </div>
    </div>
</asp:Content>
