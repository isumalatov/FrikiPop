<%@ Page Title="FrikiPop: Provincias" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Provincias.aspx.cs" Inherits="usuWeb.Provincias" %>

<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="head" >
    <link rel="stylesheet" href="..\App_Style\ubicacionesStyle.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="modProvincia">
            <div>
                <asp:GridView ID="GridView" runat="server" AutoGenerateColumns="False" DataKeyNames="provincia" CssClass="gridView" OnSelectedIndexChanged="GridView_SelectedIndexChanged">
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" ControlStyle-CssClass="selectButton" HeaderText="Ver Localidades:" />
                        <asp:BoundField DataField="provincia" HeaderText="Provincia" SortExpression="provincia" ReadOnly="true" />
                        <asp:BoundField DataField="pais" HeaderText="Pais" SortExpression="pais" />
                    </Columns>
                </asp:GridView>
            </div>

        <section id="textoProvincias">
            <asp:TextBox runat="server" id="provincia_text" CssClass="cuadroDeTexto" name="provincia" placeholder="Provincia"/>
            <br />
            <asp:TextBox runat="server" id="pais_text" CssClass="cuadroDeTexto" name="pais" placeholder="Pais"/>
            <br />
        </section>

        <section ID="botonesProvincias">
            <asp:Button runat="server" ID="anyadir" CssClass="boton" type="submit" Text="Añadir provincia" OnClick="añadir_Click"></asp:Button>
            <asp:Button runat="server" ID="borrar" CssClass="boton" type="submit" Text="Eliminar provincia" OnClick="borrar_Click"></asp:Button>
            <asp:Button runat="server" Text="Ver Paises" CssClass="boton" CausesValidation="false" OnClick="Paises_Click" />
        </section>
    </section>
</asp:Content>
