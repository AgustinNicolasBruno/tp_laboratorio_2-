using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tp1_lab2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
            this.cmbOperacion.Items.Add("/");
            this.cmbOperacion.Items.Add("*");
            this.cmbOperacion.Items.Add("+");
            this.cmbOperacion.Items.Add("-");
            this.cmbOperacion.SelectedIndex = 0;

            
           
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.lblResultado.Text = "0";
            this.txtNumero1.Text = "";
            this.txtNumero2.Text = "";
            this.cmbOperacion.Text = "/";           

        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            Calculadora ca = new Calculadora();
            Numero n1 = new Numero(this.txtNumero1.Text.ToString());
            Numero N2 = new Numero(this.txtNumero2.Text.ToString());
            this.lblResultado.Text = ca.operar(n1, N2, this.cmbOperacion.Text).ToString();
        }
    }
}
