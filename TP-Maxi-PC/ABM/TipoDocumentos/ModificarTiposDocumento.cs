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

namespace TP_Maxi_PC.ABM.TipoDocumentos
{
    public partial class ModificarTiposDocumento : Form
    {
        TiposDocumentoRepositorio _tipoDocumentoRepositorio;
        TiposDocumento tipoDoc;

        public ModificarTiposDocumento()
        {
            InitializeComponent();
        }

        public ModificarTiposDocumento(string id_TipoDoc)
        {
            InitializeComponent();
            _tipoDocumentoRepositorio = new TiposDocumentoRepositorio();
            tipoDoc = _tipoDocumentoRepositorio.ObtenerTipoDocumento(id_TipoDoc);
        }

        //LOAD EDITAR
        private void ModificarTiposDocumento_Load(object sender, EventArgs e)
        {
            txtID.Text = Convert.ToString(tipoDoc.idTipoDocumento);
            txtNombre.Text = tipoDoc.nombre;
        }

        //BTN GUARDAR
        private void btn_Cargar_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma tipo documento nuevo", "Confirmación", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                return;

            StringBuilder mensaje = new StringBuilder("La operación ");
            var tipoDocumento = PrepararTipoDocumento();
            try
            {
                if (_tipoDocumentoRepositorio.Actualizar(tipoDocumento))
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

        //CREA UN OBJETO CON LOS DATOS DEL FORM
        private TiposDocumento PrepararTipoDocumento()
        {
            // Agregar validaciones
            var tiposDocumento = new TiposDocumento()
            {
                idTipoDocumento = int.Parse(txtID.Text),
                nombre = txtNombre.Text
            };
            return tiposDocumento;
        }

        
    }
}
