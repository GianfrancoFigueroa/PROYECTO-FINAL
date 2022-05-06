using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Clases;
using Actividad2;

namespace ClassLibrary1
{
    public class ArticulosConexion
    {
        public List<ClassArticulo> Listar()
        {

            List<ClassArticulo> ListaArticulos = new List<ClassArticulo>();
            SqlConnection connection = new SqlConnection();
            SqlCommand command = new SqlCommand();
            SqlDataReader reader;

            try
            {

                connection.ConnectionString = "server = .\\SQLEXPRESS; database = CATALOGO_DB; integrated security = true";
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "";
                command.Connection = connection;

                connection.Open();
                command.ExecuteReader();

                return ListaArticulos;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }
        

        


    }
}
