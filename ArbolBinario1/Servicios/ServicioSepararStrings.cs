using ArbolBinario1.Exeptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArbolBinario1.servicios
{
    class ServicioSepararStrings
    {
        public static int encontrarOperadorCentral(String pCadena)
        {
            int contador = 0;
            char caracter;
            if (!esFormulaBienFormada(pCadena)) { throw new FormulaExeption("La formula no esta correctamente digitada"); }
            for (int i = 0; i < pCadena.Length; i++)
            {
                caracter = pCadena[i];
                if (caracter == '+' || caracter == '-' || caracter == '*' || caracter == '/')
                {
                    if (contador == 0)
                    {
                        return i;
                    }
                }

                if (caracter == '(')
                {
                    contador++;
                }
                else if (caracter == ')')
                {
                    contador--;
                }
            }

            throw new FormulaExeption("¡La formula esta mal formada!");
        }

        public static String[] separarCadenasOperadorCentral(String pCadena, int pPos)
        {
            String[] resultado = new String[3];

            resultado[0] = pCadena.Substring(0, pPos);

            resultado[1] = pCadena[pPos].ToString();

            resultado[2] = pCadena.Substring(pPos + 1);

            Console.WriteLine("-" + resultado[0] + "  -" + resultado[1] + " -"+ resultado[2]);
            return resultado;
        }

        public static string quitarEspaciosEnBlanco(String pCadena)
        {
            String res = pCadena.Trim();
            res = pCadena.Replace(" ", "");
            return res;
        }

        public static Boolean tieneParentesisExternos(String pCadena)
        {
            Boolean res = false;
            int contador = 0;
            for (int i = 0; i < pCadena.Length; i++)
            {
                char caracter1 = pCadena[i];
                char caracter2 = 'e';
                if (i < pCadena.Length - 1)
                {
                    caracter2 = pCadena[i + 1];
                }

                if (caracter1 == '(' && caracter2 == '(')
                {
                    contador++;
                }
                else if (caracter1 == ')' && caracter2 == ')')
                {
                    contador--;
                }
            }
            Console.WriteLine(contador);
            if (contador == 0)
            {
                res = true;
            }
            else
            {
               throw new FormulaExeption("La formula no tiene los parentesis externos.");
            }

            return res;
        }

        public static Boolean tieneParentesis(String pCadena)
        {
            Boolean res = false;
            if (pCadena.Contains("(") || pCadena.Contains(")"))
            {
                res = true;
            }
            return res;
        }

        public static String ponerParentesisExternos(String pCadena)
        {
            return "(" + pCadena + ")";
        }

        public static Boolean esOperadorChar(String pOperador)
        {
            Boolean res = false;

            if(pOperador == "+" || pOperador == "-" || pOperador == "*" || pOperador == "/")
            {
                res = true;
            }

            return res;
        }

        public static double realizarOperacion(String[] operadores)
        {
            double res = 0;
            double num1 = double.Parse(operadores[0]);
            double num2 = double.Parse(operadores[2]);

            if (operadores[1] == "+")
            {
                res = num1 + num2;
            }
            else if (operadores[1] == "-")
            {
                res = num1 - num2;
            }
            else if (operadores[1] == "*")
            {
                res = num1 * num2;
            }
            else if (operadores[1] == "/")
            {
                res = num1 / num2;
            }

            return res;
        }

        public static Boolean tieneParentesisCompletos(String pCadena)
        {
            Boolean res = false;
            int contador = 0;
            for (int i = 0; i < pCadena.Length; i++)
            {
                char caracter = pCadena[i];
                if (caracter == '(')
                {
                    contador++;
                }
                else if (caracter == ')')
                {
                    contador--;
                }
            }

            if (contador == 0)
            {
                res = true;
            }
            else
            {
                throw new FormulaExeption("La formula no tiene los parentesis completos.");
            }

            return res;
        }

        public static String quitarParentesisExternos(String pCadena)
        {
            String resultado;
            resultado = pCadena.Substring(1, pCadena.Length - 2);
            return resultado;
        }

        public static Boolean esOperador(String pCadena)
        {
            int contador = 0;
            Boolean res = false;
            String cadena = quitarParentesisExternos(pCadena);

            for (int i = 0; i < cadena.Length; i++)
            {
                char caracter = cadena[i];
                if (caracter == '+')
                {
                    contador++;
                }
                else if (caracter == '-')
                {
                    contador++;
                }
                else if (caracter == '*')
                {
                    contador++;
                }
                else if (caracter == '/')
                {
                    contador++;
                }
            }

            if (contador == 1)
            {
                res = true;
            }

            return res;
        }

        public static Boolean esFormulaBienFormada(String pCadena)
        {
            try
            {
                tieneParentesisExternos(pCadena);
                tieneParentesis(pCadena);
                return true;
            }
            catch (FormulaExeption e)
            {
                throw new FormulaExeption(e.darExeption());
            }
        }

        public static Boolean verificarParentesis(String pCadena)
        {
            Console.WriteLine(pCadena);
            Boolean res = false;
            if(darNumeroDeOperadores(pCadena)*2 == darNumeroDeParentesis(pCadena))
            {
                res = true;
            }
            else
            {
                throw new FormulaExeption("La formula no tiene los parentesis completos.");
            }
            return res;
        }

        public static int darNumeroDeParentesis(string pCadena)
        {
            int contador = 0;
            for (int i = 0; i < pCadena.Length; i++)
            {
                char caracter = pCadena[i];
                if (caracter == '(')
                {
                    contador++;
                }
                else if (caracter == ')')
                {
                    contador++;
                }
            }
            return contador;
        }

        public static int darNumeroDeOperadores(string pCadena)
        {
            int contador = 0;
            for (int i = 0; i < pCadena.Length; i++)
            {
                char caracter = pCadena[i];
                if (caracter == '+')
                {
                    contador++;
                }
                else if (caracter == '-')
                {
                    contador++;
                }
                else if (caracter == '*')
                {
                    contador++;
                }
                else if (caracter == '/')
                {
                    contador++;
                }
            }
            return contador;
        }

        public static Boolean esFormulaAtomica(String pCadena)
        {
            int contador = 0;
            Boolean res = false;
            String cadena = quitarParentesisExternos(pCadena);

            for(int i = 0; i < cadena.Length; i++)
            {
                char caracter = cadena[i];
                if(caracter == '+')
                {
                    contador++;
                }else if (caracter == '-')
                {
                    contador++;
                }
                else if (caracter == '*')
                {
                    contador++;
                }
                else if (caracter == '/')
                {
                    contador++;
                }
            }

            if(contador == 1)
            {
                res = true;
            }

            return res;
        }

    }
}
