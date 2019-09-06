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

        public FormNuevoEmpleado()
        {
            InitializeComponent();
            _empleadosRepositorio = new EmpleadosRepositorio();
        }

        private void FormNuevoEmpleado_Load(object sender, EventArgs e)
        {
            ActualizarTipoDocumento();
            ActualizarTipoEmpleado();
        }

        private void ActualizarTipoDocumento()
        {
            var tipoDoc = _empleadosRepositorio.ObtenerTipoDoc();
            cmbTipoDoc.ValueMember = "idTipoDocumento";
            cmbTipoDoc.DisplayMember = "nombre";
            cmbTipoDoc.DataSource = tipoDoc;
        }

        private void ActualizarTipoEmpleado()
        {
            var tipoEmp = _empleadosRepositorio.ObtenerTipoEmpleado();
            cmbTipoEmp.ValueMember = "idTipoEmpleado";
            cmbTipoEmp.DisplayMember = "nombre";
            cmbTipoEmp.DataSource = tipoEmp;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var empleado = new Empleado();
            if (txtLegajo.Text == "")
            {
                MessageBox.Show("Legajo inválido");
                return;
            }
            empleado.legajo = int.Parse(txtLegajo.Text);
            empleado.tipoDocumento = cmbTipoDoc.SelectedIndex;
            if (txtNroDocumento.Text == "")
            {
                MessageBox.Show("Nro Documento inválido");
                return;
            }
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

            if (_empleadosRepositorio.Guardar(empleado))
            {
                MessageBox.Show("Se registro con éxito");
                this.Dispose();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
