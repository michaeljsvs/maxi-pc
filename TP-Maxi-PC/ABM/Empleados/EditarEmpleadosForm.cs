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
using TP_Maxi_PC.ABM.TipoDocumentos;
using TP_Maxi_PC.ABM.TipoEmpleados;
using TP_Maxi_PC.Modelos;
using TP_Maxi_PC.Repositorios;

namespace TP_Maxi_PC.ABM.Empleados
{
    public partial class EditarEmpleadoForm : Form
    {
        EmpleadosRepositorio _empleadosRepositorio;
        TiposDocumentoRepositorio _tipoDocumentoRepositorio;
        Empleado empleado;

        public EditarEmpleadoForm()
        {
            InitializeComponent();
            _empleadosRepositorio = new EmpleadosRepositorio();
        }

        public EditarEmpleadoForm(string empleadoLeg)
        {
            InitializeComponent();
            _empleadosRepositorio = new EmpleadosRepositorio();
            _tipoDocumentoRepositorio = new TiposDocumentoRepositorio();
            empleado = _empleadosRepositorio.ObtenerEmpleado(empleadoLeg);
        }

        //LOAD EDITAR
        private void EditarEmpleadoForm_Load(object sender, EventArgs e)
        {
            txtLegajo.Text = Convert.ToString(empleado.legajo);
            txtNroDocumento.Text = Convert.ToString(empleado.nroDocumento);
            txtApellido.Text = empleado.apellido;
            txtNombre.Text = empleado.nombre;
            DtpFechaAlta.Value = empleado.fechaAlta != DateTime.MinValue ? empleado.fechaAlta : DateTime.Today;
            DtpFechaBaja.Value = empleado.fechaBaja != DateTime.MinValue ? empleado.fechaBaja : DateTime.Today;

            Utils.CargarCombo(ref cmbTipoDoc, _tipoDocumentoRepositorio.ObtenerTiposDocumentoDT(), "idTipoDocumento", "nombre");
            Utils.CargarCombo(ref cmbTipoEmp, _empleadosRepositorio.ObtenerTipoEmpleado(), "idTipoEmpleado", "nombre");

            Utils.Set(ref cmbTipoDoc, empleado.TiposDocumento.idTipoDocumento);
            Utils.Set(ref cmbTipoEmp, empleado.idTipoEmpleado.idTipoEmpleado);
        }

        //BTN GUARDAR
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma empleado modificado", "Confirmación", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                return;

            StringBuilder mensaje = new StringBuilder("La operación ");
            var empleado = PrepararEmpleado();
            try
            {
                if (_empleadosRepositorio.Actualizar(empleado))
                {
                    MessageBox.Show("Se actualizó con éxito");
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

        //BTN AGREGAR TIPOS DOCUMENTO
        private void btn_agregarTipoDoc_Click(object sender, EventArgs e)
        {
            AgregarTiposDocumento nuevo = new AgregarTiposDocumento();
            nuevo.Show();
        }

        private void btn_agregarTipoEmp_Click(object sender, EventArgs e)
        {
            AgregarTiposEmpleado nuevo = new AgregarTiposEmpleado();
            nuevo.Show();
        }
    }
}
