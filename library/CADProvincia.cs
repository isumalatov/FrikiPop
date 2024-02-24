using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data;

namespace library {
    public class CADProvincia {

        private String constring;

        //Establece la cadena de conexion de la BD
        public CADProvincia() {
            constring = ConfigurationManager.ConnectionStrings["Database"].ToString();
        }

        
        public bool createProvincia(ENProvincia provincia) {
            bool creado = false;
            SqlConnection conexion = null;

            //Todo el codigo dentro del try para capturar excepciones
            try {
                conexion = new SqlConnection(constring);
                conexion.Open(); //Abre la conexion

                string consulta = "Insert into Provincia (provincia, pais) values ('" + provincia.provincia + "', '" + provincia.pais + "')";
                SqlCommand command = new SqlCommand(consulta, conexion);

                command.ExecuteNonQuery(); //Ejecuta el comando

                creado = true; //Si se ha podido insertar, devuelve true

            } catch (SqlException e) {
                Console.WriteLine("User operation has failed. Error: {0}", e.Message);
            } catch (Exception e) {
                Console.WriteLine("User operation has failed. Error: {0}", e.Message);
            } finally {
                //Asegurarse de cerrar la conexion
                if(conexion.State == ConnectionState.Open) {
                    conexion.Close();
                }
            }

            return creado;
        }

        public bool deleteProvincia(ENProvincia provincia) {
            bool eliminado = false;
            SqlConnection conexion = null;

            //Todo el codigo dentro del try para capturar excepciones
            try {
                conexion = new SqlConnection(constring);
                conexion.Open(); //Se abre la conexion

                string consulta = "Delete from Provincia where provincia = '" + provincia.provincia + "' and pais = '" + provincia.pais + "'";
                SqlCommand command = new SqlCommand(consulta, conexion);

                command.ExecuteNonQuery(); //Se ejecuta la consulta
                eliminado = true; //Si todo va bien, devuelve true 
            } catch (SqlException e) {
                Console.WriteLine("User operation has failed. Error: {0}", e.Message);
            } catch (Exception e) {
                Console.WriteLine("User operation has failed. Error: {0}", e.Message);
            } finally {
                //Asegurarse de cerrar la conexion
                if(conexion.State == ConnectionState.Open) {
                    conexion.Close();
                }
            }

            return eliminado;
        }

        public bool readProvincia(ENProvincia provincia) {
            bool leido = false;
            SqlConnection conexion = null;

            //Todo el codigo dentro del try para capturar excepciones
            try {
                conexion = new SqlConnection(constring);
                conexion.Open(); //Se abre la conexion

                string consulta = "Select * from Provincia where provincia = '" + provincia.provincia + "' and pais = '" + provincia.pais + "'";
                SqlCommand command = new SqlCommand(consulta, conexion);

                SqlDataReader busqueda = command.ExecuteReader(); //Se guardan los datos leidos
                busqueda.Read(); //Se lee el primer dato, que como los dos campos son CP no puede haber otro igual

                if (busqueda.HasRows) {
                    if (busqueda["provincia"].ToString() == provincia.provincia &&
                        busqueda["pais"].ToString() == provincia.pais) {
                        provincia.provincia = busqueda["provincia"].ToString();
                        provincia.pais = busqueda["pais"].ToString();
                        leido = true;
                    }
                }

                busqueda.Close(); 

            } catch (SqlException e) {
                Console.WriteLine("User operation has failed. Error: {0}", e.Message);
            } catch (Exception e) {
                Console.WriteLine("User operation has failed. Error: {0}", e.Message);
            } finally {
                //Asegurarse de cerrar la conexion
                if(conexion.State == ConnectionState.Open) {
                    conexion.Close();
                }
            }

            return leido;
        }

        public DataTable listarProvincias(string pais) {
            DataTable tabla = new DataTable();
            SqlConnection conexion = null;

            //Todo el codigo dentro del try para capturar excepciones
            try {
                conexion = new SqlConnection(constring);
                string consulta = null;
                //Si se recibe un pais, se listan unicamente las provincias de ese pais
                if(pais == "") {
                    consulta = "Select * from Provincia";
                } else {
                    consulta = "Select * from Provincia where pais = '" + pais + "'";
                }
                SqlDataAdapter data = new SqlDataAdapter(consulta, conexion);
                data.Fill(tabla); //Se rellena la tabla con los datos leidos

            } catch (SqlException e) {
                Console.WriteLine("The operation has failed.Error: {0}", e.Message);
            } catch (Exception e) {
                Console.WriteLine("The operation has failed.Error: {0}", e.Message);
            } finally {
                //Se comprueba que la conexion este vacia
                if (conexion.State == ConnectionState.Open) {
                    conexion.Close();
                }
            }
            return tabla;
        }
    }
}
