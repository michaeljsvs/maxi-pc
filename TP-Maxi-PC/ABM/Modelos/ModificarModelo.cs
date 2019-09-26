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

namespace TP_Maxi_PC.ABM.Modelos
{
    public partial class ModificarModelo : Form
    {
        ModelosRepositorio modelosRepositorio;
        int idmod;

        public ModificarModelo(String id, String nom)
        {
            InitializeComponent();
            modelosRepositorio = new ModelosRepositorio();
            txtID.Text = id;
            txtNombre.Text = nom;

            idmod = Int32.Parse(id);
        }

        private void ModificarModelo_Load(object sender, EventArgs e)
        {
            ActualizarComboMarcas();
        }

        private void ActualizarComboMarcas()
        {
            var marcas = modelosRepositorio.obtenerMarcasDT();
            cmbMarca.ValueMember = "idMarca";
            cmbMarca.DisplayMember = "nombre";
            cmbMarca.DataSource = marcas;
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
                if (cmbMarca.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe seleccionar una marca!");
                    cmbMarca.Focus();
                }
                else
                {
                    modelosRepositorio.modificarModelo(idmod, txtNombre.Text, System.Convert.ToInt32(cmbMarca.SelectedValue));

                    MessageBox.Show("Se modificó Correctamente!");
                    this.Close();
                }


            }

        }
    }
}
