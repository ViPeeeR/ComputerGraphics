namespace CGCourseProject
{
    partial class frmMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.менюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btntoolExit = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemSphere = new System.Windows.Forms.ToolStripMenuItem();
            this.chkIsMove = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnRight = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnForward = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Location = new System.Drawing.Point(0, 47);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(800, 639);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(36, 36);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.менюToolStripMenuItem,
            this.добавитьToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1146, 47);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // менюToolStripMenuItem
            // 
            this.менюToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btntoolExit});
            this.менюToolStripMenuItem.Name = "менюToolStripMenuItem";
            this.менюToolStripMenuItem.Size = new System.Drawing.Size(105, 43);
            this.менюToolStripMenuItem.Text = "Меню";
            // 
            // btntoolExit
            // 
            this.btntoolExit.Name = "btntoolExit";
            this.btntoolExit.Size = new System.Drawing.Size(202, 42);
            this.btntoolExit.Text = "Выход";
            // 
            // добавитьToolStripMenuItem
            // 
            this.добавитьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemSphere});
            this.добавитьToolStripMenuItem.Name = "добавитьToolStripMenuItem";
            this.добавитьToolStripMenuItem.Size = new System.Drawing.Size(149, 43);
            this.добавитьToolStripMenuItem.Text = "Добавить";
            // 
            // ToolStripMenuItemSphere
            // 
            this.ToolStripMenuItemSphere.Name = "ToolStripMenuItemSphere";
            this.ToolStripMenuItemSphere.Size = new System.Drawing.Size(298, 42);
            this.ToolStripMenuItemSphere.Text = "Шар";
            this.ToolStripMenuItemSphere.Click += new System.EventHandler(this.ToolStripMenuItemSphere_Click);
            // 
            // chkIsMove
            // 
            this.chkIsMove.AutoSize = true;
            this.chkIsMove.Checked = true;
            this.chkIsMove.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsMove.Location = new System.Drawing.Point(861, 277);
            this.chkIsMove.Name = "chkIsMove";
            this.chkIsMove.Size = new System.Drawing.Size(226, 33);
            this.chkIsMove.TabIndex = 6;
            this.chkIsMove.Text = "Двигать камеру";
            this.chkIsMove.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnRight);
            this.groupBox1.Controls.Add(this.btnLeft);
            this.groupBox1.Controls.Add(this.btnBack);
            this.groupBox1.Controls.Add(this.btnForward);
            this.groupBox1.Location = new System.Drawing.Point(810, 48);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(326, 197);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Двигать камеру";
            // 
            // btnRight
            // 
            this.btnRight.Location = new System.Drawing.Point(207, 83);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(80, 30);
            this.btnRight.TabIndex = 3;
            this.btnRight.Text = "Вправо";
            this.btnRight.UseVisualStyleBackColor = true;
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // btnLeft
            // 
            this.btnLeft.Location = new System.Drawing.Point(8, 83);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(80, 30);
            this.btnLeft.TabIndex = 2;
            this.btnLeft.Text = "Влево";
            this.btnLeft.UseVisualStyleBackColor = true;
            this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(106, 129);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(80, 30);
            this.btnBack.TabIndex = 1;
            this.btnBack.Text = "Назад";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnForward
            // 
            this.btnForward.Location = new System.Drawing.Point(106, 34);
            this.btnForward.Name = "btnForward";
            this.btnForward.Size = new System.Drawing.Size(80, 30);
            this.btnForward.TabIndex = 0;
            this.btnForward.Text = "Вперед";
            this.btnForward.UseVisualStyleBackColor = true;
            this.btnForward.Click += new System.EventHandler(this.btnForward_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(813, 334);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 29);
            this.label1.TabIndex = 8;
            this.label1.Text = "Ожидайте";
            this.label1.Visible = false;
            // 
            // frmMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(1146, 686);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chkIsMove);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(7);
            this.Name = "frmMain";
            this.Text = "Engine";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem менюToolStripMenuItem;
        private System.Windows.Forms.CheckBox chkIsMove;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnForward;
        private System.Windows.Forms.ToolStripMenuItem btntoolExit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem добавитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemSphere;
    }
}

