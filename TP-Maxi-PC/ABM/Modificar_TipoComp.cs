using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TP_Maxi_PC.Repositorios;

namespace TP_Maxi_PC.ABM
{
    public partial class Modificar_TipoComp : Form
    {
        TiposCompRepositorio tiposCompRepositorio;
        int idTipoComp;
        public Modificar_TipoComp(String id, String nombre)
        {
            InitializeComponent();
            tiposCompRepositorio = new TiposCompRepositorio();
            txtNombre.Text = nombre;
            idTipoComp = Int32.Parse(id);
        }
        

        private void Modificar_TipoPC_Load(object sender, EventArgs e)
        {

        }

        private void btn_Cargar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == "")
            {
                MessageBox.Show("Complete el nombre");
                txtNombre.Focus();
            }
            else
            {
                tiposCompRepositorio.modificarTiposComponente(idTipoComp, txtNombre.Text);
                MessageBox.Show("Se modifico Correctamente!");
                this.Close();
            }
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
