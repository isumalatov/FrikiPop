using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using library;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Globalization;

namespace library
{
    public class CADLineaCarrito{
		//atributos
        private string constring;

		//constructor por defecto que inicliaza constring
        public CADLineaCarrito() {
            constring = ConfigurationManager.ConnectionStrings["Database"].ToString();
        }

		/* Funcion que lee una linea de carrito, que abre la conexion, con SqlCommand lanza una consulta en la que se
		 * muestre todos los campos de la linea del carrito donde el usuario coincida con el usuario de la linea del 
		 * carrito pasada por parametro, luego se efectua un ExecuteReader() y un readerSQL.read() y si el usuario es
		 * igual al usuario de linCarrito pues los atributos de linCarrito se inicializan con los que se van leyendo de
		 * la base de datos y haciendo conversion de tipo de datos para los que haga falta. En caso de que se produzca
		 * una excepcion se mostarar un mensaje de error en el catch y en le finally se cierra la conexion.
		 
		 * parametros: un obejeto de ENLineaCarrito llamado lincarrito.
		 * retorno:una variable de tipo bool denominada leido que devuelve false si entra en el catch y true si se hace todo
		 * bien en el try.
		*/

		public bool readLineaCarrito(ENLineaCarrito lincarrito) {

			bool leido;
			SqlConnection conex;
			conex = new SqlConnection(constring);
			leido = false;

			try {
				SqlCommand comandoSQL;
				string consultaSQL;

				conex.Open();

				consultaSQL = "Select * from LinCarrito where usuario = '" + lincarrito.usuario + "'";

				comandoSQL = new SqlCommand(consultaSQL, conex);

				SqlDataReader readerSQL;
				readerSQL = comandoSQL.ExecuteReader();

				readerSQL.Read();
				bool condicion;
				condicion = (readerSQL["usuario"].ToString() == lincarrito.usuario);
				if (condicion) {
					
					lincarrito.id_carrito = int.Parse(readerSQL["id_carrito"].ToString());
					lincarrito.linea = int.Parse(readerSQL["linea"].ToString());
					lincarrito.importe = float.Parse(readerSQL["importe"].ToString());
					lincarrito.articulo = readerSQL["articulo"].ToString();


					leido = true;
				}

				readerSQL.Close();
			}

			catch (SqlException exception) {
				Console.WriteLine("User operation has failed. Error: {0}", exception.Message);
			}

			catch (Exception exception) {
				Console.WriteLine("User operation has failed. Error: {0}", exception.Message);
			}

			finally {

				if (conex.State == ConnectionState.Open) {
					conex.Close();
				}
			}

			return leido;
        }

		/* Funcion que crea una linea de carrito, que abre la conexion, construye una consulta SQL para insertar una nueva línea de
		 * carrito en la base de datos, utilizando los valores del objeto ENLineaCarrito. Crea un objeto SqlCommand con la
		 * consulta SQL y la conexión. Ejecuta la consulta SQL utilizando comandoSQL.ExecuteNonQuery(), que realiza la
		 * inserción en la base de datos. En caso de que se produzca una excepcion se mostrara un mensaje de error en el catch.
		 * En el bloque finally que se entra siempre, se cierra la conexion.
		 
		 * parametros: un obejeto de ENLineaCarrito llamado lincarrito.
		 * retorno:una variable de tipo bool denominada creado que devuelve false si entra en el catch y true si se hace todo
		 * bien en el try.
		*/

		public bool createLineaCarrito(ENLineaCarrito lincarrito) {
			bool creado;
			creado = false;
			SqlConnection conex;
			conex = null;
            try {
				conex = new SqlConnection(constring);
				conex.Open();
				string consultaSQL;
				CultureInfo culture = new CultureInfo("en-US");
				string resultado = lincarrito.importe.ToString("0.00", culture);
				consultaSQL = "Insert into LinCarrito (linea, id_carrito, importe, usuario, articulo) VALUES ("+lincarrito.linea+", "+lincarrito.id_carrito+", "+resultado+", '"+lincarrito.usuario+ "', '"+ lincarrito.articulo+ "')";
				SqlCommand comandoSQL;
				comandoSQL = new SqlCommand(consultaSQL, conex);

				comandoSQL.ExecuteNonQuery();
				creado = true;
            }

			catch (SqlException exception) {
				Console.WriteLine("User operation has failed. Error: {0}", exception.Message);
			}

			catch (Exception exception) {
				Console.WriteLine("User operation has failed. Error: {0}", exception.Message);
			}

			finally {

				if (conex.State == ConnectionState.Open) {
					conex.Close();
				}
			}

			return creado;
		}

