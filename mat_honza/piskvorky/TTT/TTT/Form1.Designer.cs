namespace TTT
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
            this.gamepanel = new System.Windows.Forms.Panel();
            this.ShowPlayer = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // gamepanel
            // 
            this.gamepanel.Location = new System.Drawing.Point(11, 19);
            this.gamepanel.Name = "gamepanel";
            this.gamepanel.Size = new System.Drawing.Size(516, 465);
            this.gamepanel.TabIndex = 0;
            // 
            // ShowPlayer
            // 
            this.ShowPlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ShowPlayer.Location = new System.Drawing.Point(533, 109);
            this.ShowPlayer.Name = "ShowPlayer";
            this.ShowPlayer.Size = new System.Drawing.Size(104, 96);
            this.ShowPlayer.TabIndex = 1;
            this.ShowPlayer.Text = "O";
            this.ShowPlayer.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(528, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Hráč na tahu:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 496);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ShowPlayer);
            this.Controls.Add(this.gamepanel);
            this.Name = "Form1";
            this.Text = "Piškvorky";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel gamepanel;
        private System.Windows.Forms.Button ShowPlayer;
        private System.Windows.Forms.Label label1;
    }
}

