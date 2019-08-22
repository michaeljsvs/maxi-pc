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

namespace TP_Maxi_PC
{
    public partial class Agregar_PC : Form
    {
        public Agregar_PC()
        {
            InitializeComponent();
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
            ArrayList listaMarca = new ArrayList();
            listaMarca.Add("Lenovo");
            listaMarca.Add("Asus");
            listaMarca.Add("HP");
            listaMarca.Add("Samsung");

            ArrayList listaDueños = new ArrayList();
            listaDueños.Add("Pedro Paramo");
            listaDueños.Add("Martín Santome");
            listaDueños.Add("Gregor Samsa");
            listaDueños.Add("Arcadio Buendía");

            combo_Dueño.DataSource = listaDueños;
            combo_Marca.DataSource = listaMarca;
            dgv_PC.Columns.Add("clDueño","Dueño");
            dgv_PC.Columns.Add("clMarca", "Marca");
            dgv_PC.Columns.Add("clModelo", "Modelo");


        }

        private void btn_Cargar_Click(object sender, EventArgs e)
        {
            if (txt_Modelo.Text == "")
            {
                MessageBox.Show("El modelo no debe estar vacío!");
                txt_Modelo.Focus();
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
                            dgv_PC.Rows.Add(combo_Dueño.SelectedValue.ToString(), combo_Marca.SelectedValue.ToString(), txt_Modelo.Text.ToString());
                        txt_Modelo.Clear();
                        combo_Marca.SelectedIndex = 0;
                        combo_Dueño.SelectedIndex = 0;
                        txt_Modelo.Focus();
                    }
                }
            }
             
        }
    }
}
