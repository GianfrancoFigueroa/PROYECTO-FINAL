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
                accesos.SetConsulta("Select A.Codigo, A.Nombre, A.Descripcion, M.id, M.Descripcion as 'Marca', C.id, C.Descripcion as 'Categoria', A.ImagenUrl, A.Precio from ARTICULOS A, CATEGORIAS C, MARCAS M where M.Id = A.IdMarca and C.Id = A.IdCategoria");
                accesos.exeLectura();

                while (accesos.Reader.Read())
                {
                    ClassArticulo Aux = new ClassArticulo();
                    Aux.Codigo = (string)accesos.Reader["Codigo"];
                    Aux.Nombre = (string)accesos.Reader["Nombre"];
                    Aux.Descripción = (string)accesos.Reader["Descripcion"];
                    Aux.Marcas = new Marcas();
                    Aux.Marcas.ID = (int)accesos.Reader["Id"];
                    Aux.Marcas.Marca = (string)accesos.Reader["Marca"];
                    Aux.Categorias = new Categorias();
                    Aux.Categorias.ID = (int)accesos.Reader["Id"];
                    Aux.Categorias.Categoria = (string)accesos.Reader["Categoria"];
                    Aux.ImagenURL = (string)accesos.Reader["ImagenURL"];
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
