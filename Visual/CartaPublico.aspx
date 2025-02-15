<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CartaPublico.aspx.cs" Inherits="Visual.CartaPublico" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous" />
    <title></title>
</head>
<body class="bg-secondary">
    <form id="form1" runat="server">
        <div class="row bg-dark mb-3">
            <div class="col-3">
                <a href="Default.aspx" class=" text-decoration-none" id="linkVovler" visible="false" runat="server"><h3 class="text-warning"><<</h3></a>
            </div>
            <div class="col d-flex justify-content-center">
                
                <h1 class="text-warning">Carta</h1>
            </div>
            <div class="col-3"></div>
        </div>
        <div class="row">
            <div class="col d-flex justify-content-center flex-wrap">
                <h4 class="mb-0">Bebidas</h4>
                <div class="row flex-wrap m-4 justify-content-evenly">
                    <%foreach (Dominio.Producto item in bebidas)
                        { %>
                    <div class="card m-1 bg-dark" style="width: 18rem;">
                        <img src="<%: item.Imagen %>" class="card-img-top" />
                        <div class="card-body">
                            <h5 class="card-title text-warning"><%: item.Nombre %></h5>
                            <p class="card-text text-warning"><%: item.Precio %></p>
                        </div>
                    </div>
                    <% } %>
                </div>
                <h4 class="mb-0">Comidas</h4>
                <div class="row flex-wrap m-4 justify-content-evenly">
                    <%foreach (Dominio.Producto item in comidas)
                        { %>
                    <div class="card m-1 bg-dark" style="width: 18rem;">
                        <img src="<%: item.Imagen %>" class="card-img-top" />
                        <div class="card-body">
                            <h5 class="card-title text-warning"><%: item.Nombre %></h5>
                            <p class="card-text text-warning"><%: item.Precio %></p>
                        </div>
                    </div>
                    <% } %>
                </div>
                <h4 class="mb-0">Postres</h4>
                <div class="row flex-wrap m-4 justify-content-evenly">
                    <%foreach (Dominio.Producto item in postres)
                        { %>
                    <div class="card m-1 bg-dark" style="width: 18rem;">
                        <img src="<%: item.Imagen %>" class="card-img-top" />
                        <div class="card-body">
                            <h5 class="card-title text-warning"><%: item.Nombre %></h5>
                            <p class="card-text text-warning"><%: item.Precio %></p>
                        </div>
                    </div>
                    <% } %>
                </div>

            </div>
        </div>
    </form>

</body>







</html>
