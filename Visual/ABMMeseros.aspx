<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="ABMMeseros.aspx.cs" Inherits="Visual.ABMMeseros" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MasterSite" runat="server">
    <div class="row m-3">
        <div class="col-2"></div>
        <div class="col-3 bg-dark rounded-3" id="div1" runat="server">
            <div class="mb-1 d-flex justify-content-center">
                <h5 class="text-warning mt-2">Modificar Mesero</h5>
            </div>
            <div class="mb-3 d-flex flex-column justify-content-center">
                <label for="ddlRol" class="form-label text-warning m-1">Mesero:</label>
                <asp:DropDownList ID="ddlMeseros" runat="server" class="form-control" CssClass="btn btn-warning dropdown w-100"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <label for="txtNombre" class="form-label text-warning" >Nombre</label>
                <asp:TextBox ID="txtNombreMesero" runat="server" class="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtUsuario" class="form-label text-warning">Usuario</label>
                <asp:TextBox ID="txtUsuarioMesero" runat="server" class="form-control" ></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtContrasena" class="form-label text-warning">Contraseña</label>
                <asp:TextBox ID="txtContrasenaMesero" type="password" runat="server" class="form-control"></asp:TextBox>
            </div>
            <div class="mb-3 d-flex flex-column justify-content-center">
                <label for="ddlRol" class="form-label text-warning m-1">Rol</label>
                <asp:DropDownList ID="ddlRolMesero" runat="server" class="form-control" CssClass="btn btn-warning dropdown w-100"></asp:DropDownList>
            </div>
            <div class="mb-3 d-flex justify-content-center">
                <asp:Button ID="btnEliminarMesero" runat="server" class="form-control" Text="Eliminar" CssClass="btn btn-danger m-1" OnClick="btnCancelarUsuario_Click"></asp:Button>
                <asp:Button ID="btnModificarMesero" runat="server" class="form-control" Text="Modificar" CssClass="btn btn-warning m-1" OnClick="btnCrearUsuario_Click"></asp:Button>
            </div>
        </div>

        <!--Mostrar div para agregar mesero-->
        <div class="col-2 d-flex justify-content-center">
            <div><asp:Button ID="btnMostrarNuevoMesero" runat="server" Text="Nuevo Mesero >" CssClass="btn btn-warning" OnClick="btnMostrarNuevoMesero_Click" /></div>
        </div>


        <div class="col-3 bg-dark rounded-3" id="divAgregarMesero" runat="server" visible="false">
            <div class="mb-1 d-flex justify-content-center">
                <h5 class="text-warning mt-2">Nuevo Mesero</h5>
            </div>
            <div class="mb-3">
                <label for="txtNombre" class="form-label text-warning">Nombre</label>
                <asp:TextBox ID="txtNombre" runat="server" class="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtUsuario" class="form-label text-warning">Usuario</label>
                <asp:TextBox ID="txtUsuario" runat="server" class="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtContrasena" class="form-label text-warning">Contraseña</label>
                <asp:TextBox ID="txtContrasena" type="password" runat="server" class="form-control"></asp:TextBox>
            </div>
            <div class="mb-3 d-flex flex-column justify-content-center">
                <label for="ddlRol" class="form-label text-warning m-1">Rol</label>
                <asp:DropDownList ID="ddlRol" runat="server" class="form-control" CssClass="btn btn-warning dropdown w-100"></asp:DropDownList>
            </div>
            <div class="mb-3 d-flex justify-content-center">
                <asp:Button ID="btnCancelarUsuario" runat="server" class="form-control" Text="Cancelar" CssClass="btn btn-secondary m-1" OnClick="btnCancelarUsuario_Click"></asp:Button>
                <asp:Button ID="btnCrearUsuario" runat="server" class="form-control" Text="Crear" CssClass="btn btn-warning m-1" OnClick="btnCrearUsuario_Click"></asp:Button>
            </div>
        </div>
        <div class="col-2 "></div>
    </div>
</asp:Content>
