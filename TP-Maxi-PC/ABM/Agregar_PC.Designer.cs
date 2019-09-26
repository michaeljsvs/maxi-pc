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
            this.combo_Marca = new System.Windows.Forms.ComboBox();
            this.combo_Dueño = new System.Windows.Forms.ComboBox();
            this.lbl_Marca = new System.Windows.Forms.Label();
            this.lbl_dueño = new System.Windows.Forms.Label();
            this.dgv_PC = new System.Windows.Forms.DataGridView();
            this.btn_Cargar = new System.Windows.Forms.Button();
            this.btn_Salir = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.labelDescripcion = new System.Windows.Forms.Label();
            this.cmbModelo = new System.Windows.Forms.ComboBox();
            this.agregarDueño = new System.Windows.Forms.Button();
            this.button1Modelo = new System.Windows.Forms.Button();
            this.idPC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.duenio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.marca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modelo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoPC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.detalle = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.menuStrip1.Size = new System.Drawing.Size(790, 24);
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
            this.lbl_Modelo.Location = new System.Drawing.Point(12, 61);
            this.lbl_Modelo.Name = "lbl_Modelo";
            this.lbl_Modelo.Size = new System.Drawing.Size(45, 13);
            this.lbl_Modelo.TabIndex = 1;
            this.lbl_Modelo.Text = "Modelo:";
            // 
            // combo_Marca
            // 
            this.combo_Marca.AllowDrop = true;
            this.combo_Marca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_Marca.FormattingEnabled = true;
            this.combo_Marca.Location = new System.Drawing.Point(63, 30);
            this.combo_Marca.Name = "combo_Marca";
            this.combo_Marca.Size = new System.Drawing.Size(121, 21);
            this.combo_Marca.TabIndex = 1;
            this.combo_Marca.SelectedIndexChanged += new System.EventHandler(this.cambioMarca);
            // 
            // combo_Dueño
            // 
            this.combo_Dueño.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_Dueño.FormattingEnabled = true;
            this.combo_Dueño.Location = new System.Drawing.Point(63, 82);
            this.combo_Dueño.Name = "combo_Dueño";
            this.combo_Dueño.Size = new System.Drawing.Size(121, 21);
            this.combo_Dueño.TabIndex = 2;
            // 
            // lbl_Marca
            // 
            this.lbl_Marca.AutoSize = true;
            this.lbl_Marca.Location = new System.Drawing.Point(12, 33);
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
            this.dgv_PC.AllowUserToAddRows = false;
            this.dgv_PC.AllowUserToDeleteRows = false;
            this.dgv_PC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_PC.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idPC,
            this.duenio,
            this.marca,
            this.modelo,
            this.TipoPC,
            this.detalle});
            this.dgv_PC.Location = new System.Drawing.Point(15, 234);
            this.dgv_PC.MultiSelect = false;
            this.dgv_PC.Name = "dgv_PC";
            this.dgv_PC.ReadOnly = true;
            this.dgv_PC.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_PC.Size = new System.Drawing.Size(763, 150);
            this.dgv_PC.TabIndex = 5;
            // 
            // btn_Cargar
            // 
            this.btn_Cargar.Location = new System.Drawing.Point(224, 121);
            this.btn_Cargar.Name = "btn_Cargar";
            this.btn_Cargar.Size = new System.Drawing.Size(75, 23);
            this.btn_Cargar.TabIndex = 3;
            this.btn_Cargar.Text = "Cargar";
            this.btn_Cargar.UseVisualStyleBackColor = true;
            this.btn_Cargar.Click += new System.EventHandler(this.btn_Cargar_Click);
            // 
            // btn_Salir
            // 
            this.btn_Salir.Location = new System.Drawing.Point(305, 121);
            this.btn_Salir.Name = "btn_Salir";
            this.btn_Salir.Size = new System.Drawing.Size(75, 23);
            this.btn_Salir.TabIndex = 4;
            this.btn_Salir.Text = "Salir";
            this.btn_Salir.UseVisualStyleBackColor = true;
            this.btn_Salir.Click += new System.EventHandler(this.btn_Salir_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(15, 150);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(367, 67);
            this.richTextBox1.TabIndex = 6;
            this.richTextBox1.Text = "";
            // 
            // labelDescripcion
            // 
            this.labelDescripcion.AutoSize = true;
            this.labelDescripcion.Location = new System.Drawing.Point(12, 134);
            this.labelDescripcion.Name = "labelDescripcion";
            this.labelDescripcion.Size = new System.Drawing.Size(66, 13);
            this.labelDescripcion.TabIndex = 1;
            this.labelDescripcion.Text = "Descripción:";
            // 
            // cmbModelo
            // 
            this.cmbModelo.AllowDrop = true;
            this.cmbModelo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbModelo.FormattingEnabled = true;
            this.cmbModelo.Location = new System.Drawing.Point(63, 57);
            this.cmbModelo.Name = "cmbModelo";
            this.cmbModelo.Size = new System.Drawing.Size(121, 21);
            this.cmbModelo.TabIndex = 1;
            // 
            // agregarDueño
            // 
            this.agregarDueño.Location = new System.Drawing.Point(190, 82);
            this.agregarDueño.Name = "agregarDueño";
            this.agregarDueño.Size = new System.Drawing.Size(21, 21);
            this.agregarDueño.TabIndex = 7;
            this.agregarDueño.Text = "+";
            this.agregarDueño.UseVisualStyleBackColor = true;
            this.agregarDueño.Click += new System.EventHandler(this.agregarMarca_Click);
            // 
            // button1Modelo
            // 
            this.button1Modelo.Location = new System.Drawing.Point(190, 56);
            this.button1Modelo.Name = "button1Modelo";
            this.button1Modelo.Size = new System.Drawing.Size(21, 21);
            this.button1Modelo.TabIndex = 8;
            this.button1Modelo.Text = "+";
            this.button1Modelo.UseVisualStyleBackColor = true;
            this.button1Modelo.Click += new System.EventHandler(this.button1Modelo_Click);
            // 
            // idPC
            // 
            this.idPC.HeaderText = "ID";
            this.idPC.Name = "idPC";
            this.idPC.ReadOnly = true;
            // 
            // duenio
            // 
            this.duenio.HeaderText = "Dueño";
            this.duenio.Name = "duenio";
            this.duenio.ReadOnly = true;
            // 
            // marca
            // 
            this.marca.HeaderText = "Marca";
            this.marca.Name = "marca";
            this.marca.ReadOnly = true;
            // 
            // modelo
            // 
            this.modelo.HeaderText = "Modelo";
            this.modelo.Name = "modelo";
            this.modelo.ReadOnly = true;
            // 
            // TipoPC
            // 
            this.TipoPC.HeaderText = "TipoPC";
            this.TipoPC.Name = "TipoPC";
            this.TipoPC.ReadOnly = true;
            // 
            // detalle
            // 
            this.detalle.HeaderText = "Descripcion";
            this.detalle.Name = "detalle";
            this.detalle.ReadOnly = true;
            this.detalle.Width = 200;
            // 
            // Agregar_PC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 391);
            this.Controls.Add(this.button1Modelo);
            this.Controls.Add(this.agregarDueño);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.btn_Salir);
            this.Controls.Add(this.btn_Cargar);
            this.Controls.Add(this.dgv_PC);
            this.Controls.Add(this.combo_Dueño);
            this.Controls.Add(this.cmbModelo);
            this.Controls.Add(this.combo_Marca);
            this.Controls.Add(this.labelDescripcion);
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
        private System.Windows.Forms.ComboBox combo_Marca;
        private System.Windows.Forms.ComboBox combo_Dueño;
        private System.Windows.Forms.Label lbl_Marca;
        private System.Windows.Forms.Label lbl_dueño;
        private System.Windows.Forms.DataGridView dgv_PC;
        private System.Windows.Forms.Button btn_Cargar;
        private System.Windows.Forms.Button btn_Salir;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label labelDescripcion;
        private System.Windows.Forms.ComboBox cmbModelo;
        private System.Windows.Forms.Button agregarDueño;
        private System.Windows.Forms.Button button1Modelo;
        private System.Windows.Forms.DataGridViewTextBoxColumn idPC;
        private System.Windows.Forms.DataGridViewTextBoxColumn duenio;
        private System.Windows.Forms.DataGridViewTextBoxColumn marca;
        private System.Windows.Forms.DataGridViewTextBoxColumn modelo;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoPC;
        private System.Windows.Forms.DataGridViewTextBoxColumn detalle;
    }
}