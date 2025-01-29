<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Visual.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .sin-bordes-externos{
            border:none !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MasterSite" runat="server">
    <div class="row">
        <div class="col"></div>
        <div class="col-sm-10 col-lg-5">
            <h2>Lista de Mesas</h2>
            <asp:GridView runat="server" ID="dgvMesas" DataKeyNames="Id" AutoGenerateColumns="false" OnSelectedIndexChanged="dgvMesas_SelectedIndexChanged" CssClass="table table-borderless sin-bordes-externos table-striped text-center table-sm">
                <Columns>
                    <asp:BoundField DataField="Numero" HeaderText="Numero" />
                    <asp:CommandField SelectText="Ver" ControlStyle-CssClass=" btn btn-primary btn-lg form-control" HeaderText="Mesa" runat="server" ShowSelectButton="true"></asp:CommandField>
                </Columns>
            </asp:GridView>
        </div>
        <div class="col"></div>

    </div>



</asp:Content>
