using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;


namespace library {
    public class CADPedido {
        private string constring;
        public CADPedido() {
            constring = ConfigurationManager.ConnectionStrings["Database"].ToString();
        }
        public bool createPedido(ENPedido en) {
            bool creado = false;
            CultureInfo culture = new CultureInfo("en-US");
            string resultado = en.total.ToString("0.00", culture);
            string consulta = "INSERT INTO [dbo].[Pedido] (num_pedido, usuario, estado_carrito, fecha, total) VALUES (" + en.idPedido + ", '" + en.user + "', 'Listo', '" + en.date + "', " + resultado + ")";
            SqlConnection connection = new SqlConnection(constring);

            try {
                connection.Open();
                SqlCommand command = new SqlCommand(consulta, connection);
                command.ExecuteNonQuery();

                creado = true;

            } catch (SqlException e) {
                Console.WriteLine("The operation has failed.Error: {0}", e.Message);
            } catch (Exception e) {
                Console.WriteLine("The operation has failed.Error: {0}", e.Message);
            } finally {
                if (connection.State == ConnectionState.Open) {
                    connection.Close();
                }
            }
            return creado;
        }
        public bool readPedido(ENPedido en) {
            bool read = false;
            string consulta = "SELECT * FROM [dbo].[Pedido] " + "WHERE num_pedido = '" + en.idPedido + "'";

            SqlConnection connection = new SqlConnection(constring);
            try {
                connection.Open();
                SqlCommand command = new SqlCommand(consulta, connection);
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();

                if (int.Parse(reader["num_pedido"].ToString()) == en.idPedido) {
                    en.user = reader["usuario"].ToString();
                    en.date = String.Format("{0:mm/dd/yyyy}", reader["fecha"]);
                    reader.Close();
                    read = true;
                } else {
                    reader.Close();
                    read = false;
                }
            } catch (SqlException e) {
                Console.WriteLine("The operation has failed.Error: {0}", e.Message);
            } catch (Exception e) {
                Console.WriteLine("The operation has failed.Error: {0}", e.Message);
            } finally {
                if (connection.State == ConnectionState.Open) {
                    connection.Close();
                }
            }
            return read;
        }

        public int getId() {

            int newId = 1;
            string consulta = "Select max(num_pedido) max from[dbo].[Pedido]";
            SqlConnection connection = new SqlConnection(constring);

            try {
                connection.Open();
                SqlCommand command = new SqlCommand(consulta, connection);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read()) {
                    newId = int.Parse(reader["max"].ToString()) + 1;
                    reader.Close();
                }
            } catch (SqlException e) {
                Console.WriteLine("The operation has failed.Error: {0}", e.Message);
            } catch (Exception e) {
                Console.WriteLine("The operation has failed.Error: {0}", e.Message);
            } finally {
                if (connection.State == ConnectionState.Open) {
                    connection.Close();
                }
            }

            return newId;
        }

        public DataTable joinPedido(ENPedido en) {
            string consulta = "Select * from [dbo].[LinPedido], [dbo].[Articulo] where articulo = codigo  and id_pedido = " + en.idPedido;
            DataSet dbVirtual = new DataSet();
            SqlConnection connection = new SqlConnection(constring);
            SqlDataAdapter adap = new SqlDataAdapter(consulta, connection);
            adap.Fill(dbVirtual, "LINPED");

            return dbVirtual.Tables["LINPED"];
        }

        public bool updatePedido(ENPedido en) {
            SqlConnection connection = new SqlConnection(constring);

            try {
                CultureInfo culture = new CultureInfo("en-US");
                string resultado = en.total.ToString("0.00", culture);
                connection.Open();
                SqlCommand command = new SqlCommand("UPDATE [dbo].[Pedido] set usuario= '" + en.user + "', estado_carrito= 'Listo', fecha= '" + en.date + "', total=" + resultado + "where num_pedido=" + en.idPedido, connection);
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception e) {
                Console.WriteLine("Updating table PEDIDO has failed. Error: {0}", e.Message);
                return false;
            }
            finally {
                connection.Close();
            }
        }

        public bool deletePedido(ENPedido en) {
            bool borrado = false;
            string consulta = "delete from [dbo].[Pedido] where num_pedido=" + en.idPedido;
            SqlConnection connection = new SqlConnection(constring);

            try {
                connection.Open();
                SqlCommand command = new SqlCommand(consulta, connection);
                command.ExecuteNonQuery();

                borrado = true;

            }
            catch (SqlException e) {
                Console.WriteLine("The operation has failed.Error: {0}", e.Message);
            }
            catch (Exception e) {
                Console.WriteLine("The operation has failed.Error: {0}", e.Message);
            }
            finally {
                if (connection.State == ConnectionState.Open) {
                    connection.Close();
                }
            }
            return borrado;
        }

        public DataSet listPedidos(string en) {
            string consulta = "select * from [dbo].[Pedido] where usuario= '" + en + "'";
            DataSet dbVirtual = new DataSet();
            SqlConnection connection = new SqlConnection(constring);
            SqlDataAdapter adap = new SqlDataAdapter(consulta, connection);
            adap.Fill(dbVirtual, "Pedido");

            return dbVirtual;
        }
    }
}

