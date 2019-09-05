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
using System.Collections;

namespace TP_Maxi_PC.ABM
{
    public partial class Modificar_Cliente : Form

    {
        ClientesRepositorio clientesRepositorio;
        int idCliente;
        public Modificar_Cliente(String id, String doc, String ape, String nom, String calle, String numero)
        {
            InitializeComponent();
            clientesRepositorio = new ClientesRepositorio();
            txtDoc.Text = doc;
            txtApe.Text = ape;
            txtNombre.Text = nom;
            txtCalle.Text = calle;
            txtNroCalle.Text = numero;
            idCliente = Int32.Parse(id);
        }

        private void Modificar_Cliente_Load(object sender, EventArgs e)
        {
            ActualizarComboBarrio();
            ActualizarComboDni();

            ArrayList listaSexo = new ArrayList();
            listaSexo.Add("M");
            listaSexo.Add("F");
            listaSexo.Add("X");
            cmbSexo.DataSource = listaSexo;
            cmbSexo.SelectedIndex = 0;


        }
        private void ActualizarComboDni()
        {
            var tipos = clientesRepositorio.obtenerDniDT();
            cmbTipoDoc.ValueMember = "idTipoDocumento";
            cmbTipoDoc.DisplayMember = "nombre";
            cmbTipoDoc.DataSource = tipos;
        }
        private void ActualizarComboBarrio()
        {
            var barrios = clientesRepositorio.obtenerBarriosDT();
            cmbBarrio.ValueMember = "idBarrio";
            cmbBarrio.DisplayMember = "nombre";
            cmbBarrio.DataSource = barrios;
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
                        if (cmbBarrio.SelectedIndex == -1)
                        {
                            MessageBox.Show("El Barrio debe estar seleccionado!");
                            cmbBarrio.Focus();
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
                                clientesRepositorio.modificarCliente(idCliente, txtNombre.Text, txtApe.Text, char.Parse(cmbSexo.SelectedValue.ToString()), dateTimePicker1.Value, txtCalle.Text, txtNroCalle.Text, cmbBarrio.SelectedIndex, cmbTipoDoc.SelectedIndex, System.Convert.ToInt32(txtDoc.Text));
                                //No se si se cambia de esta manera System.Convert.ToInt32(txtDoc.Text)
                                //dgv_Clientes.Rows.Add(txtApe.Text.ToString(),txtNombre.Text.ToString(),txtDoc.Text.ToString(), cmbTipoDoc.SelectedValue.ToString(), cmbSexo.SelectedValue.ToString(), 
                                //    txtFechaIng.Text.ToString(), cmbBarrio.SelectedValue.ToString(),txtCalle.Text.ToString(),txtNroCalle.Text.ToString());
                                MessageBox.Show("Se modifico Correctamente!");
                                this.Close();


                            }

                        }
                    }
                }
            }
        }
    }
}
