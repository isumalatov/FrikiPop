<%@ Page Title="FrikiPop: Articulo" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="verArticulo.aspx.cs" Inherits="usuWeb.verArticulo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="..\App_Style\verArticulosStyle.css" />
        <section class="modVerArticulo">
                <br />
                <div class="imagenArticulo">
                    <asp:Image ID="url_imagen" runat="server" CssClass="laImagen" />
                </div>
                <h1>
                    <asp:Label ID="nombre" runat="server">
                    </asp:Label>
                </h1>
                <h3>
                    Precio del producto:
                </h3>
                <p>
                    <asp:Label ID="precio" runat="server"></asp:Label>
                </p>
                <h3>
                    Descripción del producto:
                </h3>
                <p>
                    <asp:Label ID="descripcion" runat="server"></asp:Label>
                </p>
                <p class="botonesArticulo">     
                    <asp:Button ID="añadirCesta" runat="server" Text="Añadir al carrito" OnClick="añadirCestaClick" CssClass="boton">
                    </asp:Button>
                    <asp:Label ID="outputMessageAñadir" runat="server"></asp:Label>
                </p>
                <p class="botonesArticulo">     
                    <asp:Button ID="comprarAhora" runat="server" Text="Comprar ahora" OnClick="comprarAhoraClick" CssClass="boton">
                    </asp:Button>
                    <asp:Label ID="outputMessageComprar" runat="server"></asp:Label>
                </p>
    </section>
</asp:Content>
