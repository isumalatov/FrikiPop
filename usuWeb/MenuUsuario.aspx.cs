using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace usuWeb {
    public partial class MenuUsuario : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if(Session["nick"] == null) {
                Response.Redirect("~/Usuario.aspx");
            }
        }

        protected void modificarUsuario_Click(object sender, EventArgs e) {
            string sigPag = "~/modificarUsuario.aspx?nick=" + (string)Session["nick"];
            Response.Redirect(sigPag);
        }
    }
}