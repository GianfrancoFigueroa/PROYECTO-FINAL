using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class ClassArticulo
    {
        public string Codigo { get; set; }

        public string Nombre { get; set; }

        public string Descripción { get; set; }

        public Marcas Marcas { get; set; }

        public Categorias Categorias { get; set; }

        public string ImagenURL { get; set; }

        public decimal Precio { get; set; }

    }
}
