using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using library;

namespace usuWeb
{
    public partial class Articulos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] == null || (int)Session["admin"] != 1) {
                Response.Redirect("~/paginaPrincipal.aspx");
            }

            string usuario = Request.QueryString["nick"];
            if (usuario == null)
            {
                ENArticulo articulo = new ENArticulo();
                GridView.DataSource = articulo.usuarioArticulo("");
                GridView.DataBind();
            }
            else
            {
                ENArticulo articulo = new ENArticulo();
                GridView.DataSource = articulo.usuarioArticulo(usuario);
                GridView.DataBind();
            }

        }

        protected void GridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridView.SelectedRow;
            string codigoName = row.Cells[1].Text;
            string nombreName = row.Cells[2].Text;
            string descripcionName = row.Cells[3].Text;
            string precioName = row.Cells[4].Text;
            string urlImagenName = row.Cells[5].Text;
            string usuarioName = row.Cells[6].Text;
            string tipoName = row.Cells[7].Text;
            Response.Redirect("~/VerArticulo.aspx?codigo=" + codigoName);

        }
    }
}