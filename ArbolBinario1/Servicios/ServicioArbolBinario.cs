using ArbolBinario1.estructural;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArbolBinario1.servicios
{
    class ServicioArbolBinario
    {
        private static Nodo raiz;

        public static void setRaiz(Nodo pRaiz)
        {
            raiz = pRaiz;
        }

        public static Nodo getRaiz()
        {
            return raiz;
        }

        public static String darRecorridoPreorden()
        {
            String cad = "";
            cad = recorrerPreorden(raiz, cad);
            return cad;
        }

        public static String darRecorridoPostorden()
        {
            String cad = "";
            cad = recorrerPosorden(raiz, cad);
            return cad;
        }

        public static String darRecorridoInorden()
        {
            String cad = "";
            cad = recorrerInorden(raiz, cad);
            return cad;
        }


        private static String recorrerPreorden(Nodo recorrer, String cad)
        {
            if (recorrer == null)
            {
                return cad;
            }
            cad = cad + recorrer.getDato() + ", ";
            cad = recorrerPreorden(recorrer.getIzq(), cad);
            cad = recorrerPreorden(recorrer.getDer(), cad);
            return cad;
        }

        private static String recorrerInorden(Nodo recorrer, String cad)
        {
            if (recorrer == null)
            {
                return cad;
            }
            cad = recorrerInorden(recorrer.getIzq(), cad);
            cad = cad + recorrer.getDato() + ", ";
            cad = recorrerInorden(recorrer.getDer(), cad);
            return cad;
        }

        private static String recorrerPosorden(Nodo recorrer, String cad)
        {
            if (recorrer == null)
            {
                return cad;
            }
            cad = recorrerPosorden(recorrer.getIzq(), cad);
            cad = recorrerPosorden(recorrer.getDer(), cad);
            cad = cad + recorrer.getDato() + ", ";
            return cad;
        }


        public static void calcularArbol(Nodo actual)
        {
            if( ServicioSepararStrings.esOperadorChar(actual.getDato()) && ServicioSepararStrings.esOperadorChar(actual.getIzq().getDato()))
            {
                calcularArbol(actual.getIzq());
            }else
            {
                if(ServicioSepararStrings.esOperadorChar(actual.getDer().getDato()))
                {
                    calcularArbol(actual.getDer());
                }
                else
                {
                    String[] operacion = new String[3];
                    operacion[0] = actual.getIzq().getDato();
                    operacion[1] = actual.getDato();
                    operacion[2] = actual.getDer().getDato();
                    actual.setDer(null);
                    actual.setIzq(null);
                    actual.setDato(  Convert.ToString( ServicioSepararStrings.realizarOperacion(operacion) ));
                }
            }

            if(actual.getDer() != null && actual.getIzq() != null)
            {
                calcularArbol(actual);
            }
        }

        public static void crearArbol(Nodo actual)
        {
            if (ServicioSepararStrings.tieneParentesisExternos(actual.getDato()))
            {
                //Quita los parentesis del actual
                if (ServicioSepararStrings.esFormulaAtomica(actual.getDato()))
                {
                    if (ServicioSepararStrings.tieneParentesisCompletos(actual.getDato()))
                    {
                        actual.setDato(ServicioSepararStrings.quitarParentesisExternos(actual.getDato()));
                    }
                    //Encuentra el operador central
                    int operadorCentral = ServicioSepararStrings.encontrarOperadorCentral(actual.getDato());
                    String[] cadenas = ServicioSepararStrings.separarCadenasOperadorCentral(actual.getDato(), operadorCentral);
                    Nodo izq = new Nodo(cadenas[0]);
                    actual.setDato(cadenas[1]);
                    Nodo der = new Nodo(cadenas[2]);
                    actual.setIzq(izq);
                    actual.setDer(der);
                    return;
                }
                else
                {

                    actual.setDato(ServicioSepararStrings.quitarParentesisExternos(actual.getDato()));

                    int operadorCentral = ServicioSepararStrings.encontrarOperadorCentral(actual.getDato());
                    String[] cadenas = ServicioSepararStrings.separarCadenasOperadorCentral(actual.getDato(), operadorCentral);
                    Nodo izq = new Nodo(cadenas[0]);
                    actual.setDato(cadenas[1]);
                    Nodo der = new Nodo(cadenas[2]);
                    actual.setIzq(izq);
                    actual.setDer(der);
                    crearArbol(izq);
                    crearArbol(der);
                }
            }
        }

    }
}
