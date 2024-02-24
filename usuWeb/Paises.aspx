<%@ Page Title="FrikiPop: Paises" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Paises.aspx.cs" Inherits="usuWeb.Paises" %>

<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="head" >
    <link rel="stylesheet" href="..\App_Style\ubicacionesStyle.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="modPais">
            <div>
                <br />
                <asp:GridView ID="GridView" runat="server" AutoGenerateColumns="False" DataKeyNames="pais" CssClass="gridView" OnSelectedIndexChanged="GridView_SelectedIndexChanged" >
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" ControlStyle-CssClass="selectButton" HeaderText="Ver Provincias:" />
                        <asp:BoundField DataField="pais" HeaderText="Pais" SortExpression="pais" ReadOnly="true" />
                    </Columns>
                </asp:GridView>
            </div>
            
       <section id="textoPaises">
            <br /><br />
            <asp:TextBox runat="server" id="pais_text" CssClass="cuadroDeTexto" name="pais" placeholder="Pais"/>
            <br>
       </section>

        <section ID="botonesPaises" >
            <asp:Button runat="server" ID="anyadir" CssClass="boton" type="submit" Text="Añadir pais" OnClick="añadir_Click"></asp:Button>
            <asp:Button runat="server" ID="borrar" CssClass="boton" type="submit" Text="Eliminar pais" OnClick="borrar_Click"></asp:Button>
        </section>
    </section>
</asp:Content>
