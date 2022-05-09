namespace Pokladna
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
            this.btnZadatManualne = new System.Windows.Forms.Button();
            this.lblInstrukce = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnZadatManualne
            // 
            this.btnZadatManualne.Location = new System.Drawing.Point(12, 111);
            this.btnZadatManualne.Name = "btnZadatManualne";
            this.btnZadatManualne.Size = new System.Drawing.Size(341, 44);
            this.btnZadatManualne.TabIndex = 0;
            this.btnZadatManualne.TabStop = false;
            this.btnZadatManualne.Text = "Zadejte manuálně";
            this.btnZadatManualne.UseVisualStyleBackColor = true;
            this.btnZadatManualne.Click += new System.EventHandler(this.BtnZadatManualne_Click);
            // 
            // lblInstrukce
            // 
            this.lblInstrukce.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblInstrukce.Location = new System.Drawing.Point(12, 9);
            this.lblInstrukce.Name = "lblInstrukce";
            this.lblInstrukce.Size = new System.Drawing.Size(341, 40);
            this.lblInstrukce.TabIndex = 1;
            this.lblInstrukce.Text = "Naskenujte čárový kód uživatele";
            this.lblInstrukce.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox1.Location = new System.Drawing.Point(16, 65);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(337, 29);
            this.textBox1.TabIndex = 2;
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox1_KeyDown);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 167);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lblInstrukce);
            this.Controls.Add(this.btnZadatManualne);
            this.Name = "Form1";
            this.Text = "Přihlášení obsluhy";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnZadatManualne;
        private System.Windows.Forms.Label lblInstrukce;
        private System.Windows.Forms.TextBox textBox1;
    }
}

