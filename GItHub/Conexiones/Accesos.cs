using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Conexiones
{
    class Accesos
    {
        private SqlConnection Connection;
        private SqlCommand Command;
        private SqlDataReader reader;

        public SqlDataReader Reader
        {
            get { return reader; }
        }


        public Accesos()
        {
            Connection = new SqlConnection("server = .\\SQLEXPRESS; database = CATALOGO_DB; integrated security = true");
            Command = new SqlCommand();
        }

        public void SetConsulta(string CC)
        {
            Command.CommandType = System.Data.CommandType.Text;
            Command.CommandText = CC;
        }

        public void SetearPARAMETROS(string Parametro, object valor)
        {
            Command.Parameters.AddWithValue(Parametro, valor);      
        }

        public void exeLectura()
        {
            Command.Connection = Connection;
            try
            {
                Connection.Open();
                reader = Command.ExecuteReader();
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void exeEscribir()
        {
            Command.Connection = Connection;
            try
            {
                Connection.Open();
                Command.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }

        public void CloseConecction()
        {
            if (reader != null)
            {
                reader.Close();
                Connection.Close();
            }
        }

    }
}
