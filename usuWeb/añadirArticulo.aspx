<%@ Page Title="FrikiPop: Anyadir Articulo" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="añadirArticulo.aspx.cs" Inherits="usuWeb.añadirArticulo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="modAñadirArticulo">
            <asp:Label runat="server" for="nombre" Text="Nombre: "></asp:Label>
            <asp:TextBox runat="server" id="nombre" name="nombre" placeholder="Nombre" CssClass="cuadroDeTexto"/><br />
            <br>
            <asp:Label runat="server" for="descripcion" Text="Descripcion: "></asp:Label>
            <asp:TextBox runat="server" id="descripcion" name="descripcion" placeholder="Descripcion" CssClass="cuadroDeTexto"/><br />
            <br>
            <asp:Label runat="server" for="precio" Text="Precio: "></asp:Label>
            <asp:TextBox runat="server" id="precio" name="precio" placeholder="Precio" CssClass="cuadroDeTexto"/><br />
            <br>
            <asp:Label runat="server" for="url_imagen" Text="Url imagen: "></asp:Label>
            <asp:FileUpload ID="FileUpload1" runat="server" Width="437px" /><br />
            <br>
            <asp:Label runat="server" for="tipo" Text="Tipo: "></asp:Label>
            <asp:TextBox runat="server" id="tipo" name="tipo" placeholder="Tipo" CssClass="cuadroDeTexto"/><br />
            <br>
            <section ID="botonesAñadirArticulo">
                <asp:Button runat="server" ID="anyadir" type="submit" Text="Añadir articulo" OnClick="añadir_Click" CssClass="boton"></asp:Button>
            </section>
    </section>
</asp:Content>
