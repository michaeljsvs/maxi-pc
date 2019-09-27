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

namespace TP_Maxi_PC.ABM.Empleados
{
    public partial class FormNuevoEmpleado : Form
    {
        EmpleadosRepositorio _empleadosRepositorio;
        TiposDocumentoRepositorio _tipoDocumentoRepositorio;

        public FormNuevoEmpleado()
        {
            InitializeComponent();
            _empleadosRepositorio = new EmpleadosRepositorio();
            _tipoDocumentoRepositorio = new TiposDocumentoRepositorio();
        }

        //LOAD NUEVO
        private void FormNuevoEmpleado_Load(object sender, EventArgs e)
        {
            Utils.CargarCombo(ref cmbTipoDoc, _tipoDocumentoRepositorio.ObtenerTiposDocumentoDT(), "idTipoDocumento", "nombre");
            Utils.CargarCombo(ref cmbTipoEmp, _empleadosRepositorio.ObtenerTipoEmpleado(), "idTipoEmpleado", "nombre");
        }

        //BTN GUARDAR
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma empleado nuevo", "Confirmación", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                return;

            StringBuilder mensaje = new StringBuilder("La operación ");
            var empleado = PrepararEmpleado();
            try
            {
                if (_empleadosRepositorio.Guardar(empleado))
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
                if (empleado == null)
                    MessageBox.Show(mensaje.ToString());
                this.Dispose();
            }
        }

        //BTN CANCELAR
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Está seguro que desea salir?", "Salir", MessageBoxButtons.OKCancel) == DialogResult.OK)
                Dispose();
        }

        //CREA UN OBJETO CON LOS DATOS DEL FORM
        private Empleado PrepararEmpleado()
        {
            // Agregar validaciones
            var empleado = new Empleado()
            {
                legajo = int.Parse(txtLegajo.Text),
                TiposDocumento = new TiposDocumento() { idTipoDocumento = int.Parse(cmbTipoDoc.SelectedValue.ToString()) },
                nroDocumento = int.Parse(txtNroDocumento.Text),
                apellido = txtApellido.Text,
                nombre = txtNombre.Text,
                idTipoEmpleado = new TiposEmpleado() { idTipoEmpleado = int.Parse(cmbTipoEmp.SelectedValue.ToString()) },
                fechaAlta = DtpFechaAlta.Value.Date,
                fechaBaja = DtpFechaBaja.Value.Date
            };
            return empleado;
        }
    }
}
