namespace GORILY
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tmrMoveShot = new System.Windows.Forms.Timer(this.components);
            this.btnShoot1 = new System.Windows.Forms.Button();
            this.Label1_1 = new System.Windows.Forms.Label();
            this.Label1_0 = new System.Windows.Forms.Label();
            this.txtSpeed1 = new System.Windows.Forms.TextBox();
            this.txtDegrees1 = new System.Windows.Forms.TextBox();
            this.btnShoot2 = new System.Windows.Forms.Button();
            this.label2_1 = new System.Windows.Forms.Label();
            this.label2_0 = new System.Windows.Forms.Label();
            this.txtSpeed2 = new System.Windows.Forms.TextBox();
            this.txtDegrees2 = new System.Windows.Forms.TextBox();
            this.lblKonec = new System.Windows.Forms.Label();
            this.buttonNewGame = new System.Windows.Forms.Button();
            this.lblScore = new System.Windows.Forms.Label();
            this.picCanvas = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // tmrMoveShot
            // 
            this.tmrMoveShot.Tick += new System.EventHandler(this.tmrMoveShot_Tick);
            // 
            // btnShoot1
            // 
            this.btnShoot1.BackColor = System.Drawing.SystemColors.Control;
            this.btnShoot1.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnShoot1.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShoot1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnShoot1.Location = new System.Drawing.Point(138, 11);
            this.btnShoot1.Name = "btnShoot1";
            this.btnShoot1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnShoot1.Size = new System.Drawing.Size(49, 25);
            this.btnShoot1.TabIndex = 22;
            this.btnShoot1.Text = "Střelba";
            this.btnShoot1.UseVisualStyleBackColor = false;
            this.btnShoot1.Click += new System.EventHandler(this.btnShoot1_Click);
            // 
            // Label1_1
            // 
            this.Label1_1.BackColor = System.Drawing.SystemColors.Control;
            this.Label1_1.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label1_1.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1_1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label1_1.Location = new System.Drawing.Point(2, 30);
            this.Label1_1.Name = "Label1_1";
            this.Label1_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label1_1.Size = new System.Drawing.Size(81, 17);
            this.Label1_1.TabIndex = 20;
            this.Label1_1.Text = "Rychlost (m/s)";
            // 
            // Label1_0
            // 
            this.Label1_0.BackColor = System.Drawing.SystemColors.Control;
            this.Label1_0.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label1_0.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1_0.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label1_0.Location = new System.Drawing.Point(2, 4);
            this.Label1_0.Name = "Label1_0";
            this.Label1_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label1_0.Size = new System.Drawing.Size(88, 17);
            this.Label1_0.TabIndex = 18;
            this.Label1_0.Text = "Úhel (Stupňe)";
            // 
            // txtSpeed1
            // 
            this.txtSpeed1.AcceptsReturn = true;
            this.txtSpeed1.BackColor = System.Drawing.SystemColors.Window;
            this.txtSpeed1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSpeed1.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSpeed1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtSpeed1.Location = new System.Drawing.Point(96, 27);
            this.txtSpeed1.MaxLength = 0;
            this.txtSpeed1.Name = "txtSpeed1";
            this.txtSpeed1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtSpeed1.Size = new System.Drawing.Size(33, 20);
            this.txtSpeed1.TabIndex = 21;
            this.txtSpeed1.Text = "50";
            this.txtSpeed1.TextChanged += new System.EventHandler(this.txtChanged);
            // 
            // txtDegrees1
            // 
            this.txtDegrees1.AcceptsReturn = true;
            this.txtDegrees1.BackColor = System.Drawing.SystemColors.Window;
            this.txtDegrees1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDegrees1.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDegrees1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDegrees1.Location = new System.Drawing.Point(96, 1);
            this.txtDegrees1.MaxLength = 0;
            this.txtDegrees1.Name = "txtDegrees1";
            this.txtDegrees1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtDegrees1.Size = new System.Drawing.Size(33, 20);
            this.txtDegrees1.TabIndex = 19;
            this.txtDegrees1.Text = "45";
            this.txtDegrees1.TextChanged += new System.EventHandler(this.txtChanged);
            // 
            // btnShoot2
            // 
            this.btnShoot2.BackColor = System.Drawing.SystemColors.Control;
            this.btnShoot2.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnShoot2.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShoot2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnShoot2.Location = new System.Drawing.Point(458, 11);
            this.btnShoot2.Name = "btnShoot2";
            this.btnShoot2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnShoot2.Size = new System.Drawing.Size(49, 25);
            this.btnShoot2.TabIndex = 28;
            this.btnShoot2.Text = "Střelba";
            this.btnShoot2.UseVisualStyleBackColor = false;
            this.btnShoot2.Click += new System.EventHandler(this.btnShoot2_Click);
            // 
            // label2_1
            // 
            this.label2_1.BackColor = System.Drawing.SystemColors.Control;
            this.label2_1.Cursor = System.Windows.Forms.Cursors.Default;
            this.label2_1.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2_1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2_1.Location = new System.Drawing.Point(552, 30);
            this.label2_1.Name = "label2_1";
            this.label2_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2_1.Size = new System.Drawing.Size(81, 17);
            this.label2_1.TabIndex = 26;
            this.label2_1.Text = "Rychlost (m/s)";
            // 
            // label2_0
            // 
            this.label2_0.BackColor = System.Drawing.SystemColors.Control;
            this.label2_0.Cursor = System.Windows.Forms.Cursors.Default;
            this.label2_0.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2_0.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2_0.Location = new System.Drawing.Point(552, 4);
            this.label2_0.Name = "label2_0";
            this.label2_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2_0.Size = new System.Drawing.Size(88, 17);
            this.label2_0.TabIndex = 24;
            this.label2_0.Text = "Úhel (Stupňe)";
            // 
            // txtSpeed2
            // 
            this.txtSpeed2.AcceptsReturn = true;
            this.txtSpeed2.BackColor = System.Drawing.SystemColors.Window;
            this.txtSpeed2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSpeed2.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSpeed2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtSpeed2.Location = new System.Drawing.Point(513, 27);
            this.txtSpeed2.MaxLength = 0;
            this.txtSpeed2.Name = "txtSpeed2";
            this.txtSpeed2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtSpeed2.Size = new System.Drawing.Size(33, 20);
            this.txtSpeed2.TabIndex = 27;
            this.txtSpeed2.Text = "50";
            this.txtSpeed2.TextChanged += new System.EventHandler(this.txtChanged);
            // 
            // txtDegrees2
            // 
            this.txtDegrees2.AcceptsReturn = true;
            this.txtDegrees2.BackColor = System.Drawing.SystemColors.Window;
            this.txtDegrees2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDegrees2.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDegrees2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDegrees2.Location = new System.Drawing.Point(513, 1);
            this.txtDegrees2.MaxLength = 0;
            this.txtDegrees2.Name = "txtDegrees2";
            this.txtDegrees2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtDegrees2.Size = new System.Drawing.Size(33, 20);
            this.txtDegrees2.TabIndex = 25;
            this.txtDegrees2.Text = "45";
            this.txtDegrees2.TextChanged += new System.EventHandler(this.txtChanged);
            // 
            // lblKonec
            // 
            this.lblKonec.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKonec.Location = new System.Drawing.Point(193, 1);
            this.lblKonec.Name = "lblKonec";
            this.lblKonec.Size = new System.Drawing.Size(259, 23);
            this.lblKonec.TabIndex = 29;
            this.lblKonec.Text = "lblKonec";
            this.lblKonec.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonNewGame
            // 
            this.buttonNewGame.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonNewGame.Location = new System.Drawing.Point(288, 25);
            this.buttonNewGame.Name = "buttonNewGame";
            this.buttonNewGame.Size = new System.Drawing.Size(65, 23);
            this.buttonNewGame.TabIndex = 30;
            this.buttonNewGame.Text = "Nová Hra";
            this.buttonNewGame.UseVisualStyleBackColor = true;
            this.buttonNewGame.Click += new System.EventHandler(this.buttonNewGame_Click);
            // 
            // lblScore
            // 
            this.lblScore.BackColor = System.Drawing.SystemColors.HotTrack;
            this.lblScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScore.ForeColor = System.Drawing.Color.White;
            this.lblScore.Location = new System.Drawing.Point(300, 86);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(42, 23);
            this.lblScore.TabIndex = 31;
            this.lblScore.Text = "0:0";
            this.lblScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblScore.Click += new System.EventHandler(this.lblScore_Click);
            // 
            // picCanvas
            // 
            this.picCanvas.BackColor = System.Drawing.SystemColors.HotTrack;
            this.picCanvas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picCanvas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picCanvas.Cursor = System.Windows.Forms.Cursors.Default;
            this.picCanvas.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.picCanvas.ForeColor = System.Drawing.SystemColors.ControlText;
            this.picCanvas.Location = new System.Drawing.Point(1, 50);
            this.picCanvas.Name = "picCanvas";
            this.picCanvas.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.picCanvas.Size = new System.Drawing.Size(640, 490);
            this.picCanvas.TabIndex = 23;
            this.picCanvas.TabStop = false;
            this.picCanvas.Click += new System.EventHandler(this.picCanvas_Click);
            this.picCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.picCanvas_Paint);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 543);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.buttonNewGame);
            this.Controls.Add(this.lblKonec);
            this.Controls.Add(this.btnShoot2);
            this.Controls.Add(this.label2_1);
            this.Controls.Add(this.label2_0);
            this.Controls.Add(this.txtSpeed2);
            this.Controls.Add(this.txtDegrees2);
            this.Controls.Add(this.picCanvas);
            this.Controls.Add(this.btnShoot1);
            this.Controls.Add(this.Label1_1);
            this.Controls.Add(this.Label1_0);
            this.Controls.Add(this.txtSpeed1);
            this.Controls.Add(this.txtDegrees1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "GORILY";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.PictureBox picCanvas;
        internal System.Windows.Forms.Timer tmrMoveShot;
        public System.Windows.Forms.Button btnShoot1;
        public System.Windows.Forms.Label Label1_1;
        public System.Windows.Forms.Label Label1_0;
        public System.Windows.Forms.TextBox txtSpeed1;
        public System.Windows.Forms.TextBox txtDegrees1;
        public System.Windows.Forms.Button btnShoot2;
        public System.Windows.Forms.Label label2_1;
        public System.Windows.Forms.Label label2_0;
        public System.Windows.Forms.TextBox txtSpeed2;
        public System.Windows.Forms.TextBox txtDegrees2;
        private System.Windows.Forms.Label lblKonec;
        private System.Windows.Forms.Button buttonNewGame;
        private System.Windows.Forms.Label lblScore;
    }
}

