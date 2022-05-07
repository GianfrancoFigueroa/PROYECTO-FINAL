using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class Categorias
    {
        public int ID { get; set; }

        public string Categoria { get; set; }

        public override string ToString()
        {
            return Categoria;
        }
    }
}
