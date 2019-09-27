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
    public partial class AgregarTiposEmpleado : Form
    {
        TiposEmpleadoRepositorio _tiposEmpleadoRepositorio;
        
        public AgregarTiposEmpleado()
        {
            InitializeComponent();
            _tiposEmpleadoRepositorio = new TiposEmpleadoRepositorio();
        }

        //LOAD
        private void AgregarTiposEmpleado_Load_1(object sender, EventArgs e)
        {
            ActualizarTiposEmpleado();
        }

        //ACTUALIZAR (OBTIENE LISTA)
        private void ActualizarTiposEmpleado()
        {
            dgv_TiposEmpleado.Rows.Clear();
            var registros = _tiposEmpleadoRepositorio.ObtenerTiposEmpleado();
            ActualizarGrilla(registros);
        }

        //ACTUALIZA EL DATA GRID VIEW
        private void ActualizarGrilla(List<TiposEmpleado> registros)
        {
            foreach (TiposEmpleado registro in registros)
            {
                var fila = new string[] {
                    registro.idTipoEmpleado.ToString(), // idTipoEmpleado
                    registro.nombre.ToString(), // Nombre Tipo Empleado
                };
                dgv_TiposEmpleado.Rows.Add(fila);
            }
        }

        //BTN ELIMINAR
        private void btn_Eliminar_Click_1(object sender, EventArgs e)
        {
            var seleccionadas = dgv_TiposEmpleado.SelectedRows;
            if (seleccionadas.Count == 0 || seleccionadas.Count > 1)
            {
                MessageBox.Show("Debe seleccionar una fila");
                return;
            }

            foreach (DataGridViewRow fila in seleccionadas)
            {
                var nombre = fila.Cells[1].Value;
                var id_TipoEmp = fila.Cells[0].Value;

                //pregunto confirmación
                var confirmacion = MessageBox.Show($"Esta seguro que desea eliminar a {nombre}?",
                    "Confirmar operación",
                    MessageBoxButtons.YesNo);

                if (confirmacion.Equals(DialogResult.No))
                    return;

                if (_tiposEmpleadoRepositorio.Eliminar(id_TipoEmp.ToString()))
                {
                    MessageBox.Show("Se eliminó exitosamente");
                    ActualizarTiposEmpleado();
                }
            }
        }

        //BTN MODIFICAR
        private void btn_Modificar_Click_1(object sender, EventArgs e)
        {
            var seleccionadas = dgv_TiposEmpleado.SelectedRows;
            if (seleccionadas.Count == 0 || seleccionadas.Count > 1)
            {
                MessageBox.Show("Debe seleccionar una fila");
                return;
            }
            foreach (DataGridViewRow fila in seleccionadas)
            {
                var id_TipoEmp = fila.Cells[0].Value;

                var ventana = new ModificarTiposEmpleados(id_TipoEmp.ToString());
                ventana.ShowDialog();
                ActualizarTiposEmpleado();
            }
        }

        //BTN ACTUALIZAR
        private void btn_Actualizar_Click_1(object sender, EventArgs e)
        {
            ActualizarTiposEmpleado();
        }

        //BTN GUARDAR
        private void btn_Cargar_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma tipo empleado nuevo", "Confirmación", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                return;

            StringBuilder mensaje = new StringBuilder("La operación ");
            var tipoEmpleado = PrepararTipoEmpleado();
            try
            {
                if (_tiposEmpleadoRepositorio.Guardar(tipoEmpleado))
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

        //BTN CANCELAR
        private void btn_Salir_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Está seguro que desea salir?", "Salir", MessageBoxButtons.OKCancel) == DialogResult.OK)
                Dispose();
        }

        //CREA UN OBJETO CON LOS DATOS DEL FORM
        private TiposEmpleado PrepararTipoEmpleado()
        {
            // Agregar validaciones
            var tiposEmpleado = new TiposEmpleado()
            {
                nombre = txtNombre.Text
            };
            return tiposEmpleado;
        }
    }
}
