using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Globalization;

namespace library
{
	public class CADCarrito{
		private string constring;

		/*
		 * Constructor por defecto que inicializa constring.
		 */
		public CADCarrito(){
			constring = ConfigurationManager.ConnectionStrings["Database"].ToString();
		}

		/* Funcion que lee un carrito en la que lanzamos la conexion SQL, una consulta
		 * donde te muestre todos los campos de la tabla carrito donde usuario sea igual al usuario
		 * del carrito pasado por parametro, leemos la consulta con ExecuteReader. Luego asignamos o "Vacio" o "Comprando"
		 * al estado del carrito y a numeroCarrito su numero de carrito correspondiente que lee con readerSQL.
		 * En caso de que haya algun error se va al catch y muestra un mensaje de error, en el finally siempre
		 * entra para cerrar la conexion.
		 
		
		 * parametros: Un objeto carrito de tipo ENCarrito.
		 * retorno: una variable de tipo bool denominada leido. 
		 */
		public bool readCarrito(ENCarrito carrito){
			bool leido;
			SqlConnection conex;
			conex = new SqlConnection(constring);
			leido = false;

			try {
				SqlCommand comandoSQL;
				string consultaSQL;

				conex.Open();

				consultaSQL= "Select * from Carrito where usuario = '" + carrito.usuario + "'";
				
				comandoSQL = new SqlCommand(consultaSQL, conex);

				SqlDataReader readerSQL;
				readerSQL = comandoSQL.ExecuteReader();

				readerSQL.Read();
				if(readerSQL.HasRows) { // No hacer mucho caso a esto, ya que estabamos probando cuando
										// teniamos un error, si entraba o no.
					Console.WriteLine("ENTRA");
                } else {
					Console.WriteLine("No entra");
                }

				bool condicion;
				condicion = (readerSQL[1].ToString() == carrito.usuario);
                if (condicion==true) {
                    if (readerSQL["estado_carrito"].ToString() == "Comprando") {
						carrito.estadoCarrito = "Comprando";
                    }
                    else {
						carrito.estadoCarrito = "Vacio";
                    }

					leido = true;

					carrito.numeroCarrito = int.Parse(readerSQL["num_carrito"].ToString());
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

		/* Funcion que crea un carrito en la que lanzamos la conexion SQL, una consulta
		 * donde se inserta al carrito el numero de carrito, usuario y estado del carrito pasado por parametro.
		 * Luego hacemos un ExecuteNonQuery y en caso de que ocurra un error se va al catch mostrando un mensaje de error,
		 * en el finally siempre entra para cerrar la conexion.
		 
		
		 * parametros: Un objeto carrito de tipo ENCarrito.
		 * retorno: una variable de tipo bool denominada creado. 
		 */
		public bool createCarrito(ENCarrito carrito){
			bool creado;
			creado = false;
			SqlConnection conex;
			conex = new SqlConnection(constring);

            try {
				string consultaSQL;

				conex.Open();
				consultaSQL = "Insert into Carrito (num_carrito, usuario, estado_carrito) values ("+carrito.numeroCarrito+", '"+carrito.usuario+"', '"+carrito.estadoCarrito+"')";

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

		public bool updateCarrito(ENCarrito carrito) {
			return true; //????? Metodo provisional, igual no nos hará falta
        }

		/* Funcion que hace un Join carrito en la que abrimos la conexion SQL, lanzamos una consulta con dataAdapter
		 * en la que muestre todos los campos de la linea del carrito y Articulo, relacionando las 2 tablas.
		 * Usamos un dataAdapter.Fill para ejecutar una consulta y llenar el DataTable con los resultados de esa consulta.
		 * En caso de que haya alguna excepcion, se va al catch mostrando un mensaje de error y al finally siempre entra
		 * para cerrar la conexion.
		 
		
		 * parametros: Un objeto carrito de tipo ENCarrito.
		 * retorno: una variable de tipo DataTable denominada datatable. 
		 */
		public DataTable unirCarrito(ENCarrito carrito){

			DataTable datatable = new DataTable();	
			SqlConnection conex;
			conex = null;

            try {
				string consultaSQL;
				consultaSQL = "Select * from LinCarrito, Articulo where articulo = codigo and id_carrito = "+carrito.numeroCarrito;

				conex = new SqlConnection(constring);

				conex.Open();

				SqlDataAdapter dataAdapter;
				dataAdapter = new SqlDataAdapter(consultaSQL, conex);
				dataAdapter.Fill(datatable);

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

			return datatable;
			
		}

		/* Funcion que elimina un articulo, abrimos la conexion luego hacemos una consulta SQL para eliminar
		 * un artículo del carrito y la lanzamos con SqlCommand, luego con ExecuteNonQuery que se encarga de la ejecución
		 * de la consulta SQL para eliminar el artículo, luego en caso de excepcion entra al catch y me muestra un mensaje
		 * de error y al finally entra siempre y cierra la conexion.

		 * parametros: Un objeto carrito de tipo ENCarrito y un tipo de dato entero llamado linea.
		 * retorno: una variable de tipo bool denominada borradoArticulo. 
		 */

		public bool deleteArticulo(ENCarrito carrito, int linea){
			bool borradoArticulo;
			borradoArticulo = false;
			SqlConnection conex;
			conex = null;

			try {
				string consultaSQL;
				consultaSQL = "Delete from LinCarrito where id_carrito = " + carrito.numeroCarrito + " and linea = " + linea;
				SqlCommand comandoSQL;

				conex = new SqlConnection(constring);

				conex.Open();

				comandoSQL = new SqlCommand(consultaSQL, conex);
				comandoSQL.ExecuteNonQuery();

				borradoArticulo = true;
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

			return borradoArticulo;
		}

		/* Funcion que hace un pedido, abrimos la conexion luego hacemos una consulta SQL para mostrar todos
		 * los campos de linea de carrito si coincide el id_carrito con el numeroCarrito del carrito pasado por
		 * parametro, lanzamos esta consulta con SqlDataAdapter. Llena un DataSet con los resultados de la consulta.
		 * Crea un objeto ENPedido y lo guarda en la base de datos. Itera a través de las filas del DataSet y crea objetos
		 * ENLinPedido para cada fila luego vacía el carrito. Y en caso de haya una excepcion entra al catch para mostrar
		 * un mensaje de error y al finally entra siempre po lo que cierra la conexion ahí.
		 
		
		 * parametros: Un objeto carrito de tipo ENCarrito.
		 * retorno: una variable de tipo bool denominada realizado. 
		 */
		public bool makePedido(ENCarrito carrito){
			bool realizado;
			realizado = false;
			SqlConnection conex;
			conex = null;
			try {
				DataSet dataset;
				SqlDataAdapter dataAdapter;
				string consultaSQL;

				consultaSQL = "Select * from linCarrito l where l.id_carrito= '" + carrito.numeroCarrito + "'";
				dataset = new DataSet();

				conex = new SqlConnection(constring);

				dataAdapter = new SqlDataAdapter(consultaSQL, conex);

				dataAdapter.Fill(dataset,"LinCarrito");
				ENUsuario usu;
				usu = new ENUsuario();
				usu.nick = carrito.usuario;
				usu.readUsuario();
				ENPedido ped;
				ped = new ENPedido();

				ped.idPedido = 1;
				ped.total = 0;
				ped.state = "";
				ped.user = carrito.usuario;
				ped.date= DateTime.Now.ToString("d", DateTimeFormatInfo.InvariantInfo);


				ped.createPedido();

				int iter;
				iter = 1;
				string lincarrito = "LinCarrito";
				string importe = "importe";
				string articulo = "articulo";
				foreach(DataRow dataRow in dataset.Tables[lincarrito].Rows) {
					ENLinPedido linped;
					float importeF;
					importeF = float.Parse(dataRow[importe].ToString());
					string articuloI = dataRow[articulo].ToString();

					linped = new ENLinPedido(iter, ped.idPedido,articuloI,importeF,carrito.usuario);

					linped.createLinPedido();

					++iter;

                }
				vaciarCarrito(carrito);
				realizado = true;
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

			return realizado;
		}

		/* Funcion que vacia el carrito, abre la conexion, lanza con SqlCommand una consulta en la que elimina de la tabla
		 * de linea de carrito cuando el id_carrito coincide con el numeroCarrito del carrito pasado por parametro. Hacemos
		 * un ExecuteNonQuery donde se ejecuta una consulta en la base de datos sin retornar ningún conjunto de resultados. 
		 * Si hay alguna excepcion entra dentro del bloque catch mostrando un mensaje de error y al finally entra siempre y
		 * cierra la conexion.
		 
		
		 * parametros: Un objeto carrito de tipo ENCarrito.
		 * retorno: una variable de tipo bool denominada borrado. 
		 */

		public bool vaciarCarrito(ENCarrito carrito){
			bool borrado;
			borrado = false;
			SqlConnection conex;
			conex = null;

            try {
				string consultaSQL;
				consultaSQL = "Delete from LinCarrito where id_carrito = "+carrito.numeroCarrito;
				SqlCommand comandoSQL;

				conex = new SqlConnection(constring);

				conex.Open();

				comandoSQL = new SqlCommand(consultaSQL, conex);

				comandoSQL.ExecuteNonQuery();

				borrado = true;
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

			return borrado;
		}

		/* Funcion que obtiene el id del carrito, abre la conexion, lanza con SqlCommand una consulta en la que seleciona 
		 * todos los campos de carrito donde el usuario coincide con el nick pasado por parametro, hace un ExecuteReader() y
		 * un readerSQL.read() mas tarde y convierte de string a int el id leido de la base de datos.
		 
		 * parametros: un tipo de dato string llamado nick.
		 * retorno: una variable de tipo int denominada id. 
		 */
		public int obtenerIdCarrito(string nick) {
			int id = 0;
			SqlConnection conex;
			conex = new SqlConnection(constring);

			try {
				SqlCommand comandoSQL;
				string consultaSQL;

				conex.Open();

				consultaSQL = "Select * from Carrito where usuario = '" + nick + "'";

				comandoSQL = new SqlCommand(consultaSQL, conex);

				SqlDataReader readerSQL;
				readerSQL = comandoSQL.ExecuteReader();

				readerSQL.Read();

				id = int.Parse(readerSQL["num_carrito"].ToString());

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

			return id;
		}
	}
}
