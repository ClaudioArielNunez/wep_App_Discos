<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="DetalleDisco.aspx.cs" Inherits="Ejemplo_ASP.DetalleDisco" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="my-3">Página de Detalle </h2>
    <div class="row">
        <div class="col-5">

            <div class="mb-3">
                <label class="form-label">Nombre</label>
                <asp:TextBox ID="txtTitulo" CssClass="form-control" runat="server" />
            </div>
            <div class="mb-3">
                <label class="form-label">Número de Canciones:</label>
                <asp:TextBox ID="txtCanciones" CssClass="form-control" runat="server" />
            </div>
            <div class="mb-3">
                <label for="ddlEstilo" class="form-label">Estilo:</label>
                <asp:TextBox ID="txtEstilo" CssClass="form-control" runat="server" />
            </div>
            <div class="mb-3">
                <label for="ddlEdicion" class="form-label">Edición:</label>
                <asp:TextBox ID="txtEdicion" CssClass="form-control" runat="server" />
            </div>
            <div class="mb-3">
                <label for="txtFecha" class="form-label">Fecha de lanzamiento:</label>
                <asp:TextBox ID="txtFecha" CssClass="form-control" TextMode="DateTime" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="col-5">
            <div class="mb-3">
                <div>
                    <label for="txtImagen" class="form-label">Imagen Portada:</label>                   
                </div>
                <asp:Image ID="imgUrl" CssClass="mt-3 img-thumbnail" ImageUrl="https://media.istockphoto.com/id/1409329028/vector/no-picture-available-placeholder-thumbnail-icon-illustration-design.jpg?s=612x612&w=0&k=20&c=_zOuJu755g2eEUioiOUdz_mHKJQJn-tDgIAhQzyeKUQ=" Width="75%" runat="server" />
            </div>
        </div>
    </div>

</asp:Content>
