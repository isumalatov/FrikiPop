using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using library;

namespace usuWeb
{
    public partial class verArticulo : System.Web.UI.Page
    {

        ENArticulo articulo;
        protected void Page_Load(object sender, EventArgs e)
        {
            articulo = new ENArticulo();

            articulo.codigo = Request.QueryString["codigo"];
                
            if(articulo.codigo == null) {
                Response.Redirect("~/paginaPrincipal.aspx");
            }

            articulo.readArticulo();

            precio.Text = articulo.precio.ToString();
            nombre.Text = articulo.nombre;
            descripcion.Text = articulo.descripcion;
            url_imagen.ImageUrl = articulo.urlImagen;
        }

        protected void añadirCestaClick(object sender, EventArgs e) {
            ENCarrito carrito = new ENCarrito();

            int idCar = carrito.obtenerIdCarrito((string)Session["nick"]);
            ENLineaCarrito lincar = new ENLineaCarrito();
            lincar.id_carrito = idCar;
            lincar.importe = (float)articulo.precio;
            lincar.linea = lincar.obtenerMaxLineaCarrito(idCar)+1;
            lincar.usuario = (string)Session["nick"];
            lincar.articulo = articulo.codigo;

            lincar.createLineaCarrito();
            Response.Redirect("~/verArticulo.aspx?codigo=" + articulo.codigo);
        }

        protected void comprarAhoraClick(object sender, EventArgs e) {
            Response.Redirect("~/PasarelaPago.aspx?codigo=" + articulo.codigo);
        }
    }
}