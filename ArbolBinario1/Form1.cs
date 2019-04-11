using ArbolBinario1.estructural;
using ArbolBinario1.Exeptions;
using ArbolBinario1.servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArbolBinario1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                tbxFormula.Text = ServicioSepararStrings.quitarEspaciosEnBlanco(tbxFormula.Text);
                if(!ServicioSepararStrings.tieneParentesis(tbxFormula.Text))
                {
                    tbxFormula.Text = ServicioSepararStrings.ponerParentesisExternos(tbxFormula.Text);
                }
                Nodo raiz = new Nodo(tbxFormula.Text);
                ServicioArbolBinario.setRaiz(raiz);
                ServicioArbolBinario.crearArbol(raiz);
                MessageBox.Show("¡Se creo el arbol correctamente!");
            }
            catch (FormulaExeption er)
            {
                MessageBox.Show(er.darExeption());
            }
        }

        private void btnPreorden_Click(object sender, EventArgs e)
        {
            String cad;
            cad = ServicioArbolBinario.darRecorridoPreorden();
            tbxPreorden.Text = cad;
        }

        private void btnInorden_Click(object sender, EventArgs e)
        {
            String cad;
            cad = ServicioArbolBinario.darRecorridoInorden();
            tbxInorden.Text = cad;
        }

        private void btnPostOrden_Click(object sender, EventArgs e)
        {
            String cad;
            cad = ServicioArbolBinario.darRecorridoPostorden();
            tbxPostOrden.Text = cad;
        }

        private void btnResultado_Click(object sender, EventArgs e)
        {
            try
            {
                if (ServicioArbolBinario.getRaiz() != null)
                {
                    ServicioArbolBinario.calcularArbol(ServicioArbolBinario.getRaiz());
                    tbxResultado.Text = ServicioArbolBinario.getRaiz().getDato();

                    tbxFormula.Text = ServicioSepararStrings.quitarEspaciosEnBlanco(tbxFormula.Text);
                    Nodo raiz = new Nodo(tbxFormula.Text);
                    ServicioArbolBinario.setRaiz(raiz);
                    ServicioArbolBinario.crearArbol(raiz);
                }
                else
                {
                    MessageBox.Show("¡Debe crear primero el arbol binario!");
                }
            }
            catch (FormulaExeption er)
            {
                MessageBox.Show(er.darExeption());
            }
        }
    }
}
