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
using TP_Maxi_PC.OrdenesServicio;

namespace TP_Maxi_PC.OrdenesServicio
{
    public partial class Ordenes : Form
    {
        OrdenesRepositorio OSRepo;
        
        public Ordenes()
        {
            OSRepo = new OrdenesRepositorio();
            InitializeComponent();
        }

        private void OrdenesServicio_Load(object sender, EventArgs e)
        {
            ActualizarOS();
        }
        
        public void ActualizarOS()
        {
            dgvOS.Rows.Clear();
            var oss = OSRepo.obtenerOS().Rows;
            var filas = new List<DataGridViewRow>();
            foreach (DataRow os in oss)
            {
                if (os.HasErrors)
                    continue;
                var fila = new string[]
                {
                    os.ItemArray[0].ToString(),
                    os.ItemArray[1].ToString(),
                    os.ItemArray[2].ToString(),
                    os.ItemArray[3].ToString(),
                    os.ItemArray[4].ToString(),
                    os.ItemArray[5].ToString(),
                    os.ItemArray[6].ToString(),
                    os.ItemArray[7].ToString()
            };
                dgvOS.Rows.Add(fila);
            }
        }

        private void btnNueva_Click(object sender, EventArgs e)
        {
            CargarOrdenServicio nueva = new CargarOrdenServicio();
            nueva.ShowDialog();
            ActualizarOS();
        }

        private void dgvOS_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnEntregar_Click(object sender, EventArgs e)
        {
            var confirmacion = MessageBox.Show("Confirmar Entrega?","Confirmar Operación", MessageBoxButtons.YesNo);
            if (confirmacion.Equals(DialogResult.No))
            {
                return;
            }
            else
            {
                var OSSelec = dgvOS.SelectedRows;
                string ent = "";
                foreach (DataGridViewRow fila in OSSelec)
                {
                     ent = fila.Cells[0].Value.ToString();
                }
                OSRepo.entregar(ent);
                MessageBox.Show("Se cargo la entrega correctamente!");
                ActualizarOS();
            }
            
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            var OSSelec = dgvOS.SelectedRows;
            foreach(DataGridViewRow fila in OSSelec)
            {
                var eliminar = fila.Cells[0].Value.ToString();
                var confirmacion = MessageBox.Show("Eliminar Orden de Servicio Nº: "+eliminar+"?", "Confirmar Operación", MessageBoxButtons.YesNo);
                if (confirmacion.Equals(DialogResult.No))
                {
                    return;
                }
                else
                {
                    OSRepo.eliminarOS(eliminar);
                    MessageBox.Show("Eliminado Correctamente!");
                    ActualizarOS();
                }
            }
        }
    }
}
