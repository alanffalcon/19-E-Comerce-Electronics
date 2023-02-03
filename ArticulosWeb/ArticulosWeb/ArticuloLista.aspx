<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="ArticuloLista.aspx.cs" Inherits="ArticulosWeb.ArticuloLista" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Lista Articulos</h1>

    <!-- FILTRO: -->
    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <asp:Label Text="Filtrar" runat="server" />
                <asp:TextBox runat="server" ID="txtFiltro" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtFiltro_TextChanged" />
            </div>
        </div>
        <div class="col-6" style="display: flex; flex-direction: column; justify-content: flex-end;">
            <div class="mb-3">
                <asp:CheckBox Text=" Filtro Avanzado" 
                    CssClass="" ID="chkAvanzado" runat="server" 
                    AutoPostBack="true"
                    OnCheckedChanged="chkAvanzado_CheckedChanged"/>
            </div>
        </div>

        <!-- FILTRO AVANZADO: -->
        <%if (chkAvanzado.Checked)
            { %>
        <div class="row">
            <div class="col-3">
                <div class="mb-3">
                    <asp:Label Text="Campo" ID="lblCampo" runat="server" />
                    <asp:DropDownList runat="server" AutoPostBack="true" CssClass="form-control" id="ddlCampo" OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged">
                        <asp:ListItem Text="Codigo" />
                        <asp:ListItem Text="Nombre" />
                        <asp:ListItem Text="Precio" />
                    </asp:DropDownList>
                </div>
            </div>
            <div class="col-3">
                <div class="mb-3">
                    <asp:Label Text="Criterio" runat="server" />
                    <asp:DropDownList runat="server" ID="ddlCriterio" CssClass="form-control"></asp:DropDownList>
                </div>
            </div>
            <div class="col-3">
                <div class="mb-3">
                    <asp:Label Text="Filtro" runat="server" />
                    <asp:TextBox runat="server" ID="txtFiltroAvanzado" CssClass="form-control" />
                </div>
            </div>
            <div class="col-3">
                <div class="mb-3">
                    <asp:Label Text="Estado" runat="server" />
                    <asp:DropDownList runat="server" ID="ddlEstado" CssClass="form-control">
                        <asp:ListItem Text="Todos" />
                        <asp:ListItem Text="Activo" />
                        <asp:ListItem Text="Inactivo" />
                    </asp:DropDownList>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-3">
                <div class="mb-3">
                    <asp:Button Text="Buscar" runat="server" CssClass="btn btn-primary" id="btnBuscar" OnClick="btnBuscar_Click"/>
                </div>
            </div>
        </div>
        <%} %>
    </div>



    <!-- LISTA: -->
    <asp:GridView ID="dgvArticulos" runat="server" DataKeyNames="Id"
        CssClass="table" AutoGenerateColumns="false"
        OnSelectedIndexChanged="dgvArticulos_SelectedIndexChanged"
        OnPageIndexChanging="dgvArticulos_PageIndexChanging"
        AllowPaging="True" PageSize="5">
        <Columns>
            <asp:BoundField HeaderText="Codigo" DataField="CodigoArticulo" />
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:BoundField HeaderText="Precio" DataField="Precio" />
            <asp:BoundField HeaderText="Categoria" DataField="Categoria" />
            <asp:CommandField HeaderText="Acción" ShowSelectButton="true" SelectText="✍" />
        </Columns>
    </asp:GridView>

    <!-- AGREGAR: -->
    <a href="FormularioArticulo.aspx" class="btn btn-primary">Agregar</a>

</asp:Content>
