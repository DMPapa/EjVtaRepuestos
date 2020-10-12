using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjVtaRepuestos.Entidades
{
    class StockNegativoException : Exception
    {
        public StockNegativoException(string message) : base(message)
        {
        }
    }
}
