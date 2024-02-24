<%@ Page Title="FrikiPop: Localidades" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Localidades.aspx.cs" Inherits="usuWeb.Localidades" %>

<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="head" >
    <link rel="stylesheet" href="..\App_Style\ubicacionesStyle.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="modLocalidad">
            <div>
                <asp:GridView ID="GridView" runat="server" AutoGenerateColumns="False" DataKeyNames="localidad" CssClass="gridView" OnSelectedIndexChanged="GridView_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="localidad" HeaderText="Localidad" SortExpression="localidad" ReadOnly="True" />
                        <asp:BoundField DataField="provincia" HeaderText="Provincia" SortExpression="provincia" />
                        <asp:BoundField DataField="pais" HeaderText="Pais" SortExpression="pais" />
                    </Columns>
                </asp:GridView>
            </div>
        
        <section id="textoLocalidades">
            <asp:TextBox runat="server" id="localidad_text" CssClass="cuadroDeTexto" name="localidad" placeholder="Localidad"/>
            <br>
            <asp:TextBox runat="server" id="provincia_text" CssClass="cuadroDeTexto" name="provincia" placeholder="Provincia"/>
            <br>
            <asp:TextBox runat="server" id="pais_text" CssClass="cuadroDeTexto" name="pais" placeholder="Pais"/>
            <br>
        </section>
        <section ID="botonesLocalidades">
            <asp:Button runat="server" ID="anyadir" CssClass="boton" type="submit" Text="Añadir localidad" OnClick="añadir_Click"></asp:Button>
            <asp:Button runat="server" ID="borrar" CssClass="boton" type="submit" Text="Eliminar localidad" OnClick="borrar_Click"></asp:Button>
            <asp:Button runat="server" Text="Ver Provincias" CssClass="boton" CausesValidation="false" OnClick="Provincias_Click" />
        </section>
    </section>
</asp:Content>
