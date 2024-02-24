using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using library;

namespace usuWeb {
    public partial class modificarUsuario : System.Web.UI.Page {

        private ENUsuario modUsuario;
        protected void Page_Load(object sender, EventArgs e) {
            if(Session["admin"] != null) {

                string desde = Request.QueryString["desde"];
                string usuario = Request.QueryString["nick"];

                if(desde == null) {
                    if(usuario == (string)Session["nick"]) {

                        modUsuario = new ENUsuario();

                        modUsuario.nick = usuario;

                    } else {
                        Response.Redirect("~/paginaPrincipal.aspx");
                    }

                }else {
                    if(desde == "admin" && (int)Session["admin"] == 1) {

                        modUsuario = new ENUsuario();

                        modUsuario.nick = usuario;

                    } else {
                        Response.Redirect("~/paginaPrincipal.aspx");
                    }
                }

            } else {
                Response.Redirect("~/Usuario.aspx");
            }
        }

        protected void modificarUsuario_Click(object sender, EventArgs e) {
            ENUsuario usuarioLeido = new ENUsuario();
            usuarioLeido.nick = modUsuario.nick;

            if (usuarioLeido.readUsuario()) {

                if (Nombre1.Text != "") {
                    modUsuario.nombre = Nombre1.Text;
                } else {
                    modUsuario.nombre = usuarioLeido.nombre;
                }

                if (Apellidos1.Text != "") {
                    modUsuario.apellidos = Apellidos1.Text;
                } else {
                    modUsuario.apellidos = usuarioLeido.apellidos;
                }

                if (Edad1.Text != "") {
                    modUsuario.edad = int.Parse(Edad1.Text);
                } else {
                    modUsuario.edad = usuarioLeido.edad;
                }

                if (Contrasenya1.Text != "") {
                    modUsuario.contrasenya = Contrasenya1.Text;
                } else {
                    modUsuario.contrasenya = usuarioLeido.contrasenya;
                }

                modUsuario.pais = Paises.SelectedValue;
                modUsuario.provincia = Provincias.SelectedValue;
                modUsuario.localidad = Localidades.SelectedValue;
    
                modUsuario.imagen = usuarioLeido.imagen;

                modUsuario.numVentas = usuarioLeido.numVentas;

                modUsuario.admin = usuarioLeido.admin;

                if (modUsuario.updateUsuario() == true)
                {
                    LabelError.Text = "Los datos se han actualizado correctamente en nuestra Base de Datos.";
                }
                else
                {
                    LabelError.Text = "Comprueba bien tus datos";
                }

            } else {
                LabelError.Text = "Hay un problema con el nick. No se ha podido realizar la operacion.";
            }
            

        }

        protected void Provincias_SelectedIndexChanged(object sender, EventArgs e)
        {
            ENProvincia provincia = new ENProvincia();
            provincia.provincia = Provincias.SelectedValue;
            provincia.pais = Paises.SelectedValue;

            if (provincia.readProvincia() == false)
            {
                LabelErrorProvincia.Text = "La provincia seleccionada es incorrecta";
                LabelErrorLocalidad.Text = "";
            }
            else
            {
                LabelErrorProvincia.Text = "";
                LabelErrorLocalidad.Text = "";
            }
        }

        protected void Localidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            ENLocalidad localidad = new ENLocalidad();
            localidad.localidad = Localidades.SelectedValue;
            localidad.provincia = Provincias.SelectedValue;
            localidad.pais = Paises.SelectedValue;

            if (localidad.readLocalidad() == false)
            {
                LabelErrorLocalidad.Text = "La localidad seleccionada es incorrecta";
            }
            else
            {
                LabelErrorLocalidad.Text = "";
            }
        }
    }
}