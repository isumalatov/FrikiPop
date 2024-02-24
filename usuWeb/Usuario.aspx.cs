using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using library;

namespace usuWeb
{
    public partial class Formulario_web11 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e) {
            if(Session["nick"] != null) {
                Response.Redirect("~/paginaPrincipal.aspx");
            }
        }

        //Si el usuario es correcto añade las propiedades imagen, nick, admin a la session. En caso contrario enseña un mensaje de error
        protected void LogIn(object sender, EventArgs e)
        {

            if (Session["nick"] != null)
            {
                Response.Redirect("~/paginaPrincipal.aspx");
            }

            ENUsuario en = new ENUsuario();
            en.nick = Nick.Text;
            if (en.readUsuario() == true && en.contrasenya == Contrasenya.Text)
            {
                Session.Add("imagen", en.imagen);
                Session.Add("nick", en.nick);
                Session.Add("admin", en.admin);

                Response.Redirect("~/paginaPrincipal.aspx");
            }
            else
            {
                LabelError.Text = "No apareces en nuestra base de datos";
            }
        }
    }
}