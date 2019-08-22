namespace TP_Maxi_PC
{
    partial class Agregar_PC
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lbl_Modelo = new System.Windows.Forms.Label();
            this.txt_Modelo = new System.Windows.Forms.TextBox();
            this.combo_Marca = new System.Windows.Forms.ComboBox();
            this.combo_Dueño = new System.Windows.Forms.ComboBox();
            this.lbl_Marca = new System.Windows.Forms.Label();
            this.lbl_dueño = new System.Windows.Forms.Label();
            this.dgv_PC = new System.Windows.Forms.DataGridView();
            this.btn_Cargar = new System.Windows.Forms.Button();
            this.btn_Salir = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_PC)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(394, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salirToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(96, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // lbl_Modelo
            // 
            this.lbl_Modelo.AutoSize = true;
            this.lbl_Modelo.Location = new System.Drawing.Point(12, 31);
            this.lbl_Modelo.Name = "lbl_Modelo";
            this.lbl_Modelo.Size = new System.Drawing.Size(45, 13);
            this.lbl_Modelo.TabIndex = 1;
            this.lbl_Modelo.Text = "Modelo:";
            // 
            // txt_Modelo
            // 
            this.txt_Modelo.Location = new System.Drawing.Point(63, 28);
            this.txt_Modelo.MaxLength = 32;
            this.txt_Modelo.Name = "txt_Modelo";
            this.txt_Modelo.Size = new System.Drawing.Size(174, 20);
            this.txt_Modelo.TabIndex = 2;
            // 
            // combo_Marca
            // 
            this.combo_Marca.FormattingEnabled = true;
            this.combo_Marca.Location = new System.Drawing.Point(63, 55);
            this.combo_Marca.Name = "combo_Marca";
            this.combo_Marca.Size = new System.Drawing.Size(121, 21);
            this.combo_Marca.TabIndex = 3;
            // 
            // combo_Dueño
            // 
            this.combo_Dueño.FormattingEnabled = true;
            this.combo_Dueño.Location = new System.Drawing.Point(63, 82);
            this.combo_Dueño.Name = "combo_Dueño";
            this.combo_Dueño.Size = new System.Drawing.Size(121, 21);
            this.combo_Dueño.TabIndex = 3;
            // 
            // lbl_Marca
            // 
            this.lbl_Marca.AutoSize = true;
            this.lbl_Marca.Location = new System.Drawing.Point(12, 58);
            this.lbl_Marca.Name = "lbl_Marca";
            this.lbl_Marca.Size = new System.Drawing.Size(40, 13);
            this.lbl_Marca.TabIndex = 1;
            this.lbl_Marca.Text = "Marca:";
            // 
            // lbl_dueño
            // 
            this.lbl_dueño.AutoSize = true;
            this.lbl_dueño.Location = new System.Drawing.Point(12, 85);
            this.lbl_dueño.Name = "lbl_dueño";
            this.lbl_dueño.Size = new System.Drawing.Size(42, 13);
            this.lbl_dueño.TabIndex = 1;
            this.lbl_dueño.Text = "Dueño:";
            // 
            // dgv_PC
            // 
            this.dgv_PC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_PC.Location = new System.Drawing.Point(15, 131);
            this.dgv_PC.Name = "dgv_PC";
            this.dgv_PC.Size = new System.Drawing.Size(367, 150);
            this.dgv_PC.TabIndex = 4;
            // 
            // btn_Cargar
            // 
            this.btn_Cargar.Location = new System.Drawing.Point(305, 80);
            this.btn_Cargar.Name = "btn_Cargar";
            this.btn_Cargar.Size = new System.Drawing.Size(75, 23);
            this.btn_Cargar.TabIndex = 5;
            this.btn_Cargar.Text = "Cargar";
            this.btn_Cargar.UseVisualStyleBackColor = true;
            this.btn_Cargar.Click += new System.EventHandler(this.btn_Cargar_Click);
            // 
            // btn_Salir
            // 
            this.btn_Salir.Location = new System.Drawing.Point(224, 80);
            this.btn_Salir.Name = "btn_Salir";
            this.btn_Salir.Size = new System.Drawing.Size(75, 23);
            this.btn_Salir.TabIndex = 5;
            this.btn_Salir.Text = "Salir";
            this.btn_Salir.UseVisualStyleBackColor = true;
            this.btn_Salir.Click += new System.EventHandler(this.btn_Salir_Click);
            // 
            // Agregar_PC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 296);
            this.Controls.Add(this.btn_Salir);
            this.Controls.Add(this.btn_Cargar);
            this.Controls.Add(this.dgv_PC);
            this.Controls.Add(this.combo_Dueño);
            this.Controls.Add(this.combo_Marca);
            this.Controls.Add(this.txt_Modelo);
            this.Controls.Add(this.lbl_dueño);
            this.Controls.Add(this.lbl_Marca);
            this.Controls.Add(this.lbl_Modelo);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Agregar_PC";
            this.Text = "Agregar PC";
            this.Load += new System.EventHandler(this.Agregar_PC_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_PC)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.Label lbl_Modelo;
        private System.Windows.Forms.TextBox txt_Modelo;
        private System.Windows.Forms.ComboBox combo_Marca;
        private System.Windows.Forms.ComboBox combo_Dueño;
        private System.Windows.Forms.Label lbl_Marca;
        private System.Windows.Forms.Label lbl_dueño;
        private System.Windows.Forms.DataGridView dgv_PC;
        private System.Windows.Forms.Button btn_Cargar;
        private System.Windows.Forms.Button btn_Salir;
    }
}