using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using library;

namespace usuWeb {
    public partial class Provincias : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

            //Se comprueba que hay una session de administrador activa
            if (Session["admin"] == null || (int)Session["admin"] != 1) {
                Response.Redirect("~/paginaPrincipal.aspx");
            }
            
            //Se mira el pais pasado por parametro
            string pais = Request.QueryString["pais"];

            if (pais == null) { //Si esta vacion, se muestran todas las provincias. Si no, solo las del pais indicado 
                ENProvincia provincia = new ENProvincia();
                GridView.DataSource = provincia.listarProvincias("");
                GridView.DataBind();
            } else {
                ENProvincia provincia = new ENProvincia();
                GridView.DataSource = provincia.listarProvincias(pais);
                GridView.DataBind();
            }
        }

        //Lee los datos de los textBox y los almacena en un enProvincia para crear una nueva
        protected void añadir_Click(object sender, EventArgs e) {
            ENProvincia provincia = new ENProvincia();
            provincia.provincia = provincia_text.Text;
            provincia.pais = pais_text.Text;
            provincia.createProvincia();
            Response.Redirect("~/Provincias.aspx");
        }

        //Lee los datos de los textBox y los almacena en un enProvincia para eliminarla
        protected void borrar_Click(object sender, EventArgs e) {
            ENProvincia provincia = new ENProvincia();
            provincia.provincia = provincia_text.Text;
            provincia.pais = pais_text.Text;
            provincia.deleteProvincia();
            Response.Redirect("~/Provincias.aspx");
        }

        //Vuelve para atras para ver todos los paises
        protected void Paises_Click(object sender, EventArgs e) {
            Response.Redirect("~/Paises.aspx");
        }

        //Si selecciona un elemento del gridView, pasas por parametro sus elementos a Localidades para visualizarlas
        protected void GridView_SelectedIndexChanged(object sender, EventArgs e) {
            GridViewRow row = GridView.SelectedRow;
            string paisName = row.Cells[2].Text;
            string provinciaName = row.Cells[1].Text;
            Response.Redirect("~/Localidades.aspx?provincia=" + provinciaName + "&pais=" + paisName);
        }
    }
}