using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library {
    public class ENTipoArticulo {

        private string _tipoArticulo;
        private int _numVentas;

        public string tipoArticulo {
            get { return _tipoArticulo; }
            set { _tipoArticulo = value; }
        }

        public int numVentas {
            get { return _numVentas; }
            set { _numVentas = value; }
        }

        //Contructor copia
        public ENTipoArticulo() {
            tipoArticulo = null;
            numVentas = 0;
        }

        //CRUD (create, read, update, delete)
        public bool createTipoArticulo() {
            CADTipoArticulo tipoArticulo = new CADTipoArticulo();
            if (!tipoArticulo.readTipoArticulo(this)) {
                return tipoArticulo.createTipoArticulo(this);
            }
            return false;
        }

        public bool deleteTipoArticulo() {
            CADTipoArticulo tipoArticulo = new CADTipoArticulo();
            if (tipoArticulo.readTipoArticulo(this)) {
                return tipoArticulo.deleteTipoArticulo(this);
            }
            return false;
        }

        public bool readTipoArticulo() {
            CADTipoArticulo tipoArticulo = new CADTipoArticulo();
            return tipoArticulo.readTipoArticulo(this);
        }

        public bool updateTipoArticulo() {
            CADTipoArticulo tipoArticulo = new CADTipoArticulo();
            if (!tipoArticulo.readTipoArticulo(this)) {
                return tipoArticulo.updateTipoArticulo(this);
            }
            return false;
        }

        public bool incrementarNumeroVentas() {
            CADTipoArticulo tipoArticulo = new CADTipoArticulo();
            return tipoArticulo.incrementarNumeroVentas(this);
        }

    }
}
