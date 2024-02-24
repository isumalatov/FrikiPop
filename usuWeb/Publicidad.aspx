<%@ Page Title="FrikiPop: Publicidad" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Publicidad.aspx.cs" Inherits="usuWeb.Publicidad" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <link rel="stylesheet" href="..\App_Style\tarjetasStyle.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="..\App_Style\publicidadStyle.css" />
    <section id="modPublicidad">
            <div>
                <asp:GridView ID="GridView" runat="server" AutoGenerateColumns="False" DataKeyNames="id_publi" CssClass="gridView">
                    <Columns>
                        <asp:BoundField DataField="id_publi" HeaderText="ID publicidad" SortExpression="id_publi" ReadOnly="True" />
                        <asp:BoundField DataField="id_empresa" HeaderText="ID Empresa" SortExpression="id_empresa" />
                        <asp:BoundField DataField="url_imagen" HeaderText="Imagen" SortExpression="url_imagen" />
                        <asp:BoundField DataField="link_empresa" HeaderText="Link Empresa" SortExpression="link_empresa" />
                    </Columns>
                </asp:GridView>
            </div>
            <section id="textoPublicidad">
            <asp:Label runat="server" for="id_p" Text="ID Publicidad: "></asp:Label>
            <asp:TextBox runat="server" CssClass="cuadroDeTexto" id="id_p" name="id_p" placeholder="ID" Width="409px"/>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="id_p" ErrorMessage="Rellene este campo"></asp:RequiredFieldValidator>
            <br>
            <asp:Label runat="server" for="id_e" Text="ID Empresa: "></asp:Label>
            <asp:TextBox runat="server" CssClass="cuadroDeTexto" id="id_e" name="id_e" placeholder="ID"/>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="id_e" ErrorMessage="Rellene este campo"></asp:RequiredFieldValidator>
            <br>
            <asp:Label runat="server" for="link_e" Text="Link Empresa: " />
            <asp:TextBox runat="server" CssClass="cuadroDeTexto" id="link_e" name="link_e" placeholder="Link"/>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="link_e" ErrorMessage="Rellene este campo"></asp:RequiredFieldValidator>
            <br>
            <asp:Label runat="server" for="imagen" Text="Imagen: " />
            <asp:TextBox runat="server" CssClass="cuadroDeTexto" id="imagen" name="imagen" placeholder="URL"/>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="imagen" ErrorMessage="Rellene este campo"></asp:RequiredFieldValidator>
            <br>
            </section>
        <section ID="botonesPublicidad">
            <asp:Button runat="server" CssClass="boton" ID="anyadir" type="submit" Text="Añadir Publicidad" OnClick="anyadir_Click" />
            <asp:Button runat="server" CssClass="boton" ID="borrar" type="submit" Text="Eliminar Publicidad" OnClick="borrar_Click" />
            <asp:Button runat="server" CssClass="boton" ID="actualizar" type="submit" Text="Actualizar Publicidad" OnClick="actualizar_Click" />
        </section>
    </section>
</asp:Content>
