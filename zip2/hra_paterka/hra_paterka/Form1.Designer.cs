namespace hra_paterka
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
            this.timer_pro_cil = new System.Windows.Forms.Timer(this.components);
            this.timer_pro_kulku = new System.Windows.Forms.Timer(this.components);
            this.hrac = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cile = new System.Windows.Forms.PictureBox();
            this.kulka = new System.Windows.Forms.PictureBox();
            this.skore = new System.Windows.Forms.Label();
            this.pokus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.hrac)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kulka)).BeginInit();
            this.SuspendLayout();
            // 
            // timer_pro_cil
            // 
            this.timer_pro_cil.Enabled = true;
            this.timer_pro_cil.Interval = 35;
            this.timer_pro_cil.Tick += new System.EventHandler(this.timer_pro_cil_Tick);
            // 
            // timer_pro_kulku
            // 
            this.timer_pro_kulku.Enabled = true;
            this.timer_pro_kulku.Interval = 5;
            this.timer_pro_kulku.Tick += new System.EventHandler(this.timer_pro_kulku_Tick);
            // 
            // hrac
            // 
            this.hrac.BackColor = System.Drawing.Color.Black;
            this.hrac.Cursor = System.Windows.Forms.Cursors.Default;
            this.hrac.Location = new System.Drawing.Point(12, 58);
            this.hrac.Name = "hrac";
            this.hrac.Size = new System.Drawing.Size(32, 92);
            this.hrac.TabIndex = 0;
            this.hrac.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(57, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "počet pokusů";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(241, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "skóre";
            // 
            // cile
            // 
            this.cile.BackColor = System.Drawing.Color.Red;
            this.cile.Cursor = System.Windows.Forms.Cursors.Default;
            this.cile.Location = new System.Drawing.Point(785, 140);
            this.cile.Name = "cile";
            this.cile.Size = new System.Drawing.Size(40, 60);
            this.cile.TabIndex = 5;
            this.cile.TabStop = false;
            // 
            // kulka
            // 
            this.kulka.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.kulka.BackColor = System.Drawing.Color.Black;
            this.kulka.Cursor = System.Windows.Forms.Cursors.Default;
            this.kulka.Location = new System.Drawing.Point(50, 97);
            this.kulka.Name = "kulka";
            this.kulka.Size = new System.Drawing.Size(15, 15);
            this.kulka.TabIndex = 6;
            this.kulka.TabStop = false;
            // 
            // skore
            // 
            this.skore.AutoSize = true;
            this.skore.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.skore.Location = new System.Drawing.Point(156, 15);
            this.skore.Name = "skore";
            this.skore.Size = new System.Drawing.Size(16, 17);
            this.skore.TabIndex = 7;
            this.skore.Text = "0";
            // 
            // pokus
            // 
            this.pokus.AutoSize = true;
            this.pokus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.pokus.Location = new System.Drawing.Point(290, 15);
            this.pokus.Name = "pokus";
            this.pokus.Size = new System.Drawing.Size(16, 17);
            this.pokus.TabIndex = 8;
            this.pokus.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 632);
            this.Controls.Add(this.pokus);
            this.Controls.Add(this.skore);
            this.Controls.Add(this.kulka);
            this.Controls.Add(this.cile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.hrac);
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.hrac)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kulka)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer_pro_cil;
        private System.Windows.Forms.PictureBox hrac;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox cile;
        private System.Windows.Forms.PictureBox kulka;
        private System.Windows.Forms.Label skore;
        private System.Windows.Forms.Label pokus;
        public System.Windows.Forms.Timer timer_pro_kulku;
    }
}

