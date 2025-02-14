<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CartaPublico.aspx.cs" Inherits="Visual.CartaPublico" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="row">
            <div class="col d-flex justify-content-center flex-wrap">
                <%foreach (Dominio.Producto item in listaProductos)
                    { %>
                <div class="card" style="width: 18rem;">
                    <img src="<%: item.Imagen %>" class="card-img-top" />
                    <div class="card-body">
                        <h5 class="card-title"><%: item.Nombre %></h5>
                        <p class="card-text"><%: item.Precio %></p>
                    </div>
                </div>
                <% } %>
            </div>
        </div>
    </form>

</body>







</html>
