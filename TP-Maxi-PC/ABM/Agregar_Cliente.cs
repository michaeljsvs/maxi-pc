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
using TP_Maxi_PC.Repositorios;

namespace TP_Maxi_PC
{
    public partial class Agregar_Cliente : Form
    {
        ClientesRepositorio clientesRepositorio;
        public Agregar_Cliente()
        {
            InitializeComponent();
            clientesRepositorio = new ClientesRepositorio();
        }

        private void ActualizarClientes()
        {
            dgv_Clientes.Rows.Clear();
            var clientes = clientesRepositorio.obtenerClientesDT().Rows;
            var filas = new List<DataGridViewRow>();
            foreach (DataRow cliente in clientes)
            {
                if (cliente.HasErrors)
                
                    continue;
                    var fila = new string[]
                    {
                    cliente.ItemArray[0].ToString(),
                    cliente.ItemArray[1].ToString(),
                    cliente.ItemArray[2].ToString(),
                    cliente.ItemArray[3].ToString(),
                    cliente.ItemArray[4].ToString(),
                    cliente.ItemArray[5].ToString(),
                    cliente.ItemArray[6].ToString(),
                    cliente.ItemArray[7].ToString(),
                    cliente.ItemArray[8].ToString(),
                    cliente.ItemArray[9].ToString()
                    };
                    dgv_Clientes.Rows.Add(fila);
                    
                
            }
        }
        private void ActualizarComboBarrio()
        {
            var barrios = clientesRepositorio.obtenerBarriosDT();
            cmbBarrio.ValueMember = "idBarrio";
            cmbBarrio.DisplayMember = "nombre";
            cmbBarrio.DataSource = barrios;
        }
        private void Agregar_Cliente_Load(object sender, EventArgs e)
        {
            ActualizarClientes();
            ActualizarComboBarrio();
            //ArrayList listaBarrio = new ArrayList();
            //listaBarrio.Add("Centro");
            //listaBarrio.Add("Nueva Cordoba");
            //listaBarrio.Add("General Paz");
            //listaBarrio.Add("Pueyrredón");
            //cmbBarrio.DataSource = listaBarrio;
            //cmbBarrio.SelectedIndex = 0;

            //ArrayList listaTipoDoc = new ArrayList();
            //listaTipoDoc.Add("DNI");
            //listaTipoDoc.Add("PAS");
            //cmbTipoDoc.DataSource = listaTipoDoc;
            //cmbTipoDoc.SelectedIndex = 0;

            //ArrayList listaSexo = new ArrayList();
            //listaSexo.Add("Masculino");
            //listaSexo.Add("Femenino");
            //listaSexo.Add("Otro");
            //cmbSexo.DataSource = listaSexo;
            //cmbSexo.SelectedIndex = 0;

            //dgv_Clientes.Columns.Add("clApellido","Apellido");
            //dgv_Clientes.Columns.Add("clNombre", "Nombre");
            //dgv_Clientes.Columns.Add("clDoc", "Documento");
            //dgv_Clientes.Columns.Add("clTipoDoc", "Tipo Documento");
            //dgv_Clientes.Columns.Add("clSexo", "Sexo");
            //dgv_Clientes.Columns.Add("clFecIng", "Fecha Ingreso");
            //dgv_Clientes.Columns.Add("clBarrio", "Barrio");
            //dgv_Clientes.Columns.Add("clCalle", "Calle");
            //dgv_Clientes.Columns.Add("clNroCal", "Nro Calle");

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
                                dgv_Clientes.Rows.Add(txtApe.Text.ToString(),txtNombre.Text.ToString(),txtDoc.Text.ToString(), cmbTipoDoc.SelectedValue.ToString(), cmbSexo.SelectedValue.ToString(), 
                                    txtFechaIng.Text.ToString(), cmbBarrio.SelectedValue.ToString(),txtCalle.Text.ToString(),txtNroCalle.Text.ToString());
                                txtNombre.Clear();
                                txtApe.Clear();
                                txtDoc.Clear();
                                cmbTipoDoc.SelectedIndex = 0;
                                cmbSexo.SelectedIndex = 0;
                                txtCalle.Clear();
                                txtFechaIng.Clear();
                                cmbBarrio.SelectedIndex = 0;
                                txtNroCalle.Clear();
                                txtNombre.Focus();
                            }
                        }
                    }
                }
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ActualizarClientes();
        }
    }
}
