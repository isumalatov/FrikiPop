using library;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace usuWeb {
    public partial class PasarelaPago : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (Session["nick"] == null) {  //verifica si el usuario está logueado
                Response.Redirect("~/SignUp.aspx");
            }
            else {  //lista las tarjetas del usuario
                DataSet data = new DataSet();
                data = ENTarjeta.listarTarjetas((string)Session["nick"]); 
                GridView.DataSource = data;
                GridView.DataBind();
            }
        }

        protected bool DataValidation(ENTarjeta tarjeta) {  //valida los datos de la tarjeta

            if (long.TryParse(num.Text, out long num_tarj)) {
                if(num.Text.Length == 16) {
                    tarjeta.num = num.Text;
                }
            }
            else {
                Message.Text = "Formato del nº de tarjeta INCORRECTO!";
                return false;
            }

            if (int.TryParse(fechaMes.Text, out int mes_tarj) && (fechaMes.Text.Length == 2 || fechaMes.Text.Length == 1) && mes_tarj > 0 && mes_tarj < 13) {
                tarjeta.mesFecha = mes_tarj;
            }
            else {
                Message.Text = "Formato del mes INCORRECTO!";
                return false;
            }

            if (int.TryParse(fechaAnyo.Text, out int anyo_tarj) && fechaAnyo.Text.Length == 4 && anyo_tarj > 2023 && anyo_tarj < 2030) {
                tarjeta.anyoFecha = anyo_tarj;
            }
            else {
                Message.Text = "Formato del año INCORRECTO!";
                return false;
            }

            if (int.TryParse(cvvTarj.Text, out int cvv) && cvvTarj.Text.Length == 3) {
                tarjeta.cvv = cvvTarj.Text;
            }
            else {
                Message.Text = "Formato del cvv INCORRECTO!";
                return false;
            }

            tarjeta.usuario = Session["nick"].ToString();
            return true;
        }

        //Añade una tarjeta introducida por el usuario
        protected void anyadir_Click(object sender, EventArgs e) { 

            ENTarjeta tarjeta = new ENTarjeta();

            if (DataValidation(tarjeta)) {
                tarjeta.createTarjeta();
            }
            Response.Redirect("~/PasarelaPago.aspx");
        }

        //Borra la tarjeta introducida por el usuario
        protected void borrar_Click(object sender, EventArgs e) {
            ENTarjeta tarjeta = new ENTarjeta();

            if (DataValidation(tarjeta)) {
                tarjeta.deleteTarjeta();
            }

            Response.Redirect("~/PasarelaPago.aspx");
        }

        //Hace el proceso de pago
        protected void GridView_SelectedIndexChanged(object sender, EventArgs e) {

            string id_articulo = Request.QueryString["codigo"]; //recibe el codigo del articulo
            string id_carrito = Request.QueryString["carrito"]; //recibe el id del carrito

            //prepara los atributos del pedido
            ENPedido pedido = new ENPedido();

            string connection = ConfigurationManager.ConnectionStrings["Database"].ToString();
            SqlConnection conex = new SqlConnection(connection);
            conex.Open();

            string query = "SELECT MAX(num_pedido) AS max_numPedido FROM Pedido";
            SqlCommand command = new SqlCommand(query, conex);
            int maxNumPedido = Convert.ToInt32(command.ExecuteScalar());
            pedido.idPedido = maxNumPedido + 1; //Asigna a idPedido el max id actual + 1
            pedido.user = (string)Session["nick"];
            DateTime now = DateTime.Now;
            pedido.date = now.ToString("yyyy-MM-dd");
            pedido.state = "listo";

            if (id_articulo != null) {  //caso se ha comprado directamente el articulo
                
                //Cambiar propietario del articulo
                ENArticulo articulo = new ENArticulo();
                articulo.codigo = id_articulo;
                articulo.readArticulo();

                string antiguoUsuario = articulo.usuario;

                articulo.cambiarUsuario((string)Session["nick"]);

                //Incrementar numVentas al usuario  
                ENUsuario usuarioIncrementar = new ENUsuario();
                usuarioIncrementar.nick = antiguoUsuario;
                usuarioIncrementar.readUsuario();
                int numVentasAntiguo = usuarioIncrementar.numVentas + 1;
                usuarioIncrementar.incrementarNumVentas(numVentasAntiguo);

                //Incrementar numVentas del tipo
                ENTipoArticulo tipoArticulo = new ENTipoArticulo();
                tipoArticulo.tipoArticulo = articulo.tipoArticulo;
                tipoArticulo.incrementarNumeroVentas();

                //obtiene el precio del articulo
                SqlCommand sql = new SqlCommand("SELECT precio from Articulo where codigo='" + id_articulo + "'", conex);
                float precio = float.Parse(sql.ExecuteScalar().ToString());
                conex.Close();

                pedido.total = precio;
                //crea el pedido
                pedido.createPedido();
                //crea una línea de pedido
                ENLinPedido linped = new ENLinPedido(1, pedido.idPedido, id_articulo, pedido.total, (string)Session["nick"]);
                linped.createLinPedido();

            }
            
            if(id_carrito != null) {    //caso se compra desde una cesta

                //creamos la cesta
                ENCarrito carroCompra = new ENCarrito();
                carroCompra.numeroCarrito = int.Parse(id_carrito);
                DataTable unirCarrito;

                unirCarrito = carroCompra.unirCarrito();
                string importeS = "importe";
                float importeTotal;
                float importe;
                importeTotal = 0;

                int contador = 1;
                pedido.total = 0;

                //crea el pedido
                pedido.createPedido();

                //hace el sumatorio del precio de todos los artículos de la cesta
                foreach (DataRow lineaCarri in unirCarrito.Rows) {
                    importe = float.Parse(lineaCarri[importeS].ToString());
                    importeTotal = importeTotal + importe;
                    //crea una línea de pedido por artículo leído de la cesta
                    ENLinPedido lineaPedido = new ENLinPedido(contador, pedido.idPedido, lineaCarri["codigo"].ToString(), importe, (string)Session["nick"]);
                    lineaPedido.createLinPedido();
                    contador++;

                    //Cambiar el propietario del articulo
                    ENArticulo articulo = new ENArticulo();
                    articulo.codigo = lineaPedido._articulo;
                    articulo.readArticulo();

                    string antiguoUsuario = articulo.usuario;

                    articulo.cambiarUsuario((string)Session["nick"]);

                    //Incrementar Ventas del usuario
                    ENUsuario usuarioAntiguo = new ENUsuario();
                    usuarioAntiguo.nick = antiguoUsuario;
                    usuarioAntiguo.readUsuario();
                    int numVentasAntiguo = usuarioAntiguo.numVentas + 1;
                    usuarioAntiguo.incrementarNumVentas(numVentasAntiguo);

                    //Incrementar numVentas del tipo
                    ENTipoArticulo tipoArticulo = new ENTipoArticulo();
                    tipoArticulo.tipoArticulo = articulo.tipoArticulo;
                    tipoArticulo.incrementarNumeroVentas();
                }

                //actualiza el precio del pedido
                pedido.total = ((float)(importeTotal + 5.49));
                pedido.updatePedido();

                //vacia el carrito
                carroCompra.vaciarCarrito();
            }
            
            Response.Redirect("~/paginaPrincipal.aspx");
        }
    }
}