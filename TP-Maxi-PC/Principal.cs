using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TP_Maxi_PC.ABM;

namespace TP_Maxi_PC
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void sistemaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void equiposToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pCToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Agregar_PC nuevo = new Agregar_PC();
            nuevo.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Agregar_Cliente nuevo = new Agregar_Cliente();
            nuevo.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Agregar_PC nuevo = new Agregar_PC();
            nuevo.Show();
        }

        private void tiposPCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Agregar_TipoPC nuevo = new Agregar_TipoPC();
            nuevo.Show();
        }
    }
}
