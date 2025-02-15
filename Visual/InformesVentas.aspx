<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="InformesVentas.aspx.cs" Inherits="Visual.InformesVentas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .margin{
            margin: 25px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MasterSite" runat="server">
    <div class="accordion accordion-flush margin" id="accordionFlushExample">
        <div class="accordion-item">
            <h2 class="accordion-header">
                <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#flush-collapseOne" aria-expanded="false" aria-controls="flush-collapseOne">
                    Ventas
                </button>
            </h2>
            <div id="flush-collapseOne" class="accordion-collapse collapse" data-bs-parent="#accordionFlushExample" >
                <div class="accordion-body">
                    <asp:GridView ID="gdwVentas" CssClass="table table-striped" runat="server" AutoGenerateColumns="false" OnRowCommand="gdwVentas_RowCommand">
                        <Columns>
                            <asp:BoundField DataField="Id" HeaderText="Id" HeaderStyle-CssClass="visually-hidden" ItemStyle-CssClass="visually-hidden" />
                            <asp:BoundField DataField="Mesero.Nombre" HeaderText="Mesero"/>
                            <asp:BoundField DataField="NumMesa" HeaderText="Mesa"/>
                            <asp:BoundField DataField="Personas" HeaderText="Personas"/>
                            <asp:BoundField DataField="IdPedido" HeaderText="Pedido" HeaderStyle-CssClass="visually-hidden" ItemStyle-CssClass="visually-hidden"/>
                            <asp:BoundField DataField="TotalCuenta" HeaderText="Total"/>
                            <asp:BoundField DataField="PlatillosConsumidos" HeaderText="Cantidad de platillos"/>
                            <asp:BoundField DataField="Fecha" HeaderText="Fecha" DataFormatString="{0:yyyy-MM-dd}"/>
                            <asp:ButtonField Text="🔍" CommandName="Ver"/>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
