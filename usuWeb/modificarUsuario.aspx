<%@ Page Title="FrikiPop: Actualizar Datos" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="modificarUsuario.aspx.cs" Inherits="usuWeb.modificarUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="..\App_Style\usuarioStyle.css" />

    <h1 style="margin-left:75px">Actualizar datos</h1>
    <section id="cuadrosTextoUsuario">            
        <asp:TextBox placeholder="Nombre" class ="cuadroDeTexto"  runat="server" ID="Nombre1"></asp:TextBox><br />
            
        <asp:TextBox placeholder="Apellidos" class ="cuadroDeTexto" runat="server" ID="Apellidos1"></asp:TextBox><br />
            
        <asp:TextBox placeholder="Edad" class ="cuadroDeTexto" runat="server" ID="Edad1"></asp:TextBox><br />
            
        <asp:DropDownList ID="Paises" runat="server" CssClass="listas" DataSourceID="Database1" DataTextField="pais" DataValueField="pais">
            <asp:ListItem Text="Seleccione un pais"></asp:ListItem>
        </asp:DropDownList>
        <asp:SqlDataSource ID="Database1" runat="server" ConnectionString="<%$ ConnectionStrings:Database %>" SelectCommand="SELECT [pais] FROM [Pais]"></asp:SqlDataSource>
            
        <asp:DropDownList ID="Provincias" runat="server" CssClass="listas" DataSourceID="SqlDatabase" DataTextField="provincia" DataValueField="provincia" OnSelectedIndexChanged="Provincias_SelectedIndexChanged">
            <asp:ListItem Text="Seleccione una provincia"></asp:ListItem>
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDatabase" runat="server" ConnectionString="<%$ ConnectionStrings:Database %>" SelectCommand="SELECT [provincia] FROM [Provincia]"></asp:SqlDataSource>
        <asp:Label CssClass="labelsDeError" runat ="server" ID = "LabelErrorProvincia"></asp:Label>
            
        <asp:DropDownList ID="Localidades" runat="server" CssClass="listas" DataSourceID="SqlDataSource1" DataTextField="localidad" DataValueField="localidad" OnSelectedIndexChanged="Localidades_SelectedIndexChanged">
            <asp:ListItem Text="Seleccione una localidad"></asp:ListItem>
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Database %>" SelectCommand="SELECT [localidad] FROM [Localidad]"></asp:SqlDataSource>
        <asp:Label CssClass="labelsDeError" runat ="server" ID = "LabelErrorLocalidad"></asp:Label>
            
        <asp:TextBox placeholder="Nueva Contraseña" class ="cuadroDeTexto" TextMode="Password" runat="server" ID="Contrasenya1"></asp:TextBox>
    </section>
    <br />
    <section id="botonesUsuario">
        <asp:Button CssClass="boton" runat="server" Text="Modificar Datos"  ID="Modificar" OnClick="modificarUsuario_Click"/>
        <asp:Label CssClass="labelsDeError" runat="server" ID = "LabelError"></asp:Label>
    </section>
</asp:Content>