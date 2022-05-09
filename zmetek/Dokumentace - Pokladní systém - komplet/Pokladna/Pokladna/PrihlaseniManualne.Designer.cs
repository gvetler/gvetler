
namespace Pokladna
{
    partial class PrihlaseniManualne
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtUzivatelskeJmeno = new System.Windows.Forms.TextBox();
            this.txtHeslo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnPrihlasit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(6, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(280, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "Uživatelské jméno:";
            // 
            // txtUzivatelskeJmeno
            // 
            this.txtUzivatelskeJmeno.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtUzivatelskeJmeno.Location = new System.Drawing.Point(12, 62);
            this.txtUzivatelskeJmeno.Name = "txtUzivatelskeJmeno";
            this.txtUzivatelskeJmeno.Size = new System.Drawing.Size(556, 44);
            this.txtUzivatelskeJmeno.TabIndex = 1;
            // 
            // txtHeslo
            // 
            this.txtHeslo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtHeslo.Location = new System.Drawing.Point(12, 176);
            this.txtHeslo.Name = "txtHeslo";
            this.txtHeslo.Size = new System.Drawing.Size(556, 44);
            this.txtHeslo.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(6, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 33);
            this.label2.TabIndex = 2;
            this.label2.Text = "Heslo:";
            // 
            // btnPrihlasit
            // 
            this.btnPrihlasit.Location = new System.Drawing.Point(12, 240);
            this.btnPrihlasit.Name = "btnPrihlasit";
            this.btnPrihlasit.Size = new System.Drawing.Size(556, 56);
            this.btnPrihlasit.TabIndex = 4;
            this.btnPrihlasit.Text = "Přihlásit";
            this.btnPrihlasit.UseVisualStyleBackColor = true;
            this.btnPrihlasit.Click += new System.EventHandler(this.btnPrihlasit_Click);
            // 
            // PrihlaseniManualne
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 353);
            this.Controls.Add(this.btnPrihlasit);
            this.Controls.Add(this.txtHeslo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtUzivatelskeJmeno);
            this.Controls.Add(this.label1);
            this.Name = "PrihlaseniManualne";
            this.Text = "Přihlášení";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PrihlaseniManualne_FormClosing);
            this.Load += new System.EventHandler(this.PrihlaseniManualne_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUzivatelskeJmeno;
        private System.Windows.Forms.TextBox txtHeslo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnPrihlasit;
    }
}