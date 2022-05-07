using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases;


namespace Conexiones
{
         public class MarcasListado
        {
            public List<Marcas> Listado()
            {
                List<Marcas> Lista = new List<Marcas>();
                Accesos accesos = new Accesos();
                try
                {
                    accesos.SetConsulta("Select ID, Descripcion as 'Categoria' from MARCAS");
                    accesos.exeLectura();

                    while (accesos.Reader.Read())
                    {
                        Marcas Aux = new Marcas();
                         Aux.ID = (int)accesos.Reader["ID"];
                         Aux.Marca = (string)accesos.Reader["Categoria"];

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

