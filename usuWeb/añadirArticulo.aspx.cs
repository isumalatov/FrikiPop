using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using library;

namespace usuWeb
{
    public partial class añadirArticulo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["nick"] == null) {
                Response.Redirect("~/paginaPrincipal.aspx");
            }
        }

        protected void añadir_Click(object sender, EventArgs e) {
            ENArticulo articulo = new ENArticulo();
            articulo.usuario = (string)Session["nick"];
            articulo.codigo = (int.Parse(articulo.getMaxID())+1).ToString();
            articulo.nombre = nombre.Text;
            articulo.tipoArticulo = tipo.Text;
            articulo.precio = double.Parse(precio.Text);
            articulo.descripcion = descripcion.Text;

            string fotoName = nombre.Text + "-" + (string)Session["nick"] + ".png";
            string nombreFoto = "/App_Images/Articulos/" + fotoName;

            string ruta = Server.MapPath("~/App_Images/Articulos/") + fotoName;
            FileUpload1.SaveAs(ruta);
            articulo.urlImagen = nombreFoto;

            articulo.createArticulo();

            Response.Redirect("~/paginaPrincipal.aspx");
        }
    }
}