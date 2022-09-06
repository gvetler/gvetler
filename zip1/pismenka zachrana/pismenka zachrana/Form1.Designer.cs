namespace pismenka_zachrana
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
            this.breh1 = new System.Windows.Forms.PictureBox();
            this.breh2 = new System.Windows.Forms.PictureBox();
            this.voda = new System.Windows.Forms.PictureBox();
            this.lod = new System.Windows.Forms.PictureBox();
            this.timer_pro_pismenka = new System.Windows.Forms.Timer(this.components);
            this.timer_kolize = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pohyb_pismena = new System.Windows.Forms.Timer(this.components);
            this.konec = new System.Windows.Forms.PictureBox();
            this.zavora = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.breh1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.breh2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.voda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.konec)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zavora)).BeginInit();
            this.SuspendLayout();
            // 
            // breh1
            // 
            this.breh1.BackColor = System.Drawing.Color.Green;
            this.breh1.Location = new System.Drawing.Point(-13, 300);
            this.breh1.Name = "breh1";
            this.breh1.Size = new System.Drawing.Size(213, 149);
            this.breh1.TabIndex = 0;
            this.breh1.TabStop = false;
            // 
            // breh2
            // 
            this.breh2.BackColor = System.Drawing.Color.Green;
            this.breh2.Location = new System.Drawing.Point(620, 300);
            this.breh2.Name = "breh2";
            this.breh2.Size = new System.Drawing.Size(213, 149);
            this.breh2.TabIndex = 1;
            this.breh2.TabStop = false;
            // 
            // voda
            // 
            this.voda.BackColor = System.Drawing.Color.Navy;
            this.voda.Location = new System.Drawing.Point(127, 327);
            this.voda.Name = "voda";
            this.voda.Size = new System.Drawing.Size(585, 122);
            this.voda.TabIndex = 2;
            this.voda.TabStop = false;
            // 
            // lod
            // 
            this.lod.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lod.Location = new System.Drawing.Point(454, 300);
            this.lod.Name = "lod";
            this.lod.Size = new System.Drawing.Size(77, 32);
            this.lod.TabIndex = 3;
            this.lod.TabStop = false;
            // 
            // timer_pro_pismenka
            // 
            this.timer_pro_pismenka.Enabled = true;
            this.timer_pro_pismenka.Interval = 400;
            this.timer_pro_pismenka.Tick += new System.EventHandler(this.timer_pro_lod_Tick);
            // 
            // timer_kolize
            // 
            this.timer_kolize.Enabled = true;
            this.timer_kolize.Interval = 10;
            this.timer_kolize.Tick += new System.EventHandler(this.timer_kolize_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(82, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "utopena:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(403, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "zachranena:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(148, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label4.Location = new System.Drawing.Point(487, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "0";
            // 
            // pohyb_pismena
            // 
            this.pohyb_pismena.Enabled = true;
            this.pohyb_pismena.Tick += new System.EventHandler(this.pohyb_pismena_Tick);
            // 
            // konec
            // 
            this.konec.BackColor = System.Drawing.SystemColors.Control;
            this.konec.Location = new System.Drawing.Point(792, 193);
            this.konec.Name = "konec";
            this.konec.Size = new System.Drawing.Size(103, 163);
            this.konec.TabIndex = 8;
            this.konec.TabStop = false;
            // 
            // zavora
            // 
            this.zavora.BackColor = System.Drawing.SystemColors.Control;
            this.zavora.Location = new System.Drawing.Point(520, 300);
            this.zavora.Name = "zavora";
            this.zavora.Size = new System.Drawing.Size(19, 16);
            this.zavora.TabIndex = 9;
            this.zavora.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 453);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lod);
            this.Controls.Add(this.breh1);
            this.Controls.Add(this.breh2);
            this.Controls.Add(this.voda);
            this.Controls.Add(this.zavora);
            this.Controls.Add(this.konec);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.breh1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.breh2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.voda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.konec)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zavora)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox breh1;
        private System.Windows.Forms.PictureBox breh2;
        private System.Windows.Forms.PictureBox voda;
        private System.Windows.Forms.PictureBox lod;
        private System.Windows.Forms.Timer timer_pro_pismenka;
        private System.Windows.Forms.Timer timer_kolize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Timer pohyb_pismena;
        private System.Windows.Forms.PictureBox konec;
        private System.Windows.Forms.PictureBox zavora;
    }
}

