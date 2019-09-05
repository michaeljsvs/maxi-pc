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
    public partial class Modificar_TipoPC : Form
    {
        TiposPCRepositorio tiposPCRepositorio;
        int idTipoPC;
        public Modificar_TipoPC(String id, String descrip)
        {
            InitializeComponent();
            tiposPCRepositorio = new TiposPCRepositorio();
            txtDescripcion.Text = descrip;
            idTipoPC = Int32.Parse(id);
        }

        private void Modificar_TipoPC_Load(object sender, EventArgs e)
        {

        }

        private void btn_Cargar_Click(object sender, EventArgs e)
        {
            if (txtDescripcion.Text == "")
            {
                MessageBox.Show("Complete la descripción");
                txtDescripcion.Focus();
            }
            else
            {
                tiposPCRepositorio.modificarTipoPC(idTipoPC, txtDescripcion.Text);
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
