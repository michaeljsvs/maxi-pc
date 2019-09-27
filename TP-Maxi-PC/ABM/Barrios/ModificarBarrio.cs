using PTP_Maxi_PC.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TP_Maxi_PC.Modelos;
using TP_Maxi_PC.Repositorios;

namespace TP_Maxi_PC.ABM.Barrios
{
    public partial class ModificarBarrio : Form
    {
        BarriosRepositorio _barriosRepositorio;
        Barrio barrio;

        public ModificarBarrio()
        {
            InitializeComponent();
        }

        public ModificarBarrio(string id_Barrio)
        {
            InitializeComponent();
            _barriosRepositorio = new BarriosRepositorio();
            barrio = _barriosRepositorio.ObtenerBarrio(id_Barrio);
        }

        //LOAD EDITAR
        private void ModificarBarrio_Load(object sender, EventArgs e)
        {
            txtID.Text = Convert.ToString(barrio.idBarrio);
            txtNombre.Text = barrio.nombre;
        }

        //BTN GUARDAR
        private void btn_Cargar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma barrio modificado", "Confirmación", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                return;

            StringBuilder mensaje = new StringBuilder("La operación ");
            var barrio = PrepararBarrio();
            try
            {
                if (_barriosRepositorio.Actualizar(barrio))
                {
                    MessageBox.Show("Se guardó con éxito");
                }
            }
            catch (InvalidOperationException ex)
            {
                mensaje.Append("no se realizó. Hubo un problema en la conexión a la BD");
            }
            catch (Exception exc)
            {
                mensaje.Append("no se realizó. Ops. Hubo un problema inesperado.");
            }
            finally
            {
                if (barrio == null)
                    MessageBox.Show(mensaje.ToString());
                this.Dispose();
            }
        }

        //CREA UN OBJETO CON LOS DATOS DEL FORM
        private Barrio PrepararBarrio()
        {
            // Agregar validaciones
            var barrio = new Barrio()
            {
                idBarrio = int.Parse(txtID.Text),
                nombre = txtNombre.Text
            };
            return barrio;
        }
    }
}
