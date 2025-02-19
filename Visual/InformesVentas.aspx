<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="InformesVentas.aspx.cs" Inherits="Visual.InformesVentas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        Estilos del calendario
        .calendar {
        }

        .calendar th {
            background-color: #ffc107;
            padding: 10px;
        }

        .calendar td {
            padding: 8px;
            color: black;
            font-weight: 600;
        }

        .calendar a {
            display: block;
            text-decoration: none;
            color: #FFC107;
            !important;
            font-weight: bold;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MasterSite" runat="server">
    <div class="row m-2 ">
        <div class="col d-flex justify-content-center">
            <h3 class="text-dark">Ventas</h3>
        </div>
    </div>
    <div class="row m-1">

        <div class="col d-flex justify-content-center">
            <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged" BackColor="White" DayStyle-CssClass="bg-dark" TodayDayStyle-CssClass=" bg-warning" CssClass="calendar"></asp:Calendar>
        </div>
    </div>
    <div class="m-1 d-flex justify-content-center">
        <asp:Button ID="btnLimpiar" CssClass="btn btn-warning m-1" runat="server" Text="Limpiar filtro" OnClick="btnLimpiar_Click" />
    </div>
    <div class="row d-flex justify-content-center">
        <div class="col-1 d-flex justify-content-center">
            <div id="info" visible="false" class="alert alert-danger" role="alert" runat="server">
                Sin ventas...
            </div>
        </div>
    </div>
    <div class="row d-flex justify-content-center">
        <div class="col-8">
            <asp:GridView ID="gdwVentas" CssClass="table table-dark text-bg-warning" runat="server" AutoGenerateColumns="false" OnRowCommand="gdwVentas_RowCommand">
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
        </div>
    </div>
    <div class="row d-flex justify-content-center">
        <div class="col-8">
            <asp:GridView runat="server" ID="dgvItems" CssClass="table table-dark text-bg-warning" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                    <asp:BoundField DataField="Producto.Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="Producto.Precio" HeaderText="Precio" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
    <div class="row d-flex justify-content-center">
        <div class="col-1 d-flex justify-content-center">
            <div id="infoItems" visible="false" class="alert alert-danger" role="alert" runat="server">
                Sin productos
            </div>
        </div>
    </div>


</asp:Content>
