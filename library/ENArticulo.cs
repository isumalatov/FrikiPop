using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace library
{
    public class ENArticulo
    {
        private string _codigo; //declara los atributos
        private string _nombre;
        private string _descripcion;
        private double _precio;
        private string _urlImagen;
        private string _tipoArticulo;
        private string _usuario;

        public string codigo
        {
            get
            {
                return _codigo;
            }
            set
            {
                _codigo = value;
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

        public string descripcion
        {
            get
            {
                return _descripcion;
            }
            set
            {
                _descripcion = value;
            }
        }

        public double precio
        {
            get
            {
                return _precio;
            }
            set
            {
                _precio = value;
            }
        }

        public string urlImagen
        {
            get
            {
                return _urlImagen;
            }
            set
            {
                _urlImagen = value;
            }
        }

        public string tipoArticulo
        {
            get
            {
                return _tipoArticulo;
            }
            set
            {
                _tipoArticulo = value;
            }
        }

        public string usuario
        {
            get
            {
                return _usuario;
            }
            set
            {
                _usuario = value;
            }
        }

        public ENArticulo() //crea la clase
        {
            codigo = null;
            nombre = null;
            descripcion = null;
            precio = 0.0;
            urlImagen = null;
            tipoArticulo = null;
            usuario = null;

        }

        public bool createArticulo() //funciones del en
        {
            CADArticulo articulo = new CADArticulo();
            if (!articulo.readArticulo(this))
            {
                return articulo.createArticulo(this);
            }
            return false;
        }

        public bool deleteArticulo()
        {
            CADArticulo articulo = new CADArticulo();
            if (articulo.readArticulo(this))
            {
                return articulo.deleteArticulo(this);
            }
            return false;
        }

        public bool readArticulo()
        {
            CADArticulo articulo = new CADArticulo();
            return articulo.readArticulo(this);
        }

        public bool updateArticulo()
        {
            CADArticulo articulo = new CADArticulo();
            if (articulo.readArticulo(this))
            {
                return articulo.updateArticulo(this);
            }
            return false;
        }

        public DataTable usuarioArticulo(string usuario)
        {
            CADArticulo articulo = new CADArticulo();
            DataTable tabla = articulo.usuarioArticulo(usuario);
            return tabla;
        }

        public string getMaxID() {
            CADArticulo articulo = new CADArticulo();
            string max = articulo.getMaxID();
            return max;
        }

        public DataTable filtrarPorTipo(string tipo) {
            CADArticulo articulo = new CADArticulo();
            DataTable tabla = articulo.filtrarPorTipo(tipo);
            return tabla;
        }

        public bool cambiarUsuario(string nuevoUsuario) {
            CADArticulo articulo = new CADArticulo();
            return articulo.cambiarUsuario(this, nuevoUsuario);
        }
    }
}
