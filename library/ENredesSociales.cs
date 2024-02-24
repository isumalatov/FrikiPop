using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using library;

namespace library
{
    public class ENredesSociales
    {
        private string _red; //declara los atributos
        private string _urlLogo;
        private string _linkRed;

        public string red
        {
            get
            {
                return _red;
            }
            set
            {
                _red = value;
            }
        }

        public string urlLogo
        {
            get
            {
                return _urlLogo;
            }
            set
            {
                _urlLogo = value;
            }
        }

        public string linkRed
        {
            get
            {
                return _linkRed;
            }
            set
            {
                _linkRed = value;
            }
        }

        public ENredesSociales() //crea la clase
        {
            red = null;
            urlLogo = null;
            linkRed = null;
        }

        public bool createRedesSociales() //funciones del en
        {
            CADredesSociales redesSociales = new CADredesSociales();
            if (!redesSociales.readRedesSociales(this))
            {
                return redesSociales.createRedesSociales(this);
            }
            return false;
        }

        public bool deleteRedesSociales()
        {
            CADredesSociales redesSociales = new CADredesSociales();
            if (redesSociales.readRedesSociales(this))
            {
                return redesSociales.deleteRedesSociales(this);
            }
            return false;
        }

        public bool readRedesSociales()
        {
            CADredesSociales redesSociales = new CADredesSociales();
            return redesSociales.readRedesSociales(this);
        }

        public bool updateRedesSociales()
        {
            CADredesSociales redesSociales = new CADredesSociales();
            if (redesSociales.readRedesSociales(this))
            {
                return redesSociales.updateRedesSociales(this);
            }
            return false;
        }

        public DataTable listarRedesSociales()
        {
            CADredesSociales redesSociales = new CADredesSociales();
            DataTable tabla = redesSociales.listarRedesSociales();
            return tabla;
        }
    }
}
