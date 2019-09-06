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
            var registros = _empleadosRepositorio.ObtenerEmpleados().Rows;
            ActualizarGrilla(registros);
        }

        private void ActualizarGrilla(DataRowCollection registros)
        {
            foreach (DataRow registro in registros)
            {
                if (registro.HasErrors)
                    continue; // no corto el ciclo
                // tratamiento de fechas
                DateTime fecha = DateTime.MinValue;
                DateTime fecha1 = DateTime.MinValue;

                // Si lo que esta en la BD de datos se puede parsear a date se lo parsea y almacena en la varaible fecha
                DateTime.TryParse(registro.ItemArray[6]?.ToString(), out fecha);
                DateTime.TryParse(registro.ItemArray[7]?.ToString(), out fecha1);

                var fila = new string[] {
                    registro.ItemArray[0].ToString(), // Legajo
                    registro.ItemArray[1].ToString(), // Tipo Documento
                    registro.ItemArray[2].ToString(), // Nro Documento
                    registro.ItemArray[3].ToString(), // Apellido
                    registro.ItemArray[4].ToString(), // Nombre
                    registro.ItemArray[5].ToString(), // Id Tipo Empleado
                    fecha != DateTime.MinValue ? fecha.ToString("dd/MM/yyyy") : null,// Fecha Alta
                    fecha1 != DateTime.MinValue ? fecha1.ToString("dd/MM/yyyy") : null // Fecha Baja
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
