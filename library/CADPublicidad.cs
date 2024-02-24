using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    public class CADPublicidad
    {
        private string constring;

        //Constructor por defecto
        public CADPublicidad()
        {
            constring = ConfigurationManager.ConnectionStrings["Database"].ToString();
        }

        //Crea la publicidad pasada como parámetro
        public bool createPublicidad(ENPublicidad publicidad)
        {
            SqlConnection connection = new SqlConnection(constring);
            try {
                connection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO [dbo].[Publicidad](id_publi, id_empresa, url_imagen, link_empresa) VALUES('" + publicidad.id + "', '" + publicidad.empresa + "', '"+ publicidad.imagen+ "', '"+ publicidad.url_empresa+ "')", connection);
                command.ExecuteNonQuery();
                return true;
            }
            catch(Exception e) {
                Console.WriteLine("Create PUBLICIDAD has failed. Error: {0}", e.Message);
                return false;
            }
            finally {
                connection.Close();
            }
        }

        //Lee la publicidad pasada como parámetro
        public bool readPublicidad(ENPublicidad publicidad)
        {
            SqlConnection connection = new SqlConnection(constring);
            try {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM [dbo].[Publicidad] where id_publi= '"+ publicidad.id+ "'", connection);
                command.ExecuteNonQuery();
                return true;
            }
            catch(Exception e) {
                Console.WriteLine("Reading PUBLICIDAD has failed. Error= {0}", e.Message);
                return false;
            }
            finally {
                connection.Close();
            }
        }
        //Actualiza la publicidad actual por la pasada por parámetro
        public bool updatePublicidad(ENPublicidad publicidad)
        {
            SqlConnection connection = new SqlConnection(constring);
            try {
                connection.Open();
                SqlCommand command = new SqlCommand("UPDATE [dbo].[Publicidad] set id_publi= '" + publicidad.id + "', id_empresa= '" + publicidad.empresa + "', url_imagen= '" + publicidad.imagen + "', link_empresa= '" + publicidad.url_empresa+ "' where id_publi= '"+ publicidad.id+"'", connection);
                command.ExecuteNonQuery();
                return true;
            }
            catch(Exception e) {
                Console.WriteLine("Updating PUBLICIDAD table has failed. Error= {0}", e.Message);
                return false;
            }
            finally {
                connection.Close();
            }
        }
        //Borra la publicidad pasada como parámetro si existe
        public bool deletePublicidad(ENPublicidad publicidad)
        {
            SqlConnection connection = new SqlConnection(constring);
            try {
                connection.Open();
                SqlCommand command = new SqlCommand("DELETE FROM [dbo].[Publicidad] where id_publi= '" + publicidad.id+ "'", connection);
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception e) {
                Console.WriteLine("Deleting PUBLICIDAD table has failed. Error= {0}", e.Message);
                return false;
            }
            finally {
                connection.Close();
            }
        }

        //Lista la publicidad
        public DataTable listarPublicidad() {
            DataTable table = new DataTable();
            SqlConnection connection = new SqlConnection(constring);

            try {
                SqlDataAdapter data = new SqlDataAdapter("Select * from Publicidad", connection);
                data.Fill(table);
            }
            catch (Exception e) {
                Console.WriteLine("The operation has failed.Error: {0}", e.Message);
            }
            finally {
                if (connection.State == ConnectionState.Open) {
                    connection.Close();
                }
            }

            return table;
        }
    }
}
