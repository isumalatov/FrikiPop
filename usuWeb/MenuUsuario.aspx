<%@ Page Title="FrikiPop: Usuario" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="MenuUsuario.aspx.cs" Inherits="usuWeb.MenuUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="..\App_Style\adminStyle.css" />
    <section id="admin">
        <div>
            <h1>
                Menu del Usuario
            </h1>

            <section id="opcionesUsuario">
                <asp:Button runat="server" ID="modificarUsuario" CssClass="boton" Text="Modificar Datos" OnClick="modificarUsuario_Click" /><br /><br />
                <asp:Button runat="server" ID="carritoUsuario" CssClass="boton" Text="Ver Carrito" PostBackUrl="~/Carrito.aspx"/><br /><br />
                <asp:Button runat="server" ID="pedidosUsuario" CssClass="boton" Text="Ver Pedidos" PostBackUrl="~/VerPedido.aspx" /><br /><br />
                <asp:Button runat="server" ID="anyadirArticuloUsuario" CssClass="boton" Text="Añadir Articulo" PostBackUrl="~/añadirArticulo.aspx" /><br /><br />
            </section>
        </div>
    </section>
</asp:Content>
