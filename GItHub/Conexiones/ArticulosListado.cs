using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases;

namespace Conexiones
{
    public class ArticulosListado
    {
        public List<ClassArticulo> Listado()
        {
            List<ClassArticulo> Lista = new List<ClassArticulo>();
            Accesos accesos = new Accesos();
            try
            {
                accesos.SetConsulta("Select Codigo, Nombre, Descripcion, IdMarca, IdCategoria, ImagenUrl, Precio from ARTICULOS");
                accesos.exeLectura();

                while (accesos.Reader.Read())
                {
                    ClassArticulo Aux = new ClassArticulo();
                    Aux.Codigo = (int)accesos.Reader["Codigo"];
                    Aux.Nombre = (string)accesos.Reader["Nombre"];
                    Aux.Descripción = (string)accesos.Reader["Descripción"];
                    Aux.Marcas = new Marcas();
                    Aux.Marcas.Marca = (string)accesos.Reader["Marca"];
                    Aux.Categorias = new Categorias();
                    Aux.Categorias.Categoria = (string)accesos.Reader["Categoria"];
                    Aux.ImagenURL = (string)accesos.Reader["URL"];
                    Aux.Precio = (decimal)accesos.Reader["Precio"];

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

        public void insert(ClassArticulo Agregar)
        {
            Accesos accesos = new Accesos();

            try
            {
                accesos.SetConsulta("insert into ARTICULOS values(" + Agregar.Codigo + ", '" + Agregar.Nombre + "', '" + Agregar.Descripción + "'@IDMarca, IDCategoria, " + Agregar.Precio + "  )");
                accesos.SetearPARAMETROS("IDMarca", Agregar.Marcas.ID);
                accesos.SetearPARAMETROS("IDCategoria", Agregar.Categorias.ID);
                accesos.exeLectura();

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
