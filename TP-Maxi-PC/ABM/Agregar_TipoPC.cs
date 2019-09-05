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
    public partial class Agregar_TipoPC : Form
    {
        TiposPCRepositorio tiposPCRepositorio;
        public Agregar_TipoPC()
        {
            InitializeComponent();
            tiposPCRepositorio = new TiposPCRepositorio();
        }

        private void ActualizarTiposPC()
        {
            dgv_TiposPC.Rows.Clear();
            var tipos = tiposPCRepositorio.obtenerTiposDT().Rows;
            var filas = new List<DataGridViewRow>();
            foreach (DataRow tipo in tipos)
            {
                if (tipo.HasErrors)

                    continue;
                var fila = new string[]
                {
                    tipo.ItemArray[0].ToString(),
                    tipo.ItemArray[1].ToString()
                };
                dgv_TiposPC.Rows.Add(fila);


            }
        }

        private void MostrarID()
        {
            var tipos = tiposPCRepositorio.obtenerTiposDT();
            
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

        private void dgv_TiposPC_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Agregar_TiposPC_Load(object sender, EventArgs e)
        {
            ActualizarTiposPC();
            MostrarID();
            
        }

        private void btn_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Actualizar_Click(object sender, EventArgs e)
        {
            ActualizarTiposPC();
            MostrarID();
        }

        private void btn_Cargar_Click(object sender, EventArgs e)
        {
            if (txtDescripcion.Text == "")
            {
                MessageBox.Show("Complete la descripción");
                txtDescripcion.Focus();
            }
            else
            {
                tiposPCRepositorio.insertarTipoPC(txtDescripcion.Text);
                ActualizarTiposPC();
                MostrarID();
            }
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            var seleccionadas = dgv_TiposPC.SelectedRows;

            foreach (DataGridViewRow fila in seleccionadas)
            {
                var id = fila.Cells[0].Value;
                var descrip = fila.Cells[1].Value;
                
                
                var confirmacion = MessageBox.Show($"Seguro que desea eliminar: {descrip}?", "Confirmar Operación", MessageBoxButtons.YesNo);
                if (confirmacion.Equals(DialogResult.No))
                {
                    return;
                }
                else
                {
                    tiposPCRepositorio.borrarTipoPC(id.ToString());
                    MessageBox.Show("Se elimino Correctamente!!!");
                    ActualizarTiposPC();

                }
            }
        }

        private void btn_Modificar_Click(object sender, EventArgs e)
        {
            var seleccionadas = dgv_TiposPC.SelectedRows;
            foreach (DataGridViewRow fila in seleccionadas)
            {
                String id = fila.Cells[0].Value.ToString();
                
                String descrip = fila.Cells[1].Value.ToString();
                
                Modificar_TipoPC form = new Modificar_TipoPC(id, descrip);
                form.ShowDialog();
                ActualizarTiposPC();
            }
        }
    }
}
