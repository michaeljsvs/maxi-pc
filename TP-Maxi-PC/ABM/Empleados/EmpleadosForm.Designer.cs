namespace TP_Maxi_PC.ABM.Empleados
{
    partial class EmpleadosForm
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
            this.DgvEmpleados = new System.Windows.Forms.DataGridView();
            this.legajo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nroDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.apellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idTipoEmpleado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaAlta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaBaja = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.BtnNuevo = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.cmbTipoDoc = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNroDocumento = new System.Windows.Forms.TextBox();
            this.txtLegajo = new System.Windows.Forms.TextBox();
            this.cmbTipoEmp = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.DtpFechaBaja = new System.Windows.Forms.DateTimePicker();
            this.DtpFechaAlta = new System.Windows.Forms.DateTimePicker();
            this.btnCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DgvEmpleados)).BeginInit();
            this.SuspendLayout();
            // 
            // DgvEmpleados
            // 
            this.DgvEmpleados.AllowUserToAddRows = false;
            this.DgvEmpleados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvEmpleados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.legajo,
            this.tipoDocumento,
            this.nroDocumento,
            this.apellido,
            this.nombre,
            this.idTipoEmpleado,
            this.fechaAlta,
            this.fechaBaja});
            this.DgvEmpleados.Location = new System.Drawing.Point(9, 155);
            this.DgvEmpleados.Name = "DgvEmpleados";
            this.DgvEmpleados.Size = new System.Drawing.Size(836, 234);
            this.DgvEmpleados.TabIndex = 4;
            // 
            // legajo
            // 
            this.legajo.HeaderText = "Legajo";
            this.legajo.Name = "legajo";
            // 
            // tipoDocumento
            // 
            this.tipoDocumento.HeaderText = "Tipo Documento";
            this.tipoDocumento.Name = "tipoDocumento";
            // 
            // nroDocumento
            // 
            this.nroDocumento.HeaderText = "Nro Documento";
            this.nroDocumento.Name = "nroDocumento";
            // 
            // apellido
            // 
            this.apellido.HeaderText = "Apellido";
            this.apellido.Name = "apellido";
            // 
            // nombre
            // 
            this.nombre.HeaderText = "Nombre";
            this.nombre.Name = "nombre";
            // 
            // idTipoEmpleado
            // 
            this.idTipoEmpleado.HeaderText = "Id Tipo Empleado";
            this.idTipoEmpleado.Name = "idTipoEmpleado";
            // 
            // fechaAlta
            // 
            this.fechaAlta.HeaderText = "Fecha Alta";
            this.fechaAlta.Name = "fechaAlta";
            // 
            // fechaBaja
            // 
            this.fechaBaja.HeaderText = "Fecha Baja";
            this.fechaBaja.Name = "fechaBaja";
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(749, 126);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(75, 23);
            this.btnActualizar.TabIndex = 0;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(689, 406);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(75, 23);
            this.btnModificar.TabIndex = 2;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // BtnNuevo
            // 
            this.BtnNuevo.Location = new System.Drawing.Point(649, 126);
            this.BtnNuevo.Name = "BtnNuevo";
            this.BtnNuevo.Size = new System.Drawing.Size(75, 23);
            this.BtnNuevo.TabIndex = 1;
            this.BtnNuevo.Text = "Cargar";
            this.BtnNuevo.UseVisualStyleBackColor = true;
            this.BtnNuevo.Click += new System.EventHandler(this.BtnNuevo_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(608, 406);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 3;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // cmbTipoDoc
            // 
            this.cmbTipoDoc.FormattingEnabled = true;
            this.cmbTipoDoc.Location = new System.Drawing.Point(109, 52);
            this.cmbTipoDoc.Name = "cmbTipoDoc";
            this.cmbTipoDoc.Size = new System.Drawing.Size(200, 21);
            this.cmbTipoDoc.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Nro Documento";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Tipo Documento";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Legajo";
            // 
            // txtNroDocumento
            // 
            this.txtNroDocumento.Location = new System.Drawing.Point(109, 93);
            this.txtNroDocumento.Name = "txtNroDocumento";
            this.txtNroDocumento.Size = new System.Drawing.Size(200, 20);
            this.txtNroDocumento.TabIndex = 17;
            // 
            // txtLegajo
            // 
            this.txtLegajo.Location = new System.Drawing.Point(109, 9);
            this.txtLegajo.Name = "txtLegajo";
            this.txtLegajo.Size = new System.Drawing.Size(200, 20);
            this.txtLegajo.TabIndex = 15;
            // 
            // cmbTipoEmp
            // 
            this.cmbTipoEmp.FormattingEnabled = true;
            this.cmbTipoEmp.Location = new System.Drawing.Point(425, 93);
            this.cmbTipoEmp.Name = "cmbTipoEmp";
            this.cmbTipoEmp.Size = new System.Drawing.Size(200, 21);
            this.cmbTipoEmp.TabIndex = 23;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(330, 96);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 13);
            this.label6.TabIndex = 25;
            this.label6.Text = "Id Tipo empleado";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(330, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 26;
            this.label5.Text = "Nombre";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(328, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "Apellido";
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(425, 9);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(200, 20);
            this.txtApellido.TabIndex = 21;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(425, 52);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(200, 20);
            this.txtNombre.TabIndex = 22;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(328, 134);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 13);
            this.label8.TabIndex = 30;
            this.label8.Text = "Fecha Baja";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 135);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 13);
            this.label7.TabIndex = 29;
            this.label7.Text = "Fecha Alta";
            // 
            // DtpFechaBaja
            // 
            this.DtpFechaBaja.Location = new System.Drawing.Point(425, 128);
            this.DtpFechaBaja.Name = "DtpFechaBaja";
            this.DtpFechaBaja.Size = new System.Drawing.Size(200, 20);
            this.DtpFechaBaja.TabIndex = 28;
            // 
            // DtpFechaAlta
            // 
            this.DtpFechaAlta.Location = new System.Drawing.Point(109, 129);
            this.DtpFechaAlta.Name = "DtpFechaAlta";
            this.DtpFechaAlta.Size = new System.Drawing.Size(200, 20);
            this.DtpFechaAlta.TabIndex = 27;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(770, 406);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 31;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click_1);
            // 
            // EmpleadosForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 441);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.DtpFechaBaja);
            this.Controls.Add(this.DtpFechaAlta);
            this.Controls.Add(this.cmbTipoEmp);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtApellido);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.cmbTipoDoc);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNroDocumento);
            this.Controls.Add(this.txtLegajo);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.BtnNuevo);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.DgvEmpleados);
            this.Name = "EmpleadosForm";
            this.Text = "EmpleadosForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EmpleadosForm_FormClosing);
            this.Load += new System.EventHandler(this.EmpleadosForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvEmpleados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DgvEmpleados;
        private System.Windows.Forms.DataGridViewTextBoxColumn legajo;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn nroDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn apellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn idTipoEmpleado;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaAlta;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaBaja;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button BtnNuevo;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.ComboBox cmbTipoDoc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNroDocumento;
        private System.Windows.Forms.TextBox txtLegajo;
        private System.Windows.Forms.ComboBox cmbTipoEmp;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker DtpFechaBaja;
        private System.Windows.Forms.DateTimePicker DtpFechaAlta;
        private System.Windows.Forms.Button btnCancelar;
    }
}