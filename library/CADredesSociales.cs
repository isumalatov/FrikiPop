using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.Sql;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Data.Common;

namespace library
{
    public class CADredesSociales
    {
        private String constring;

        public CADredesSociales()
        {
            constring = ConfigurationManager.ConnectionStrings["Database"].ToString();
        }

        public bool createRedesSociales(ENredesSociales redesSociales) //funcion que crea una red social con un insert
        {
            bool creado = false;
            SqlConnection conexion = null;

            try
            {
                conexion = new SqlConnection(constring);
                conexion.Open();

                string consulta = "Insert into RedesSociales (red, url_logo, link_red) values ('" + redesSociales.red + "', '" + redesSociales.urlLogo + "' , '" + redesSociales.linkRed + "')";
                SqlCommand command = new SqlCommand(consulta, conexion);

                command.ExecuteNonQuery();
                creado = true;

            }
            catch (SqlException e) //si hay una excepcion tira un error
            {
                Console.WriteLine("User operation has failed. Error: {0}", e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("User operation has failed. Error: {0}", e.Message);
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
            return creado;
        }

        public bool deleteRedesSociales(ENredesSociales redesSociales) //funcion que borra una red social con un delete
        {
            bool eliminado = false;
            SqlConnection conexion = null;

            try
            {
                conexion = new SqlConnection(constring);
                conexion.Open();

                string consulta = "Delete from RedesSociales where red = '" + redesSociales.red + "' and url_logo = '" + redesSociales.urlLogo + "' and link_red = '" + redesSociales.linkRed + "'";
                SqlCommand command = new SqlCommand(consulta, conexion);

                command.ExecuteNonQuery();
                eliminado = true;

            }
            catch (SqlException e) //si hay una excepcion tira un error
            {
                Console.WriteLine("User operation has failed.Error: {0}", e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("User operation has failed.Error: {0}", e.Message);
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }

            return eliminado;
        }

        public bool readRedesSociales(ENredesSociales redesSociales) //lee una red social mediante un select
        {
            bool leido = false;
            SqlConnection conexion = null;

            try
            {
                conexion = new SqlConnection(constring);
                conexion.Open();

                string consulta = "Select * from RedesSociales where red = '" + redesSociales.red + "' and url_logo = '" + redesSociales.urlLogo + "' and link_red = '" + redesSociales.linkRed + "'";
                SqlCommand command = new SqlCommand(consulta, conexion);

                SqlDataReader busqueda = command.ExecuteReader();
                busqueda.Read();

                if (busqueda.HasRows)
                {
                    if (busqueda["red"].ToString() == redesSociales.red &&
                            busqueda["url_logo"].ToString() == redesSociales.urlLogo &&
                            busqueda["link_red"].ToString() == redesSociales.linkRed)
                    {
                        redesSociales.red = busqueda["red"].ToString();
                        redesSociales.urlLogo = busqueda["url_logo"].ToString();
                        redesSociales.linkRed = busqueda["link_red"].ToString();
                        leido = true;
                    }
                }

                busqueda.Close();

            }
            catch (SqlException e) //si hay una excepcion tira un error
            {
                Console.WriteLine("User operation has failed. Error: {0}", e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("User operation has failed. Error: {0}", e.Message);
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }

            return leido;
        }

        public bool updateRedesSociales(ENredesSociales redesSociales) //actualiza una red social con un update
        {
            SqlConnection connection = new SqlConnection(constring);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("UPDATE [dbo].[RedesSociales] set red = '" + redesSociales.red + "', url_logo = '" + redesSociales.urlLogo + "', link_red = '" + redesSociales.linkRed + "'", connection);
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception e) //si hay una excepcion tira un error
            {
                Console.WriteLine("User operation has failed. Error: {0}", e.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public DataTable listarRedesSociales() //lista las redes sociales con un select
        {
            DataTable tabla = new DataTable();
            SqlConnection conexion = null;

            try
            {
                conexion = new SqlConnection(constring);
                string consulta = "";

                consulta = "Select * from RedesSociales";

                SqlDataAdapter data = new SqlDataAdapter(consulta, conexion);
                data.Fill(tabla);

            }
            catch (SqlException e) //si hay una excepcion tira un error
            {
                Console.WriteLine("The operation has failed.Error: {0}", e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("The operation has failed.Error: {0}", e.Message);
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
            return tabla;
        }
    }
}