		/* Funcion que elimina una linea de carrito, que abre la conexion, construye una consulta SQL para eliminar una 
		 * línea de carrito de la base de datos, utilizando el valor de linea del objeto ENLineaCarrito. Crea un objeto
		 * SqlCommand con la consulta SQL y la conexión. Ejecuta la consulta SQL utilizando comandoSQL.ExecuteNonQuery(),
		 * que realiza la eliminación en la base de datos.  En caso de que se produzca una excepcion se mostrara un mensaje de error en el catch.
		 * En el bloque finally que se entra siempre, se cierra la conexion.
		 
		 * parametros: un obejeto de ENLineaCarrito llamado lincarrito.
		 * retorno: una variable de tipo bool denominada borrrado que devuelve false si entra en el catch y true si se hace todo
		 * bien en el try.
		*/

		public bool deleteLineaCarrito(ENLineaCarrito lincarrito) {

			bool borrado;
			borrado = false;
			SqlConnection conex;
			conex = null;

            try {
				conex = new SqlConnection(constring);
				conex.Open();
				string consultaSQL;

				consultaSQL = "Delete from LinCarrito  where linea='"+lincarrito.linea+"')";
				SqlCommand comandoSQL;
				comandoSQL = new SqlCommand(consultaSQL, conex);

				comandoSQL.ExecuteNonQuery();
				borrado = true;
            }

			catch (SqlException exception) {
				Console.WriteLine("User operation has failed. Error: {0}", exception.Message);
			}

			catch (Exception exception) {
				Console.WriteLine("User operation has failed. Error: {0}", exception.Message);
			}

			finally {

				if (conex.State == ConnectionState.Open) {
					conex.Close();
				}
			}

			return borrado;
        }

		/* Funcion que lista la linea de carrito, que abre la conexion, construye una consulta SQL para seleccionar todas
		 * las filas de la tabla LinCarrito relacionadas con un carrito específico. Crea un objeto SqlDataAdapter y lo
		 * utiliza para llenar el dataset con los resultados de la consulta. En caso de que se produzca una excepcion se mostrara un mensaje de error en el catch.
		 * En el bloque finally que se entra siempre, se cierra la conexion.
		 
		 * parametros: un obejeto de ENLineaCarrito llamado lincarrito.
		 * retorno: una variable de tipo bool denominada dataset. 
		*/

		public DataSet enlistarLineaCarrito(ENLineaCarrito lincarrito) {

			DataSet dataset;
			dataset= new DataSet();
			SqlConnection conex;
			conex = null;

			try {
				string consultaSQL;
				consultaSQL = "Select * from LinCarrito l where l.id_carrito = '"+lincarrito.id_carrito + "'";

				conex = new SqlConnection(constring);

				SqlDataAdapter dataAdapter;
				dataAdapter = new SqlDataAdapter(consultaSQL, conex);
				dataAdapter.Fill(dataset,"LinCarrito");

			}

			catch (SqlException exception) {
				Console.WriteLine("The operation has failed.Error: {0}", exception.Message);
			}

			catch (Exception exception) {
				Console.WriteLine("The operation has failed.Error: {0}", exception.Message);
			}

			finally {

				if (conex.State == ConnectionState.Open) {
					conex.Close();
				}
			}

			return dataset;

		}
		/* Funcion que obtiene la maxima linea de carrito, que abre la conexion, construye una consulta SQL para seleccionar 
		 * todas las filas de la tabla LinCarrito relacionadas con un número de carrito específico. Crea un objeto 
		 * SqlCommand y lo utiliza para ejecutar la consulta SQL y obtener un objeto SqlDataReader. Itera a través de
		 * las filas del SqlDataReader y actualiza la variable linea con el valor máximo encontrado en la columna "linea".
		 * En caso de que se produzca una excepcion se mostrara un mensaje de error en el catch.
		 * En el bloque finally que se entra siempre, se cierra la conexion.
		 
		 
		 * parametros: un obejeto de ENLineaCarrito llamado lincarrito.
		 * retorno: una variable de tipo int denominada linea que devuelve la max linea.
		*/
		public int obtenerMaxLineaCarrito(int num_carrito) {
			int linea = 0;
			SqlConnection conex = null;

			try {
				conex = new SqlConnection(constring);
				conex.Open();
				string consultaSQL;

				consultaSQL = "Select * from LinCarrito where id_carrito=" + num_carrito;
				SqlCommand comandoSQL;
				comandoSQL = new SqlCommand(consultaSQL, conex);

				SqlDataReader readerSQL;
				readerSQL = comandoSQL.ExecuteReader();

				while(readerSQL.Read()) { //Algoritmo para obtener el maximo elemento.
					if(linea < int.Parse(readerSQL["linea"].ToString())) {
						linea = int.Parse(readerSQL["linea"].ToString());
                    }
                }

				readerSQL.Close();

			} catch (SqlException exception) {
				Console.WriteLine("User operation has failed. Error: {0}", exception.Message);
			} catch (Exception exception) {
				Console.WriteLine("User operation has failed. Error: {0}", exception.Message);
			} finally {

				if (conex.State == ConnectionState.Open) {
					conex.Close();
				}
			}

			return linea;
		}

    }
}
