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
    public partial class ModificarPC : Form
    {
        PCRepositorio pcrepo = new PCRepositorio();
        ClientesRepositorio clienterepo = new ClientesRepositorio();
        string idAModi, descrip;
        public ModificarPC(String AModi, string descripcion)
        {
            InitializeComponent();
            idAModi = AModi;
            descrip = descripcion;
        }

        private void actualizarComboMarca()
        {
            var Marcas = pcrepo.obtenerMarcasDT();
            combo_Marca.ValueMember = "idMarca";
            combo_Marca.DisplayMember = "nombre";
            combo_Marca.DataSource = Marcas;
        }
        private void actualizarDueños()
        {
            var dueños = clienterepo.obtenerParaCombo();
            combo_Dueño.ValueMember = "idCliente";
            combo_Dueño.DisplayMember = "final";
            combo_Dueño.DataSource = dueños;
        }
        private void actualizarModelos()
        {
            var modelos = pcrepo.obtenerModelosDT();
            cmbModelo.ValueMember = "idModelo";
            cmbModelo.DisplayMember = "nombre";
            cmbModelo.DataSource = modelos;
        }

        private void actualizarTipoPC()
        {
            var tipos = pcrepo.obtenerTipos();
            cmbTipoPC.ValueMember = "idTipoPC";
            cmbTipoPC.DisplayMember = "descripcion";
            cmbTipoPC.DataSource = tipos;
        }

        private void ModificarPC_Load(object sender, EventArgs e)
        {
            actualizarDueños();
            actualizarComboMarca();
            actualizarTipoPC();
            actualizarModelos();
            richTextBox1.Text = descrip;

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Cargar_Click(object sender, EventArgs e)
        {
            if (cmbModelo.SelectedIndex == -1)
            {
                MessageBox.Show("El modelo no debe estar vacío!");
                cmbModelo.Focus();
            }
            else
            {
                if (combo_Marca.SelectedIndex == -1)
                {
                    MessageBox.Show("La marca debe estar selecionada!");
                    combo_Marca.Focus();
                }
                else
                {
                    if (combo_Dueño.SelectedIndex == -1)
                    {
                        MessageBox.Show("El dueño debe estar seleccioado.");
                        combo_Dueño.Focus();
                    }
                    else
                    {
                        int pasar = Convert.ToInt32(combo_Dueño.SelectedValue.ToString());
                        int pasarMarca = Convert.ToInt32(combo_Marca.SelectedValue.ToString());
                        int pasarModelo = Convert.ToInt32(cmbModelo.SelectedValue.ToString());
                        int pasarTipo = Convert.ToInt32(cmbTipoPC.SelectedValue.ToString());
                        string pasarDescrip = richTextBox1.Text;

                        pcrepo.modificarPC(idAModi, pasar, pasarMarca, pasarModelo, pasarDescrip, pasarTipo);
                        MessageBox.Show("Se modifico correctamente!");
                        this.Close();
                    }
                }
            }
        }
    }
}
