namespace kasa
{
    partial class kasa
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
            this.id = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.zbozi = new System.Windows.Forms.TextBox();
            this.cena = new System.Windows.Forms.TextBox();
            this.kusy = new System.Windows.Forms.TextBox();
            this.kus = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.celkemc = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.datagrid = new System.Windows.Forms.Button();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // id
            // 
            this.id.Location = new System.Drawing.Point(77, 53);
            this.id.Multiline = true;
            this.id.Name = "id";
            this.id.Size = new System.Drawing.Size(100, 19);
            this.id.TabIndex = 0;
            this.id.TextChanged += new System.EventHandler(this.Id_TextChanged);
            this.id.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Id_KeyPress);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(502, 22);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(446, 198);
            this.dataGridView1.TabIndex = 1;
            // 
            // zbozi
            // 
            this.zbozi.Location = new System.Drawing.Point(77, 88);
            this.zbozi.Name = "zbozi";
            this.zbozi.ReadOnly = true;
            this.zbozi.Size = new System.Drawing.Size(100, 20);
            this.zbozi.TabIndex = 2;
            // 
            // cena
            // 
            this.cena.Location = new System.Drawing.Point(77, 119);
            this.cena.Name = "cena";
            this.cena.ReadOnly = true;
            this.cena.Size = new System.Drawing.Size(100, 20);
            this.cena.TabIndex = 3;
            // 
            // kusy
            // 
            this.kusy.Location = new System.Drawing.Point(80, 224);
            this.kusy.Name = "kusy";
            this.kusy.ReadOnly = true;
            this.kusy.Size = new System.Drawing.Size(100, 20);
            this.kusy.TabIndex = 4;
            // 
            // kus
            // 
            this.kus.Location = new System.Drawing.Point(77, 149);
            this.kus.Name = "kus";
            this.kus.ReadOnly = true;
            this.kus.Size = new System.Drawing.Size(100, 20);
            this.kus.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Zboží";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Cena za kus";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "kus";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 231);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "kusy celkem";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(201, 53);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(114, 121);
            this.listBox1.TabIndex = 11;
            // 
            // celkemc
            // 
            this.celkemc.Location = new System.Drawing.Point(396, 97);
            this.celkemc.Name = "celkemc";
            this.celkemc.ReadOnly = true;
            this.celkemc.Size = new System.Drawing.Size(100, 20);
            this.celkemc.TabIndex = 12;
            this.celkemc.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(321, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Cena celkem";
            // 
            // datagrid
            // 
            this.datagrid.Location = new System.Drawing.Point(269, 226);
            this.datagrid.Name = "datagrid";
            this.datagrid.Size = new System.Drawing.Size(98, 23);
            this.datagrid.TabIndex = 14;
            this.datagrid.Text = "Zobraz datagrid";
            this.datagrid.UseVisualStyleBackColor = true;
            this.datagrid.Click += new System.EventHandler(this.Datagrid_Click);
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(502, 282);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(114, 121);
            this.listBox2.TabIndex = 15;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(390, 156);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 23);
            this.button1.TabIndex = 16;
            this.button1.Text = "Zobraz datagrid";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // kasa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 256);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.datagrid);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.celkemc);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.kus);
            this.Controls.Add(this.kusy);
            this.Controls.Add(this.cena);
            this.Controls.Add(this.zbozi);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.id);
            this.Name = "kasa";
            this.Text = "kasa";
            this.Load += new System.EventHandler(this.Kasa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox id;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox zbozi;
        private System.Windows.Forms.TextBox cena;
        private System.Windows.Forms.TextBox kusy;
        private System.Windows.Forms.TextBox kus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox celkemc;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button datagrid;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Button button1;
    }
}

