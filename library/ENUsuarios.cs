using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace library
{
    /// <summary>
    /// Clase correspondiente a la entidad usuario. 
    /// Tiene metodos para crear,actualizar,borrar y filtrar sobre los usuarios.
    /// Guarda valores como el nombre de la imagen que utilizara el usuario, el nick que sera unico para el y demas datos personales ademas de la contraseña.
    /// Tiene una propiedad llamada admin que funciona como un bool. Si vale 1 es admin y si vale 0 no es admin.
    /// Por ultimo tiene una propiedad llamada numVentas la cual sera utilizada para las estadisticas y la modifica el encargado de los pedidos.
    /// </summary>
    public class ENUsuario
    {
        private string _nick;
        private string _nombre;
        private string _apellidos;
        private int _edad;
        private string _contrasenya;
        private string _imagen;
        private int _admin;
        private string _localidad;
        private string _provincia;
        private string _pais;
        private int _numVentas;

        public string localidad
        {
            get 
            {
                return _localidad;
            }
            set 
            {
                _localidad = value; 
            }
        }

        public string provincia
        {
            get 
            {
                return _provincia; 
            }
            set 
            {
                _provincia = value; 
            }
        }

        public string pais
        {
            get 
            { 
                return _pais;
            }
            set 
            {
                _pais = value; 
            }
        }

        public string nick
        {
            get
            {
                return _nick;
            }
            set
            {
                _nick = value;
            }
        }
        public string nombre
        {
            get
            {
                return _nombre;
            }
            set
            {
                _nombre = value;
            }
        }
        public string apellidos
        {
            get
            {
                return _apellidos;
            }
            set
            {
                _apellidos = value;
            }
        }
        public int edad
        {
            get
            {
                return _edad;
            }
            set
            {
                _edad = value;
            }
        }
        public string contrasenya
        {
            get
            {
                return _contrasenya;
            }
            set
            {
                _contrasenya = value;
            }
        }
        public string imagen
        {
            get
            {
                return _imagen;
            }
            set
            {
                _imagen = value;
            }
        }
        public int admin
        {
            get
            {
                return _admin;
            }
            set
            {
                _admin = value;
            }
        }

        public int numVentas
        {
            get
            {
                return _numVentas;
            }
            set
            {
                _numVentas = value;
            }
        }



        public ENUsuario()
        {
            nick = null;
            nombre = null;
            apellidos = null;
            contrasenya = null;
            imagen = null;
            localidad = null;
            provincia = null;
            localidad = null;
            admin = 0;
            edad = 0;
            numVentas = 0;
        }

        /// <summary>
        ///  nick,  nombre, apellidos, contrasenya, localidad,  provincia, pais,  imagen,  edad,  admin,numVentas
        /// </summary>
        public ENUsuario(string nick, string nombre,string apellidos,
                        string contrasenya,string localidad, string provincia,
                        string pais, string imagen, int edad, int admin, int numVentas)
        {
            this.nick = nick;
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.contrasenya = contrasenya;
            this.imagen = imagen;
            this.localidad = localidad;
            this.provincia = provincia;
            this.pais = pais;
            this.edad = edad;
            this.admin = admin;
            this.numVentas = numVentas;
        }

        //Comandos CRUD
        /// <summary>
        /// Meter en el orden: nick_name,nombre,apellidos,edad,contrasenya,imagen,localidad,provincia,pais
        /// </summary>
        public bool createUsuario()
        {
            CADUsuario cADUsuario = new CADUsuario();
            return cADUsuario.createUsuario(this);
        }
        public bool readUsuario()
        {
            CADUsuario cADUsuario = new CADUsuario();
            return cADUsuario.readUsuario(this);
        }
        public bool updateUsuario()
        {
            CADUsuario cADUsuario = new CADUsuario();
            return cADUsuario.updateUsuario(this);
        }
        public bool deleteUsuario()
        {
            CADUsuario cADUsuario = new CADUsuario();
            if (cADUsuario.readUsuario(this) == false)
            {
                return false;
            }
            return cADUsuario.deleteUsuario(this);
        }

        //FILTROS DE LOS USUARIOS SEGUN SUS ATRIBUTOS(No filtro por contraseña porque no tiene sentido, se supone que es privada para nosotros)
        public DataSet filtrarPorAdministrador(int admin)
        {
            CADUsuario cADUsuario = new CADUsuario();
            return cADUsuario.filtrarPorAdministrador(admin);
        }

        public DataSet filtrarPorNick(string nick)
        {
            CADUsuario cADUsuario = new CADUsuario();
            return cADUsuario.filtrarPorNick(nick);
        }

        public DataSet filtrarPorLocalidad(string localidad)
        {
            CADUsuario cADUsuario = new CADUsuario();
            return cADUsuario.filtrarPorLocalidad(localidad);
        }
        public DataSet filtrarPorProvincia(string provincia)
        {
            CADUsuario cADUsuario = new CADUsuario();
            return cADUsuario.filtrarPorProvincia(provincia);
        }
        public DataSet filtrarPorPais(string pais)
        {
            CADUsuario cADUsuario = new CADUsuario();
            return cADUsuario.filtrarPorPais(pais);
        }
        public DataSet filtrarPorNombre(string nombre)
        {
            CADUsuario cADUsuario = new CADUsuario();
            return cADUsuario.filtrarPorNombre(nombre);
        }
        public DataSet filtrarPorApellidos(string apellidos)
        {
            CADUsuario cADUsuario = new CADUsuario();
            return cADUsuario.filtrarPorApellidos(apellidos);
        }
        public DataSet filtrarPorEdad(int edad)
        {
            CADUsuario cADUsuario = new CADUsuario();
            return cADUsuario.filtrarPorEdad(edad);
        }

        public DataTable listarUsuarios()
        {
            CADUsuario cADUsuario = new CADUsuario();
            return cADUsuario.listarUsuarios();
        }

        //Metodo con el que cambio la propiedad de admin del usuario
        public void ModificarAdmin(int admin,int index)
        {
            CADUsuario cADUsuario = new CADUsuario();
             cADUsuario.ModificarAdmin(admin,index);
        }

        public bool incrementarNumVentas(int numVentasNuevo) {
            CADUsuario usuario = new CADUsuario();
            return usuario.incrementarNumVentas(this, numVentasNuevo);
        }
    }
}

