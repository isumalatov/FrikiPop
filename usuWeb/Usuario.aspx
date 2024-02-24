<%@ Page Title="FrikiPop: LogIn" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Usuario.aspx.cs" Inherits="usuWeb.Formulario_web11" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="..\App_Style\usuarioStyle.css" />
        <h1>Inicio de sesión</h1>
        <section id="cuadrosTextoUsuario">
            <asp:TextBox CssClass="cuadroDeTexto" placeholder="Nombre de usuario" runat="server" ID="Nick" ></asp:TextBox>
            <asp:RequiredFieldValidator CssClass="validator" runat="server" ControlToValidate="Nick" ErrorMessage="Falta el nombre de usuario"></asp:RequiredFieldValidator>
            <asp:TextBox class ="cuadroDeTexto" placeholder="Contraseña" TextMode="Password" runat="server" ID="Contrasenya"></asp:TextBox>
            <asp:RequiredFieldValidator CssClass="validator" runat="server" ControlToValidate="Contrasenya" ErrorMessage="Falta la contraseña"></asp:RequiredFieldValidator>
        </section>
        <section id="botonesUsuario">
            <asp:Button CssClass="boton"  id="Login" runat="server" Text="Log In" OnClick="LogIn"/>
            <asp:Label runat ="server" ID = "LabelError"></asp:Label>
            <br /><br />
        </section>
        <section id="nuevaCuenta">
            ¿No tiene una cuenta todavía?
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/SignUp.aspx">Regístrate aquí</asp:HyperLink>
        </section>
</asp:Content>
