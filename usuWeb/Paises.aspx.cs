using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using library;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Configuration;

namespace usuWeb {
    public partial class Paises : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

            //Se comprueba que hay una session de administrador activa
            if (Session["admin"] == null || (int)Session["admin"] != 1) {
                Response.Redirect("~/paginaPrincipal.aspx");
            }

            //Se leen los paises almacenados en la BD
            ENPais pais = new ENPais();
            GridView.DataSource = pais.listarPaises();
            GridView.DataBind();
        }

        //Si se selecciona un elemento del GridView, se visualizan las provincias de ese pais
        protected void GridView_SelectedIndexChanged(object sender, EventArgs e) {
            GridViewRow row = GridView.SelectedRow;
            string paisName = row.Cells[1].Text; //El nombre del pais es la celda 1 de la fila seleccionada (la 0 es la del boton)
            Response.Redirect("~/Provincias.aspx?pais=" + paisName);
        }

        //Se leen los datos de los TextBox y se crea un nuevo pais
        protected void añadir_Click(object sender, EventArgs e) {
            ENPais pais = new ENPais();
            pais.pais = pais_text.Text;
            pais.createPais();
            Response.Redirect("~/Paises.aspx");
        }

        //Se leen los datos de los TextBox y se elimina ese pais
        protected void borrar_Click(object sender, EventArgs e) {
            ENPais pais = new ENPais();
            pais.pais = pais_text.Text;
            pais.deletePais();
            Response.Redirect("~/Paises.aspx");
        }
    }
}