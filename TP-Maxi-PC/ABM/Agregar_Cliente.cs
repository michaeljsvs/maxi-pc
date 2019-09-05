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
using TP_Maxi_PC.ABM;

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
        private void Agregar_Cliente_Load(object sender, EventArgs e)
        {
            ActualizarClientes();
            ActualizarComboBarrio();
            ActualizarComboDni();
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

            ArrayList listaSexo = new ArrayList();
            listaSexo.Add("M");
            listaSexo.Add("F");
            listaSexo.Add("X");
            cmbSexo.DataSource = listaSexo;
            cmbSexo.SelectedIndex = 0;

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
                                clientesRepositorio.insertarCliente(txtNombre.Text,txtApe.Text,char.Parse(cmbSexo.SelectedValue.ToString()),dateTimePicker1.Value,txtCalle.Text,txtNroCalle.Text,cmbBarrio.SelectedIndex,cmbTipoDoc.SelectedIndex, System.Convert.ToInt32(txtDoc.Text));
                                //No se si se cambia de esta manera System.Convert.ToInt32(txtDoc.Text)
                                //dgv_Clientes.Rows.Add(txtApe.Text.ToString(),txtNombre.Text.ToString(),txtDoc.Text.ToString(), cmbTipoDoc.SelectedValue.ToString(), cmbSexo.SelectedValue.ToString(), 
                                //    txtFechaIng.Text.ToString(), cmbBarrio.SelectedValue.ToString(),txtCalle.Text.ToString(),txtNroCalle.Text.ToString());
                                txtNombre.Clear();
                                txtApe.Clear();
                                txtDoc.Clear();
                                cmbTipoDoc.SelectedIndex = 0;
                                cmbSexo.SelectedIndex = 0;
                                txtCalle.Clear();
                                cmbBarrio.SelectedIndex = 0;
                                txtNroCalle.Clear();

                                ActualizarClientes();
                                txtNombre.Focus();
                            }
                        }
                    }
                }
            }
        }

        

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ActualizarClientes();
        }

        private void btn_Eliminar_Click_1(object sender, EventArgs e)
        {
            var seleccionadas = dgv_Clientes.SelectedRows;

            foreach (DataGridViewRow fila in seleccionadas)
            {
                var id = fila.Cells[0].Value;
                var nombre = fila.Cells[3].Value;
                var ape = fila.Cells[4].Value;



                var confirmacion = MessageBox.Show($"Seguro que desea eliminar a: {ape} {nombre}?", "Confirmar Operación", MessageBoxButtons.YesNo);
                if (confirmacion.Equals(DialogResult.No))
                {
                    return;
                }
                else
                {
                    clientesRepositorio.borrarCliente(id.ToString());
                    MessageBox.Show("Se elimino Correctamente!!!");
                    ActualizarClientes();

                }
            }
        }

        private void button1Modificar_Click(object sender, EventArgs e)
        {
            var seleccionadas = dgv_Clientes.SelectedRows;
            foreach (DataGridViewRow fila in seleccionadas)
            {
                String id = fila.Cells[0].Value.ToString();
                //cmbTipoDoc.SelectedIndex = Int32.Parse(fila.Cells[1].Value.ToString());
                String doc = fila.Cells[2].Value.ToString();
                String ape= fila.Cells[3].Value.ToString();
                String nombre= fila.Cells[4].Value.ToString();
                //cmbSexo.SelectedValue = Int32.Parse(fila.Cells[5].Value.ToString());
                String calle = fila.Cells[7].Value.ToString();
                String nro= fila.Cells[8].Value.ToString();
                //cmbBarrio.SelectedValue = Int32.Parse(fila.Cells[9].Value.ToString());
                Modificar_Cliente form = new Modificar_Cliente(id,doc,ape,nombre,calle,nro);
                form.ShowDialog();
                ActualizarClientes();
            }
            
        }
    }
}
