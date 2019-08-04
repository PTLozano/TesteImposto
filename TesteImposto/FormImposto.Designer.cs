namespace TesteImposto
{
    partial class FormImposto
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxNomeCliente = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridViewPedidos = new System.Windows.Forms.DataGridView();
            this.buttonGerarNotaFiscal = new System.Windows.Forms.Button();
            this.cmbEstadoOrigem = new System.Windows.Forms.ComboBox();
            this.cmbEstadoDestino = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPedidos)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome do Cliente";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 51);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Estado Origem";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 85);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Estado Destino";
            // 
            // textBoxNomeCliente
            // 
            this.textBoxNomeCliente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxNomeCliente.Location = new System.Drawing.Point(142, 14);
            this.textBoxNomeCliente.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxNomeCliente.MaxLength = 50;
            this.textBoxNomeCliente.Name = "textBoxNomeCliente";
            this.textBoxNomeCliente.Size = new System.Drawing.Size(837, 26);
            this.textBoxNomeCliente.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 143);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Itens do pedido";
            // 
            // dataGridViewPedidos
            // 
            this.dataGridViewPedidos.AllowUserToOrderColumns = true;
            this.dataGridViewPedidos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewPedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPedidos.Location = new System.Drawing.Point(9, 168);
            this.dataGridViewPedidos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridViewPedidos.Name = "dataGridViewPedidos";
            this.dataGridViewPedidos.RowHeadersWidth = 62;
            this.dataGridViewPedidos.Size = new System.Drawing.Size(1542, 500);
            this.dataGridViewPedidos.TabIndex = 3;
            this.dataGridViewPedidos.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.DataGridViewPedidos_CellValidating);
            // 
            // buttonGerarNotaFiscal
            // 
            this.buttonGerarNotaFiscal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonGerarNotaFiscal.Location = new System.Drawing.Point(1360, 677);
            this.buttonGerarNotaFiscal.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonGerarNotaFiscal.Name = "buttonGerarNotaFiscal";
            this.buttonGerarNotaFiscal.Size = new System.Drawing.Size(190, 35);
            this.buttonGerarNotaFiscal.TabIndex = 8;
            this.buttonGerarNotaFiscal.Text = "Gerar Nota Fiscal";
            this.buttonGerarNotaFiscal.UseVisualStyleBackColor = true;
            this.buttonGerarNotaFiscal.Click += new System.EventHandler(this.ButtonGerarNotaFiscal_Click);
            // 
            // cmbEstadoOrigem
            // 
            this.cmbEstadoOrigem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstadoOrigem.FormattingEnabled = true;
            this.cmbEstadoOrigem.Location = new System.Drawing.Point(142, 48);
            this.cmbEstadoOrigem.Name = "cmbEstadoOrigem";
            this.cmbEstadoOrigem.Size = new System.Drawing.Size(121, 28);
            this.cmbEstadoOrigem.TabIndex = 1;
            // 
            // cmbEstadoDestino
            // 
            this.cmbEstadoDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstadoDestino.FormattingEnabled = true;
            this.cmbEstadoDestino.Location = new System.Drawing.Point(142, 82);
            this.cmbEstadoDestino.Name = "cmbEstadoDestino";
            this.cmbEstadoDestino.Size = new System.Drawing.Size(121, 28);
            this.cmbEstadoDestino.TabIndex = 2;
            // 
            // FormImposto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1564, 734);
            this.Controls.Add(this.cmbEstadoDestino);
            this.Controls.Add(this.cmbEstadoOrigem);
            this.Controls.Add(this.buttonGerarNotaFiscal);
            this.Controls.Add(this.dataGridViewPedidos);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxNomeCliente);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormImposto";
            this.Text = "Calculo de imposto";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPedidos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonGerarNotaFiscal;
        protected internal System.Windows.Forms.TextBox textBoxNomeCliente;
        protected internal System.Windows.Forms.ComboBox cmbEstadoOrigem;
        protected internal System.Windows.Forms.ComboBox cmbEstadoDestino;
        protected internal System.Windows.Forms.DataGridView dataGridViewPedidos;
    }
}

