
namespace Pokladna
{
    partial class HistorieNakupu
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
            this.lblPokladniSystem = new System.Windows.Forms.Label();
            this.CisloNakupu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nazev = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PocetPolozek = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CenaZaKus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.datagridPrehledNakupu)).BeginInit();
            this.SuspendLayout();
            // 
            // datagridPrehledNakupu
            // 
            this.datagridPrehledNakupu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridPrehledNakupu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CisloNakupu,
            this.Nazev,
            this.PocetPolozek,
            this.CenaZaKus});
            this.datagridPrehledNakupu.Location = new System.Drawing.Point(15, 74);
            this.datagridPrehledNakupu.Margin = new System.Windows.Forms.Padding(6);
            this.datagridPrehledNakupu.Name = "datagridPrehledNakupu";
            this.datagridPrehledNakupu.RowHeadersWidth = 82;
            this.datagridPrehledNakupu.Size = new System.Drawing.Size(1144, 1019);
            this.datagridPrehledNakupu.TabIndex = 26;
            // 
            // lblPokladniSystem
            // 
            this.lblPokladniSystem.AutoSize = true;
            this.lblPokladniSystem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPokladniSystem.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblPokladniSystem.Location = new System.Drawing.Point(15, 19);
            this.lblPokladniSystem.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblPokladniSystem.Name = "lblPokladniSystem";
            this.lblPokladniSystem.Size = new System.Drawing.Size(301, 46);
            this.lblPokladniSystem.TabIndex = 23;
            this.lblPokladniSystem.Text = "Historie nákupů";
            // 
            // CisloNakupu
            // 
            this.CisloNakupu.HeaderText = "Číslo nákupu";
            this.CisloNakupu.MinimumWidth = 10;
            this.CisloNakupu.Name = "CisloNakupu";
            this.CisloNakupu.ReadOnly = true;
            this.CisloNakupu.Width = 200;
            // 
            // Nazev
            // 
            this.Nazev.HeaderText = "Název produktu";
            this.Nazev.MinimumWidth = 10;
            this.Nazev.Name = "Nazev";
            this.Nazev.ReadOnly = true;
            this.Nazev.Width = 200;
            // 
            // PocetPolozek
            // 
            this.PocetPolozek.HeaderText = "Počet položek";
            this.PocetPolozek.MinimumWidth = 10;
            this.PocetPolozek.Name = "PocetPolozek";
            this.PocetPolozek.ReadOnly = true;
            this.PocetPolozek.Width = 200;
            // 
            // CenaZaKus
            // 
            this.CenaZaKus.HeaderText = "Cena za kus";
            this.CenaZaKus.MinimumWidth = 10;
            this.CenaZaKus.Name = "CenaZaKus";
            this.CenaZaKus.ReadOnly = true;
            this.CenaZaKus.Width = 200;
            // 
            // HistorieNakupu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1178, 1109);
            this.Controls.Add(this.datagridPrehledNakupu);
            this.Controls.Add(this.lblPokladniSystem);
            this.Name = "HistorieNakupu";
            this.Text = "Historie nákupů";
            this.Load += new System.EventHandler(this.HistorieNakupu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.datagridPrehledNakupu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView datagridPrehledNakupu;
        private System.Windows.Forms.Label lblPokladniSystem;
        private System.Windows.Forms.DataGridViewTextBoxColumn CisloNakupu;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nazev;
        private System.Windows.Forms.DataGridViewTextBoxColumn PocetPolozek;
        private System.Windows.Forms.DataGridViewTextBoxColumn CenaZaKus;
    }
}