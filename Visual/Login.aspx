﻿<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Visual.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MasterSite" runat="server">
    <div class="row">
    </div>
    <div class="row mt-5">
        <div class="col-5"></div>
        <div class="col-2 bg-dark rounded-3 d-flex flex-column align-items-center">
            <div class="mb-3">
                <h5 class="d-flex justify-content-center mt-2 text-warning mt-3 mb-4">Iniciar Sesión</h5>
                <asp:Label for="usuario" class="form-label text-warning" runat="server">Usuario</asp:Label>
                <asp:TextBox type="" class="form-control" ID="tbUsuario" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <asp:Label for="password" class="form-label text-warning" runat="server">Contraseña</asp:Label>
                <asp:TextBox type="password" ID="tbPassword" class="form-control" runat="server"></asp:TextBox>
            </div>
            <asp:Button type="submit" ID="btnIngresar" class="btn btn-warning mb-2" OnClick="btnIngresar_Click" runat="server" Text="Ingresar"></asp:Button>
        <asp:Label ID="lblError" CssClass=" text-warning mb-3" runat="server" Text=""></asp:Label>
        </div>
        <div class="col-5"></div>
    </div>
</asp:Content>
