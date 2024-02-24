<%@ Page Title="FrikiPop: Tarjetas" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Tarjetas.aspx.cs" Inherits="usuWeb.Tarjeta" %>

<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="head" >
    <link rel="stylesheet" href="..\App_Style\tarjetasStyle.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="modTarjeta">
            <div>
                <asp:GridView ID="GridView" runat="server" AutoGenerateColumns="False" DataKeyNames="numTarjeta" CssClass="gridView">
                    <Columns>
                        <asp:BoundField DataField="numTarjeta" HeaderText="Número Tarjeta" SortExpression="numTarjeta" ReadOnly="True" />
                        <asp:BoundField DataField="usuario" HeaderText="Usuario" SortExpression="usuario" />
                        <asp:BoundField DataField="cvv" HeaderText="CVV" SortExpression="cvv" />
                        <asp:BoundField DataField="mes_cad" HeaderText="Mes de caducidad" SortExpression="mes_cad" />
                        <asp:BoundField DataField="anyo_cad" HeaderText="Año de caducidad" SortExpression="anyo_cad" />
                    </Columns>
                </asp:GridView>
            </div>
        <section id="campos">
            <asp:Label runat="server" for="num" Text="Número de tarjeta: "></asp:Label>
            <asp:TextBox runat="server" CssClass="cuadroDeTexto" id="num" name="num" placeholder="xxxxxxxxxxxxxxxx" Width="200px"/>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorNumTarj"  runat="server" ControlToValidate="num" ErrorMessage="Rellene este campo"></asp:RequiredFieldValidator>
            <br>
            <asp:Label runat="server" for="usuario" Text="Usuario: "></asp:Label>
            <asp:TextBox runat="server" CssClass="cuadroDeTexto" id="usuario" name="usuario"/>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorUsuario" runat="server" ControlToValidate="usuario" ErrorMessage="Rellene este campo"></asp:RequiredFieldValidator>
            <br>
            <asp:Label runat="server" for="fechaMes" Text="Mes de caducidad: "></asp:Label>
            <asp:TextBox runat="server" CssClass="cuadroDeTexto" id="fechaMes" name="fechaMes" placeholder="mm" Width="35px"/>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorFechaMes" runat="server" ControlToValidate="fechaMes" ErrorMessage="Rellene este campo"></asp:RequiredFieldValidator>
            <br>
            <asp:Label runat="server" for="fechaAnyo" Text="Año de caducidad: "></asp:Label>
            <asp:TextBox runat="server" CssClass="cuadroDeTexto" id="fechaAnyo" name="fechaAnyo" placeholder="aaaa" Width="45px"/>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorFechaAnyo" runat="server" ControlToValidate="fechaAnyo" ErrorMessage="Rellene este campo"></asp:RequiredFieldValidator>
            <br>
            <asp:Label runat="server" for="cvvTarj" Text="CVV: "></asp:Label>
            <asp:TextBox runat="server" CssClass="cuadroDeTexto" id="cvvTarj" name="cvvTarj" placeholder="" Width="45px"/>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorCVV" runat="server" ControlToValidate="cvvTarj" ErrorMessage="Rellene este campo"></asp:RequiredFieldValidator>
            <br>
            <asp:Label ID="Message" runat="server"></asp:Label>
        </section>
        <section ID="botonesTarjeta">
            <asp:Button runat="server" CssClass="boton" ID="anyadir" type="submit" Text="Añadir tarjeta" OnClick="anyadir_Click"></asp:Button>
            <asp:Button runat="server" CssClass="boton" ID="borrar" type="submit" Text="Eliminar tajeta" OnClick="borrar_Click"></asp:Button>
            <asp:Button runat="server" CssClass="boton" ID="actualizar" type="submit" Text="Actualizar tajeta" OnClick="actualizar_Click"></asp:Button>
        </section>
    </section>
</asp:Content>
