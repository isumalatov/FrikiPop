<%@ Page Title="FrikiPop: Usuarios" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="VerUsuarios.aspx.cs" Inherits="usuWeb.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="..\App_Style\verUsuariosStyle.css" />
    <section id="filtradoDelGrid">
        <asp:Button CssClass="botonParaFiltrar" runat="server" Text="Filtrar" OnClick="Filtrar_Valores"></asp:Button>
        <asp:DropDownList ID="filtros" CssClass="filtros"  runat="server">
            <asp:ListItem CssClass="filtros" Text="(Seleccione una columna para filtrar)" id="valorInicial"></asp:ListItem>
            <asp:ListItem CssClass="filtros" Text="Nick_name" id="nick"></asp:ListItem>
            <asp:ListItem CssClass="filtros" Text="Nombre" id="nombre"></asp:ListItem>
            <asp:ListItem CssClass="filtros" Text="Apellidos" id="apellidos"></asp:ListItem>
            <asp:ListItem CssClass="filtros" Text="Edad" id="edad"></asp:ListItem>
            <asp:ListItem CssClass="filtros" Text="Administrador" id="administrador"></asp:ListItem>
            <asp:ListItem CssClass="filtros" Text="Localidad" id="localidad"></asp:ListItem>
            <asp:ListItem CssClass="filtros" Text="Provincia" id="provincia"></asp:ListItem>
            <asp:ListItem CssClass="filtros" Text="Pais" id="pais"></asp:ListItem>
        </asp:DropDownList>
        <asp:TextBox id="valorParaFiltrar" CssClass="valorParaFiltrar" runat="server" placeHolder="Introduzca el valor por el que quiera filtrar"></asp:TextBox><br />
        <asp:label runat="server" id="faltaLista"></asp:label>
        <asp:label runat="server" id="faltaValorParaFiltrar"></asp:label>
    </section>
    <asp:GridView CssClass="gridViewUsuarios" ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowEditing="Editar" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
        <Columns>
            <asp:CommandField HeaderText="Hacer admin" ShowSelectButton="True" SelectText="Change admin" ControlStyle-CssClass="selectButtonUsuarios" />
            <asp:CommandField HeaderText="Modificar usuario" ShowEditButton="true" EditText="Modificar" ButtonType="Button" />
            <asp:BoundField HeaderText="Nick_name" DataField="nick_name" SortExpression="nick_name"/>
            <asp:BoundField HeaderText="Nombre" DataField="nombre" SortExpression="nombre"/>
            <asp:BoundField HeaderText="Apellidos" DataField="apellidos" SortExpression="apellidos"/>
            <asp:BoundField HeaderText="Edad" DataField="edad" SortExpression="edad"/>
            <asp:BoundField HeaderText="Contraseña" DataField="contrasenya" SortExpression="contrasenya"/>
            <asp:BoundField HeaderText="Imagen" DataField="url_imagen" SortExpression="url_imagen"/>
            <asp:BoundField HeaderText="Administrador?" DataField="admin" SortExpression="admin"/>
            <asp:BoundField HeaderText="Localidad" DataField="localidad" SortExpression="localidad"/>
            <asp:BoundField HeaderText="Provincia" DataField="provincia" SortExpression="provincia"/>
            <asp:BoundField HeaderText="Pais" DataField="pais" SortExpression="pais"/>
            <asp:BoundField HeaderText="Numero de ventas" DataField="numVentas" SortExpression="numVentas"/>
        </Columns>
    </asp:GridView>
    <section id="botonesVerUsuarios">
        <asp:Button class="boton" runat="server" Text="Añadir nuevo usuario" OnClick="CrearUsuario" /><br /><br />
        <asp:TextBox placeHolder="Nombre de usuario" CssClass="cuadroDeTexto" runat="server" ID="eliminar"></asp:TextBox><br /><br />
        <asp:Button class="boton" runat="server" Text="Eliminar usuario" OnClick="EliminarUsuario" /><br />
        <asp:Label ID="LabelError" runat="server"></asp:Label>
    </section>
</asp:Content>
