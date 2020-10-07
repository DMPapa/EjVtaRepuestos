using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EjVtaRepuestos.Entidades;

namespace EjVtaRepuestos
{
    static class CategoriaHelper
    {
        private static List<Categoria> _listaCategorias;

        static CategoriaHelper()
        {
            _listaCategorias = new List<Categoria>();
            _listaCategorias.Add(new Categoria(1, "general"));
            _listaCategorias.Add(new Categoria(2, "específico"));
        }
        public static List<Categoria> GetCategorias ()
        {
            return _listaCategorias;
        }
        public static Categoria GetCategoriaPorCodigo (int codcat)
        {
            Categoria cat = null;
            foreach (Categoria c in _listaCategorias)
            {
                if (c.Codigo == codcat)
                    cat = c;
            }
            return cat;
        }


    }
}
