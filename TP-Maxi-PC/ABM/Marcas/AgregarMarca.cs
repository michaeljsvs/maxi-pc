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
    public partial class AgregarMarca : Form
    {
        MarcasRepositorio marcasRepositorio;

        public AgregarMarca()
        {
            InitializeComponent();
            marcasRepositorio = new MarcasRepositorio();
        }

        private void AgregarMarca_Load(object sender, EventArgs e)
        {
            txtNombre.Focus();
            ActualizarMarcas();
        }

        private void ActualizarMarcas()
        {
            dgv_Marcas.Rows.Clear();
            var marcas = marcasRepositorio.obtenerMarcasDT().Rows;
            var filas = new List<DataGridViewRow>();
            foreach (DataRow marca in marcas)
            {
                if (marca.HasErrors)

                    continue;
                var fila = new string[]
                {
                    marca.ItemArray[0].ToString(),
                    marca.ItemArray[1].ToString(),
                    
                };
                dgv_Marcas.Rows.Add(fila);
             }
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
                marcasRepositorio.insertarMarca(txtNombre.Text);

                txtNombre.Clear();
                
                ActualizarMarcas();
                txtNombre.Focus();
            }
        }

        private void btn_Actualizar_Click(object sender, EventArgs e)
        {
            ActualizarMarcas();
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            var seleccionadas = dgv_Marcas.SelectedRows;

            foreach (DataGridViewRow fila in seleccionadas)
            {
                var id = fila.Cells[0].Value;
                var nombre = fila.Cells[1].Value;
               
                var confirmacion = MessageBox.Show($"Seguro que desea eliminar la marca: {nombre}?", "Confirmar Operación", MessageBoxButtons.YesNo);
                if (confirmacion.Equals(DialogResult.No))
                {
                    return;
                }
                else
                {
                    marcasRepositorio.borrarMarca(id.ToString());
                    MessageBox.Show("Se eliminó Correctamente!!!");
                    ActualizarMarcas();

                }
            }
        }

        private void btn_Modificar_Click(object sender, EventArgs e)
        {
            var seleccionadas = dgv_Marcas.SelectedRows;
            foreach (DataGridViewRow fila in seleccionadas)
            {
                String id = fila.Cells[0].Value.ToString();
                String nom = fila.Cells[1].Value.ToString();
               
                ModificarMarcas form = new ModificarMarcas(id, nom);
                form.ShowDialog();
                ActualizarMarcas();
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
