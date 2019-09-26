using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using TP_Maxi_PC.Repositorios;
using TP_Maxi_PC.ABM;

namespace TP_Maxi_PC
{
    public partial class Agregar_PC : Form
    {
        PCRepositorio pcrepo;
        ClientesRepositorio clienterepo;
        public Agregar_PC()
        {
            InitializeComponent();
            pcrepo = new PCRepositorio();
            clienterepo = new ClientesRepositorio();
        }
        private void ActualizarPC()
        {
            dgv_PC.Rows.Clear();
            var pcs = pcrepo.obtenerPC().Rows;
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
                    pc.ItemArray[4].ToString()
                };
                dgv_PC.Rows.Add(fila);


            }
        }

        private void actualizarComboMarca()
        {
            var Marcas = pcrepo.obtenerMarcasDT();
            combo_Marca.ValueMember = "idMarca";
            combo_Marca.DisplayMember = "nombre";
            combo_Marca.DataSource = Marcas;
        }
        private void actualizarDueños()
        {
            var dueños = clienterepo.obtenerParaCombo();
            combo_Dueño.ValueMember = "idCliente";
            combo_Dueño.DisplayMember = "final";
            combo_Dueño.DataSource = dueños;
        }
        private void actualizarModelos()
        {
            var modelos = pcrepo.obtenerModelosDT();
            cmbModelo.ValueMember = "idModelo";
            cmbModelo.DisplayMember = "nombre";
            cmbModelo.DataSource = modelos;
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Agregar_PC_Load(object sender, EventArgs e)
        {
            //ArrayList listaMarca = new ArrayList();
            //listaMarca.Add("Lenovo");
            //listaMarca.Add("Asus");
            //listaMarca.Add("HP");
            //listaMarca.Add("Samsung");

            //ArrayList listaDueños = new ArrayList();
            //listaDueños.Add("Pedro Paramo");
            //listaDueños.Add("Martín Santome");
            //listaDueños.Add("Gregor Samsa");
            //listaDueños.Add("Arcadio Buendía");

            //combo_Dueño.DataSource = listaDueños;
            //combo_Marca.DataSource = listaMarca;
            //dgv_PC.Columns.Add("clDueño","Dueño");
            //dgv_PC.Columns.Add("clMarca", "Marca");
            //dgv_PC.Columns.Add("clModelo", "Modelo");
           // ActualizarPC();
            actualizarComboMarca();
            actualizarDueños();
            actualizarModelos();
            ActualizarPC();
        }
        

        private void btn_Cargar_Click(object sender, EventArgs e)
        {
            if (cmbModelo.SelectedIndex == -1)
            {
                MessageBox.Show("El modelo no debe estar vacío!");
                cmbModelo.Focus();
            }
            else
            {
                if (combo_Marca.SelectedIndex == -1)
                {
                    MessageBox.Show("La marca debe estar selecionada!");
                    combo_Marca.Focus();
                }
                else
                {
                    if(combo_Dueño.SelectedIndex == -1)
                    {
                        MessageBox.Show("El dueño debe estar seleccioado.");
                        combo_Dueño.Focus();
                    }
                    else
                    {
                        int pasar = Convert.ToInt32(combo_Dueño.SelectedValue.ToString());
                        int pasarMarca = Convert.ToInt32(combo_Marca.SelectedValue.ToString());
                        int pasarModelo = Convert.ToInt32(cmbModelo.SelectedValue.ToString());
                            pcrepo.insertarPC(pasar, pasarMarca, pasarModelo,richTextBox1.Text);
                        cmbModelo.SelectedIndex = 0;
                        combo_Marca.SelectedIndex = 0;
                        combo_Dueño.SelectedIndex = 0;
                        richTextBox1.Clear();
                        combo_Marca.Focus();
                    }
                }
            }
             
        }

        private void cambioMarca(object sender, EventArgs e)
        {
            int index = combo_Marca.SelectedIndex;
            var modelos = pcrepo.obtenerModeloDT(index +1);
            cmbModelo.ValueMember = "idModelo";
            cmbModelo.DisplayMember = "nombre";
            cmbModelo.DataSource = modelos;
        }

        private void agregarMarca_Click(object sender, EventArgs e)
        {
            Agregar_Cliente nuevo = new Agregar_Cliente();
            nuevo.Show();
        }

        private void button1Modelo_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = combo_Dueño.SelectedValue.ToString();
        }
    }
}
