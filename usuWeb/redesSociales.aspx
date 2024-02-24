    <%@ Page Title="FrikiPop: RRSS" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="redesSociales.aspx.cs" Inherits="usuWeb.redesSociales" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="..\App_Style\redesSocialesStyle.css" />
    <section id="modRedesSociales">
            <div>
                <asp:GridView ID="GridView" runat="server" AutoGenerateColumns="False" DataKeyNames="red,url_logo,link_red" CssClass="gridView" OnSelectedIndexChanged="GridView_SelectedIndexChanged">
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" ControlStyle-CssClass="selectButton" />
                        <asp:BoundField DataField="red" HeaderText="Red" SortExpression="red" />
                        <asp:ImageField DataImageUrlField="url_logo" HeaderText="Url logo" SortExpression="url_logo" ControlStyle-Width="150px" />
                        <asp:BoundField DataField="link_red" HeaderText="Link red" SortExpression="link_red" />
                    </Columns>
                </asp:GridView>
            </div>
            <section id="textoRedesSociales">
            <asp:Label runat="server" for="red" Text="Red: "></asp:Label>
            <asp:TextBox runat="server" id="red" name="red" placeholder="Red" CssClass="cuadroDeTexto"/><br />
            <br>
            <asp:Label runat="server" for="url_logo" Text="Url log: : "></asp:Label>
            <asp:TextBox runat="server" id="url_logo" name="url_logo" placeholder="Url logo" CssClass="cuadroDeTexto"/><br />
            <br>
            <asp:Label runat="server" for="link_red" Text="Link red: "></asp:Label>
            <asp:TextBox runat="server" id="link_red" name="link_red" placeholder="Link red" CssClass="cuadroDeTexto"/><br />
            <br>
            </section>
            <section ID="botonesRedesSociales">
                <asp:Button runat="server" ID="anyadir" type="submit" Text="Añadir red" OnClick="añadir_Click" CssClass="boton"></asp:Button>
                <asp:Button runat="server" ID="borrar" type="submit" Text="Eliminar red" OnClick="borrar_Click" CssClass="boton"></asp:Button>
                <asp:Button runat="server" Text="Volver" CausesValidation="false" OnClick="Volver_Click" CssClass="boton" />
            </section>
    </section>
</asp:Content>
