using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace TP_Maxi_PC
{
    public partial class Agregar_Cliente : Form
    {
        public Agregar_Cliente()
        {
            InitializeComponent();
        }

        private void Agregar_Cliente_Load(object sender, EventArgs e)
        {
            ArrayList listaBarrio = new ArrayList();
            listaBarrio.Add("Centro");
            listaBarrio.Add("Nueva Cordoba");
            listaBarrio.Add("General Paz");
            listaBarrio.Add("Pueyrredón");
            combo_Barrio.DataSource = listaBarrio;
            combo_Barrio.SelectedIndex = 0;

            dgv_Clientes.Columns.Add("clApellido","Apellido");
            dgv_Clientes.Columns.Add("clNombre", "Nombre");
            dgv_Clientes.Columns.Add("clDoc", "Documento");
            dgv_Clientes.Columns.Add("clBarrio", "Barrio");
            dgv_Clientes.Columns.Add("clCalle", "Calle");

        }

        private void dgv_Clientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Cargar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == "")
            {
                MessageBox.Show("El Nombre no puede estar vacio!");
                txtNombre.Focus();
            }
            else
            {
                if (txtApe.Text == "")
                {
                    MessageBox.Show("El Apellido no puede estar vacio!");
                    txtApe.Focus();
                }
                else
                {
                    if (txtDoc.Text == "")
                    {
                        MessageBox.Show("El Documento no puede estar vacio!");
                        txtDoc.Focus();
                    }
                    else
                    {
                        if (combo_Barrio.SelectedIndex == -1)
                        {
                            MessageBox.Show("El Barrio debe estar seleccionado!");
                            combo_Barrio.Focus();
                        }
                        else
                        {
                            if (txtCalle.Text == "")
                            {
                                MessageBox.Show("La calle no puede estar vacia!");
                                txtCalle.Focus();
                            }
                            else
                            {
                                dgv_Clientes.Rows.Add(txtApe.Text.ToString(),txtNombre.Text.ToString(),txtDoc.Text.ToString(),combo_Barrio.SelectedValue.ToString(),txtCalle.Text.ToString());
                                txtNombre.Clear();
                                txtApe.Clear();
                                txtDoc.Clear();
                                txtCalle.Clear();
                                combo_Barrio.SelectedIndex = 0;
                                txtApe.Focus();
                            }
                        }
                    }
                }
            }
        }
    }
}
