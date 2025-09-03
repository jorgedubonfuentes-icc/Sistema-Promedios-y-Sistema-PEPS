namespace proyecto_inventario
{
    partial class frmpeps
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmpeps));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpFechaPEPS = new System.Windows.Forms.DateTimePicker();
            this.cmbTipoPEPS = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCantidadPEPS = new System.Windows.Forms.TextBox();
            this.txtValorUnitarioPEPS = new System.Windows.Forms.TextBox();
            this.btnAgregarPEPS = new System.Windows.Forms.Button();
            this.btnEliminarPEPS = new System.Windows.Forms.Button();
            this.btnsalirPEPS = new System.Windows.Forms.Button();
            this.dgvmovimientoPEPS = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvmovimientoPEPS)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(633, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 69);
            this.label1.TabIndex = 0;
            this.label1.Text = "PEPS";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(96, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "Fecha";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(96, 173);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 22);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tipo";
            // 
            // dtpFechaPEPS
            // 
            this.dtpFechaPEPS.Location = new System.Drawing.Point(176, 130);
            this.dtpFechaPEPS.Name = "dtpFechaPEPS";
            this.dtpFechaPEPS.Size = new System.Drawing.Size(262, 22);
            this.dtpFechaPEPS.TabIndex = 3;
            // 
            // cmbTipoPEPS
            // 
            this.cmbTipoPEPS.FormattingEnabled = true;
            this.cmbTipoPEPS.Location = new System.Drawing.Point(176, 173);
            this.cmbTipoPEPS.Name = "cmbTipoPEPS";
            this.cmbTipoPEPS.Size = new System.Drawing.Size(262, 24);
            this.cmbTipoPEPS.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(479, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 22);
            this.label4.TabIndex = 5;
            this.label4.Text = "Cantidad";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(479, 170);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 22);
            this.label5.TabIndex = 6;
            this.label5.Text = "Valor Unitario";
            // 
            // txtCantidadPEPS
            // 
            this.txtCantidadPEPS.Location = new System.Drawing.Point(586, 125);
            this.txtCantidadPEPS.Name = "txtCantidadPEPS";
            this.txtCantidadPEPS.Size = new System.Drawing.Size(218, 22);
            this.txtCantidadPEPS.TabIndex = 7;
            // 
            // txtValorUnitarioPEPS
            // 
            this.txtValorUnitarioPEPS.Location = new System.Drawing.Point(648, 170);
            this.txtValorUnitarioPEPS.Name = "txtValorUnitarioPEPS";
            this.txtValorUnitarioPEPS.Size = new System.Drawing.Size(186, 22);
            this.txtValorUnitarioPEPS.TabIndex = 8;
            // 
            // btnAgregarPEPS
            // 
            this.btnAgregarPEPS.Location = new System.Drawing.Point(99, 244);
            this.btnAgregarPEPS.Name = "btnAgregarPEPS";
            this.btnAgregarPEPS.Size = new System.Drawing.Size(113, 36);
            this.btnAgregarPEPS.TabIndex = 9;
            this.btnAgregarPEPS.Text = "Agregar";
            this.btnAgregarPEPS.UseVisualStyleBackColor = true;
            this.btnAgregarPEPS.Click += new System.EventHandler(this.btnAgregarPEPS_Click);
            // 
            // btnEliminarPEPS
            // 
            this.btnEliminarPEPS.Location = new System.Drawing.Point(226, 244);
            this.btnEliminarPEPS.Name = "btnEliminarPEPS";
            this.btnEliminarPEPS.Size = new System.Drawing.Size(113, 36);
            this.btnEliminarPEPS.TabIndex = 10;
            this.btnEliminarPEPS.Text = "Eliminar";
            this.btnEliminarPEPS.UseVisualStyleBackColor = true;
            this.btnEliminarPEPS.Click += new System.EventHandler(this.btnEliminarPEPS_Click);
            // 
            // btnsalirPEPS
            // 
            this.btnsalirPEPS.Location = new System.Drawing.Point(356, 244);
            this.btnsalirPEPS.Name = "btnsalirPEPS";
            this.btnsalirPEPS.Size = new System.Drawing.Size(113, 36);
            this.btnsalirPEPS.TabIndex = 11;
            this.btnsalirPEPS.Text = "Salir";
            this.btnsalirPEPS.UseVisualStyleBackColor = true;
            this.btnsalirPEPS.Click += new System.EventHandler(this.btnsalirPEPS_Click);
            // 
            // dgvmovimientoPEPS
            // 
            this.dgvmovimientoPEPS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvmovimientoPEPS.Location = new System.Drawing.Point(49, 286);
            this.dgvmovimientoPEPS.Name = "dgvmovimientoPEPS";
            this.dgvmovimientoPEPS.RowHeadersWidth = 51;
            this.dgvmovimientoPEPS.RowTemplate.Height = 24;
            this.dgvmovimientoPEPS.Size = new System.Drawing.Size(1437, 244);
            this.dgvmovimientoPEPS.TabIndex = 12;
            // 
            // frmpeps
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1663, 574);
            this.Controls.Add(this.dgvmovimientoPEPS);
            this.Controls.Add(this.btnsalirPEPS);
            this.Controls.Add(this.btnEliminarPEPS);
            this.Controls.Add(this.btnAgregarPEPS);
            this.Controls.Add(this.txtValorUnitarioPEPS);
            this.Controls.Add(this.txtCantidadPEPS);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbTipoPEPS);
            this.Controls.Add(this.dtpFechaPEPS);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmpeps";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PEPS";
            this.Load += new System.EventHandler(this.frmpeps_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvmovimientoPEPS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpFechaPEPS;
        private System.Windows.Forms.ComboBox cmbTipoPEPS;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCantidadPEPS;
        private System.Windows.Forms.TextBox txtValorUnitarioPEPS;
        private System.Windows.Forms.Button btnAgregarPEPS;
        private System.Windows.Forms.Button btnEliminarPEPS;
        private System.Windows.Forms.Button btnsalirPEPS;
        private System.Windows.Forms.DataGridView dgvmovimientoPEPS;
    }
}