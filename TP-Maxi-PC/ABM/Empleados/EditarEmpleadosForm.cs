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
    public partial class EditarEmpleadoForm : Form
    {
        EmpleadosRepositorio _empleadosRepositorio;
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
            empleado = _empleadosRepositorio.ObtenerEmpleados(empleadoLeg);
        }

        private void ActualizarTipoEmpleado()
        {
            var tipoEmp = _empleadosRepositorio.ObtenerTipoEmpleado();
            cmbTipoEmp.ValueMember = "idTipoEmpleado";
            cmbTipoEmp.DisplayMember = "nombre";
            cmbTipoEmp.DataSource = tipoEmp;
        }

        private void ActualizarTipoDocumento()
        {
            var tipoDoc = _empleadosRepositorio.ObtenerTipoDoc();
            cmbTipoDoc.ValueMember = "idTipoDocumento";
            cmbTipoDoc.DisplayMember = "nombre";
            cmbTipoDoc.DataSource = tipoDoc;
        }

        private void EditarEmpleadoForm_Load(object sender, EventArgs e)
        {
            ActualizarTipoDocumento();
            ActualizarTipoEmpleado();

            txtLegajo.Text = Convert.ToString(empleado.legajo);
            cmbTipoDoc.SelectedIndex = empleado.tipoDocumento;
            txtNroDocumento.Text = Convert.ToString(empleado.nroDocumento);
            txtApellido.Text = empleado.apellido;
            txtNombre.Text = empleado.nombre;
            cmbTipoEmp.SelectedIndex = empleado.idTipoEmpleado - 1;
            DtpFechaAlta.Value = empleado.fechaAlta != DateTime.MinValue ? empleado.fechaAlta : DateTime.Today;
            DtpFechaBaja.Value = empleado.fechaBaja != DateTime.MinValue ? empleado.fechaBaja : DateTime.Today;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var empleado = new Empleado();
            empleado.legajo = int.Parse(txtLegajo.Text);
            empleado.tipoDocumento = cmbTipoDoc.SelectedIndex;
            empleado.nroDocumento = int.Parse(txtNroDocumento.Text);
            empleado.apellido = txtApellido.Text;
            empleado.nombre = txtNombre.Text;
            empleado.idTipoEmpleado = cmbTipoEmp.SelectedIndex + 1;
            empleado.fechaAlta = DtpFechaAlta.Value.Date;
            empleado.fechaBaja = DtpFechaBaja.Value.Date;

            if (!empleado.ValidarLegajo())
            {
                MessageBox.Show("Legajo inválido");
                return;
            }
            if (!empleado.ValidarTipoDocumento())
            {
                MessageBox.Show("Tipo Documento inválido");
                return;
            }
            if (!empleado.ValidarNroDocumento())
            {
                MessageBox.Show("Nro Documento inválido");
                return;
            }
            if (!empleado.ValidarApellido())
            {
                MessageBox.Show("Apellido inválido");
                return;
            }
            if (!empleado.ValidarNombre())
            {
                MessageBox.Show("Nombre inválido");
                return;
            }
            if (!empleado.ValidarFechaAlta())
            {
                MessageBox.Show("Fecha Alta inválida");
                return;
            }
            if (!empleado.ValidarFechaBaja())
            {
                MessageBox.Show("Fecha Baja inválida");
                return;
            }

            if (_empleadosRepositorio.Actualizar(empleado))
            {
                MessageBox.Show("Se actualizó con éxito");
                this.Dispose();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
