
namespace PristupovySystemRFID
{
    partial class Form1
    {
        /// <summary>
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód generovaný Návrhářem Windows Form

        /// <summary>
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelJmenoUzivatele = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.jmenoUzivatele = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prijmeniUzivatele = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vchod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pristup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSpravaSkupin = new System.Windows.Forms.Button();
            this.btnSpravaUzivatelu = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timerAktualizaceUI = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(6, 5);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(207, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "PŘÍSTUPOVÝ SYSTÉM";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(6, 38);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(165, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Oznámení o přístupu:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(14, 206);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Jméno uživatele:";
            // 
            // labelJmenoUzivatele
            // 
            this.labelJmenoUzivatele.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelJmenoUzivatele.Location = new System.Drawing.Point(12, 233);
            this.labelJmenoUzivatele.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelJmenoUzivatele.Name = "labelJmenoUzivatele";
            this.labelJmenoUzivatele.Size = new System.Drawing.Size(161, 87);
            this.labelJmenoUzivatele.TabIndex = 4;
            this.labelJmenoUzivatele.Text = "Po naskenování čipu se zde zobrazí jméno uživatele";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Segoe UI", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(264, 5);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(648, 39);
            this.label4.TabIndex = 7;
            this.label4.Text = "HISTORIE PŘÍSTUPŮ:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.jmenoUzivatele,
            this.prijmeniUzivatele,
            this.datum,
            this.cas,
            this.vchod,
            this.pristup});
            this.dataGridView1.Location = new System.Drawing.Point(268, 58);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 82;
            this.dataGridView1.RowTemplate.Height = 33;
            this.dataGridView1.Size = new System.Drawing.Size(643, 452);
            this.dataGridView1.TabIndex = 8;
            // 
            // jmenoUzivatele
            // 
            this.jmenoUzivatele.HeaderText = "Jméno";
            this.jmenoUzivatele.MinimumWidth = 10;
            this.jmenoUzivatele.Name = "jmenoUzivatele";
            this.jmenoUzivatele.ReadOnly = true;
            // 
            // prijmeniUzivatele
            // 
            this.prijmeniUzivatele.HeaderText = "Příjmení";
            this.prijmeniUzivatele.MinimumWidth = 10;
            this.prijmeniUzivatele.Name = "prijmeniUzivatele";
            this.prijmeniUzivatele.ReadOnly = true;
            // 
            // datum
            // 
            this.datum.HeaderText = "Datum";
            this.datum.MinimumWidth = 10;
            this.datum.Name = "datum";
            this.datum.ReadOnly = true;
            // 
            // cas
            // 
            this.cas.HeaderText = "Čas";
            this.cas.MinimumWidth = 10;
            this.cas.Name = "cas";
            this.cas.ReadOnly = true;
            // 
            // vchod
            // 
            this.vchod.HeaderText = "Vchod";
            this.vchod.MinimumWidth = 10;
            this.vchod.Name = "vchod";
            this.vchod.ReadOnly = true;
            // 
            // pristup
            // 
            this.pristup.HeaderText = "Přístup udělen";
            this.pristup.MinimumWidth = 10;
            this.pristup.Name = "pristup";
            this.pristup.ReadOnly = true;
            // 
            // btnSpravaSkupin
            // 
            this.btnSpravaSkupin.Location = new System.Drawing.Point(6, 532);
            this.btnSpravaSkupin.Margin = new System.Windows.Forms.Padding(2);
            this.btnSpravaSkupin.Name = "btnSpravaSkupin";
            this.btnSpravaSkupin.Size = new System.Drawing.Size(445, 44);
            this.btnSpravaSkupin.TabIndex = 9;
            this.btnSpravaSkupin.Text = "Správa skupin";
            this.btnSpravaSkupin.UseVisualStyleBackColor = true;
            this.btnSpravaSkupin.Click += new System.EventHandler(this.btnSpravaSkupin_Click);
            // 
            // btnSpravaUzivatelu
            // 
            this.btnSpravaUzivatelu.Location = new System.Drawing.Point(494, 532);
            this.btnSpravaUzivatelu.Margin = new System.Windows.Forms.Padding(2);
            this.btnSpravaUzivatelu.Name = "btnSpravaUzivatelu";
            this.btnSpravaUzivatelu.Size = new System.Drawing.Size(445, 44);
            this.btnSpravaUzivatelu.TabIndex = 10;
            this.btnSpravaUzivatelu.Text = "Správa uživatelů";
            this.btnSpravaUzivatelu.UseVisualStyleBackColor = true;
            this.btnSpravaUzivatelu.Click += new System.EventHandler(this.btnSpravaUzivatelu_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PristupovySystemRFID.Properties.Resources.PristupNeudelen;
            this.pictureBox1.Location = new System.Drawing.Point(35, 85);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 104);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // timerAktualizaceUI
            // 
            this.timerAktualizaceUI.Tick += new System.EventHandler(this.TimerAktualizaceUI_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1007, 615);
            this.Controls.Add(this.btnSpravaUzivatelu);
            this.Controls.Add(this.btnSpravaSkupin);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labelJmenoUzivatele);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Přístupový systém";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelJmenoUzivatele;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnSpravaSkupin;
        private System.Windows.Forms.Button btnSpravaUzivatelu;
        private System.Windows.Forms.DataGridViewTextBoxColumn jmenoUzivatele;
        private System.Windows.Forms.DataGridViewTextBoxColumn prijmeniUzivatele;
        private System.Windows.Forms.DataGridViewTextBoxColumn datum;
        private System.Windows.Forms.DataGridViewTextBoxColumn cas;
        private System.Windows.Forms.DataGridViewTextBoxColumn vchod;
        private System.Windows.Forms.DataGridViewTextBoxColumn pristup;
        private System.Windows.Forms.Timer timerAktualizaceUI;
    }
}

