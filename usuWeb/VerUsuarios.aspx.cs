using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using library;

namespace usuWeb
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] == null || (int)Session["admin"] != 1) {
                Response.Redirect("~/paginaPrincipal.aspx");
            }
            ENUsuario usuario = new ENUsuario();
            GridView1.DataSource = usuario.listarUsuarios();
            GridView1.DataBind();
        }

        //Pasa por parametro una variable llamada desde igualandola a admin. Asi reutilizo la interfaz de signUp para crear un usuario nuevo.
        protected void CrearUsuario(object sender, EventArgs e)
        {
            Response.Redirect("~/SignUp.aspx?desde=admin");
        }

        //Elimina el usuario cuyo nick es el especificado en el cuadro de texto encima del boton Eliminar Usuario.
        protected void EliminarUsuario(object sender, EventArgs e)
        {
            ENUsuario usur = new ENUsuario();
            usur.nick = eliminar.Text;
            if(usur.deleteUsuario() == true)
            {
                LabelError.Text = "Se ha eliminado correctamente el usuario: " + eliminar.Text;
            }
            else
            {
                LabelError.Text = "No se ha podido eliminar el usuario: " + eliminar.Text;
            }
            Response.Redirect("~/VerUsuarios.aspx");
        }

        //Metodo encargado de realizar el filtro especificado en el desplegable segun el valor pasado en el cuadro de texto.
        protected void Filtrar_Valores(object sender, EventArgs e)
        {
            if (filtros.SelectedItem == valorInicial)
            {
                faltaLista.Text = "Tiene que seleccionar antes un valor de la lista";
                faltaValorParaFiltrar.Text = "";
            }
            else if (valorParaFiltrar.Text == "")
            {
                faltaLista.Text = "";
                faltaValorParaFiltrar.Text = "Tiene que escribir una valor que quiera filtrar";
            }
            else if (filtros.SelectedItem == nick)
            {
                ENUsuario usuario = new ENUsuario();
                GridView1.DataSource = usuario.filtrarPorNick(valorParaFiltrar.Text);
                GridView1.DataBind();

                if (faltaLista.Text != "")
                {
                    faltaLista.Text = "";
                }

                if (faltaValorParaFiltrar.Text != "")
                {
                    faltaValorParaFiltrar.Text = "";
                }

            }
            else if (filtros.SelectedItem == nombre)
            {
                ENUsuario usuario = new ENUsuario();
                GridView1.DataSource = usuario.filtrarPorNombre(valorParaFiltrar.Text);
                GridView1.DataBind();

                if (faltaLista.Text != "")
                {
                    faltaLista.Text = "";
                }

                if (faltaValorParaFiltrar.Text != "")
                {
                    faltaValorParaFiltrar.Text = "";
                }

            }
            else if (filtros.SelectedItem == apellidos)
            {
                ENUsuario usuario = new ENUsuario();
                GridView1.DataSource = usuario.filtrarPorApellidos(valorParaFiltrar.Text);
                GridView1.DataBind();

                if (faltaLista.Text != "")
                {
                    faltaLista.Text = "";
                }

                if (faltaValorParaFiltrar.Text != "")
                {
                    faltaValorParaFiltrar.Text = "";
                }

            }
            else if (filtros.SelectedItem == edad)
            {
                ENUsuario usuario = new ENUsuario();
                GridView1.DataSource = usuario.filtrarPorEdad(int.Parse(valorParaFiltrar.Text));
                GridView1.DataBind();

                if (faltaLista.Text != "")
                {
                    faltaLista.Text = "";
                }

                if (faltaValorParaFiltrar.Text != "")
                {
                    faltaValorParaFiltrar.Text = "";
                }

            }
            else if (filtros.SelectedItem == localidad)
            {
                ENUsuario usuario = new ENUsuario();
                GridView1.DataSource = usuario.filtrarPorLocalidad(valorParaFiltrar.Text);
                GridView1.DataBind();

                if (faltaLista.Text != "")
                {
                    faltaLista.Text = "";
                }

                if (faltaValorParaFiltrar.Text != "")
                {
                    faltaValorParaFiltrar.Text = "";
                }

            }
            else if (filtros.SelectedItem == provincia)
            {
                ENUsuario usuario = new ENUsuario();
                GridView1.DataSource = usuario.filtrarPorProvincia(valorParaFiltrar.Text);
                GridView1.DataBind();

                if (faltaLista.Text != "")
                {
                    faltaLista.Text = "";
                }

                if (faltaValorParaFiltrar.Text != "")
                {
                    faltaValorParaFiltrar.Text = "";
                }

            }
            else if (filtros.SelectedItem == pais)
            {
                ENUsuario usuario = new ENUsuario();
                GridView1.DataSource = usuario.filtrarPorPais(valorParaFiltrar.Text);
                GridView1.DataBind();

                if (faltaLista.Text != "")
                {
                    faltaLista.Text = "";
                }

                if (faltaValorParaFiltrar.Text != "")
                {
                    faltaValorParaFiltrar.Text = "";
                }

            }
            else if (filtros.SelectedItem == administrador)
            {
                ENUsuario usuario = new ENUsuario();
                GridView1.DataSource = usuario.filtrarPorAdministrador(int.Parse(valorParaFiltrar.Text));
                GridView1.DataBind();
                
                if(faltaLista.Text != "")
                {
                    faltaLista.Text = "";
                }

                if(faltaValorParaFiltrar.Text != "")
                {
                    faltaValorParaFiltrar.Text = "";
                }

            }
        }

        ///Al seleccionar el indice se cambia el valor de la casilla administrador del usuario seleccionado
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ENUsuario usur = new ENUsuario();
            usur.nick = GridView1.Rows[GridView1.SelectedIndex].Cells[2].Text;
            usur.readUsuario();

            if(int.Parse(GridView1.Rows[GridView1.SelectedIndex].Cells[8].Text) == 1)
            {
                usur.ModificarAdmin(0, GridView1.SelectedIndex);
            }
            else
            {
                usur.ModificarAdmin(1, GridView1.SelectedIndex);
            }
            Response.Redirect("~/VerUsuarios.aspx");
        }

        //Al hacer click sobre el boton editar te redirije a la pagina modificarUsuario. Pasa por parametro una variable desde para saber que voy desde admin.
        protected void Editar(object sender, GridViewEditEventArgs e)
        {
            int index = e.NewEditIndex;
            GridViewRow row = GridView1.Rows[index];
            string usuario = row.Cells[2].Text;
            Response.Redirect("~/modificarUsuario.aspx?desde=admin&nick="+ usuario);
        }
    }
}