using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using library;

namespace usuWeb {
    public partial class Carrito : System.Web.UI.Page {

        private DataTable unirCarrito;

        private ENCarrito carroCompra;
        protected void Page_Load(object sender, EventArgs e) {
            carroCompra = new ENCarrito();

            carroCompra.usuario = (string)Session["nick"];
            if(!carroCompra.readCarrito() || carroCompra.usuario == "invitado") {
                Response.Redirect("paginaPrincipal.aspx");
            }
            else { 
                LoadCarroCompra(); 
            }
        }

        protected void eliminarCarritoCompra(object sender, EventArgs e)    {

            carroCompra.vaciarCarrito();
            LoadCarroCompra();
        }

        protected void LoadCarroCompra() {
            unirCarrito = carroCompra.unirCarrito();
            string importeS = "importe";
            double importeTotal;
            double importe;
            importeTotal = 0;

            foreach(DataRow lineaCarri in unirCarrito.Rows) {
                importe = double.Parse(lineaCarri[importeS].ToString());
                importeTotal = importeTotal + importe;
            }

            TotalPrecio.Text = (importeTotal + 5.49).ToString();

            value.Text = importeTotal.ToString();

            GridView.DataSource = unirCarrito;
            GridView.DataBind();
        }

        protected void tramitarPedido(object sender, EventArgs e) {

            Response.Redirect("~/PasarelaPago.aspx?carrito=" + carroCompra.numeroCarrito);

        }

        protected void GridView_SelectedIndexChanged(object sender, EventArgs e) {
            GridViewRow row = GridView.SelectedRow;
            int linea = int.Parse(row.Cells[1].Text);
            carroCompra.deleteArticulo(linea);
            LoadCarroCompra();
        }
    }
}