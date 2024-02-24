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
    public class CADArticulo
    {
        private String constring;

        public CADArticulo()
        {
            constring = ConfigurationManager.ConnectionStrings["Database"].ToString();
        }

        public bool createArticulo(ENArticulo articulo) //funcion para crear un articulo haciendo un insert
        {
            bool creado = false;
            SqlConnection conexion = null;

            try
            {
                conexion = new SqlConnection(constring);
                conexion.Open();

                string consulta = "Insert into Articulo (codigo,nombre,descripcion,precio,url_imagen,usuario,tipo) values ('" + articulo.codigo + "', '" + articulo.nombre + "' , '" + articulo.descripcion + "', " + articulo.precio + ", '" + articulo.urlImagen + "', '" + articulo.usuario + "' , '" + articulo.tipoArticulo + "')";
                SqlCommand command = new SqlCommand(consulta, conexion);

                command.ExecuteNonQuery();
                creado = true;

            }
            catch (SqlException e) //si hay excepcion tira un error
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

        public bool deleteArticulo(ENArticulo articulo) //borra uin articulo haciendo un delete
        {
            bool eliminado = false;
            SqlConnection conexion = null;

            try
            {
                conexion = new SqlConnection(constring);
                conexion.Open();

                string consulta = "Delete from Articulo where codigo = '" + articulo.codigo + "' and nombre = '" + articulo.nombre + "' and descripcion = '" + articulo.descripcion + "' and url_imagen = '" + articulo.urlImagen + "' and usuario = '" + articulo.usuario + "' and tipo = '" + articulo.tipoArticulo + "'";
                SqlCommand command = new SqlCommand(consulta, conexion);

                command.ExecuteNonQuery();
                eliminado = true;

            }
            catch (SqlException e) //si hay excepcion tira un error
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

        public bool readArticulo(ENArticulo articulo) //lee un articulo haciendo un select
        {
            bool leido = false;
            SqlConnection conexion = null;

            try
            {
                conexion = new SqlConnection(constring);
                conexion.Open();

                string consulta = "Select * from Articulo where codigo = '" + articulo.codigo + "'";

                SqlCommand command = new SqlCommand(consulta, conexion);

                SqlDataReader busqueda = command.ExecuteReader();
                busqueda.Read();

                if (busqueda.HasRows)
                {
                    if (busqueda["codigo"].ToString() == articulo.codigo)
                    {
                        articulo.codigo = busqueda["codigo"].ToString();
                        articulo.nombre = busqueda["nombre"].ToString();
                        articulo.descripcion = busqueda["descripcion"].ToString();
                        articulo.precio = Convert.ToDouble(busqueda["precio"]);
                        articulo.urlImagen = busqueda["url_imagen"].ToString();
                        articulo.usuario = busqueda["usuario"].ToString();
                        articulo.tipoArticulo = busqueda["tipo"].ToString();
                        leido = true;
                    }
                }

                busqueda.Close();

            }
            catch (SqlException e) //si hay excepcion tira un error
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

        public bool updateArticulo(ENArticulo articulo) //actualiza un articulo haciendo un update
        {
            SqlConnection connection = new SqlConnection(constring);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("UPDATE [dbo].[Articulo] set codigo = '" + articulo.codigo + "' , nombre = '" + articulo.nombre + "' , descripcion = '" + articulo.descripcion + "' , precio = '" + articulo.precio + "' , url_imagen = '" + articulo.urlImagen + "' , usuario = '" + articulo.usuario + "' , tipo = '" + articulo.tipoArticulo + "'", connection);
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception e) //si hay excepcion tira un error
            {
                Console.WriteLine("User operation has failed. Error: {0}", e.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public DataTable usuarioArticulo(string usuarioArticulo) //devuelve los articulos de un usuario
        {
            DataTable tabla = new DataTable();
            SqlConnection conexion = null;

            try
            {
                conexion = new SqlConnection(constring);
                string consulta = null;
                if (usuarioArticulo == "")
                {
                    consulta = "Select * from Articulo";
                }
                else
                {
                    consulta = "Select * from Articulo where usuario = '" + usuarioArticulo + "'";
                }
                SqlDataAdapter data = new SqlDataAdapter(consulta, conexion);
                data.Fill(tabla);

            }
            catch (SqlException e) //si hay excepcion tira un error
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

        public string getMaxID() { //devuelve el MaxID
            int max = 0;
            string result = null;
            SqlConnection conexion = null;
            try {
                conexion = new SqlConnection(constring);
                conexion.Open();

                string query = "SELECT codigo FROM Articulo";
                SqlCommand command = new SqlCommand(query, conexion);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read()) {
                    if (reader.HasRows) {
                        if (max < int.Parse(reader["codigo"].ToString())) {
                            max = int.Parse(reader["codigo"].ToString());
                            result = reader["codigo"].ToString();
                        }
                    }
                }

                reader.Close();

            } catch (SqlException e) { //si hay excepcion tira un error
                Console.WriteLine("The operation has failed.Error: {0}", e.Message); 
            } catch (Exception e) {
                Console.WriteLine("The operation has failed.Error: {0}", e.Message);
            } finally {
                if(conexion.State == ConnectionState.Open) {
                    conexion.Close();
                }
            }

            return result;
        }

        public DataTable filtrarPorTipo(string tipo) { //filtra los articulos haciendo un select
            DataTable tabla = new DataTable();
            SqlConnection conexion = null;

            try {
                conexion = new SqlConnection(constring);
                string consulta = null;
                if (tipo == "") {
                    consulta = "Select * from Articulo";
                } else {
                    consulta = "Select * from Articulo where tipo = '" + tipo + "'";
                }
                SqlDataAdapter data = new SqlDataAdapter(consulta, conexion);
                data.Fill(tabla);
 
            } catch (SqlException e) { //si hay excepcion tira un error
                Console.WriteLine("The operation has failed.Error: {0}", e.Message);
            } catch (Exception e) {
                Console.WriteLine("The operation has failed.Error: {0}", e.Message);
            } finally {
                if (conexion.State == ConnectionState.Open) {
                    conexion.Close();
                }
            }
            return tabla;
        }

        public bool cambiarUsuario(ENArticulo articulo, string nuevoUsuario) {
            bool actualizado = false;
            SqlConnection conexion = null;

            try {
                conexion = new SqlConnection(constring);
                conexion.Open();

                string consulta = "Update Articulo set usuario = '" + nuevoUsuario + "' where codigo = '" + articulo.codigo + "'";
                SqlCommand comando = new SqlCommand(consulta, conexion);

                comando.ExecuteNonQuery();

                actualizado = true;

            } catch(SqlException e) {
                Console.WriteLine("The operation has failed.Error: {0}", e.Message);
            } catch(Exception e) {
                Console.WriteLine("The operation has failed.Error: {0}", e.Message);
            } finally {
                if(conexion.State == ConnectionState.Open) {
                    conexion.Close();
                }
            }

            return actualizado;
        }
    }
}
