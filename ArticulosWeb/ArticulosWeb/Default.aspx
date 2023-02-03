<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ArticulosWeb.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Hola!</h1>
    <p>Llegaste a Electronics, tu lugar de compras...</p>


    <div class="row row-cols-1 row-cols-md-3 g-4">

    <!-- CARDS -->
       <asp:Repeater runat="server" id="repRepetidor">
            <ItemTemplate>
                <div class="col">
                <div class="card" style="width: 18rem;">
                    <div style="width: 18rem; height: 14rem;" >
                    <img src="<%#Eval("UrlImagen") %>" class="card-img-top" alt="Sin Imagen" style="object-fit:contain; width: 100%; height: 100%;">
                    </div>

                    <div class="card-body">
                        <h5 class="card-title"><%#Eval("Nombre") %></h5>
                        <p class="card-text"><%#Eval("Descripcion") %></p>
                        <a href="DetallePokemon.aspx?id=<%#Eval("Id") %>">Ver Detalle</a>
                    </div>
                </div>
            </div>
            </ItemTemplate>
        </asp:Repeater>

    </div>

</asp:Content>
