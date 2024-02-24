using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    public class ENPublicidad
    {
        private string _id;
        private string _empresa;
        private string _imagen;
        private string _url_empresa;

        public string id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }

        public string empresa
        {
            get
            {
                return _empresa;
            }

            set
            {
                _empresa = value;
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

        public string url_empresa
        {
            get
            {
                return _url_empresa;
            }

            set
            {
                _url_empresa = value;
            }
        }

        //Constructor por defecto
        public ENPublicidad()
        {
            id = null;
            empresa = null;
            imagen = null;
            url_empresa = null;
        }

        //Constructor de copia
        public ENPublicidad(string id, string empresa, string imagen, string url_empresa)
        {
            this.id = id;
            this.empresa = empresa;
            this.imagen = imagen;
            this.url_empresa = url_empresa;
        }

        //crea la publicidad
        public bool createPublicidad()
        {
            CADPublicidad publicidad = new CADPublicidad();
            bool creado = false;
            if (!publicidad.createPublicidad(this))
            {
                creado = publicidad.createPublicidad(this);
            }
            return creado;
        }

        //lee la publicidad
        public bool readPublicidad()
        {
            CADPublicidad publicidad = new CADPublicidad();
            bool read = publicidad.readPublicidad(this);
            return read;
        }

        //actualiza la publicidad
        public bool updatePublicidad()
        {
            ENPublicidad aux = new ENPublicidad();
            CADPublicidad publicidad = new CADPublicidad();

            bool actualizado = false;

            aux.id = this.id;
            aux.imagen = this.imagen;
            aux.empresa = this.empresa;
            aux.url_empresa = this.url_empresa;

            if (publicidad.readPublicidad(this))
            {
                this.id = aux.id;
                this.imagen = aux.imagen;
                this.url_empresa = aux.url_empresa;
                this.empresa = aux.empresa;
                actualizado = publicidad.updatePublicidad(this);
            }

            return actualizado;
        }

        //borra la publicidad
        public bool deletePublicidad()
        {
            CADPublicidad publicidad = new CADPublicidad();
            bool leido = false;
            if (publicidad.readPublicidad(this))
            {
                leido = publicidad.deletePublicidad(this);
            }
            return leido;
        }

        //lista la publicidad
        public DataTable listarPublicidad() {
            CADPublicidad publicidad = new CADPublicidad();
            return publicidad.listarPublicidad();
        }

    }
}
