namespace Pokladna
{
    partial class Form2
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
            this.datagridPrehledNakupu = new System.Windows.Forms.DataGridView();
            this.NazevProduktu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mnozstvi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CenaZaKus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CenaCelkove = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblCenaNakupu = new System.Windows.Forms.Label();
            this.lblCelkovaCena = new System.Windows.Forms.Label();
            this.lblPokladniSystem = new System.Windows.Forms.Label();
            this.btnZaplatit = new System.Windows.Forms.Button();
            this.btnStorno = new System.Windows.Forms.Button();
            this.btnVymazatPosledni = new System.Windows.Forms.Button();
            this.btnHistorieNakupu = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.datagridPrehledNakupu)).BeginInit();
            this.SuspendLayout();
            // 
            // datagridPrehledNakupu
            // 
            this.datagridPrehledNakupu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridPrehledNakupu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NazevProduktu,
            this.Mnozstvi,
            this.CenaZaKus,
            this.CenaCelkove});
            this.datagridPrehledNakupu.Location = new System.Drawing.Point(12, 34);
            this.datagridPrehledNakupu.Name = "datagridPrehledNakupu";
            this.datagridPrehledNakupu.RowHeadersWidth = 82;
            this.datagridPrehledNakupu.Size = new System.Drawing.Size(572, 530);
            this.datagridPrehledNakupu.TabIndex = 18;
            // 
            // NazevProduktu
            // 
            this.NazevProduktu.HeaderText = "Název produktu";
            this.NazevProduktu.MinimumWidth = 10;
            this.NazevProduktu.Name = "NazevProduktu";
            this.NazevProduktu.ReadOnly = true;
            this.NazevProduktu.Width = 200;
            // 
            // Mnozstvi
            // 
            this.Mnozstvi.HeaderText = "Množství";
            this.Mnozstvi.MinimumWidth = 10;
            this.Mnozstvi.Name = "Mnozstvi";
            this.Mnozstvi.ReadOnly = true;
            this.Mnozstvi.Width = 200;
            // 
            // CenaZaKus
            // 
            this.CenaZaKus.HeaderText = "Cena za kus";
            this.CenaZaKus.MinimumWidth = 10;
            this.CenaZaKus.Name = "CenaZaKus";
            this.CenaZaKus.ReadOnly = true;
            this.CenaZaKus.Width = 200;
            // 
            // CenaCelkove
            // 
            this.CenaCelkove.HeaderText = "Celková cena";
            this.CenaCelkove.MinimumWidth = 10;
            this.CenaCelkove.Name = "CenaCelkove";
            this.CenaCelkove.ReadOnly = true;
            this.CenaCelkove.Width = 200;
            // 
            // lblCenaNakupu
            // 
            this.lblCenaNakupu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblCenaNakupu.Location = new System.Drawing.Point(591, 34);
            this.lblCenaNakupu.Name = "lblCenaNakupu";
            this.lblCenaNakupu.Size = new System.Drawing.Size(216, 29);
            this.lblCenaNakupu.TabIndex = 17;
            this.lblCenaNakupu.Text = "0 Kč";
            this.lblCenaNakupu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCelkovaCena
            // 
            this.lblCelkovaCena.AutoSize = true;
            this.lblCelkovaCena.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblCelkovaCena.Location = new System.Drawing.Point(590, 5);
            this.lblCelkovaCena.Name = "lblCelkovaCena";
            this.lblCelkovaCena.Size = new System.Drawing.Size(217, 24);
            this.lblCelkovaCena.TabIndex = 16;
            this.lblCelkovaCena.Text = "Celková cena nákupu:";
            // 
            // lblPokladniSystem
            // 
            this.lblPokladniSystem.AutoSize = true;
            this.lblPokladniSystem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPokladniSystem.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblPokladniSystem.Location = new System.Drawing.Point(12, 5);
            this.lblPokladniSystem.Name = "lblPokladniSystem";
            this.lblPokladniSystem.Size = new System.Drawing.Size(162, 26);
            this.lblPokladniSystem.TabIndex = 15;
            this.lblPokladniSystem.Text = "Pokladní systém";
            // 
            // btnZaplatit
            // 
            this.btnZaplatit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnZaplatit.Location = new System.Drawing.Point(590, 541);
            this.btnZaplatit.Name = "btnZaplatit";
            this.btnZaplatit.Size = new System.Drawing.Size(273, 23);
            this.btnZaplatit.TabIndex = 14;
            this.btnZaplatit.Text = "Přejít k zaplacení [PgUp]";
            this.btnZaplatit.UseVisualStyleBackColor = true;
            this.btnZaplatit.Click += new System.EventHandler(this.btnZaplatit_Click);
            // 
            // btnStorno
            // 
            this.btnStorno.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnStorno.Location = new System.Drawing.Point(590, 483);
            this.btnStorno.Name = "btnStorno";
            this.btnStorno.Size = new System.Drawing.Size(273, 23);
            this.btnStorno.TabIndex = 20;
            this.btnStorno.Text = "STORNO nákupu [PgDn]";
            this.btnStorno.UseVisualStyleBackColor = true;
            this.btnStorno.Click += new System.EventHandler(this.btnStorno_Click);
            // 
            // btnVymazatPosledni
            // 
            this.btnVymazatPosledni.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnVymazatPosledni.Location = new System.Drawing.Point(590, 512);
            this.btnVymazatPosledni.Name = "btnVymazatPosledni";
            this.btnVymazatPosledni.Size = new System.Drawing.Size(273, 23);
            this.btnVymazatPosledni.TabIndex = 21;
            this.btnVymazatPosledni.Text = "Vymazat poslední záznam [Home]";
            this.btnVymazatPosledni.UseVisualStyleBackColor = true;
            this.btnVymazatPosledni.Click += new System.EventHandler(this.btnVymazatPosledni_Click);
            // 
            // btnHistorieNakupu
            // 
            this.btnHistorieNakupu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnHistorieNakupu.Location = new System.Drawing.Point(592, 454);
            this.btnHistorieNakupu.Name = "btnHistorieNakupu";
            this.btnHistorieNakupu.Size = new System.Drawing.Size(271, 23);
            this.btnHistorieNakupu.TabIndex = 22;
            this.btnHistorieNakupu.Text = "Historie nákupů [End]";
            this.btnHistorieNakupu.UseVisualStyleBackColor = true;
            this.btnHistorieNakupu.Click += new System.EventHandler(this.btnHistorieNakupu_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(590, 261);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(273, 190);
            this.label1.TabIndex = 23;
            this.label1.Text = "Pro vyvolání dané funkce stiskněte tlačítko, které je v hranaté závorce. U numeri" +
    "cké klávesnice je potřeba vypnout NumLock, aby byly tyto klávesy aktivovány  a b" +
    "yly správně registrovány.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 583);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnHistorieNakupu);
            this.Controls.Add(this.btnVymazatPosledni);
            this.Controls.Add(this.btnStorno);
            this.Controls.Add(this.datagridPrehledNakupu);
            this.Controls.Add(this.lblCenaNakupu);
            this.Controls.Add(this.lblCelkovaCena);
            this.Controls.Add(this.lblPokladniSystem);
            this.Controls.Add(this.btnZaplatit);
            this.Name = "Form2";
            this.Text = "Pokladní systém";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            this.Load += new System.EventHandler(this.Form2_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form2_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.datagridPrehledNakupu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView datagridPrehledNakupu;
        private System.Windows.Forms.Label lblCenaNakupu;
        private System.Windows.Forms.Label lblCelkovaCena;
        private System.Windows.Forms.Label lblPokladniSystem;
        private System.Windows.Forms.Button btnZaplatit;
        private System.Windows.Forms.DataGridViewTextBoxColumn NazevProduktu;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mnozstvi;
        private System.Windows.Forms.DataGridViewTextBoxColumn CenaZaKus;
        private System.Windows.Forms.DataGridViewTextBoxColumn CenaCelkove;
        private System.Windows.Forms.Button btnStorno;
        private System.Windows.Forms.Button btnVymazatPosledni;
        private System.Windows.Forms.Button btnHistorieNakupu;
        private System.Windows.Forms.Label label1;
    }
}