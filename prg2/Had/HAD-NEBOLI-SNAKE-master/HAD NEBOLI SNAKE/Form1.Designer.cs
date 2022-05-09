using System.Runtime.CompilerServices;

namespace HAD_NEBOLI_SNAKE
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
            this.pbGameField = new System.Windows.Forms.PictureBox();
            this.labelScore = new System.Windows.Forms.Label();
            this.labelScore0 = new System.Windows.Forms.Label();
            this.GameTimer = new System.Windows.Forms.Timer(this.components);
            this.labelGameOver = new System.Windows.Forms.Label();
            this.checkboxSettingsWalls = new System.Windows.Forms.CheckBox();
            this.labelSettings = new System.Windows.Forms.Label();
            this.radioButtonSettings1 = new System.Windows.Forms.RadioButton();
            this.radioButtonSettings2 = new System.Windows.Forms.RadioButton();
            this.radioButtonSettings3 = new System.Windows.Forms.RadioButton();
            this.labelDiffs = new System.Windows.Forms.Label();
            this.panelDiffs = new System.Windows.Forms.Panel();
            this.panelSettings = new System.Windows.Forms.Panel();
            this.labelControls = new System.Windows.Forms.Label();
            this.labelControls0 = new System.Windows.Forms.Label();
            this.labelFoodCount = new System.Windows.Forms.Label();
            this.labelFoodCount0 = new System.Windows.Forms.Label();
            this.pictureBoxHeart1 = new System.Windows.Forms.PictureBox();
            this.pictureBoxHeart2 = new System.Windows.Forms.PictureBox();
            this.pictureBoxHeart3 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbGameField)).BeginInit();
            this.panelDiffs.SuspendLayout();
            this.panelSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHeart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHeart2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHeart3)).BeginInit();
            this.SuspendLayout();
            // 
            // pbGameField
            // 
            this.pbGameField.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.pbGameField.Location = new System.Drawing.Point(10, 10);
            this.pbGameField.Name = "pbGameField";
            this.pbGameField.Size = new System.Drawing.Size(900, 600);
            this.pbGameField.TabIndex = 0;
            this.pbGameField.TabStop = false;
            this.pbGameField.Paint += new System.Windows.Forms.PaintEventHandler(this.pbGameField_Paint);
            // 
            // labelScore
            // 
            this.labelScore.AutoSize = true;
            this.labelScore.Font = new System.Drawing.Font("Verdana", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelScore.Location = new System.Drawing.Point(916, 10);
            this.labelScore.Name = "labelScore";
            this.labelScore.Size = new System.Drawing.Size(154, 45);
            this.labelScore.TabIndex = 0;
            this.labelScore.Text = "Skóre:";
            // 
            // labelScore0
            // 
            this.labelScore0.Font = new System.Drawing.Font("Verdana", 26.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelScore0.Location = new System.Drawing.Point(1070, 13);
            this.labelScore0.Name = "labelScore0";
            this.labelScore0.Size = new System.Drawing.Size(187, 45);
            this.labelScore0.TabIndex = 0;
            this.labelScore0.Text = "0";
            this.labelScore0.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelGameOver
            // 
            this.labelGameOver.AutoSize = true;
            this.labelGameOver.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.labelGameOver.Font = new System.Drawing.Font("Verdana", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGameOver.Location = new System.Drawing.Point(159, 114);
            this.labelGameOver.Name = "labelGameOver";
            this.labelGameOver.Size = new System.Drawing.Size(246, 42);
            this.labelGameOver.TabIndex = 0;
            this.labelGameOver.Text = "lblGameOver";
            // 
            // checkboxSettingsWalls
            // 
            this.checkboxSettingsWalls.AutoSize = true;
            this.checkboxSettingsWalls.Checked = true;
            this.checkboxSettingsWalls.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkboxSettingsWalls.Font = new System.Drawing.Font("Verdana", 14.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkboxSettingsWalls.Location = new System.Drawing.Point(10, 56);
            this.checkboxSettingsWalls.Name = "checkboxSettingsWalls";
            this.checkboxSettingsWalls.Size = new System.Drawing.Size(195, 29);
            this.checkboxSettingsWalls.TabIndex = 0;
            this.checkboxSettingsWalls.TabStop = false;
            this.checkboxSettingsWalls.Text = "Smrtelné okraje";
            // 
            // labelSettings
            // 
            this.labelSettings.AutoSize = true;
            this.labelSettings.Font = new System.Drawing.Font("Verdana", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSettings.Location = new System.Drawing.Point(3, 13);
            this.labelSettings.Name = "labelSettings";
            this.labelSettings.Size = new System.Drawing.Size(158, 35);
            this.labelSettings.TabIndex = 0;
            this.labelSettings.Text = "Nastavení";
            // 
            // radioButtonSettings1
            // 
            this.radioButtonSettings1.AutoSize = true;
            this.radioButtonSettings1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonSettings1.Location = new System.Drawing.Point(10, 30);
            this.radioButtonSettings1.Name = "radioButtonSettings1";
            this.radioButtonSettings1.Size = new System.Drawing.Size(74, 22);
            this.radioButtonSettings1.TabIndex = 0;
            this.radioButtonSettings1.Text = "Lehká";
            this.radioButtonSettings1.UseVisualStyleBackColor = true;
            // 
            // radioButtonSettings2
            // 
            this.radioButtonSettings2.AutoSize = true;
            this.radioButtonSettings2.Checked = true;
            this.radioButtonSettings2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonSettings2.Location = new System.Drawing.Point(10, 50);
            this.radioButtonSettings2.Name = "radioButtonSettings2";
            this.radioButtonSettings2.Size = new System.Drawing.Size(84, 22);
            this.radioButtonSettings2.TabIndex = 0;
            this.radioButtonSettings2.TabStop = true;
            this.radioButtonSettings2.Text = "Střední";
            this.radioButtonSettings2.UseVisualStyleBackColor = true;
            // 
            // radioButtonSettings3
            // 
            this.radioButtonSettings3.AutoSize = true;
            this.radioButtonSettings3.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonSettings3.Location = new System.Drawing.Point(10, 70);
            this.radioButtonSettings3.Name = "radioButtonSettings3";
            this.radioButtonSettings3.Size = new System.Drawing.Size(74, 22);
            this.radioButtonSettings3.TabIndex = 0;
            this.radioButtonSettings3.Text = "Těžká";
            this.radioButtonSettings3.UseVisualStyleBackColor = true;
            // 
            // labelDiffs
            // 
            this.labelDiffs.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDiffs.Location = new System.Drawing.Point(5, 0);
            this.labelDiffs.Name = "labelDiffs";
            this.labelDiffs.Size = new System.Drawing.Size(112, 27);
            this.labelDiffs.TabIndex = 0;
            this.labelDiffs.Text = "Obtížnost";
            // 
            // panelDiffs
            // 
            this.panelDiffs.Controls.Add(this.radioButtonSettings1);
            this.panelDiffs.Controls.Add(this.radioButtonSettings2);
            this.panelDiffs.Controls.Add(this.radioButtonSettings3);
            this.panelDiffs.Controls.Add(this.labelDiffs);
            this.panelDiffs.Location = new System.Drawing.Point(0, 95);
            this.panelDiffs.Name = "panelDiffs";
            this.panelDiffs.Size = new System.Drawing.Size(218, 110);
            this.panelDiffs.TabIndex = 10;
            // 
            // panelSettings
            // 
            this.panelSettings.Controls.Add(this.labelSettings);
            this.panelSettings.Controls.Add(this.panelDiffs);
            this.panelSettings.Controls.Add(this.checkboxSettingsWalls);
            this.panelSettings.Location = new System.Drawing.Point(924, 172);
            this.panelSettings.Name = "panelSettings";
            this.panelSettings.Size = new System.Drawing.Size(218, 206);
            this.panelSettings.TabIndex = 10;
            // 
            // labelControls
            // 
            this.labelControls.AutoSize = true;
            this.labelControls.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControls.Location = new System.Drawing.Point(929, 490);
            this.labelControls.Name = "labelControls";
            this.labelControls.Size = new System.Drawing.Size(94, 23);
            this.labelControls.TabIndex = 11;
            this.labelControls.Text = "Ovládání";
            // 
            // labelControls0
            // 
            this.labelControls0.AutoSize = true;
            this.labelControls0.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControls0.Location = new System.Drawing.Point(930, 516);
            this.labelControls0.Name = "labelControls0";
            this.labelControls0.Size = new System.Drawing.Size(162, 36);
            this.labelControls0.TabIndex = 12;
            this.labelControls0.Text = "Pohyb: WASD/ŠIPKY\nKonec Hry: ESC";
            // 
            // labelFoodCount
            // 
            this.labelFoodCount.AutoSize = true;
            this.labelFoodCount.Font = new System.Drawing.Font("Verdana", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFoodCount.Location = new System.Drawing.Point(916, 55);
            this.labelFoodCount.Name = "labelFoodCount";
            this.labelFoodCount.Size = new System.Drawing.Size(133, 45);
            this.labelFoodCount.TabIndex = 14;
            this.labelFoodCount.Text = "Jídlo:";
            // 
            // labelFoodCount0
            // 
            this.labelFoodCount0.Font = new System.Drawing.Font("Verdana", 26.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFoodCount0.Location = new System.Drawing.Point(1048, 58);
            this.labelFoodCount0.Name = "labelFoodCount0";
            this.labelFoodCount0.Size = new System.Drawing.Size(209, 45);
            this.labelFoodCount0.TabIndex = 15;
            this.labelFoodCount0.Text = "0";
            this.labelFoodCount0.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // pictureBoxHeart1
            // 
            this.pictureBoxHeart1.Image = global::HAD_NEBOLI_SNAKE.Properties.Resources.Heart;
            this.pictureBoxHeart1.Location = new System.Drawing.Point(924, 114);
            this.pictureBoxHeart1.Name = "pictureBoxHeart1";
            this.pictureBoxHeart1.Size = new System.Drawing.Size(30, 30);
            this.pictureBoxHeart1.TabIndex = 16;
            this.pictureBoxHeart1.TabStop = false;
            // 
            // pictureBoxHeart2
            // 
            this.pictureBoxHeart2.Image = global::HAD_NEBOLI_SNAKE.Properties.Resources.Heart;
            this.pictureBoxHeart2.Location = new System.Drawing.Point(960, 114);
            this.pictureBoxHeart2.Name = "pictureBoxHeart2";
            this.pictureBoxHeart2.Size = new System.Drawing.Size(30, 30);
            this.pictureBoxHeart2.TabIndex = 17;
            this.pictureBoxHeart2.TabStop = false;
            // 
            // pictureBoxHeart3
            // 
            this.pictureBoxHeart3.Image = global::HAD_NEBOLI_SNAKE.Properties.Resources.Heart;
            this.pictureBoxHeart3.Location = new System.Drawing.Point(996, 114);
            this.pictureBoxHeart3.Name = "pictureBoxHeart3";
            this.pictureBoxHeart3.Size = new System.Drawing.Size(30, 30);
            this.pictureBoxHeart3.TabIndex = 18;
            this.pictureBoxHeart3.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1269, 620);
            this.Controls.Add(this.pictureBoxHeart3);
            this.Controls.Add(this.pictureBoxHeart2);
            this.Controls.Add(this.pictureBoxHeart1);
            this.Controls.Add(this.labelFoodCount0);
            this.Controls.Add(this.labelFoodCount);
            this.Controls.Add(this.labelControls0);
            this.Controls.Add(this.labelControls);
            this.Controls.Add(this.panelSettings);
            this.Controls.Add(this.labelGameOver);
            this.Controls.Add(this.labelScore);
            this.Controls.Add(this.labelScore0);
            this.Controls.Add(this.pbGameField);
            this.Icon = global::HAD_NEBOLI_SNAKE.Properties.Resources.Ikonka;
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "HAD NEBOLI SNAKE";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pbGameField)).EndInit();
            this.panelDiffs.ResumeLayout(false);
            this.panelDiffs.PerformLayout();
            this.panelSettings.ResumeLayout(false);
            this.panelSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHeart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHeart2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHeart3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbGameField;
        private System.Windows.Forms.Label labelScore;
        private System.Windows.Forms.Label labelScore0;
        private System.Windows.Forms.Timer GameTimer;
        private System.Windows.Forms.Label labelGameOver;
        private System.Windows.Forms.CheckBox checkboxSettingsWalls;
        private System.Windows.Forms.Label labelSettings;
        private System.Windows.Forms.RadioButton radioButtonSettings1;
        private System.Windows.Forms.RadioButton radioButtonSettings2;
        private System.Windows.Forms.RadioButton radioButtonSettings3;
        private System.Windows.Forms.Label labelDiffs;
        private System.Windows.Forms.Panel panelDiffs;
        private System.Windows.Forms.Panel panelSettings;
        private System.Windows.Forms.Label labelControls;
        private System.Windows.Forms.Label labelControls0;
        private System.Windows.Forms.Label labelFoodCount;
        private System.Windows.Forms.Label labelFoodCount0;
        private System.Windows.Forms.PictureBox pictureBoxHeart1;
        private System.Windows.Forms.PictureBox pictureBoxHeart2;
        private System.Windows.Forms.PictureBox pictureBoxHeart3;
    }
}

