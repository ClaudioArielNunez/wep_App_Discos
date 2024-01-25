<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Lista.aspx.cs" Inherits="Ejemplo_ASP.Lista" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="my-3">LISTA DE DISCOS</h2>
    <div class="row my-3">
        <div class="col-4">
            <asp:Label Text="Filtro por titulo:" runat="server" />
            <asp:TextBox OnTextChanged="txtFiltro_TextChanged" AutoPostBack="true" cssClass="form-control" ID="txtFiltro" runat="server" />
        </div>
    </div>
    <asp:GridView ID="dgvDiscos" DataKeyNames="Id" OnSelectedIndexChanged="dgvDiscos_SelectedIndexChanged" AutoGenerateColumns="false" cssClass="table" runat="server"
                  OnPageIndexChanging="dgvDiscos_PageIndexChanging" AllowPaging="true" PageSize="8"   >
        <Columns>
            <asp:BoundField HeaderText="Titulo" DataField="Titulo" />
            <asp:BoundField HeaderText="CantCanciones" DataField="CantCanciones" />
            <asp:BoundField HeaderText="Estilo" DataField="Estilo.Descripcion" />
            <asp:BoundField HeaderText="Tipo de Edicion" DataField="TipoEdicion.Descripcion" />
            <asp:BoundField HeaderText="Lanzamiento" DataField="FechaLanzamiento" />
            <asp:CheckBoxField HeaderText="Activo" DataField="Estado" />
            <asp:CommandField HeaderText="Acción" ShowSelectButton="true" SelectText="🎸"  />  
        </Columns>
    </asp:GridView>
</asp:Content>
