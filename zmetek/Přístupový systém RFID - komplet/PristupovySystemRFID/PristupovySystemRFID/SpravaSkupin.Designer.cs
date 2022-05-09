
namespace PristupovySystemRFID
{
    partial class SpravaSkupin
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxZvoleneSkupiny = new System.Windows.Forms.ComboBox();
            this.btnVymazatSkupinu = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxZvolenyDen = new System.Windows.Forms.ComboBox();
            this.rbVytvoritSkupinu = new System.Windows.Forms.RadioButton();
            this.rbPouzitExistujici = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNovaSkupina = new System.Windows.Forms.TextBox();
            this.checkBoxServerovna = new System.Windows.Forms.CheckBox();
            this.checkBoxKancelare = new System.Windows.Forms.CheckBox();
            this.checkBoxSklad = new System.Windows.Forms.CheckBox();
            this.comboBoxPocatecniHodiny = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBoxPocatecniMinuty = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBoxPocatecniSekundy = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBoxKoncoveSekundy = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.comboBoxKoncoveMinuty = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.comboBoxKoncoveHodiny = new System.Windows.Forms.ComboBox();
            this.btnVytvoritPravidlo = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.vchodServerovna = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.vchodKancelare = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.vchodSklad = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.den = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pocatecniCas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.koncovyCas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(6, 5);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "SPRÁVA SKUPIN";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 46);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Vyberte skupinu:";
            // 
            // comboBoxZvoleneSkupiny
            // 
            this.comboBoxZvoleneSkupiny.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.comboBoxZvoleneSkupiny.FormattingEnabled = true;
            this.comboBoxZvoleneSkupiny.Location = new System.Drawing.Point(113, 40);
            this.comboBoxZvoleneSkupiny.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBoxZvoleneSkupiny.Name = "comboBoxZvoleneSkupiny";
            this.comboBoxZvoleneSkupiny.Size = new System.Drawing.Size(152, 25);
            this.comboBoxZvoleneSkupiny.TabIndex = 4;
            this.comboBoxZvoleneSkupiny.SelectedIndexChanged += new System.EventHandler(this.comboBoxZvoleneSkupiny_SelectedIndexChanged);
            // 
            // btnVymazatSkupinu
            // 
            this.btnVymazatSkupinu.Font = new System.Drawing.Font("Segoe UI", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnVymazatSkupinu.Location = new System.Drawing.Point(304, 40);
            this.btnVymazatSkupinu.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnVymazatSkupinu.Name = "btnVymazatSkupinu";
            this.btnVymazatSkupinu.Size = new System.Drawing.Size(116, 23);
            this.btnVymazatSkupinu.TabIndex = 5;
            this.btnVymazatSkupinu.Text = "Vymazat skupinu";
            this.btnVymazatSkupinu.UseVisualStyleBackColor = true;
            this.btnVymazatSkupinu.Click += new System.EventHandler(this.btnVymazatSkupinu_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 77);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Zvolte den:";
            // 
            // comboBoxZvolenyDen
            // 
            this.comboBoxZvolenyDen.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.comboBoxZvolenyDen.FormattingEnabled = true;
            this.comboBoxZvolenyDen.Location = new System.Drawing.Point(113, 71);
            this.comboBoxZvolenyDen.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBoxZvolenyDen.Name = "comboBoxZvolenyDen";
            this.comboBoxZvolenyDen.Size = new System.Drawing.Size(152, 25);
            this.comboBoxZvolenyDen.TabIndex = 7;
            // 
            // rbVytvoritSkupinu
            // 
            this.rbVytvoritSkupinu.AutoSize = true;
            this.rbVytvoritSkupinu.Location = new System.Drawing.Point(15, 111);
            this.rbVytvoritSkupinu.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rbVytvoritSkupinu.Name = "rbVytvoritSkupinu";
            this.rbVytvoritSkupinu.Size = new System.Drawing.Size(134, 17);
            this.rbVytvoritSkupinu.TabIndex = 8;
            this.rbVytvoritSkupinu.TabStop = true;
            this.rbVytvoritSkupinu.Text = "Vytvořit novou skupinu";
            this.rbVytvoritSkupinu.UseVisualStyleBackColor = true;
            this.rbVytvoritSkupinu.CheckedChanged += new System.EventHandler(this.rbVytvoritSkupinu_CheckedChanged);
            // 
            // rbPouzitExistujici
            // 
            this.rbPouzitExistujici.AutoSize = true;
            this.rbPouzitExistujici.Location = new System.Drawing.Point(218, 111);
            this.rbPouzitExistujici.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rbPouzitExistujici.Name = "rbPouzitExistujici";
            this.rbPouzitExistujici.Size = new System.Drawing.Size(142, 17);
            this.rbPouzitExistujici.TabIndex = 9;
            this.rbPouzitExistujici.TabStop = true;
            this.rbPouzitExistujici.Text = "Použít existující skupinu";
            this.rbPouzitExistujici.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 140);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(144, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Zadejte název nové skupiny:";
            // 
            // txtNovaSkupina
            // 
            this.txtNovaSkupina.Location = new System.Drawing.Point(218, 139);
            this.txtNovaSkupina.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtNovaSkupina.Name = "txtNovaSkupina";
            this.txtNovaSkupina.Size = new System.Drawing.Size(138, 20);
            this.txtNovaSkupina.TabIndex = 11;
            // 
            // checkBoxServerovna
            // 
            this.checkBoxServerovna.AutoSize = true;
            this.checkBoxServerovna.Location = new System.Drawing.Point(15, 166);
            this.checkBoxServerovna.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkBoxServerovna.Name = "checkBoxServerovna";
            this.checkBoxServerovna.Size = new System.Drawing.Size(123, 17);
            this.checkBoxServerovna.TabIndex = 12;
            this.checkBoxServerovna.Text = "Přísup k serverovně";
            this.checkBoxServerovna.UseVisualStyleBackColor = true;
            // 
            // checkBoxKancelare
            // 
            this.checkBoxKancelare.AutoSize = true;
            this.checkBoxKancelare.Location = new System.Drawing.Point(15, 191);
            this.checkBoxKancelare.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkBoxKancelare.Name = "checkBoxKancelare";
            this.checkBoxKancelare.Size = new System.Drawing.Size(195, 17);
            this.checkBoxKancelare.TabIndex = 13;
            this.checkBoxKancelare.Text = "Přístup k ekonomickým kancelářím";
            this.checkBoxKancelare.UseVisualStyleBackColor = true;
            // 
            // checkBoxSklad
            // 
            this.checkBoxSklad.AutoSize = true;
            this.checkBoxSklad.Location = new System.Drawing.Point(15, 219);
            this.checkBoxSklad.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkBoxSklad.Name = "checkBoxSklad";
            this.checkBoxSklad.Size = new System.Drawing.Size(110, 17);
            this.checkBoxSklad.TabIndex = 14;
            this.checkBoxSklad.Text = "Přístup do skladu";
            this.checkBoxSklad.UseVisualStyleBackColor = true;
            // 
            // comboBoxPocatecniHodiny
            // 
            this.comboBoxPocatecniHodiny.FormattingEnabled = true;
            this.comboBoxPocatecniHodiny.Location = new System.Drawing.Point(218, 212);
            this.comboBoxPocatecniHodiny.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBoxPocatecniHodiny.Name = "comboBoxPocatecniHodiny";
            this.comboBoxPocatecniHodiny.Size = new System.Drawing.Size(70, 21);
            this.comboBoxPocatecniHodiny.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(216, 166);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Zadejte počáteční čas";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(216, 190);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 16);
            this.label6.TabIndex = 17;
            this.label6.Text = "Hodiny";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(289, 190);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 16);
            this.label7.TabIndex = 19;
            this.label7.Text = "Minuty";
            // 
            // comboBoxPocatecniMinuty
            // 
            this.comboBoxPocatecniMinuty.FormattingEnabled = true;
            this.comboBoxPocatecniMinuty.Location = new System.Drawing.Point(292, 212);
            this.comboBoxPocatecniMinuty.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBoxPocatecniMinuty.Name = "comboBoxPocatecniMinuty";
            this.comboBoxPocatecniMinuty.Size = new System.Drawing.Size(70, 21);
            this.comboBoxPocatecniMinuty.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(362, 190);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 16);
            this.label8.TabIndex = 21;
            this.label8.Text = "Sekundy";
            // 
            // comboBoxPocatecniSekundy
            // 
            this.comboBoxPocatecniSekundy.FormattingEnabled = true;
            this.comboBoxPocatecniSekundy.Location = new System.Drawing.Point(365, 212);
            this.comboBoxPocatecniSekundy.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBoxPocatecniSekundy.Name = "comboBoxPocatecniSekundy";
            this.comboBoxPocatecniSekundy.Size = new System.Drawing.Size(70, 21);
            this.comboBoxPocatecniSekundy.TabIndex = 20;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(362, 265);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 16);
            this.label9.TabIndex = 28;
            this.label9.Text = "Sekundy";
            // 
            // comboBoxKoncoveSekundy
            // 
            this.comboBoxKoncoveSekundy.FormattingEnabled = true;
            this.comboBoxKoncoveSekundy.Location = new System.Drawing.Point(365, 288);
            this.comboBoxKoncoveSekundy.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBoxKoncoveSekundy.Name = "comboBoxKoncoveSekundy";
            this.comboBoxKoncoveSekundy.Size = new System.Drawing.Size(70, 21);
            this.comboBoxKoncoveSekundy.TabIndex = 27;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold);
            this.label10.Location = new System.Drawing.Point(289, 265);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 16);
            this.label10.TabIndex = 26;
            this.label10.Text = "Minuty";
            // 
            // comboBoxKoncoveMinuty
            // 
            this.comboBoxKoncoveMinuty.FormattingEnabled = true;
            this.comboBoxKoncoveMinuty.Location = new System.Drawing.Point(292, 288);
            this.comboBoxKoncoveMinuty.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBoxKoncoveMinuty.Name = "comboBoxKoncoveMinuty";
            this.comboBoxKoncoveMinuty.Size = new System.Drawing.Size(70, 21);
            this.comboBoxKoncoveMinuty.TabIndex = 25;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold);
            this.label11.Location = new System.Drawing.Point(216, 265);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(70, 16);
            this.label11.TabIndex = 24;
            this.label11.Text = "Hodiny";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold);
            this.label12.Location = new System.Drawing.Point(216, 242);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(110, 13);
            this.label12.TabIndex = 23;
            this.label12.Text = "Zadejte koncový čas";
            // 
            // comboBoxKoncoveHodiny
            // 
            this.comboBoxKoncoveHodiny.FormattingEnabled = true;
            this.comboBoxKoncoveHodiny.Location = new System.Drawing.Point(218, 288);
            this.comboBoxKoncoveHodiny.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBoxKoncoveHodiny.Name = "comboBoxKoncoveHodiny";
            this.comboBoxKoncoveHodiny.Size = new System.Drawing.Size(70, 21);
            this.comboBoxKoncoveHodiny.TabIndex = 22;
            // 
            // btnVytvoritPravidlo
            // 
            this.btnVytvoritPravidlo.Font = new System.Drawing.Font("Segoe UI", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnVytvoritPravidlo.Location = new System.Drawing.Point(10, 320);
            this.btnVytvoritPravidlo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnVytvoritPravidlo.Name = "btnVytvoritPravidlo";
            this.btnVytvoritPravidlo.Size = new System.Drawing.Size(558, 23);
            this.btnVytvoritPravidlo.TabIndex = 29;
            this.btnVytvoritPravidlo.Text = "Vytvořit pravidlo";
            this.btnVytvoritPravidlo.UseVisualStyleBackColor = true;
            this.btnVytvoritPravidlo.Click += new System.EventHandler(this.btnVytvoritPravidlo_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.vchodServerovna,
            this.vchodKancelare,
            this.vchodSklad,
            this.den,
            this.pocatecniCas,
            this.koncovyCas});
            this.dataGridView1.Location = new System.Drawing.Point(10, 399);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 82;
            this.dataGridView1.RowTemplate.Height = 33;
            this.dataGridView1.Size = new System.Drawing.Size(558, 113);
            this.dataGridView1.TabIndex = 30;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // vchodServerovna
            // 
            this.vchodServerovna.HeaderText = "Serverovna";
            this.vchodServerovna.MinimumWidth = 10;
            this.vchodServerovna.Name = "vchodServerovna";
            this.vchodServerovna.ReadOnly = true;
            // 
            // vchodKancelare
            // 
            this.vchodKancelare.HeaderText = "Kanceláře";
            this.vchodKancelare.MinimumWidth = 10;
            this.vchodKancelare.Name = "vchodKancelare";
            this.vchodKancelare.ReadOnly = true;
            // 
            // vchodSklad
            // 
            this.vchodSklad.HeaderText = "Sklad";
            this.vchodSklad.MinimumWidth = 10;
            this.vchodSklad.Name = "vchodSklad";
            this.vchodSklad.ReadOnly = true;
            // 
            // den
            // 
            this.den.HeaderText = "Den";
            this.den.MinimumWidth = 10;
            this.den.Name = "den";
            this.den.ReadOnly = true;
            // 
            // pocatecniCas
            // 
            this.pocatecniCas.HeaderText = "Počáteční čas";
            this.pocatecniCas.MinimumWidth = 10;
            this.pocatecniCas.Name = "pocatecniCas";
            this.pocatecniCas.ReadOnly = true;
            // 
            // koncovyCas
            // 
            this.koncovyCas.HeaderText = "Koncový čas";
            this.koncovyCas.MinimumWidth = 10;
            this.koncovyCas.Name = "koncovyCas";
            this.koncovyCas.ReadOnly = true;
            // 
            // SpravaSkupin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 524);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnVytvoritPravidlo);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.comboBoxKoncoveSekundy);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.comboBoxKoncoveMinuty);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.comboBoxKoncoveHodiny);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.comboBoxPocatecniSekundy);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.comboBoxPocatecniMinuty);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBoxPocatecniHodiny);
            this.Controls.Add(this.checkBoxSklad);
            this.Controls.Add(this.checkBoxKancelare);
            this.Controls.Add(this.checkBoxServerovna);
            this.Controls.Add(this.txtNovaSkupina);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.rbPouzitExistujici);
            this.Controls.Add(this.rbVytvoritSkupinu);
            this.Controls.Add(this.comboBoxZvolenyDen);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnVymazatSkupinu);
            this.Controls.Add(this.comboBoxZvoleneSkupiny);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "SpravaSkupin";
            this.Text = "Správa skupin";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SpravaSkupin_FormClosing);
            this.Load += new System.EventHandler(this.SpravaSkupin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxZvoleneSkupiny;
        private System.Windows.Forms.Button btnVymazatSkupinu;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxZvolenyDen;
        private System.Windows.Forms.RadioButton rbVytvoritSkupinu;
        private System.Windows.Forms.RadioButton rbPouzitExistujici;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNovaSkupina;
        private System.Windows.Forms.CheckBox checkBoxServerovna;
        private System.Windows.Forms.CheckBox checkBoxKancelare;
        private System.Windows.Forms.CheckBox checkBoxSklad;
        private System.Windows.Forms.ComboBox comboBoxPocatecniHodiny;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBoxPocatecniMinuty;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBoxPocatecniSekundy;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBoxKoncoveSekundy;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox comboBoxKoncoveMinuty;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox comboBoxKoncoveHodiny;
        private System.Windows.Forms.Button btnVytvoritPravidlo;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn vchodServerovna;
        private System.Windows.Forms.DataGridViewCheckBoxColumn vchodKancelare;
        private System.Windows.Forms.DataGridViewCheckBoxColumn vchodSklad;
        private System.Windows.Forms.DataGridViewTextBoxColumn den;
        private System.Windows.Forms.DataGridViewTextBoxColumn pocatecniCas;
        private System.Windows.Forms.DataGridViewTextBoxColumn koncovyCas;
    }
}