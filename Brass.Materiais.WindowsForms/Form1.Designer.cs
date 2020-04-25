namespace Brass.Materiais.WindowsForms
{
    partial class FormMateriais
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
            this.tabCtrlMateriais = new System.Windows.Forms.TabControl();
            this.tabPageItensEng = new System.Windows.Forms.TabPage();
            this.dataGridItensEng = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnCarregarTabela = new System.Windows.Forms.Button();
            this.tabCtrlMateriais.SuspendLayout();
            this.tabPageItensEng.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridItensEng)).BeginInit();
            this.SuspendLayout();
            // 
            // tabCtrlMateriais
            // 
            this.tabCtrlMateriais.Controls.Add(this.tabPageItensEng);
            this.tabCtrlMateriais.Controls.Add(this.tabPage2);
            this.tabCtrlMateriais.Location = new System.Drawing.Point(12, 12);
            this.tabCtrlMateriais.Name = "tabCtrlMateriais";
            this.tabCtrlMateriais.SelectedIndex = 0;
            this.tabCtrlMateriais.Size = new System.Drawing.Size(1027, 426);
            this.tabCtrlMateriais.TabIndex = 0;
            // 
            // tabPageItensEng
            // 
            this.tabPageItensEng.Controls.Add(this.dataGridItensEng);
            this.tabPageItensEng.Location = new System.Drawing.Point(4, 22);
            this.tabPageItensEng.Name = "tabPageItensEng";
            this.tabPageItensEng.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageItensEng.Size = new System.Drawing.Size(1019, 400);
            this.tabPageItensEng.TabIndex = 0;
            this.tabPageItensEng.Text = "Itens Engenharia";
            this.tabPageItensEng.UseVisualStyleBackColor = true;
            // 
            // dataGridItensEng
            // 
            this.dataGridItensEng.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridItensEng.Location = new System.Drawing.Point(6, 6);
            this.dataGridItensEng.Name = "dataGridItensEng";
            this.dataGridItensEng.Size = new System.Drawing.Size(1017, 432);
            this.dataGridItensEng.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1019, 400);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnCarregarTabela
            // 
            this.btnCarregarTabela.Location = new System.Drawing.Point(19, 438);
            this.btnCarregarTabela.Name = "btnCarregarTabela";
            this.btnCarregarTabela.Size = new System.Drawing.Size(75, 23);
            this.btnCarregarTabela.TabIndex = 1;
            this.btnCarregarTabela.Text = "Carregar";
            this.btnCarregarTabela.UseVisualStyleBackColor = true;
            this.btnCarregarTabela.Click += new System.EventHandler(this.btnCarregarTabela_Click);
            // 
            // FormMateriais
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1051, 493);
            this.Controls.Add(this.btnCarregarTabela);
            this.Controls.Add(this.tabCtrlMateriais);
            this.Name = "FormMateriais";
            this.Text = "MATERIAIS BRASS";
            this.tabCtrlMateriais.ResumeLayout(false);
            this.tabPageItensEng.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridItensEng)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabCtrlMateriais;
        private System.Windows.Forms.TabPage tabPageItensEng;
        private System.Windows.Forms.DataGridView dataGridItensEng;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnCarregarTabela;
    }
}

