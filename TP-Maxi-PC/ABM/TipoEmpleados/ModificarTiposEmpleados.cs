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

namespace TP_Maxi_PC.ABM.TipoEmpleados
{
    public partial class ModificarTiposEmpleados : Form
    {
        TiposEmpleadoRepositorio _tipoEmpleadoRepositorio;
        TiposEmpleado tipoEmp;

        public ModificarTiposEmpleados()
        {
            InitializeComponent();
        }

        public ModificarTiposEmpleados(string id_TipoEmp)
        {
            InitializeComponent();
            _tipoEmpleadoRepositorio = new TiposEmpleadoRepositorio();
            tipoEmp = _tipoEmpleadoRepositorio.ObtenerTipoEmpleado(id_TipoEmp);
        }

        //LOAD EDITAR
        private void ModificarTiposEmpleados_Load(object sender, EventArgs e)
        {
            txtID.Text = Convert.ToString(tipoEmp.idTipoEmpleado);
            txtNombre.Text = tipoEmp.nombre;
        }

        //BTN GUARDAR
        private void btn_Cargar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma tipo empleado modificado", "Confirmación", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                return;

            StringBuilder mensaje = new StringBuilder("La operación ");
            var tipoEmpleado = PrepararTipoEmpleado();
            try
            {
                if (_tipoEmpleadoRepositorio.Actualizar(tipoEmpleado))
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
                if (tipoEmpleado == null)
                    MessageBox.Show(mensaje.ToString());
                this.Dispose();
            }
        }

        //CREA UN OBJETO CON LOS DATOS DEL FORM
        private TiposEmpleado PrepararTipoEmpleado()
        {
            // Agregar validaciones
            var tiposEmpleado = new TiposEmpleado()
            {
                idTipoEmpleado = int.Parse(txtID.Text),
                nombre = txtNombre.Text
            };
            return tiposEmpleado;
        }
    }
}
