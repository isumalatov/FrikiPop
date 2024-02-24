using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using library;

namespace library {
    public class ENProvincia {

        private string _provincia;

        private string _pais;

        public string provincia {
            set { _provincia = value; }
            get { return _provincia; }
        }

        public string pais {
            set { _pais = value; }
            get { return _pais; }
        }

        public ENProvincia() {
            provincia = null;
            pais = null;
        }

        public bool createProvincia() {
            CADProvincia provincia = new CADProvincia();
            if(!provincia.readProvincia(this)) {
                return provincia.createProvincia(this);
            }

            return false;
        }

        public bool deleteProvincia() {
            CADProvincia provincia = new CADProvincia();
            if(provincia.readProvincia(this)) {
                return provincia.deleteProvincia(this);
            }

            return false;
        }

        public bool readProvincia() {
            CADProvincia provincia = new CADProvincia();
            return provincia.readProvincia(this);
        }

        public DataTable listarProvincias(string pais) {
            CADProvincia provincia = new CADProvincia();
            DataTable tabla = provincia.listarProvincias(pais);
            return tabla;

        }
        
    }
}
