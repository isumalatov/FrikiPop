using library;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace usuWeb {
    public partial class paginaPrincipal : System.Web.UI.Page {

        private ENArticulo articulo = new ENArticulo();

        protected void Page_Load(object sender, EventArgs e) {

            //opción de cerrar sesión
            if (Request.QueryString["sesion"] == "cerrar") {
                Session.Remove("nick");
                Session.Remove("imagen");
                Session.Remove("admin");
                Response.Redirect("~/paginaPrincipal.aspx");
            }

            //aplicación de filtros
            if(Request.QueryString["param"] == "Merchan") {
                PrincipalListView.DataSource = articulo.filtrarPorTipo("Merchan");
                PrincipalListView.DataBind();
            } else if(Request.QueryString["param"] == "Videojuegos") {
                PrincipalListView.DataSource = articulo.filtrarPorTipo("Videojuego");
                PrincipalListView.DataBind();
            } else if(Request.QueryString["param"] == "Consolas") {
                PrincipalListView.DataSource = articulo.filtrarPorTipo("Consola");
                PrincipalListView.DataBind();
            } else {
                PrincipalListView.DataSource = articulo.usuarioArticulo("");
                PrincipalListView.DataBind();
            }
           
            //genera el banner de publicidad
            if (!IsPostBack) {
                string connectionString = ConfigurationManager.ConnectionStrings["Database"].ToString(); ;
                string tableName = "Publicidad";
                
                //crea una array donde almacenar todos los ids de la BD
                List<string> ids = new List<string>();

                using (SqlConnection connection = new SqlConnection(connectionString)) {
                    connection.Open();

                    // Obtener todos los valores de la columna id_publi
                    SqlCommand selectCommand = new SqlCommand($"SELECT id_publi FROM {tableName}", connection);
                    SqlDataReader reader = selectCommand.ExecuteReader();

                    //añade los ids a la array
                    while (reader.Read()) {
                        string id = reader["id_publi"].ToString();
                        ids.Add(id);
                    }

                    reader.Close();
                }

                //controla que haya más de una publicidad
                if (ids.Count > 0) {
                    Random random = new Random();

                    //genera un número aleatorio  entre 0 y el número de ids
                    int randomIndex = random.Next(0, ids.Count);
                    string randomId = ids[randomIndex];

                    // Utiliza el id aleatorio seleccionado para obtener el resto de los datos de la publicidad
                    using (SqlConnection connection = new SqlConnection(connectionString)) {
                        connection.Open();

                        //obtiene la imagen y link correspondientes a la publicidad elegida
                        SqlCommand selectCommand = new SqlCommand($"SELECT url_imagen, link_empresa FROM {tableName} WHERE id_publi = @id", connection);
                        selectCommand.Parameters.AddWithValue("@id", randomId);
                        SqlDataReader reader = selectCommand.ExecuteReader();

                        if (reader.Read()) {
                            string imageUrl = reader["url_imagen"].ToString();
                            string linkUrl = reader["link_empresa"].ToString();

                            // Asigna la URL de la imagen y la URL de redirección al control ImageButton
                            publicidad_imagen.ImageUrl = imageUrl;
                            publicidad_imagen.PostBackUrl = linkUrl;
                        }

                        reader.Close();
                    }
                }
            }

        }
    }
}