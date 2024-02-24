using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Net;
using System.Drawing;
using library;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Configuration;

namespace usuWeb
{
    public partial class Formulario_web2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e) {
            if(Session["nick"] != null) {
                Response.Redirect("~/paginaPrincipal.aspx");
            }
        }

        //Crea el usuario si los datos introducidos son correctos y guarda la imagen en el directorio imagenes.
        protected void createUsuario(object sender, EventArgs e)
        {
            ENUsuario usur;
            ENCarrito carrito;

            if (SoyFriki.Checked == true)
            {
                SoyFriki.Text = "Soy friki";
                if (FileUpload1.FileName == "")
                {
                    usur = new ENUsuario(Nick1.Text, Nombre1.Text, Apellidos1.Text, Contrasenya1.Text, Localidades.SelectedValue, Provincias.SelectedValue, Paises.SelectedValue, "DefaultUser.png", int.Parse(Edad1.Text), 0, 0);
                }
                else
                {
                    string nombreFoto = Nick1.Text + ".png";
                    usur = new ENUsuario(Nick1.Text, Nombre1.Text, Apellidos1.Text, Contrasenya1.Text, Localidades.SelectedValue, Provincias.SelectedValue, Paises.SelectedValue, nombreFoto, int.Parse(Edad1.Text), 0, 0);

                    string ruta = Server.MapPath("~/App_Images/Usuarios/") + nombreFoto;
                    FileUpload1.SaveAs(ruta);
                }


                if (usur.readUsuario() == false)
                {
                    if (usur.createUsuario() == false)
                    {
                        LabelError.Text = "No se ha podido crear el usuario, comprueba bien los datos";
                    }
                    else
                    {

                        string connection = ConfigurationManager.ConnectionStrings["Database"].ToString();
                        SqlConnection conex = new SqlConnection(connection);
                        conex.Open();

                        carrito = new ENCarrito();

                        string query = "SELECT MAX(num_carrito) AS max_numCarrito FROM Carrito";
                        SqlCommand command = new SqlCommand(query, conex);
                        int maxNumCarrito = Convert.ToInt32(command.ExecuteScalar());

                        conex.Close();

                        carrito.numeroCarrito = maxNumCarrito + 1;
                        carrito.usuario = Nick1.Text;
                        carrito.estadoCarrito = "Listo";

                        if (carrito.createCarrito() == false)
                        {
                            LabelError.Text = "Ha habido un error. Revise sus datos";
                            usur.deleteUsuario();
                        }
                        else
                        {
                            if (Request.QueryString["desde"] == "admin" && Session["admin"] != null)
                            {
                                Response.Redirect("~/VerUsuarios.aspx");
                            }
                            else
                            {
                                Response.Redirect("~/paginaPrincipal.aspx");
                            }
                        }

                    }
                }
                else
                {
                    LabelError.Text = "El Nick Name ya existe, por favor elija otro";
                }
            }
            else
            {

                SoyFriki.Text = "¿No eres friki?¿Y entonces que haces aqui?";
            }
        }

        //Comprueba que la provincia seleccionada pertenece al pais seleccionado en la lista de paises.
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

        //Comprueba que la localidad seleccionada pertenece a la provincia seleccionada en la lista de paises.
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