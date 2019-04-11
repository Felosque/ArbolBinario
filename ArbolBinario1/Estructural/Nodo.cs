using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArbolBinario1.estructural
{
    class Nodo
    {
        private String dato;
        private Nodo izq;
        private Nodo der;
        private Nodo padre;

        public Nodo(String pDato)
        {
            dato = pDato;
        }

        public void setDato(String pDato)
        {
            dato = pDato;
        }

        public String getDato()
        {
            return dato;
        }


        public void setIzq(Nodo pIzq)
        {
            izq = pIzq;
        }

        public Nodo getIzq()
        {
            return izq;
        }


        public void setDer(Nodo pDer)
        {
            der = pDer;
        }

        public Nodo getDer()
        {
            return der;
        }


        public void setPadre(Nodo pPadre)
        {
            padre = pPadre;
        }

        public Nodo getPadre()
        {
            return padre;
        }

    }
}
