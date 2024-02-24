using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    public class ENLinPedido
    {
        //variables privadas
        private int pedido;
        private int linea;
        private string articulo;
        private float importe;
        private string usuario;
        //(_pedido, _linea, _articulo, _importe) permiten acceder
        //y modificar los valores de las variables privadas correspondientes.
        public int _pedido
        {
            get { return pedido; }
            set { pedido = value; }
        }
        public int _linea
        {
            get { return linea; }
            set { linea = value; }
        }
        public string _articulo
        {
            get { return articulo; }
            set { articulo = value; }
        }
        public float _importe
        {
            get { return importe; }
            set { importe = value; }
        }

        public string _usuario {
            get { return usuario; }
            set { usuario = value; }
        }
 
        //se utiliza para crear instancias de la clase
        //Recibe como parámetros los valores para linea, pedido, articulo e importe, 
        //y asigna esos valores a las variables correspondientes
        public ENLinPedido(int linea, int pedido, string articulo, float importe, string usuario)
        {
            this.pedido = pedido;
            this.linea = linea;
            this.articulo = articulo;
            this.importe = importe;
            this.usuario = usuario;
        }
        // crear un nuevo registro
        public bool createLinPedido()
        {
            CADLinPedido pedido = new CADLinPedido();
            if (!pedido.readLinPedido(this))
            {
                return pedido.createLinPedido(this);
            }
            return false;
        }
        //Lee un registro
        public bool readLinPedido()
        {
            CADLinPedido pedido = new CADLinPedido();
            return pedido.readLinPedido(this);
        }
        //actualiza un registro
        public bool updateLinPedido()
        {
            CADLinPedido pedido = new CADLinPedido();
            if (pedido.readLinPedido(this))
            {
                return pedido.updateLinPedido(this);
            }

            return false;
        }
        //elimina un registro
        public bool deleteLinPedido()
        {
            CADLinPedido pedido = new CADLinPedido();
            if (pedido.readLinPedido(this))
            {
                return pedido.deleteLinPedido(this);
            }

            return false;
        }
    }
}
