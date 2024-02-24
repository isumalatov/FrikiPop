using library;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace usuWeb {
    public partial class Tarjeta : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

            if (Session["nick"] != null && (int)Session["admin"] == 1) {
                ENTarjeta tarjeta = new ENTarjeta();

                GridView.DataSource = tarjeta.listarTarjetas();
                GridView.DataBind();
                Message.Text = "";
            }
            else {
                Response.Redirect("~/SignUp.aspx");
            }
        }

        protected bool DataValidation(ENTarjeta tarjeta) {

            if (long.TryParse(num.Text, out long num_tarj) && num.Text.Length == 16) {
                tarjeta.num = num.Text;
            }
            else {
                Message.Text = "Formato del nº de tarjeta INCORRECTO!";
                return false;
            }

            if (int.TryParse(fechaMes.Text, out int mes_tarj) && (fechaMes.Text.Length == 2 || fechaMes.Text.Length == 1) && mes_tarj > 0 && mes_tarj < 13) {
                tarjeta.mesFecha = mes_tarj;
            }
            else {
                Message.Text = "Formato del mes INCORRECTO!";
                return false;
            }

            if (int.TryParse(fechaAnyo.Text, out int anyo_tarj) && fechaAnyo.Text.Length == 4 && anyo_tarj > 2023 && anyo_tarj < 2030) {
                tarjeta.anyoFecha = anyo_tarj;
            }
            else {
                Message.Text = "Formato del año INCORRECTO!";
                return false;
            }

            if (int.TryParse(cvvTarj.Text, out int cvv_int) && cvvTarj.Text.Length == 3) {
                tarjeta.cvv = cvvTarj.Text;
            }
            else {
                Message.Text = "Formato del cvv INCORRECTO!";
                return false;
            }

            tarjeta.usuario = usuario.Text;

            return true;
        }

        protected void anyadir_Click(object sender, EventArgs e) {
            ENTarjeta tarjeta = new ENTarjeta();

            if (DataValidation(tarjeta)) {
                tarjeta.createTarjeta();
            }
            
            Response.Redirect("~/Tarjetas.aspx");

        }

        protected void borrar_Click(object sender, EventArgs e) {
            ENTarjeta tarjeta = new ENTarjeta();

            if(DataValidation(tarjeta)) {
                tarjeta.deleteTarjeta();
            }

            Response.Redirect("~/Tarjetas.aspx");
        }

        protected void actualizar_Click(object sender, EventArgs e) {
            ENTarjeta tarjeta = new ENTarjeta();

            if (DataValidation(tarjeta)) {
                tarjeta.updateTarjeta();
            }

            Response.Redirect("~/Tarjetas.aspx");
        }
    }
}