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

        public EmpleadosForm()
        {
            InitializeComponent();
            _empleadosRepositorio = new EmpleadosRepositorio();
        }

        public EmpleadosForm(Principal principalForm)
        {
            InitializeComponent();
            _empleadosRepositorio = new EmpleadosRepositorio();
            _principalForm = principalForm;
        }

        private void EmpleadosForm_Load(object sender, EventArgs e)
        {
            ActualizarEmpleados();
        }

        private void ActualizarEmpleados()
        {
            DgvEmpleados.Rows.Clear();
            var registros = _empleadosRepositorio.ObtenerEmpleados();
            ActualizarGrilla(registros);
        }

        private void ActualizarGrilla(List<Empleado> registros)
        {
            foreach (Empleado registro in registros)
            {
                var fila = new string[] {
                    registro.legajo.ToString(), // Legajo
                    registro.tipoDocumento.ToString(), // Tipo Documento
                    registro.nroDocumento.ToString(), // Nro Documento
                    registro.apellido.ToString(), // Apellido
                    registro.nombre.ToString(), // Nombre
                    registro.idTipoEmpleado.ToString(), // Id Tipo Empleado
                    registro.fechaAlta != DateTime.MinValue ? registro.fechaAlta.ToString("dd/MM/yyyy") : null,// Fecha Alta
                    registro.fechaBaja != DateTime.MinValue ? registro.fechaBaja.ToString("dd/MM/yyyy") : null // Fecha Baja
                };
                DgvEmpleados.Rows.Add(fila);
            }

        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            var ventana = new FormNuevoEmpleado();
            ventana.ShowDialog();
            ActualizarEmpleados();
        }

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

        private void EmpleadosForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _principalForm.Show();
        }

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

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ActualizarEmpleados();
        }
    }
}
