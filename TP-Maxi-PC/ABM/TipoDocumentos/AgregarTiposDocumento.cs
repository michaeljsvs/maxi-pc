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

namespace TP_Maxi_PC.ABM.TipoDocumentos
{
    public partial class AgregarTiposDocumento : Form
    {
        TiposDocumentoRepositorio _tiposDocumentoRepositorio;

        public AgregarTiposDocumento()
        {
            InitializeComponent();
            _tiposDocumentoRepositorio = new TiposDocumentoRepositorio();
        }

        //LOAD
        private void AgregarTiposDocumento_Load(object sender, EventArgs e)
        {
            ActualizarTiposDocumento();
        }

        //ACTUALIZAR (OBTIENE LISTA)
        private void ActualizarTiposDocumento()
        {
            dgv_TiposDocumento.Rows.Clear();
            var registros = _tiposDocumentoRepositorio.ObtenerTiposDocumento();
            ActualizarGrilla(registros);
        }

        //ACTUALIZA EL DATA GRID VIEW
        private void ActualizarGrilla(List<TiposDocumento> registros)
        {
            foreach (TiposDocumento registro in registros)
            {
                var fila = new string[] {
                    registro.idTipoDocumento.ToString(), // idTipoDocumento
                    registro.nombre.ToString(), // Nombre Tipo Documento
                };
                dgv_TiposDocumento.Rows.Add(fila);
            }
        }

        //BTN ELIMINAR
        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            var seleccionadas = dgv_TiposDocumento.SelectedRows;
            if (seleccionadas.Count == 0 || seleccionadas.Count > 1)
            {
                MessageBox.Show("Debe seleccionar una fila");
                return;
            }

            foreach (DataGridViewRow fila in seleccionadas)
            {
                var nombre = fila.Cells[1].Value;
                var id_TipoDoc = fila.Cells[0].Value;

                //pregunto confirmación
                var confirmacion = MessageBox.Show($"Esta seguro que desea eliminar a {nombre}?",
                    "Confirmar operación",
                    MessageBoxButtons.YesNo);

                if (confirmacion.Equals(DialogResult.No))
                    return;

                if (_tiposDocumentoRepositorio.Eliminar(id_TipoDoc.ToString()))
                {
                    MessageBox.Show("Se eliminó exitosamente");
                    ActualizarTiposDocumento();
                }
            }
        }

        //BTN MODIFICAR
        private void btn_Modificar_Click(object sender, EventArgs e)
        {
            var seleccionadas = dgv_TiposDocumento.SelectedRows;
            if (seleccionadas.Count == 0 || seleccionadas.Count > 1)
            {
                MessageBox.Show("Debe seleccionar una fila");
                return;
            }
            foreach (DataGridViewRow fila in seleccionadas)
            {
                var id_TipoDoc = fila.Cells[0].Value;

                var ventana = new ModificarTiposDocumento(id_TipoDoc.ToString());
                ventana.ShowDialog();
                ActualizarTiposDocumento();
            }
        }

        //BTN ACTUALIZAR
        private void btn_Actualizar_Click(object sender, EventArgs e)
        {
            ActualizarTiposDocumento();
        }

        //BTN GUARDAR
        private void btn_Cargar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma tipo documento nuevo", "Confirmación", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                return;

            StringBuilder mensaje = new StringBuilder("La operación ");
            var tipoDocumento = PrepararTipoDocumento();
            try
            {
                if (_tiposDocumentoRepositorio.Guardar(tipoDocumento))
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
                if (tipoDocumento == null)
                    MessageBox.Show(mensaje.ToString());
                this.Dispose();
            }
        }

        //BTN CANCELAR
        private void btn_Salir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Está seguro que desea salir?", "Salir", MessageBoxButtons.OKCancel) == DialogResult.OK)
                Dispose();
        }

        //CREA UN OBJETO CON LOS DATOS DEL FORM
        private TiposDocumento PrepararTipoDocumento()
        {
            // Agregar validaciones
            var tiposDocumento = new TiposDocumento()
            {
                nombre = txtNombre.Text
            };
            return tiposDocumento;
        }
    }
}
