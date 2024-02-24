using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace library
{
    /// <summary>
    /// Esta clase es la encargada de realizar operaciones solo la base de datos.
    /// </summary>
    public class CADUsuario
    {
        private string constring;

        //El contructor lo que hace es guardar la cadena de coneccion en la propiedad de esta clase
        public CADUsuario()
        {
            constring = ConfigurationManager.ConnectionStrings["Database"].ToString();
        }

        public bool createUsuario(ENUsuario en)
        {
            SqlConnection conn = null;
            // Encapsula todo el acceso a datos dentro del try

            String comando = "Insert into [dbo].[Usuario] (nick_name,nombre,apellidos,edad,contrasenya,url_imagen,admin,localidad,provincia,pais,numVentas)" +
                "                            VALUES('" + en.nick + "','" + en.nombre + "','" + en.apellidos + "'," + en.edad +
                                                    ",'" + en.contrasenya + "','" + en.imagen + "'," + en.admin + "," +
                                                    "'" + en.localidad + "','" + en.provincia + "','" + en.pais + "'," + en.numVentas + ")";
            try
            {
                conn = new SqlConnection(constring);
                conn.Open();
                SqlCommand cmd = new SqlCommand(comando, conn);
                if (cmd.ExecuteNonQuery() == 0)
                {
                    return false;
                }
                return true;
            }
            catch (SqlException sqlex)
            {
                Console.WriteLine("User operation has failed.Error: " + sqlex.Message);
                return false;
            }
            catch (Exception ex)
            {

                Console.WriteLine("User operation has failed.Error: " + ex.Message);
                return false;
            }
            finally
            {
                if (conn != null) conn.Close(); // Se asegura de cerrar la conexión.
            }
        }

        //Devuelve solo el usuario indicado leído de la BD.
        public bool readUsuario(ENUsuario en)
        {
            SqlConnection conn = null;
            // Encapsula todo el acceso a datos dentro del try
            String comando = "Select * from [dbo].[Usuario] where nick_name = '" + en.nick + "'";
            try
            {
                conn = new SqlConnection(constring);
                conn.Open();
                SqlCommand cmd = new SqlCommand(comando, conn);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    en.nombre = dr["nombre"].ToString();
                    en.apellidos = dr["apellidos"].ToString();
                    en.edad = int.Parse(dr["edad"].ToString());
                    en.contrasenya = dr["contrasenya"].ToString();
                    en.imagen = dr["url_imagen"].ToString();
                    en.admin = int.Parse(dr["admin"].ToString());
                    en.numVentas = int.Parse(dr["numVentas"].ToString());
                    dr.Close();
                    return true;
                }

                dr.Close();
                return false;
            }
            catch (SqlException sqlex)
            {

                Console.WriteLine("User operation has failed.Error: " + sqlex.Message);
                return false;
            }
            catch (Exception ex)
            {

                Console.WriteLine("User operation has failed.Error: " + ex.Message);
                return false;
            }
            finally
            {
                if (conn != null) conn.Close(); // Se asegura de cerrar la conexión.
            }
        }

        //: Actualiza los datos de un usuario en la BD con los datos del usuario
        //representado por el parámetro en.
        public bool updateUsuario(ENUsuario en)
        {
            SqlConnection conn = null;
            // Encapsula todo el acceso a datos dentro del try
            String comando = "UPDATE [dbo].[Usuario] SET edad = " + en.edad + ",nombre = '" + en.nombre +
                                        "',apellidos = '" + en.apellidos + "',contrasenya = '" + en.contrasenya +
                                        "',localidad = '" + en.localidad + "',provincia = '" + en.provincia + "',pais = '" + en.pais +
                                        "', url_imagen = '" + en.imagen + "', admin = " + en.admin + ", numVentas = " + en.numVentas + " where nick_name = '" + en.nick + "'";

            try
            {
                conn = new SqlConnection(constring);
                conn.Open();
                SqlCommand cmd = new SqlCommand(comando, conn);

                if (cmd.ExecuteNonQuery() == 0)
                {
                    return false;
                }
                return true;
            }
            catch (SqlException sqlex)
            {

                Console.WriteLine("User operation has failed.Error: " + sqlex.Message);
                return false;
            }
            catch (Exception ex)
            {

                Console.WriteLine("User operation has failed.Error: " + ex.Message);
                return false;
            }
            finally
            {
                if (conn != null) conn.Close(); // Se asegura de cerrar la conexión.
            }
        }

        //: Borra el usuario representado
        //  en EN de la BD.
        public bool deleteUsuario(ENUsuario en)
        {
            SqlConnection conn = null;
            // Encapsula todo el acceso a datos dentro del try
            String comando = "DELETE FROM [dbo].[Usuario] WHERE nick_name = '" + en.nick + "'";

            try
            {
                conn = new SqlConnection(constring);
                conn.Open();
                SqlCommand cmd = new SqlCommand(comando, conn);

                if (cmd.ExecuteNonQuery() == 0)
                {
                    return false;
                }
                return true;
            }
            catch (SqlException sqlex)
            {

                Console.WriteLine("User operation has failed.Error: " + sqlex.Message);
                return false;
            }
            catch (Exception ex)
            {

                Console.WriteLine("User operation has failed.Error: " + ex.Message);
                return false;
            }
            finally
            {
                if (conn != null) conn.Close(); // Se asegura de cerrar la conexión.
            }
        }

        public bool esAdmin(ENUsuario en)
        {
            SqlConnection conn = null;
            // Encapsula todo el acceso a datos dentro del try
            String comando = "SELECT * FROM [dbo].[Usuario] WHERE nick_name = '" + en.nick + "'";

            try
            {
                conn = new SqlConnection(constring);
                conn.Open();
                SqlCommand cmd = new SqlCommand(comando, conn);
                SqlDataReader dr = cmd.ExecuteReader();

                return (int.Parse(dr["admin"].ToString()) == 1);
            }
            catch (SqlException sqlex)
            {

                Console.WriteLine("User operation has failed.Error: " + sqlex.Message);
                return false;
            }
            catch (Exception ex)
            {

                Console.WriteLine("User operation has failed.Error: " + ex.Message);
                return false;
            }
            finally
            {
                if (conn != null) conn.Close(); // Se asegura de cerrar la conexión.
            }
        }

        //FILTROS A LA BASE DE DATOS PARA LOS ADMINS
        public DataSet filtrarPorAdministrador(int admin)
        {
            DataSet bdvirtual = new DataSet();
            SqlConnection c = new SqlConnection(constring);

            SqlDataAdapter da = new SqlDataAdapter("select * from [dbo].[Usuario] where admin = " + admin, c);
            da.Fill(bdvirtual, "[dbo].[Usuario]");

            return bdvirtual;
        }

        public DataSet filtrarPorNick(string nick)
        {
            DataSet bdvirtual = new DataSet();
            SqlConnection c = new SqlConnection(constring);

            SqlDataAdapter da = new SqlDataAdapter("select * from [dbo].[Usuario] where nick_name = '" + nick + "'", c);
            da.Fill(bdvirtual, "[dbo].[Usuario]");

            return bdvirtual;
        }

        public DataSet filtrarPorEdad(int edad)
        {
            DataSet bdvirtual = new DataSet();
            SqlConnection c = new SqlConnection(constring);

            SqlDataAdapter da = new SqlDataAdapter("select * from [dbo].[Usuario] where edad = " + edad, c);
            da.Fill(bdvirtual, "[dbo].[Usuario]");

            return bdvirtual;
        }
        public DataSet filtrarPorNombre(string nombre)
        {
            DataSet bdvirtual = new DataSet();
            SqlConnection c = new SqlConnection(constring);

            SqlDataAdapter da = new SqlDataAdapter("select * from [dbo].[Usuario] where nombre = '" + nombre + "'", c);
            da.Fill(bdvirtual, "[dbo].[Usuario]");

            return bdvirtual;
        }
        public DataSet filtrarPorApellidos(string apellidos)
        {
            DataSet bdvirtual = new DataSet();
            SqlConnection c = new SqlConnection(constring);

            SqlDataAdapter da = new SqlDataAdapter("Select * from [dbo].[Usuario] where apellidos like '" + apellidos + "%'", c);
            da.Fill(bdvirtual, "[dbo].[Usuario]");

            return bdvirtual;
        }
        public DataSet filtrarPorLocalidad(string localidad)
        {
            DataSet bdvirtual = new DataSet();
            SqlConnection c = new SqlConnection(constring);

            SqlDataAdapter da = new SqlDataAdapter("select * from [dbo].[Usuario] where localidad = '" + localidad + "'", c);
            da.Fill(bdvirtual, "[dbo].[Usuario]");

            return bdvirtual;
        }
        public DataSet filtrarPorProvincia(string provincia)
        {
            DataSet bdvirtual = new DataSet();
            SqlConnection c = new SqlConnection(constring); 

            SqlDataAdapter da = new SqlDataAdapter("select * from [dbo].[Usuario] where provincia = '" + provincia + "'", c);
            da.Fill(bdvirtual, "[dbo].[Usuario]");

            return bdvirtual;
        }
        public DataSet filtrarPorPais(string pais)
        {
            DataSet bdvirtual = new DataSet();
            SqlConnection c = new SqlConnection(constring);

            SqlDataAdapter da = new SqlDataAdapter("select * from [dbo].[Usuario] where pais = '" + pais + "'", c);
            da.Fill(bdvirtual, "[dbo].[Usuario]");

            return bdvirtual;
        }

        public DataTable listarUsuarios()
        {
            DataTable usuarios = new DataTable();
            SqlConnection c = new SqlConnection(constring);

            SqlDataAdapter da = new SqlDataAdapter("select * from [dbo].[Usuario]", c);
            da.Fill(usuarios);

            return usuarios;
        }

        public void ModificarAdmin(int admin,int index)
        {
            DataTable usuarios = new DataTable();
            SqlConnection c = new SqlConnection(constring);

            SqlDataAdapter da = new SqlDataAdapter("select * from [dbo].[Usuario]", c);
            da.Fill(usuarios);

            ENUsuario usur = new ENUsuario(usuarios.Rows[index][0].ToString(), usuarios.Rows[index][1].ToString(), usuarios.Rows[index][2].ToString(), usuarios.Rows[index][4].ToString()
                                            , usuarios.Rows[index][7].ToString(), usuarios.Rows[index][8].ToString(), usuarios.Rows[index][9].ToString(), usuarios.Rows[index][5].ToString()
                                            , int.Parse(usuarios.Rows[index][3].ToString()), admin, int.Parse(usuarios.Rows[index][10].ToString()));
            updateUsuario(usur);
        }

        public bool incrementarNumVentas(ENUsuario usuario, int numVentasNuevo) {
            bool incrementado = false;
            SqlConnection conexion = null;

            try {
                conexion = new SqlConnection(constring);
                conexion.Open();

                string consulta = "Update Usuario set numVentas = " + numVentasNuevo + " where nick_name = '" + usuario.nick + "'";
                SqlCommand comando = new SqlCommand(consulta, conexion);

                comando.ExecuteNonQuery();

                incrementado = true;
            } catch(SqlException e) {
                Console.WriteLine("User operation has failed.Error: " + e.Message);
            } catch(Exception e) {
                Console.WriteLine("User operation has failed.Error: " + e.Message);
            } finally {
                if(conexion.State == ConnectionState.Open) {
                    conexion.Close();
                }
            }

            return incrementado;
        }

    }
}
