using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using library;

namespace usuWeb {
    public partial class Pedido : System.Web.UI.Page {
        private ENPedido pedido;
        private DataTable joinPedido;

        protected void Page_Load(object sender, EventArgs e) {
            pedido = new ENPedido();

            if (Request.QueryString.Count != 0) { //Si hay parámetros
                pedido.idPedido = int.Parse(Request.QueryString["num_pedido"]);
            }else {//Te lleva a la página principal si 
                Response.Redirect("paginaPrincipal.aspx");
            }
            if ((Session["nick"].ToString() != null) && pedido.readPedido()) {
                joinPedido = pedido.joinPedido();
                id.Text = pedido.idPedido.ToString("D9"); //D9 para que haya 9 dígitos de pedido ya que vamos a ser una tienda famosa jeje
                float finalImporte = 0;

                foreach (DataRow linea in joinPedido.Rows) {
                    finalImporte += float.Parse(linea["precio"].ToString());
                }

                price.Text = finalImporte.ToString("C2"); //C2 decimales para los precios
                total.Text = (finalImporte + 5.00).ToString("C2");
                date.Text = pedido.date;
                ListView1.DataSource = joinPedido;
                ListView1.DataBind();
            }else {
                Response.Redirect("paginaPrincipal.aspx");
            }
        }

        protected void ListView1_SelectedIndexChanged(object sender, EventArgs e) {

        }
    }
}