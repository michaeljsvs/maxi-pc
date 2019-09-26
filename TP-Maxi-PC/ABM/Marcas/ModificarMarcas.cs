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

namespace TP_Maxi_PC.ABM.Marcas
{
    public partial class ModificarMarcas : Form
    {
        MarcasRepositorio marcasRepositorio;
        int idMarca;
        
        public ModificarMarcas(String id, String nom)
        {
            InitializeComponent();
            marcasRepositorio = new MarcasRepositorio();
            txtID.Text = id;
            txtNombre.Text = nom;
            
            idMarca = Int32.Parse(id);
        }

        private void ModificarMarcas_Load(object sender, EventArgs e)
        {

        }

        private void btn_Cargar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == "")
            {
                MessageBox.Show("Debe cargar un nombre!");
                txtNombre.Focus();
            }
            else
            {
                marcasRepositorio.modificarMarca(idMarca, txtNombre.Text);
                MessageBox.Show("Se modificó Correctamente!");
                this.Close();
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                btn_Cargar_Click(sender, e);
            }
        }
    }
}
