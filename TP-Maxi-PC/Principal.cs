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
using TP_Maxi_PC.ABM.Empleados;

namespace TP_Maxi_PC
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        //SALIR
        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //PC y TIPOS PC
        private void btnPc_Click(object sender, EventArgs e)
        {
            Agregar_PC nuevo = new Agregar_PC();
            nuevo.Show();
        }

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Agregar_PC nuevo = new Agregar_PC();
            nuevo.Show();
        }

        private void tiposPCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Agregar_TipoPC nuevo = new Agregar_TipoPC();
            nuevo.Show();
        }

        //TIPOS COMPONENTE
        private void tiposComponenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Agregar_TipoComp nuevo = new Agregar_TipoComp();
            nuevo.Show();
        }

        //CLIENTE
        private void btnCliente_Click(object sender, EventArgs e)
        {
            Agregar_Cliente nuevo = new Agregar_Cliente();
            nuevo.Show();
        }

        //EMPLEADOS
        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            EmpleadosForm nuevoEmp = new EmpleadosForm(this);
            nuevoEmp.Show();
            this.Hide();
        }

        
    }
}
