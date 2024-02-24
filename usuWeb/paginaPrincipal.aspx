<%@ Page Title="FrikiPop: Tu tienda Friki" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="paginaPrincipal.aspx.cs" Inherits="usuWeb.paginaPrincipal"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="..\App_Style\paginaPrincipalStyle.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="main_container">
        <div class="articulos">
            <asp:Listview runat="server" ID="PrincipalListView">
                <ItemTemplate>
                    <div class="articulo-card">
                        <div class="imagen">
                            <asp:ImageButton runat="server" Style="cursor: url(https://cdn.custom-cursor.com/db/pointer/32/Super_Mario_BowserPointer.png), pointer!important;" CssClass="imagen_articulo" id="imagen_articulo" PostbackUrl='<%#"~/verArticulo.aspx?codigo=" + Eval("codigo") %>' imageUrl= '<%#Eval("url_imagen")%>'/>
                        </div>
                            <figcaption class="articulo-card__caption">
                                <header class="articulo-card__header">
                                    <h2 class="articulo-card__nombre"><asp:label runat = "server" Text='<%# Eval("nombre") %>'/></h2>
                                </header>
                                <footer class="articulo-card__footer">
                                    <span class="articulo-card__precio"> <%# Eval("precio") %> €</span>
                                </footer>
                           </figcaption>
                    </div>
                </ItemTemplate>
            </asp:Listview>
        </div>
        <div class="publicidad">
            <asp:ImageButton  runat="server" style="cursor: url(https://cdn.custom-cursor.com/db/pointer/32/Super_Mario_BowserPointer.png), pointer!important;" id="publicidad_imagen" CssClass="publicidad_imagen"/>
        </div>
    </div>
</asp:Content>