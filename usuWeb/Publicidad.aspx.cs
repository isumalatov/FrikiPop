using library;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace usuWeb {
    public partial class Publicidad : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

            if (Session["nick"] != null && (int)Session["admin"] == 1) {
                ENTarjeta tarjeta = new ENTarjeta();

                ENPublicidad publicidad = new ENPublicidad();
                GridView.DataSource = publicidad.listarPublicidad();
                GridView.DataBind();
            }
            else {
                Response.Redirect("~/SignUp.aspx");
            }
            
        }

        protected void actualizar_Click(object sender, EventArgs e) {
            ENPublicidad publicidad = new ENPublicidad();
            publicidad.id = id_p.Text;
            publicidad.empresa = id_e.Text;
            publicidad.imagen = imagen.Text;
            publicidad.url_empresa = link_e.Text;
            publicidad.updatePublicidad();
            Response.Redirect("~/Publicidad.aspx");

        }

        protected void anyadir_Click(object sender, EventArgs e) {
            ENPublicidad publicidad = new ENPublicidad();
            publicidad.id = id_p.Text;
            publicidad.empresa = id_e.Text;
            publicidad.imagen = imagen.Text;
            publicidad.url_empresa = link_e.Text;
            publicidad.createPublicidad();
            Response.Redirect("~/Publicidad.aspx");
        }

        protected void borrar_Click(object sender, EventArgs e) {
            ENPublicidad publicidad = new ENPublicidad();
            publicidad.id = id_p.Text;
            publicidad.empresa = id_e.Text;
            publicidad.imagen = imagen.Text;
            publicidad.url_empresa = link_e.Text;
            publicidad.deletePublicidad();
            Response.Redirect("~/Publicidad.aspx");
        }
    }
}