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
    public partial class AgregarModelo : Form
    {
        ModelosRepositorio modelosRepositorio;

        public AgregarModelo()
        {
            InitializeComponent();
            modelosRepositorio = new ModelosRepositorio();
        }

        private void ActualizarModelos()
        {
            dgv_Modelos.Rows.Clear();
            var modelos = modelosRepositorio.obtenerModelosDT().Rows;
            var filas = new List<DataGridViewRow>();
            foreach (DataRow modelo in modelos)
            {
                if (modelo.HasErrors)

                    continue;
                var fila = new string[]
                {
                    modelo.ItemArray[0].ToString(),
                    modelo.ItemArray[1].ToString(),
                    modelo.ItemArray[2].ToString(),
                    
                };
                dgv_Modelos.Rows.Add(fila);


            }
        }
        
        private void ActualizarComboMarcas()
        {
            var marcas = modelosRepositorio.obtenerMarcasDT();
            cmbMarca.ValueMember = "idMarca";
            cmbMarca.DisplayMember = "nombre";
            cmbMarca.DataSource = marcas;
        }

        private void AgregarModelo_Load(object sender, EventArgs e)
        {
            txtNombre.Focus();
            ActualizarComboMarcas();
            ActualizarModelos();
        }

        private void btn_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
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
                    modelosRepositorio.insertarModelo(txtNombre.Text, System.Convert.ToInt32(cmbMarca.SelectedValue));

                    txtNombre.Clear();
                    cmbMarca.SelectedIndex = 0;

                    ActualizarModelos();
                    txtNombre.Focus();
                }
            }
        }

        private void btn_Actualizar_Click(object sender, EventArgs e)
        {
            ActualizarModelos();
        }

        private void btn_Modificar_Click(object sender, EventArgs e)
        {
            var seleccionadas = dgv_Modelos.SelectedRows;
            foreach (DataGridViewRow fila in seleccionadas)
            {
                String id = fila.Cells[0].Value.ToString();
                String nom = fila.Cells[1].Value.ToString();
                
                ModificarModelo form = new ModificarModelo(id, nom);
                form.ShowDialog();
                ActualizarModelos();
            }
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            var seleccionadas = dgv_Modelos.SelectedRows;

            foreach (DataGridViewRow fila in seleccionadas)
            {
                var id = fila.Cells[0].Value;
                var nombre = fila.Cells[1].Value;
                var marca = fila.Cells[2].Value;



                var confirmacion = MessageBox.Show($"Seguro que desea eliminar el modelo: {nombre} ({marca})?", "Confirmar Operación", MessageBoxButtons.YesNo);
                if (confirmacion.Equals(DialogResult.No))
                {
                    return;
                }
                else
                {
                    modelosRepositorio.borrarModelo(id.ToString());
                    MessageBox.Show("Se eliminó Correctamente!!!");
                    ActualizarModelos();

                }
            }
        }
    }
}
