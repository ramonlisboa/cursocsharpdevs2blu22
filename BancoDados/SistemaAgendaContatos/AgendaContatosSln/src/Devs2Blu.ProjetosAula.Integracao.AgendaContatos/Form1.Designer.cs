
namespace Devs2Blu.ProjetosAula.Integracao.AgendaContatos
{
    partial class Form1
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboEstados = new System.Windows.Forms.ComboBox();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdInativo = new System.Windows.Forms.RadioButton();
            this.rdAtivo = new System.Windows.Forms.RadioButton();
            this.gridContatos = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridContatos)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.btnSalvar);
            this.groupBox1.Controls.Add(this.cboEstados);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtNome);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(16, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(757, 92);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cadastro Contatos";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(57, 17);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(166, 20);
            this.txtNome.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "UF";
            // 
            // cboEstados
            // 
            this.cboEstados.FormattingEnabled = true;
            this.cboEstados.Location = new System.Drawing.Point(57, 40);
            this.cboEstados.Name = "cboEstados";
            this.cboEstados.Size = new System.Drawing.Size(88, 21);
            this.cboEstados.TabIndex = 3;
            // 
            // btnSalvar
            // 
            this.btnSalvar.AutoEllipsis = true;
            this.btnSalvar.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnSalvar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvar.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSalvar.Location = new System.Drawing.Point(654, 58);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(97, 28);
            this.btnSalvar.TabIndex = 4;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = false;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox2.Controls.Add(this.rdAtivo);
            this.groupBox2.Controls.Add(this.rdInativo);
            this.groupBox2.Location = new System.Drawing.Point(597, 9);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(154, 44);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Status";
            // 
            // rdInativo
            // 
            this.rdInativo.AutoSize = true;
            this.rdInativo.BackColor = System.Drawing.Color.Red;
            this.rdInativo.ForeColor = System.Drawing.SystemColors.Control;
            this.rdInativo.Location = new System.Drawing.Point(6, 19);
            this.rdInativo.Name = "rdInativo";
            this.rdInativo.Size = new System.Drawing.Size(57, 17);
            this.rdInativo.TabIndex = 0;
            this.rdInativo.TabStop = true;
            this.rdInativo.Text = "Inativo";
            this.rdInativo.UseVisualStyleBackColor = false;
            // 
            // rdAtivo
            // 
            this.rdAtivo.AutoSize = true;
            this.rdAtivo.BackColor = System.Drawing.Color.Green;
            this.rdAtivo.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.rdAtivo.Location = new System.Drawing.Point(99, 19);
            this.rdAtivo.Name = "rdAtivo";
            this.rdAtivo.Size = new System.Drawing.Size(49, 17);
            this.rdAtivo.TabIndex = 1;
            this.rdAtivo.TabStop = true;
            this.rdAtivo.Text = "Ativo";
            this.rdAtivo.UseVisualStyleBackColor = false;
            // 
            // gridContatos
            // 
            this.gridContatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridContatos.Location = new System.Drawing.Point(24, 120);
            this.gridContatos.Name = "gridContatos";
            this.gridContatos.Size = new System.Drawing.Size(749, 282);
            this.gridContatos.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.gridContatos);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Agenda de Contatos";
            this.Activated += new System.EventHandler(this.Form1_Activated);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridContatos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboEstados;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdAtivo;
        private System.Windows.Forms.RadioButton rdInativo;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.DataGridView gridContatos;
    }
}

