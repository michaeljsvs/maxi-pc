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
using TP_Maxi_PC.ABM.Componentes;

namespace TP_Maxi_PC.ABM.Componentes
{
    public partial class ModificarComponente : Form
    {
        ComponentesRepositorio componentesRepositorio;
        int idComp;

        public ModificarComponente(String id, String nom, String desc, String pre)
        {
            InitializeComponent();
            componentesRepositorio = new ComponentesRepositorio();
            txtID.Text = id;
            txtNombre.Text = nom;
            txtDescripcion.Text = desc;
            txtPrecio.Text = pre;

            idComp = Int32.Parse(id);
        }

        private void ModificarComponente_Load(object sender, EventArgs e)
        {
            ActualizarComboModelos();
            ActualizarComboTipoComponente();
        }

        private void ActualizarComboTipoComponente()
        {
            var tipos = componentesRepositorio.obtenerTiposComponenteDT();
            cmbTipoComp.ValueMember = "idTipoComponente";
            cmbTipoComp.DisplayMember = "nombre";
            cmbTipoComp.DataSource = tipos;
        }
        private void ActualizarComboModelos()
        {
            var modelos = componentesRepositorio.obtenerModelosDT();
            cmbModelo.ValueMember = "idModelo";
            cmbModelo.DisplayMember = "nombre";
            cmbModelo.DataSource = modelos;
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
                if (txtDescripcion.Text == "")
                {
                    MessageBox.Show("Debe completar la descripción!");
                    txtDescripcion.Focus();
                }
                else
                {
                    if (cmbTipoComp.SelectedIndex == -1)
                    {
                        MessageBox.Show("Debe seleccionar un tipo de componente!");
                        cmbTipoComp.Focus();
                    }
                    else
                    {
                        if (cmbModelo.SelectedIndex == -1)
                        {
                            MessageBox.Show("Debe seleccionar un modelo!");
                            cmbModelo.Focus();
                        }
                        else
                        {
                            if (txtPrecio.Text == "")
                            {
                                MessageBox.Show("Debe cargar un precio!");
                                txtPrecio.Focus();
                            }
                            else
                            {
                                componentesRepositorio.modificarComponente(idComp, txtNombre.Text, txtDescripcion.Text, 
                                    System.Convert.ToInt32(cmbTipoComp.SelectedValue), System.Convert.ToInt32(cmbModelo.SelectedValue), 
                                    System.Convert.ToDecimal(txtPrecio.Text));

                                MessageBox.Show("Se modificó Correctamente!");
                                this.Close();
                            }
                        }
                    }
                }
            }
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                btn_Cargar_Click(sender, e);
            }
        }
    }
}
