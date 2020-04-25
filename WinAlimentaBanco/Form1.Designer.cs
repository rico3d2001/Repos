namespace WinAlimentaBanco
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.CmboxBanco = new System.Windows.Forms.ComboBox();
            this.btnInserirDados = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnPegaCatalogo = new System.Windows.Forms.Button();
            this.txtBoxCatalogo = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.cmboxIdioma = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.cmboxPais = new System.Windows.Forms.ComboBox();
            this.lblErros = new System.Windows.Forms.Label();
            this.resultLabel = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.btnParar = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnUpdateSQLite = new System.Windows.Forms.Button();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CmboxBanco
            // 
            this.CmboxBanco.FormattingEnabled = true;
            this.CmboxBanco.Items.AddRange(new object[] {
            "Local",
            "Azure"});
            this.CmboxBanco.Location = new System.Drawing.Point(40, 52);
            this.CmboxBanco.Name = "CmboxBanco";
            this.CmboxBanco.Size = new System.Drawing.Size(237, 21);
            this.CmboxBanco.TabIndex = 0;
            this.CmboxBanco.SelectedIndexChanged += new System.EventHandler(this.CmboxBanco_SelectedIndexChanged);
            // 
            // btnInserirDados
            // 
            this.btnInserirDados.Location = new System.Drawing.Point(40, 212);
            this.btnInserirDados.Name = "btnInserirDados";
            this.btnInserirDados.Size = new System.Drawing.Size(202, 23);
            this.btnInserirDados.TabIndex = 1;
            this.btnInserirDados.Text = "INSERIR";
            this.btnInserirDados.UseVisualStyleBackColor = true;
            this.btnInserirDados.Click += new System.EventHandler(this.btnInserirDados_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Banco";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Catalogo Plant3d";
            // 
            // btnPegaCatalogo
            // 
            this.btnPegaCatalogo.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnPegaCatalogo.Location = new System.Drawing.Point(21, 28);
            this.btnPegaCatalogo.Name = "btnPegaCatalogo";
            this.btnPegaCatalogo.Size = new System.Drawing.Size(164, 23);
            this.btnPegaCatalogo.TabIndex = 5;
            this.btnPegaCatalogo.Text = "CATÁLOGO";
            this.btnPegaCatalogo.UseVisualStyleBackColor = false;
            this.btnPegaCatalogo.Click += new System.EventHandler(this.btnPegaCatalogo_Click);
            // 
            // txtBoxCatalogo
            // 
            this.txtBoxCatalogo.Location = new System.Drawing.Point(189, 30);
            this.txtBoxCatalogo.Name = "txtBoxCatalogo";
            this.txtBoxCatalogo.Size = new System.Drawing.Size(531, 20);
            this.txtBoxCatalogo.TabIndex = 6;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // cmboxIdioma
            // 
            this.cmboxIdioma.FormattingEnabled = true;
            this.cmboxIdioma.Items.AddRange(new object[] {
            "Inglês",
            "Espanhol",
            "Português"});
            this.cmboxIdioma.Location = new System.Drawing.Point(21, 73);
            this.cmboxIdioma.Name = "cmboxIdioma";
            this.cmboxIdioma.Size = new System.Drawing.Size(162, 21);
            this.cmboxIdioma.TabIndex = 7;
            this.cmboxIdioma.SelectedIndexChanged += new System.EventHandler(this.cmboxIdioma_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Idioma";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cmboxPais);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cmboxIdioma);
            this.panel1.Controls.Add(this.btnPegaCatalogo);
            this.panel1.Controls.Add(this.txtBoxCatalogo);
            this.panel1.Location = new System.Drawing.Point(40, 91);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(735, 115);
            this.panel1.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(186, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "País";
            // 
            // cmboxPais
            // 
            this.cmboxPais.FormattingEnabled = true;
            this.cmboxPais.Items.AddRange(new object[] {
            "Brasil",
            "Chile",
            "USA"});
            this.cmboxPais.Location = new System.Drawing.Point(189, 73);
            this.cmboxPais.Name = "cmboxPais";
            this.cmboxPais.Size = new System.Drawing.Size(121, 21);
            this.cmboxPais.TabIndex = 9;
            this.cmboxPais.SelectedIndexChanged += new System.EventHandler(this.cmboxPais_SelectedIndexChanged);
            // 
            // lblErros
            // 
            this.lblErros.AutoSize = true;
            this.lblErros.Location = new System.Drawing.Point(40, 259);
            this.lblErros.Name = "lblErros";
            this.lblErros.Size = new System.Drawing.Size(0, 13);
            this.lblErros.TabIndex = 10;
            // 
            // resultLabel
            // 
            this.resultLabel.AutoSize = true;
            this.resultLabel.Location = new System.Drawing.Point(40, 259);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(13, 13);
            this.resultLabel.TabIndex = 12;
            this.resultLabel.Text = "0";
            // 
            // btnParar
            // 
            this.btnParar.Location = new System.Drawing.Point(248, 212);
            this.btnParar.Name = "btnParar";
            this.btnParar.Size = new System.Drawing.Size(202, 23);
            this.btnParar.TabIndex = 13;
            this.btnParar.Text = "PARAR";
            this.btnParar.UseVisualStyleBackColor = true;
            this.btnParar.Click += new System.EventHandler(this.btnParar_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(40, 276);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(735, 23);
            this.progressBar1.TabIndex = 14;
            // 
            // btnUpdateSQLite
            // 
            this.btnUpdateSQLite.Location = new System.Drawing.Point(467, 212);
            this.btnUpdateSQLite.Name = "btnUpdateSQLite";
            this.btnUpdateSQLite.Size = new System.Drawing.Size(182, 23);
            this.btnUpdateSQLite.TabIndex = 15;
            this.btnUpdateSQLite.Text = "Sincronizar Catálogo";
            this.btnUpdateSQLite.UseVisualStyleBackColor = true;
            this.btnUpdateSQLite.Click += new System.EventHandler(this.btnUpdateSQLite_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 394);
            this.Controls.Add(this.btnUpdateSQLite);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnParar);
            this.Controls.Add(this.resultLabel);
            this.Controls.Add(this.lblErros);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnInserirDados);
            this.Controls.Add(this.CmboxBanco);
            this.Name = "Form1";
            this.Text = "INSERÇÃO DE CATÁLOGOS DE TUBULAÇÃO NA BASE DE DADOS";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CmboxBanco;
        private System.Windows.Forms.Button btnInserirDados;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnPegaCatalogo;
        private System.Windows.Forms.TextBox txtBoxCatalogo;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ComboBox cmboxIdioma;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmboxPais;
        private System.Windows.Forms.Label lblErros;
        private System.Windows.Forms.Label resultLabel;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btnParar;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnUpdateSQLite;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
    }
}

