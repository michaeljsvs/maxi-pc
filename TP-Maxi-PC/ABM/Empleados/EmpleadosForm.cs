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
    public partial class EmpleadosForm : Form
    {
        EmpleadosRepositorio _empleadosRepositorio;
        Principal _principalForm;
        TiposDocumentoRepositorio _tipoDocumentoRepositorio;

        public EmpleadosForm()
        {
            InitializeComponent();
            _empleadosRepositorio = new EmpleadosRepositorio();
            _tipoDocumentoRepositorio = new TiposDocumentoRepositorio();
        }

        public EmpleadosForm(Principal principalForm)
        {
            InitializeComponent();
            _empleadosRepositorio = new EmpleadosRepositorio();
            _principalForm = principalForm;
            _tipoDocumentoRepositorio = new TiposDocumentoRepositorio();
        }

        //LOAD
        private void EmpleadosForm_Load(object sender, EventArgs e)
        {
            ActualizarEmpleados();
            Utils.CargarCombo(ref cmbTipoDoc, _tipoDocumentoRepositorio.ObtenerTiposDocumentoDT(), "idTipoDocumento", "nombre");
            Utils.CargarCombo(ref cmbTipoEmp, _empleadosRepositorio.ObtenerTipoEmpleado(), "idTipoEmpleado", "nombre");
        }

        //ACTUALIZAR (OBTIENE LISTA)
        private void ActualizarEmpleados()
        {
            DgvEmpleados.Rows.Clear();
            var registros = _empleadosRepositorio.ObtenerEmpleados();
            ActualizarGrilla(registros);
        }

        //ACTUALIZA EL DATA GRID VIEW
        private void ActualizarGrilla(List<Empleado> registros)
        {
            foreach (Empleado registro in registros)
            {
                var fila = new string[] {
                    registro.legajo.ToString(), // Legajo
                    registro.TiposDocumento.nombre.ToString(), // Nombre Tipo Documento
                    registro.nroDocumento.ToString(), // Nro Documento
                    registro.apellido.ToString(), // Apellido
                    registro.nombre.ToString(), // Nombre
                    registro.idTipoEmpleado.nombre.ToString(), // Nombre Tipo Empleado
                    registro.fechaAlta != DateTime.MinValue ? registro.fechaAlta.ToString("dd/MM/yyyy") : null,// Fecha Alta
                    registro.fechaBaja != DateTime.MinValue ? registro.fechaBaja.ToString("dd/MM/yyyy") : null // Fecha Baja
                };
                DgvEmpleados.Rows.Add(fila);
            }
        }

        //BTN NUEVO o CARGAR
        private void BtnNuevo_Click(object sender, EventArgs e)
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
            }
            txtLegajo.Clear();
            cmbTipoDoc.SelectedIndex = 0;
            txtNroDocumento.Clear();
            txtApellido.Clear();
            txtNombre.Clear();
            cmbTipoEmp.SelectedIndex = 0;
            ActualizarEmpleados();
            txtLegajo.Focus();
        }

        //BTN ELIMINAR
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            var seleccionadas = DgvEmpleados.SelectedRows;
            if (seleccionadas.Count == 0 || seleccionadas.Count > 1)
            {
                MessageBox.Show("Debe seleccionar una fila");
                return;
            }

            foreach (DataGridViewRow fila in seleccionadas)
            {
                var nombre = fila.Cells[4].Value;
                var apellido = fila.Cells[3].Value;
                var legajo = fila.Cells[0].Value;

                //pregunto confirmación
                var confirmacion = MessageBox.Show($"Esta seguro que desea eliminar a {nombre} {apellido}?",
                    "Confirmar operación",
                    MessageBoxButtons.YesNo);

                if (confirmacion.Equals(DialogResult.No))
                    return;

                if (_empleadosRepositorio.Eliminar(legajo.ToString()))
                {
                    MessageBox.Show("Se eliminó exitosamente");
                    ActualizarEmpleados();
                }
            }
        }

        //BTN CLOSING X
        private void EmpleadosForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _principalForm.Show();
        }

        //BTN MODIFICAR
        private void btnModificar_Click(object sender, EventArgs e)
        {
            var seleccionadas = DgvEmpleados.SelectedRows;
            if (seleccionadas.Count == 0 || seleccionadas.Count > 1)
            {
                MessageBox.Show("Debe seleccionar una fila");
                return;
            }
            foreach (DataGridViewRow fila in seleccionadas)
            {
                var legajo = fila.Cells[0].Value;

                var ventana = new EditarEmpleadoForm(legajo.ToString());
                ventana.ShowDialog();
                ActualizarEmpleados();
            }
        }

        //BTN ACTUALIZAR
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ActualizarEmpleados();
        }

        //BTN CANCELAR
        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Está seguro que desea salir?", "Salir", MessageBoxButtons.OKCancel) == DialogResult.OK)
                Dispose();
            _principalForm.Show();
        }

        //CREA UN OBJETO CON LOS DATOS DEL FORM
        private Empleado PrepararEmpleado()
        {
            if (String.IsNullOrEmpty(txtLegajo.Text))
            {
                MessageBox.Show("Legajo vacio");
                return null;
            }
            if (String.IsNullOrEmpty(txtNroDocumento.Text))
            {
                MessageBox.Show("Nro Documento vacio");
                return null;
            }
            if (String.IsNullOrEmpty(txtApellido.Text))
            {
                MessageBox.Show("Apellido vacio");
                return null;
            }
            if (String.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show("Nombre vacio");
                return null;
            }

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
            
            if (!empleado.ValidarApellido())
            {
                MessageBox.Show("Apellido inválido");
                return null;
            }
            if (!empleado.ValidarNombre())
            {
                MessageBox.Show("Nombre inválido");
                return null;
            }
            if (!empleado.ValidarFechaAlta())
            {
                MessageBox.Show("Fecha Alta inválida");
                return null;
            }
            if (!empleado.ValidarFechaBaja())
            {
                MessageBox.Show("Fecha Baja inválida");
                return null;
            }
            return empleado;
        }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}