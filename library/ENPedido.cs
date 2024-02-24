using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using library;
using System.Data;

namespace library {
    public class ENPedido {
        private int _idPedido;
        private string _user;
        private string _date;
        private string _state;
        private float _total;

        public int idPedido {
            get { return _idPedido; }
            set { _idPedido = value; }
        }
        public string user {
            get { return _user; }
            set { _user = value; }
        }
        public string date {
            get { return _date; }
            set { _date = value; }
        }
        public string state {
            get { return _state; }
            set { _state = value; }
        }
        public float total {
            get { return _total; }
            set { _total = value; }
        }
        public DataTable joinPedido() {
            CADPedido pedido = new CADPedido();
            return pedido.joinPedido(this);
        }

        public ENPedido() {
            idPedido = 0;
            date = null;
            state = null;
            total = 0;
        }

        public bool createPedido() {
            CADPedido pedido = new CADPedido();
            return pedido.createPedido(this);
        }
        public bool readPedido() {
            CADPedido pedido = new CADPedido();
            return pedido.readPedido(this);
        }

        public bool updatePedido() {
            CADPedido pedido = new CADPedido();
            return pedido.updatePedido(this);
        }
        public bool deletePedido() {
            CADPedido pedido = new CADPedido();
            return pedido.deletePedido(this);
        }
        public static DataSet listPedidos(string mail) {
            CADPedido pedidos = new CADPedido();
            return pedidos.listPedidos(mail);
        }

        internal void getId() {
            CADPedido pedido = new CADPedido();
            this.idPedido = pedido.getId();
        }

    }
}
