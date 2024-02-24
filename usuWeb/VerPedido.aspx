<%@ Page Title="FrikiPop: Mis Pedidos" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="VerPedido.aspx.cs" Inherits="usuWeb.VerPedido" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="..\App_Style\verPedidoStyle.css" />
    <section id="Pedidos">
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataKeyNames="num_pedido" GridLines="None" CssClass="gridView" OnSelectedIndexChanged="GridView2_SelectedIndexChanged">
            <Columns>
                <asp:CommandField ShowSelectButton="True" ControlStyle-CssClass="selectButton" HeaderText="Ver Pedido" />
                <asp:BoundField DataField="num_pedido" HeaderText="numPedido" ReadOnly="True" SortExpression="num_pedido" />
                <asp:BoundField DataField="fecha" HeaderText="Fecha" SortExpression="fecha" />
                <asp:BoundField DataField="total" HeaderText="Total" SortExpression="total" />
            </Columns>
        </asp:GridView>
        <section ID="botonesPedidos">
            <asp:Button runat="server" Text="Volver" CausesValidation="false" OnClick="volverClick" />
        </section>
    </section>
</asp:Content>