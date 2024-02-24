using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data;
using System.Configuration;
using library;

namespace usuWeb
{
    public partial class Formulario_web12 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //declaro la varibale pos inicializado en 0
            int pos = 0;
            //si existe un valor en la sesión con la clave "admin", da valor a pos
            if (Session["admin"] != null)
            {
               pos = int.Parse(Session["admin"].ToString());
            }
            //si inicia session como admin podrá entrar a ver las estadísticas
            if (pos == 1)
            {
                //realiza la conexión con la base de datos
                string s = ConfigurationManager.ConnectionStrings["Database"].ToString();
                DataSet bdvirtual = new DataSet();
                SqlConnection c = new SqlConnection(s);
                //obtiene datos de la tabla "Usuario" y ordenarlos por "numVentas" de forma descendente.
                SqlDataAdapter da = new SqlDataAdapter("SELECT [nick_name], [nombre], [apellidos],[numVentas] FROM [Usuario] ORDER BY [numVentas] desc", c);
                da.Fill(bdvirtual, 0, 10, "Usuario");
                //grafica
                Grafica1.DataSource = bdvirtual;
                Grafica1.DataBind();
                //tabla
                topUsuarios.DataSource = bdvirtual;
                topUsuarios.DataBind();

                string s2 = ConfigurationManager.ConnectionStrings["Database"].ToString();
                DataSet bdvirtual2 = new DataSet();
                SqlConnection c2 = new SqlConnection(s2);
                SqlDataAdapter da2 = new SqlDataAdapter("SELECT [tipo],[numVentas] FROM [TipoArticulo] order by [numVentas] DESC ", c2);

                da2.Fill(bdvirtual2, 0, 10, "TipoArticulo");

                Grafica2.DataSource = bdvirtual2;
                Grafica2.DataBind();

                topTipoArticulos.DataSource = bdvirtual2;
                topTipoArticulos.DataBind();

            }
            else
                //si no esta en la sesion del admin le redirige a la pagina principal
                Response.Redirect("paginaPrincipal.aspx");
        }
    }
}