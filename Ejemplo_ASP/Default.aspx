<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Ejemplo_ASP.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="my-3">WEB DISCOGRAFICA</h2>
    <h3 class="mb-3">Lista de Portadas (c/ciclo Foreach)</h3>
   
    <div class="row row-cols-2 row-cols-md-4 g-4">
        <%foreach (var item in ListaDiscos)
            {%>
                <div class="col">
                    <div class="card">
                        <img src="<%:item.UrlImagen %>" class="card-img-top" alt="<%: item.Titulo %>">
                        <div class="card-body">
                            <h5 class="card-title"><%:item.Titulo %></h5>
                            <p class="card-text"><%:item.Estilo %></p>
                            <asp:Button Text="Aceptar" ID="btnAceptar" CssClass="btn btn-primary" runat="server" />
                            <a href="DetalleDisco.aspx" class="ms-3">Ver detalle</a>
                        </div>
                    </div>
                </div>
        <% } %>
    </div>
</asp:Content>
