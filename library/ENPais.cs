using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace library
{
    /// <summary>
    /// Clase encargada de gestionar la entidad paises.
    /// Solo posee una propiedad la cual tiene el nombre del pais.
    /// Solo puede haber un pais asociado a un nombre.
    /// </summary>
     public class ENPais
    {
        private string _pais;

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

        public ENPais()
        {
            pais = null;
        }
        public ENPais(string pais)
        {
            this.pais = pais;
        }
        //Crea un nuevo pais
        public bool createPais()
        {
            CADPais pais = new CADPais();
            if(pais.readPais(this) == true)
            {
                return false;
            }
            return pais.createPais(this);
        }

        //Lee el pais pasado como parametro
        public bool readPais()
        {
            CADPais pais = new CADPais();
            return pais.readPais(this);
        }
        //Actualiza el pais actual por el pasado por parametro
        public bool updatePais()
        {
            CADPais pais = new CADPais();
            if (pais.readPais(this) == false)
            {
                return false;
            }
            return pais.updatePais(this);
        }
        //Borra el pais pasado como parametro si existe
        public bool deletePais()
        {
            CADPais pais = new CADPais();
            if (pais.readPais(this) == false)
            {
                return false;
            }
            return pais.deletePais(this);
        }

        //Un dataSet que solo lista los paises
        public DataSet listarPaises()
        {
            CADPais pais = new CADPais();
            return pais.listarPaises();
        }
    }
}
