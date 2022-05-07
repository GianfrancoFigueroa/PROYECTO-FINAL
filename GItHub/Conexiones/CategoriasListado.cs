using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases;


namespace Conexiones
{

        public class CategoriaListado
        {
            public List<Categorias> Listado()
            {
                List<Categorias> Lista = new List<Categorias>();
                Accesos accesos = new Accesos();
                try
                {
                    accesos.SetConsulta("Select Id, Descripcion as 'Categoria' from CATEGORIAS");
                    accesos.exeLectura();

                    while (accesos.Reader.Read())
                    {
                        Categorias Aux = new Categorias();
                        Aux.ID = (int)accesos.Reader["Id"];
                        Aux.Categoria = (string)accesos.Reader["Categoria"];

                        Lista.Add(Aux);
                    }

                    return Lista;
                }
                catch (Exception Ex)
                {
                     
                     throw Ex;
                }
                finally
                {
                    accesos.CloseConecction();
                }

            }


        }
    }