<%@ Page Title="FrikiPop: Carrito" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="usuWeb.Carrito" EnableEventValidation="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="..\App_Style\carritoStyle.css" />
      <div class="carritoCompra">

          <section class="topBar">

              <h3 id= "carritoFrikiPop" style="font-size: 35px">Carrito FrikiPop </h3>
               <h3 id= "BorrarTodoCarrito"> 
                   <asp:LinkButton ID = "BorrarCarrito" Text= "Borrar todo el carrito" runat="server" OnClick="eliminarCarritoCompra" ForeColor="white" />  
               </h3>
          </section>
          
          <div class="ContentCarrito">

                <div class= "EnlistarArticulos" style="width: 100%">
                    <asp:GridView runat="server" ID="GridView" CssClass="gridViewCarrito" AutoGenerateColumns="false" DataKeyNames="linea" OnSelectedIndexChanged="GridView_SelectedIndexChanged" ShowHeader="false" Width="75%" BorderColor="#0f1618" >
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" ControlStyle-CssClass="selectButton" SelectText="Borrar Articulo" />
                            <asp:BoundField DataField="linea" />
                            <asp:ImageField DataImageUrlField="url_imagen" ControlStyle-Width="100px"></asp:ImageField>
                            <asp:BoundField DataField="nombre" />
                            <asp:BoundField DataField="precio" />
                        </Columns>
                    </asp:GridView>
                </div>

                <div class = "EfectuarPedido" style="font-size: 20px">
                    <h3> Precio total del pedido </h3>

                        <div id = "ValorCarritoContainer">

                            <div class = "ContainerLeft"> Valor del carrito:  </div>

                             <div class = "ContainerRight">
                                 <asp:Label ID = "value" runat = "server"></asp:Label>
                                 €
                             </div>

                        </div>

                        <div id = "EnvioContainer" style="font-size: 20px">

                            <div class = "ContainerLeft"> Envio del pedido: </div>

                            <div class = "ContainerRight">5.49€ </div>

                        </div>

                        <div id = "PrecioTotalContainer" style="font-size: 23px">

                            <div class = "ContainerLeft">
                                <h5>Total del pedido:</h5>
                            </div>

                            <div class = "ContainerRight">
                                <h5>
                                    <asp:Label ID = "TotalPrecio" runat = "server"> </asp:Label>
                                    €
                                </h5>
                                
                            </div>
                            

                        </div>

                    <h4> Efectuar Pedido </h4>
             
                            <div id="PedidoContainer">
                                <asp:Button ID = "Button2" runat = "server" Text="Tramitar pedido" CssClass="boton" OnClick="tramitarPedido"/>
                             </div>
                </div>

            </div>

        </div>

</asp:Content>