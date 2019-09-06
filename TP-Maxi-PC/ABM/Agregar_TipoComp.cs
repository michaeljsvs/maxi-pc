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
    public partial class Agregar_TipoComp : Form
    {
        TiposCompRepositorio tiposCompRepositorio;
        public Agregar_TipoComp()
        {
            InitializeComponent();
            tiposCompRepositorio = new TiposCompRepositorio();
        }

        private void ActualizarTiposComp()
        {
            dgv_TiposComp.Rows.Clear();
            var tipos = tiposCompRepositorio.obtenerTiposComponente().Rows;
            foreach (DataRow tipo in tipos)
            {
                if (tipo.HasErrors)
                    continue;
                var fila = new string[]
                {
                    tipo.ItemArray[0].ToString(),
                    tipo.ItemArray[1].ToString()
                };
                dgv_TiposComp.Rows.Add(fila);


            }
        }

        private void MostrarID()
        {
            var tipos = tiposCompRepositorio.obtenerTiposComponente();

            if (tipos.Rows.Count.Equals(0))
            {
                txtID.Text = "1";
            }
            else
            {
                var c = tipos.Rows.Count;
                c += 1;

                txtID.Text = c.ToString();
            }

        }
        

        private void Agregar_TiposPC_Load(object sender, EventArgs e)
        {
            ActualizarTiposComp();
            MostrarID();

        }
        
        private void btn_Cargar_Click_1(object sender, EventArgs e)
        {
            if (txtNombre.Text == "")
            {
                MessageBox.Show("Complete la descripción");
                txtNombre.Focus();
            }
            else
            {
                tiposCompRepositorio.insertarTiposComponente(txtNombre.Text);
                ActualizarTiposComp();
                MostrarID();
            }
        }

        private void btn_Modificar_Click_1(object sender, EventArgs e)
        {
            var seleccionadas = dgv_TiposComp.SelectedRows;
            foreach (DataGridViewRow fila in seleccionadas)
            {
                String id = fila.Cells[0].Value.ToString();

                String nombre = fila.Cells[1].Value.ToString();

                Modificar_TipoComp form = new Modificar_TipoComp(id, nombre);
                form.ShowDialog();
                ActualizarTiposComp();
            }
        }

        private void btn_Eliminar_Click_1(object sender, EventArgs e)
        {
            var seleccionadas = dgv_TiposComp.SelectedRows;

            foreach (DataGridViewRow fila in seleccionadas)
            {
                var id = fila.Cells[0].Value;
                var nombre = fila.Cells[1].Value;


                var confirmacion = MessageBox.Show($"Seguro que desea eliminar: {nombre}?", "Confirmar Operación", MessageBoxButtons.YesNo);
                if (confirmacion.Equals(DialogResult.No))
                {
                    return;
                }
                else
                {
                    tiposCompRepositorio.borrarTiposComponente(id.ToString());
                    MessageBox.Show("Se elimino Correctamente!!!");
                    ActualizarTiposComp();

                }
            }
        }

        private void btn_Actualizar_Click_1(object sender, EventArgs e)
        {
            ActualizarTiposComp();
            MostrarID();
        }

        private void btn_Salir_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Agregar_TipoComp_Load(object sender, EventArgs e)
        {
            ActualizarTiposComp();
            MostrarID();
        }
    }
}
