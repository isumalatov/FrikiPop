<%@ Page Title="FrikiPop: SignUp" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="usuWeb.Formulario_web2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="..\App_Style\usuarioStyle.css" />

    <h1 style="margin-left:75px">Nueva cuenta</h1>
    <section id="fotoPerfil">
        Subir imagen:&nbsp;&nbsp;  
        <asp:FileUpload ID="FileUpload1" runat="server" Width="437px"/>
        <asp:Label runat="server" ID="Prueba" CssClass="labelsDeError"></asp:Label>
    </section>
    <section id="cuadrosTextoUsuario">
        <asp:TextBox placeholder="Nombre de usuario" class ="cuadroDeTexto" runat="server" ID="Nick1"></asp:TextBox>
        <asp:RequiredFieldValidator CssClass="validator" runat="server" ControlToValidate="Nick1" ErrorMessage="Falta introducir un nombre de usuario"></asp:RequiredFieldValidator>
            
        <asp:TextBox placeholder="Nombre" class ="cuadroDeTexto"  runat="server" ID="Nombre1"></asp:TextBox>
        <asp:RequiredFieldValidator CssClass="validator" runat="server" ControlToValidate="Nombre1" ErrorMessage="Falta introducir su nombre"></asp:RequiredFieldValidator>

            
        <asp:TextBox placeholder="Apellidos" class ="cuadroDeTexto" runat="server" ID="Apellidos1"></asp:TextBox>
        <asp:RequiredFieldValidator CssClass="validator" runat="server" ControlToValidate="Apellidos1" ErrorMessage="Falta introducir sus apellidos"></asp:RequiredFieldValidator>
            
        <asp:TextBox placeholder="Edad" class ="cuadroDeTexto" runat="server" ID="Edad1"></asp:TextBox>
        <asp:RequiredFieldValidator CssClass="validator" runat="server" ControlToValidate="Edad1" ErrorMessage="Falta introducir su edad"></asp:RequiredFieldValidator>
            
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
            
        <asp:TextBox placeholder="Contraseña" class ="cuadroDeTexto" TextMode="Password" runat="server" ID="Contrasenya1"></asp:TextBox>
        <asp:RequiredFieldValidator CssClass="validator" runat="server" ControlToValidate="Contrasenya1" ErrorMessage="Falta introducir una contraseña"></asp:RequiredFieldValidator>
    </section>
    <section id="CheckBoxes">
        <asp:CheckBox CssClass="checkBox" id="checkBox1" runat="server"  Text="No soy un robot (Opcional)"></asp:CheckBox><br />
        <asp:CheckBox CssClass="checkBox" ID="SoyFriki" runat="server" Text="Soy un friki (Obligatorio)"></asp:CheckBox><br />
     </section>
    <br />
    <section id="botonesUsuario">
        <asp:Button CssClass="boton" runat="server" Text="Sign Up"  ID="Crear" OnClick="createUsuario"/>
        <asp:Label CssClass="labelsDeError" runat="server" ID = "LabelError"></asp:Label>
    </section>
</asp:Content>