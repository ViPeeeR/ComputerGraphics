namespace CGCourseProject
{
    partial class frmSettingsObject
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txbCz = new System.Windows.Forms.TextBox();
            this.txbCy = new System.Windows.Forms.TextBox();
            this.txbCx = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txbKr = new System.Windows.Forms.TextBox();
            this.txbKs = new System.Windows.Forms.TextBox();
            this.txbKd = new System.Windows.Forms.TextBox();
            this.txbKa = new System.Windows.Forms.TextBox();
            this.pColor = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txbRz = new System.Windows.Forms.TextBox();
            this.txbRy = new System.Windows.Forms.TextBox();
            this.txbRx = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txbCz);
            this.groupBox1.Controls.Add(this.txbCy);
            this.groupBox1.Controls.Add(this.txbCx);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 236);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Координаты";
            // 
            // txbCz
            // 
            this.txbCz.Location = new System.Drawing.Point(26, 162);
            this.txbCz.Name = "txbCz";
            this.txbCz.Size = new System.Drawing.Size(100, 35);
            this.txbCz.TabIndex = 2;
            this.txbCz.Text = "Z";
            // 
            // txbCy
            // 
            this.txbCy.Location = new System.Drawing.Point(26, 105);
            this.txbCy.Name = "txbCy";
            this.txbCy.Size = new System.Drawing.Size(100, 35);
            this.txbCy.TabIndex = 1;
            this.txbCy.Text = "Y";
            // 
            // txbCx
            // 
            this.txbCx.Location = new System.Drawing.Point(26, 50);
            this.txbCx.Name = "txbCx";
            this.txbCx.Size = new System.Drawing.Size(100, 35);
            this.txbCx.TabIndex = 0;
            this.txbCx.Text = "X";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txbKr);
            this.groupBox2.Controls.Add(this.txbKs);
            this.groupBox2.Controls.Add(this.txbKd);
            this.groupBox2.Controls.Add(this.txbKa);
            this.groupBox2.Location = new System.Drawing.Point(12, 254);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 270);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Материал";
            // 
            // txbKr
            // 
            this.txbKr.Location = new System.Drawing.Point(23, 219);
            this.txbKr.Name = "txbKr";
            this.txbKr.Size = new System.Drawing.Size(100, 35);
            this.txbKr.TabIndex = 3;
            this.txbKr.Text = "Kr";
            // 
            // txbKs
            // 
            this.txbKs.Location = new System.Drawing.Point(23, 162);
            this.txbKs.Name = "txbKs";
            this.txbKs.Size = new System.Drawing.Size(100, 35);
            this.txbKs.TabIndex = 2;
            this.txbKs.Text = "Ks";
            // 
            // txbKd
            // 
            this.txbKd.Location = new System.Drawing.Point(23, 105);
            this.txbKd.Name = "txbKd";
            this.txbKd.Size = new System.Drawing.Size(100, 35);
            this.txbKd.TabIndex = 1;
            this.txbKd.Text = "Kd";
            // 
            // txbKa
            // 
            this.txbKa.Location = new System.Drawing.Point(23, 50);
            this.txbKa.Name = "txbKa";
            this.txbKa.Size = new System.Drawing.Size(100, 35);
            this.txbKa.TabIndex = 0;
            this.txbKa.Text = "Ka";
            // 
            // pColor
            // 
            this.pColor.BackColor = System.Drawing.Color.Black;
            this.pColor.Location = new System.Drawing.Point(234, 276);
            this.pColor.Name = "pColor";
            this.pColor.Size = new System.Drawing.Size(45, 42);
            this.pColor.TabIndex = 2;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txbRz);
            this.groupBox3.Controls.Add(this.txbRy);
            this.groupBox3.Controls.Add(this.txbRx);
            this.groupBox3.Location = new System.Drawing.Point(234, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 236);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Поворот";
            // 
            // txbRz
            // 
            this.txbRz.Location = new System.Drawing.Point(26, 162);
            this.txbRz.Name = "txbRz";
            this.txbRz.Size = new System.Drawing.Size(100, 35);
            this.txbRz.TabIndex = 2;
            this.txbRz.Text = "Z";
            // 
            // txbRy
            // 
            this.txbRy.Location = new System.Drawing.Point(26, 105);
            this.txbRy.Name = "txbRy";
            this.txbRy.Size = new System.Drawing.Size(100, 35);
            this.txbRy.TabIndex = 1;
            this.txbRy.Text = "Y";
            // 
            // txbRx
            // 
            this.txbRx.Location = new System.Drawing.Point(26, 50);
            this.txbRx.Name = "txbRx";
            this.txbRx.Size = new System.Drawing.Size(100, 35);
            this.txbRx.TabIndex = 0;
            this.txbRx.Text = "X";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(234, 371);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Добавить";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(345, 371);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Отменить";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // SettingsObject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 562);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.pColor);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "SettingsObject";
            this.Text = "SettingsObject";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txbCz;
        private System.Windows.Forms.TextBox txbCy;
        private System.Windows.Forms.TextBox txbCx;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txbKa;
        private System.Windows.Forms.TextBox txbKr;
        private System.Windows.Forms.TextBox txbKs;
        private System.Windows.Forms.TextBox txbKd;
        private System.Windows.Forms.Panel pColor;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txbRz;
        private System.Windows.Forms.TextBox txbRy;
        private System.Windows.Forms.TextBox txbRx;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnCancel;
    }
}