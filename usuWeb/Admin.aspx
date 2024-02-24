<%@ Page Title="FrikiPop: Admin" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="usuWeb.Admin" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="..\App_Style\adminStyle.css" />
    <section id="admin">
        <div>
            <h1>
                Menu del Administrador
            </h1>
            <h2>
                "Un gran poder conlleva una gran responsabilidad"
            </h2>

            <section id="opcionesAdmin">
                <asp:Button runat="server" ID="usuariosAdmin" CssClass="boton" Text="Gestion de Usuarios" PostBackUrl="~/VerUsuarios.aspx"/><br /><br />
                <asp:Button runat="server" ID="tarjetasAdmin" CssClass="boton" Text="Gestion de Tarjetas" PostBackUrl="~/Tarjetas.aspx" /><br /><br />
                <asp:Button runat="server" ID="articulosAdmin" CssClass="boton" Text="Gestion de Articulos" PostBackUrl="~/Articulos.aspx"/><br /><br />
                <asp:Button runat="server" ID="estadisticasAdmin" CssClass="boton" Text="Ver Estadisticas" PostBackUrl="~/Estadisticas.aspx" /><br /><br />
                <asp:Button runat="server" ID="ubicacionesAdmin" CssClass="boton" Text="Gestion de Ubicaciones" PostBackUrl="~/Paises.aspx" /><br /><br />
                <asp:Button runat="server" ID="redesSocialesAdmin" CssClass="boton" Text="Gestion de Redes Sociales" PostBackUrl="~/redesSociales.aspx" /><br /><br />
                <asp:Button runat="server" ID="publicidadAdmin" CssClass="boton" Text="Gestion de Publicidad" PostBackUrl="~/Publicidad.aspx" /><br /><br />
            </section>
        </div>
    </section>
</asp:Content>
