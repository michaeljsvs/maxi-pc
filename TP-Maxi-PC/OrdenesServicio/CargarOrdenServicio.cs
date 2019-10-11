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
using TP_Maxi_PC.Modelos;
using TP_Maxi_PC.ABM.Empleados;


namespace TP_Maxi_PC.OrdenesServicio
{
    public partial class CargarOrdenServicio : Form
    {
        OrdenesRepositorio OSRepo = new OrdenesRepositorio();
        PCRepositorio PCRepo = new PCRepositorio();
        EmpleadosRepositorio EMPRepo = new EmpleadosRepositorio();
        string legCargar;
        string idCargar;
        public CargarOrdenServicio()
        {
            InitializeComponent();
            
        }
        
        private void CargarOrdenServicio_Load(object sender, EventArgs e)
        {
            ActualizarEmpleados();
            ActualizarPC();
        }
        private void ActualizarPC()
        {
            dgv_PC.Rows.Clear();
            var pcs = PCRepo.obtenerPC().Rows;
            var filas = new List<DataGridViewRow>();
            foreach (DataRow pc in pcs)
            {
                if (pc.HasErrors)
                    continue;
                var fila = new string[]
                {
                    pc.ItemArray[0].ToString(),
                    pc.ItemArray[1].ToString(),
                    pc.ItemArray[2].ToString(),
                    pc.ItemArray[3].ToString(),
                    pc.ItemArray[4].ToString(),
                    pc.ItemArray[5].ToString()
                };
                dgv_PC.Rows.Add(fila);
            }

        }
        private void ActualizarEmpleados()
        {
            DgvEmpleados.Rows.Clear();
            var registros = EMPRepo.ObtenerEmpleados();
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

        private void DgvEmpleados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (maskedTextBox1.Text == "")
            {
                MessageBox.Show("El Monto Total esta vacío!");
                return;
            }
            else
            {
                if (maskedTextBox2.Text == "")
                {
                    MessageBox.Show("La seña esta vacía!");
                    return;
                }
                else
                {
                    var empSelecc = DgvEmpleados.SelectedRows;
                    foreach (DataGridViewRow fila in empSelecc)
                    {
                        legCargar = fila.Cells[0].Value.ToString();
                    }
                    var pcSelecc = dgv_PC.SelectedRows;
                    foreach(DataGridViewRow fiila in pcSelecc)
                    {
                        idCargar = fiila.Cells[0].Value.ToString();
                    }
                    OSRepo.cargarOS(legCargar,maskedTextBox2.Text,dateTimePicker2.Value,dateTimePicker1.Value,maskedTextBox1.Text,idCargar);
                    MessageBox.Show("Se cargo correctamente!");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Agregar_PC nueva = new Agregar_PC();
            nueva.ShowDialog();
            ActualizarPC();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            EmpleadosForm nuevo = new EmpleadosForm();
            nuevo.ShowDialog();
            ActualizarEmpleados();
        }
    }
}
