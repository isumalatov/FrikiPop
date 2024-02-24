using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using library;
using System.Data;

namespace library{
	public class ENCarrito {

		//atributos privados

		private string usuario_;

		private int numeroCarrito_;

		private string estadoCarrito_;

		//getters y setters
		public int numeroCarrito{
			get{ return numeroCarrito_;}
			set{ numeroCarrito_=value;}
		}
		public string usuario{
			get{ return usuario_;}
			set{ usuario_=value;}
		}

		public string estadoCarrito{
			get { return estadoCarrito_; }
			set { estadoCarrito_=value; }
		}
		//Constructor por defecto que iniciliza los atributos
		public ENCarrito(){
			numeroCarrito=0;
			estadoCarrito=null;
			usuario=null;
		}

		//Constructor parametrizado que inicializa los atributos con los parametros pasados
		public ENCarrito(string usuario_, int numeroCarrito_, string estadoCarrito_) {
			usuario = usuario_;
			numeroCarrito = numeroCarrito_;
			estadoCarrito = estadoCarrito_;
        }
		/* Funcion que crea un carrito
		  *retorno: una variable de tipo bool denominada creado.
		 */
		public bool createCarrito(){
			bool creado;
			CADCarrito carri;
			carri= new CADCarrito();
			creado = carri.createCarrito(this);
			return creado;
		}

		/* Funcion que lee un carrito
		  *retorno: una variable de tipo bool denominada leido.
		 */

		public bool readCarrito(){
			bool leido;
			CADCarrito carri;
			carri= new CADCarrito();
			leido = carri.readCarrito(this);
			return leido;
		}

		/* Funcion que actualiza un carrito
		  *retorno: una variable de tipo bool denominada actualizado.
		 */

		public bool updateCarrito() {
			bool actualizado;
			CADCarrito carri;
			carri= new CADCarrito();
			actualizado = carri.updateCarrito(this);
			return actualizado;
        }

		/* Funcion que hace un join carrito
		  *retorno: una variable de tipo DataTable denominada dataTable.
		 */

		public DataTable unirCarrito(){

			CADCarrito carri;
			carri= new CADCarrito();
			DataTable dataTable;
			dataTable= new DataTable();
			dataTable = carri.unirCarrito(this);
			return dataTable;
		}

		/* Funcion que hace un pedido
		  *retorno: una variable de tipo bool denominada realizado.
		 */

		public bool makePedido(){
			bool realizado;
			CADCarrito carri;
			carri= new CADCarrito();
			realizado = carri.makePedido(this);
			return realizado;

		}

		/* Funcion que vacia un carrito
		  *retorno: una variable de tipo bool denominada vaciado.
		 */

		public bool vaciarCarrito(){
			bool vaciado;
			CADCarrito carri;
			carri= new CADCarrito();
			vaciado = carri.vaciarCarrito(this);
			return vaciado;
		}


		/* Funcion que elimina un articulo
		  *parametros: un dato de tipo entero llamado linea
		  *retorno: una variable de tipo bool denominada borradoArticulo.
		 */

		public bool deleteArticulo(int linea) {
			bool borradoArticulo;
			CADCarrito carri;
			carri= new CADCarrito();
			borradoArticulo= carri.deleteArticulo(this, linea);
			return borradoArticulo;
		}

		/* Funcion que obtiene el identificador de un carrito
		  *parametros: un dato de tipo string llamado nick
		  *retorno: una variable de tipo int denominada numero.
		 */

		public int obtenerIdCarrito(string nick) {
			CADCarrito carrito = new CADCarrito();
			int numero = carrito.obtenerIdCarrito(nick);
			return numero;
		}
	}
}
