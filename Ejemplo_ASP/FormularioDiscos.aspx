<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="FormularioDiscos.aspx.cs" Inherits="Ejemplo_ASP.FormularioDiscos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="my-3">Formulario de Discos 🎸🎸🎸</h2>

    <div class="row">
        <div class=" col">
            <div class="mb-3">
                <label for="txtId" class="form-label">Id:</label>
                <asp:TextBox ID="txtId" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtTitulo" class="form-label">Título:</label>
                <asp:TextBox ID="txtTitulo" CssClass="form-control" runat="server"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label for="ddlEstilo" class="form-label">Estilo:</label>
                <asp:DropDownList ID="ddlEstilo" CssClass="form-select" runat="server"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <label for="ddlEdicion" class="form-label">Edición:</label>
                <asp:DropDownList ID="ddlEdicion" CssClass="form-select" runat="server"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <label for="txtCanciones" class="form-label">Cant. de canciones:</label>
                <asp:TextBox ID="txtCanciones" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtFecha" class="form-label">Fecha de lanzamiento:</label>
                <asp:TextBox ID="txtFecha" CssClass="form-control" TextMode="DateTime" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <asp:Button Text="Aceptar 💥" ID="btnAceptar" OnClick="btnAceptar_Click" CssClass="btn btn-success" runat="server" />
                <a href="Default.aspx" class="ms-2 text-decoration-none">Cancelar</a>
                <asp:Button OnClick="btnDesactivar_Click" Id="btnDesactivar" cssClass="btn btn-warning" Text="Desactivar" runat="server" />
            </div>
        </div>
        <div class="col">

            <asp:ScriptManager ID="scrManager" runat="server" />
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="mb-3">
                        <label for="txtImagen" class="form-label">Imagen Portada:</label>
                        <asp:TextBox ID="txtImagen" OnTextChanged="txtImagen_TextChanged" AutoPostBack="true" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <asp:Image ID="imgUrl" CssClass="mt-3 img-thumbnail" ImageUrl="https://media.istockphoto.com/id/1409329028/vector/no-picture-available-placeholder-thumbnail-icon-illustration-design.jpg?s=612x612&w=0&k=20&c=_zOuJu755g2eEUioiOUdz_mHKJQJn-tDgIAhQzyeKUQ=" Width="75%" runat="server" />

                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <div class="container">
        <div class="row ">
            <asp:UpdatePanel runat="server">
                <ContentTemplate>

                    <div class=" col-6 pb-3">
                        <asp:Button ID="btn_Eliminar" OnClick="btn_Eliminar_Click" CssClass="btn btn-danger" Text="Eliminar" runat="server" />
                        <%  if (chkConfirmacion)
                            {%>
                        <asp:CheckBox ID="chkConfirma" Text="Confirma eliminación" CssClass="ms-3" runat="server" />
                        <asp:Button ID="btn_ConfirmaEliminacion" OnClick="btn_ConfirmaEliminacion_Click" CssClass="btn btn-outline-danger" Text="Eliminar" runat="server" />
                        <% }%>
                    </div>

                </ContentTemplate>
            </asp:UpdatePanel>

        </div>
    </div>
</asp:Content>
