namespace TP_Maxi_PC.OrdenesServicio
{
    partial class Ordenes
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
            this.dgvOS = new System.Windows.Forms.DataGridView();
            this.idOrdenServicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.legajoEmpleado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.montoSeña = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaIngreso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaEstimadaEntrega = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaRealEntrega = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costoTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idPC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnNueva = new System.Windows.Forms.Button();
            this.btnEntregar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOS)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvOS
            // 
            this.dgvOS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOS.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idOrdenServicio,
            this.legajoEmpleado,
            this.montoSeña,
            this.fechaIngreso,
            this.fechaEstimadaEntrega,
            this.fechaRealEntrega,
            this.costoTotal,
            this.idPC});
            this.dgvOS.Location = new System.Drawing.Point(13, 50);
            this.dgvOS.MultiSelect = false;
            this.dgvOS.Name = "dgvOS";
            this.dgvOS.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOS.Size = new System.Drawing.Size(843, 278);
            this.dgvOS.TabIndex = 0;
            this.dgvOS.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOS_CellContentClick);
            // 
            // idOrdenServicio
            // 
            this.idOrdenServicio.HeaderText = "ID OS";
            this.idOrdenServicio.Name = "idOrdenServicio";
            // 
            // legajoEmpleado
            // 
            this.legajoEmpleado.HeaderText = "Empleado";
            this.legajoEmpleado.Name = "legajoEmpleado";
            // 
            // montoSeña
            // 
            this.montoSeña.HeaderText = "Seña";
            this.montoSeña.Name = "montoSeña";
            // 
            // fechaIngreso
            // 
            this.fechaIngreso.HeaderText = "Fecha Ingreso";
            this.fechaIngreso.Name = "fechaIngreso";
            // 
            // fechaEstimadaEntrega
            // 
            this.fechaEstimadaEntrega.HeaderText = "Entrega Estimada";
            this.fechaEstimadaEntrega.Name = "fechaEstimadaEntrega";
            // 
            // fechaRealEntrega
            // 
            this.fechaRealEntrega.HeaderText = "Fecha Entrega";
            this.fechaRealEntrega.Name = "fechaRealEntrega";
            // 
            // costoTotal
            // 
            this.costoTotal.HeaderText = "Monto Total";
            this.costoTotal.Name = "costoTotal";
            // 
            // idPC
            // 
            this.idPC.HeaderText = "ID PC";
            this.idPC.Name = "idPC";
            // 
            // btnNueva
            // 
            this.btnNueva.Location = new System.Drawing.Point(779, 21);
            this.btnNueva.Name = "btnNueva";
            this.btnNueva.Size = new System.Drawing.Size(75, 23);
            this.btnNueva.TabIndex = 1;
            this.btnNueva.Text = "Nueva";
            this.btnNueva.UseVisualStyleBackColor = true;
            this.btnNueva.Click += new System.EventHandler(this.btnNueva_Click);
            // 
            // btnEntregar
            // 
            this.btnEntregar.Location = new System.Drawing.Point(778, 335);
            this.btnEntregar.Name = "btnEntregar";
            this.btnEntregar.Size = new System.Drawing.Size(75, 23);
            this.btnEntregar.TabIndex = 2;
            this.btnEntregar.Text = "Entregada";
            this.btnEntregar.UseVisualStyleBackColor = true;
            this.btnEntregar.Click += new System.EventHandler(this.btnEntregar_Click);
            // 
            // Ordenes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(866, 450);
            this.Controls.Add(this.btnEntregar);
            this.Controls.Add(this.btnNueva);
            this.Controls.Add(this.dgvOS);
            this.Name = "Ordenes";
            this.Text = "OrdenesServicio";
            this.Load += new System.EventHandler(this.OrdenesServicio_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOS)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvOS;
        private System.Windows.Forms.Button btnNueva;
        private System.Windows.Forms.DataGridViewTextBoxColumn idOrdenServicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn legajoEmpleado;
        private System.Windows.Forms.DataGridViewTextBoxColumn montoSeña;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaIngreso;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaEstimadaEntrega;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaRealEntrega;
        private System.Windows.Forms.DataGridViewTextBoxColumn costoTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn idPC;
        private System.Windows.Forms.Button btnEntregar;
    }
}