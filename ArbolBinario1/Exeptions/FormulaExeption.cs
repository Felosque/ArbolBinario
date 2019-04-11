using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArbolBinario1.Exeptions
{
    class FormulaExeption : Exception
    {
        String exepcion;

        public FormulaExeption(String pExepcion)
        {
            exepcion = pExepcion;
        }

        public String darExeption()
        {
            return exepcion;
        }
    }
}
