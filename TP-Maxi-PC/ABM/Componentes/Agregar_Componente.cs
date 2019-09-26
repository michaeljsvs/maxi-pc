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

namespace TP_Maxi_PC.ABM.Componentes
{
    public partial class Agregar_Componente : Form
    {
        ComponentesRepositorio componentesRepositorio;

        public Agregar_Componente()
        {
            InitializeComponent();
            componentesRepositorio = new ComponentesRepositorio();
        }

        private void ActualizarComponentes()
        {
            dgv_Componentes.Rows.Clear();
            var componentes = componentesRepositorio.obtenerComponentesDT().Rows;
            var filas = new List<DataGridViewRow>();
            foreach (DataRow componente in componentes)
            {
                if (componente.HasErrors)

                    continue;
                var fila = new string[]
                {
                    componente.ItemArray[0].ToString(),
                    componente.ItemArray[1].ToString(),
                    componente.ItemArray[2].ToString(),
                    componente.ItemArray[3].ToString(),
                    componente.ItemArray[4].ToString(),
                    componente.ItemArray[5].ToString()
                    
                };
                dgv_Componentes.Rows.Add(fila);


            }
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

        private void Agregar_Componente_Load(object sender, EventArgs e)
        {
            txtNombre.Focus();
            ActualizarComboModelos();
            ActualizarComboTipoComponente();
            ActualizarComponentes();
        }

        private void btn_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Cargar_Click_1(object sender, EventArgs e)
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
                                componentesRepositorio.insertarComponente(txtNombre.Text, txtDescripcion.Text, 
                                    System.Convert.ToInt32(cmbTipoComp.SelectedValue), System.Convert.ToInt32(cmbModelo.SelectedValue), 
                                    System.Convert.ToDecimal(txtPrecio.Text));

                                txtNombre.Clear();
                                txtDescripcion.Clear();
                                cmbTipoComp.SelectedIndex = 0;
                                cmbModelo.SelectedIndex = 0;
                                txtPrecio.Clear();
                                

                                ActualizarComponentes();
                                txtNombre.Focus();
                            }
                        }
                    }
                }
            }
        }

        

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ActualizarComponentes();
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            var seleccionadas = dgv_Componentes.SelectedRows;

            foreach (DataGridViewRow fila in seleccionadas)
            {
                var id = fila.Cells[0].Value;
                var nombre = fila.Cells[1].Value;
                var desc = fila.Cells[2].Value;



                var confirmacion = MessageBox.Show($"Seguro que desea eliminar el componente: {nombre} ({desc})?", "Confirmar Operación", MessageBoxButtons.YesNo);
                if (confirmacion.Equals(DialogResult.No))
                {
                    return;
                }
                else
                {
                    componentesRepositorio.borrarComponente(id.ToString());
                    MessageBox.Show("Se eliminó Correctamente!!!");
                    ActualizarComponentes();

                }
            }
        }

        private void btn_Modificar_Click(object sender, EventArgs e)
        {
            var seleccionadas = dgv_Componentes.SelectedRows;
            foreach (DataGridViewRow fila in seleccionadas)
            {
                String id = fila.Cells[0].Value.ToString();
                String nom = fila.Cells[1].Value.ToString();
                String desc = fila.Cells[2].Value.ToString();
                String pre = fila.Cells[5].Value.ToString();
                
                ModificarComponente form = new ModificarComponente(id, nom, desc, pre);
                form.ShowDialog();
                ActualizarComponentes();
            }
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                btn_Cargar_Click_1(sender, e);
            }
        }
    }
}
