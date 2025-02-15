<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="InformesVentas.aspx.cs" Inherits="Visual.InformesVentas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .margin {
            margin: 15px;
        }

        .centrar {
            display: flex;
            justify-content: center;
            align-items: center;
        }

        .direction {
            flex-direction: column;
        }

        .titulo {
            padding-top: 10px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MasterSite" runat="server">
    <div class="centrar direction margin">
        <div class="centrar">
            <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged" BackColor="White"></asp:Calendar>
            <asp:GridView runat="server" ID="dgvItems" CssClass="table table-striped margin" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                    <asp:BoundField DataField="Producto.Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="Producto.Precio" HeaderText="Precio" />
                </Columns>
            </asp:GridView>
            <div id="infoItems" visible="false" class="alert alert-danger contenedor margin" role="alert" runat="server">
                Sin productos...
            </div>
        </div>
        <div class="margin">
            <asp:Button ID="btnLimpiar" CssClass="btn btn-warning margin" runat="server" Text="Limpiar filtro" OnClick="btnLimpiar_Click" />
        </div>
    </div>
    <div class="accordion accordion-flush margin" id="accordionFlushExample">
        <div class="accordion-item">
            <h2 class="centrar titulo">Ventas
            </h2>
            <div class="accordion-collapse ">
                <div class="accordion-body">
                    <asp:GridView ID="gdwVentas" CssClass="table table-striped" runat="server" AutoGenerateColumns="false" OnRowCommand="gdwVentas_RowCommand">
                        <Columns>
                            <asp:BoundField DataField="Id" HeaderText="Id" HeaderStyle-CssClass="visually-hidden" ItemStyle-CssClass="visually-hidden" />
                            <asp:BoundField DataField="Mesero.Nombre" HeaderText="Mesero" />
                            <asp:BoundField DataField="NumMesa" HeaderText="Mesa" />
                            <asp:BoundField DataField="Personas" HeaderText="Personas" />
                            <asp:BoundField DataField="IdPedido" HeaderText="Pedido" HeaderStyle-CssClass="visually-hidden" ItemStyle-CssClass="visually-hidden" />
                            <asp:BoundField DataField="TotalCuenta" HeaderText="Total" />
                            <asp:BoundField DataField="PlatillosConsumidos" HeaderText="Cantidad de platillos" />
                            <asp:BoundField DataField="Fecha" HeaderText="Fecha" DataFormatString="{0:yyyy-MM-dd}" />
                            <asp:ButtonField Text="🔍" CommandName="Ver" />
                        </Columns>
                    </asp:GridView>
                    <div id="info" visible="false" class="alert alert-danger contenedor" role="alert" runat="server">
                        Sin ventas...
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
