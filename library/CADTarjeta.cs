using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    public class CADTarjeta
    {
        private string constring;

        //Constructor por defecto
        public CADTarjeta()
        {
            constring = ConfigurationManager.ConnectionStrings["Database"].ToString();
        }

        //Crea la tarjeta pasada como parámetro
        public bool createTarjeta(ENTarjeta tarjeta)
        {
            SqlConnection connection = new SqlConnection(constring);

            try {
                connection.Open();
                SqlCommand command = new SqlCommand("Insert INTO Tarjeta VALUES('" + tarjeta.num + "', '" + tarjeta.cvv + "', " + tarjeta.mesFecha + ", " + tarjeta.anyoFecha + ", '" + tarjeta.usuario + "')", connection);
                command.ExecuteNonQuery();
                return true;
            }
            catch(Exception e) {
                Console.WriteLine("Create TARJETA has failed. Error: {0}", e.Message);
                return false;
            }
            finally {
                connection.Close();
            }
        }

        //Lee la tarjeta pasada como parámetro
        public bool readTarjeta(ENTarjeta tarjeta)
        {
            SqlConnection connection = new SqlConnection(constring);
            try {
                connection.Open();
                SqlCommand command = new SqlCommand("Select * FROM Tarjeta where numTarjeta= '" + tarjeta.num + "'", connection);
                command.ExecuteNonQuery();
                return true;
            }
            catch(Exception e) {
                Console.WriteLine("Reading TARJETA table has failed. Error: {0}", e.Message);
                return false;
            }
            finally {
                connection.Close();
            }
        }
        //Actualiza la tarjeta actual por la pasada por parámetro
        public bool updateTarjeta(ENTarjeta tarjeta)
        {
            SqlConnection connection = new SqlConnection(constring);

            try {
                connection.Open();
                SqlCommand command = new SqlCommand("UPDATE [dbo].[Tarjeta] set numTarjeta= '" + tarjeta.num + "', cvv= '" + tarjeta.cvv + "', mes_cad= " + tarjeta.mesFecha + ", anyo_cad= " + tarjeta.anyoFecha + ", usuario= '" + tarjeta.usuario + "' where numTarjeta= " + tarjeta.num, connection);
                command.ExecuteNonQuery();
                return true;
            }
            catch(Exception e) {
                Console.WriteLine("Updating table TARJETA has failed. Error: {0}", e.Message);
                return false;
            }
            finally {
                connection.Close();
            }
        }
        //Borra la tarjeta pasada como parámetro si existe
        public bool deleteTarjeta(ENTarjeta tarjeta)
        {
            SqlConnection connection = new SqlConnection(constring);

            try {
                connection.Open();
                SqlCommand command = new SqlCommand("DELETE FROM Tarjeta where numTarjeta= '" + tarjeta.num + "'", connection);
                command.ExecuteNonQuery();
                return true;
            }
            catch(Exception e) {
                Console.WriteLine("Deleting table TARJETA has failed. Error: {0}", e.Message);
                return false;
            }
            finally {
                connection.Close();
            }
        }

        //Lista las tarjetas
        public DataTable listarTarjetas() {
            DataTable table = new DataTable();
            SqlConnection connection = new SqlConnection(constring);

            try {
                SqlDataAdapter data = new SqlDataAdapter("Select * from Tarjeta", connection);
                data.Fill(table);
            }
            catch (Exception e) {
                Console.WriteLine("The operation has failed.Error: {0}", e.Message);
            }
            finally {
                connection.Close();
            }

            return table;
        }

        //Lista las tarjetas del usuario pasado como parámetro
        public DataSet listarTarjetas(string usuario) {
            DataSet bdvirtual = new DataSet();
            SqlConnection connection = new SqlConnection(constring);
            SqlDataAdapter da = new SqlDataAdapter("select * from [dbo].[Tarjeta] where usuario= '" + usuario + "'", connection);
            da.Fill(bdvirtual, "TARJETA");
            return bdvirtual;
        }
    }
}
