﻿<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="InformesVentas.aspx.cs" Inherits="Visual.InformesVentas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .margin {
            margin: 15px;
        }
        .centrar{
            display:flex;
            justify-content:center;
            align-items:center;
        }
        .titulo{
            padding-top:10px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MasterSite" runat="server">
    <div class="centrar margin">
        <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged" BackColor="White"></asp:Calendar>
        <div class="margin">
            <asp:Button ID="Button2" CssClass="btn btn-warning margin" runat="server" Text="Limpiar filtro" />
        </div>
    </div>
    <div class="accordion accordion-flush margin" id="accordionFlushExample">
        <div class="accordion-item">
            <h2 class="centrar titulo">
                Ventas
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
                </div>
            </div>
        </div>
    </div>
</asp:Content>
