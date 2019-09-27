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
    public partial class AgregarBarrio : Form
    {
        BarriosRepositorio _barriosRepositorio;

        public AgregarBarrio()
        {
            InitializeComponent();
            _barriosRepositorio = new BarriosRepositorio();
        }

        //ACTUALIZAR (OBTIENE LISTA)
        private void ActualizarBarrios()
        {
            dgv_Barrios.Rows.Clear();
            var registros = _barriosRepositorio.ObtenerBarrios();
            ActualizarGrilla(registros);
        }

        //ACTUALIZA EL DATA GRID VIEW
        private void ActualizarGrilla(List<Barrio> registros)
        {
            foreach (Barrio registro in registros)
            {
                var fila = new string[] {
                    registro.idBarrio.ToString(), // idBarrio
                    registro.nombre.ToString(), // Nombre Barrio
                };
                dgv_Barrios.Rows.Add(fila);
            }
        }

        private void btn_Cargar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma barrio nuevo", "Confirmación", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                return;

            StringBuilder mensaje = new StringBuilder("La operación ");
            var barrio = PrepararBarrio();
            try
            {
                if (_barriosRepositorio.Guardar(barrio))
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

        private void btn_Modificar_Click(object sender, EventArgs e)
        {
            var seleccionadas = dgv_Barrios.SelectedRows;
            if (seleccionadas.Count == 0 || seleccionadas.Count > 1)
            {
                MessageBox.Show("Debe seleccionar una fila");
                return;
            }
            foreach (DataGridViewRow fila in seleccionadas)
            {
                var id_Barrio = fila.Cells[0].Value;

                var ventana = new ModificarBarrio(id_Barrio.ToString());
                ventana.ShowDialog();
                ActualizarBarrios();
            }
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            var seleccionadas = dgv_Barrios.SelectedRows;
            if (seleccionadas.Count == 0 || seleccionadas.Count > 1)
            {
                MessageBox.Show("Debe seleccionar una fila");
                return;
            }

            foreach (DataGridViewRow fila in seleccionadas)
            {
                var nombre = fila.Cells[1].Value;
                var id_Barrio = fila.Cells[0].Value;

                //pregunto confirmación
                var confirmacion = MessageBox.Show($"Esta seguro que desea eliminar a {nombre}?",
                    "Confirmar operación",
                    MessageBoxButtons.YesNo);

                if (confirmacion.Equals(DialogResult.No))
                    return;

                if (_barriosRepositorio.Eliminar(id_Barrio.ToString()))
                {
                    MessageBox.Show("Se eliminó exitosamente");
                    ActualizarBarrios();
                }
            }
        }

        private void AgregarBarrio_Load(object sender, EventArgs e)
        {
            ActualizarBarrios();
        }

        private void btn_Actualizar_Click(object sender, EventArgs e)
        {
            ActualizarBarrios();
        }

        private void btn_Salir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Está seguro que desea salir?", "Salir", MessageBoxButtons.OKCancel) == DialogResult.OK)
                Dispose();
        }

        //CREA UN OBJETO CON LOS DATOS DEL FORM
        private Barrio PrepararBarrio()
        {
            // Agregar validaciones
            var barrios = new Barrio()
            {
                nombre = txtNombre.Text
            };
            return barrios;
        }
    }
}
