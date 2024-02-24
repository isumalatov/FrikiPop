using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace library {
    public class CADTipoArticulo {

        private String constring;

        public CADTipoArticulo() {
            constring = ConfigurationManager.ConnectionStrings["Database"].ToString();
        }

        public bool createTipoArticulo(ENTipoArticulo en) {
            bool creado = false;
            SqlConnection conexion = null;

            try {
                conexion = new SqlConnection(constring);
                conexion.Open();

                string consulta = "Insert into TipoArticulo tipo values ('" + en.tipoArticulo + "', 0)";
                SqlCommand command = new SqlCommand(consulta, conexion);

                command.ExecuteNonQuery();
                creado = true;

            }
            catch (SqlException e) {
                Console.WriteLine("User operation has failed. Error: {0}", e.Message);
            }
            catch (Exception e) {
                Console.WriteLine("User operation has failed. Error: {0}", e.Message);
            }
            finally {
                if (conexion.State == ConnectionState.Open) {
                    conexion.Close();
                }
            }
            return creado;
        }

        public bool deleteTipoArticulo(ENTipoArticulo en) {
            bool eliminado = false;
            SqlConnection connection = null;

            try {
                connection = new SqlConnection(constring);
                connection.Open();

                string consulta = "Delete from TipoArticulo where tipo = '" + en.tipoArticulo + "'";
                SqlCommand command = new SqlCommand(consulta, connection);

                command.ExecuteNonQuery();
                eliminado = true;

            }
            catch (SqlException e) {
                Console.WriteLine("User operation has failed.Error: {0}", e.Message);
            }
            catch (Exception e) {
                Console.WriteLine("User operation has failed.Error: {0}", e.Message);
            }
            finally {
                if (connection.State == ConnectionState.Open) {
                    connection.Close();
                }
            }

            return eliminado;
        }

        public bool readTipoArticulo(ENTipoArticulo en) {
            bool leido = false;
            SqlConnection connection = null;

            try {
                connection = new SqlConnection(constring);
                connection.Open();

                string consulta = "Select * from TipoArticulo where tipo = '" + en.tipoArticulo + "'";
                SqlCommand command = new SqlCommand(consulta, connection);

                SqlDataReader busqueda = command.ExecuteReader();
                busqueda.Read();

                if (busqueda.HasRows) {
                    if (busqueda["tipoArticulo"].ToString() == en.tipoArticulo) {
                        en.tipoArticulo = busqueda["tipoArticulo"].ToString();
                        en.numVentas = int.Parse(busqueda["numVentas"].ToString());
                        leido = true;
                    }
                }
                busqueda.Close();
            }
            catch (SqlException e) {
                Console.WriteLine("User operation has failed. Error: {0}", e.Message);
            }
            catch (Exception e) {
                Console.WriteLine("User operation has failed. Error: {0}", e.Message);
            }
            finally {
                if (connection.State == ConnectionState.Open) {
                    connection.Close();
                }
            }

            return leido;
        }

        public bool updateTipoArticulo(ENTipoArticulo en) {
            string consulta = "UPDATE [dbo].[tipoArticulo] set tipo= '" + "'";
            SqlConnection connection = new SqlConnection(constring);
            try {
                connection.Open();
                SqlCommand command = new SqlCommand(consulta, connection);
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception e) {
                Console.WriteLine("Updating TipoArticulo table has failed. Error= {0}", e.Message);
                return false;
            }
            finally {
                connection.Close();
            }
        }

        public bool incrementarNumeroVentas(ENTipoArticulo tipoArticulo) {
            bool incrementado = false;
            SqlConnection conexion = null;

            try {
                conexion = new SqlConnection(constring);
                conexion.Open();

                string consulta = "Update TipoArticulo set numVentas = numVentas + 1 where tipo = '" + tipoArticulo.tipoArticulo +"'";
                SqlCommand comando = new SqlCommand(consulta, conexion);

                comando.ExecuteNonQuery();

                incrementado = true;

            } catch(SqlException e) {
                Console.WriteLine("User operation has failed. Error: {0}", e.Message);
            } catch(Exception e) {
                Console.WriteLine("User operation has failed. Error: {0}", e.Message);
            } finally {
                if(conexion.State == ConnectionState.Open) {
                    conexion.Close();
                }
            }

            return incrementado;
        }
    }
}
