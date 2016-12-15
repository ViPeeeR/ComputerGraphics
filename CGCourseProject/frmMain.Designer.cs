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
            this.toolStripMenuItemPlane = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemBox = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemClear = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnMLow = new System.Windows.Forms.Button();
            this.btnMTop = new System.Windows.Forms.Button();
            this.btnMRight = new System.Windows.Forms.Button();
            this.btnMLeft = new System.Windows.Forms.Button();
            this.btnMBack = new System.Windows.Forms.Button();
            this.btnЬMForward = new System.Windows.Forms.Button();
            this.btnTopCamera = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnRRight = new System.Windows.Forms.Button();
            this.btnRLeft = new System.Windows.Forms.Button();
            this.btnRDown = new System.Windows.Forms.Button();
            this.btnRForward = new System.Windows.Forms.Button();
            this.btnCamDefault = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStripMenuItemLightSource = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Location = new System.Drawing.Point(0, 47);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(800, 577);
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
            this.menuStrip1.Size = new System.Drawing.Size(1134, 47);
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
            this.btntoolExit.Click += new System.EventHandler(this.btntoolExit_Click);
            // 
            // добавитьToolStripMenuItem
            // 
            this.добавитьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemSphere,
            this.toolStripMenuItemPlane,
            this.toolStripMenuItemLightSource,
            this.toolStripMenuItemBox,
            this.toolStripMenuItem1,
            this.toolStripMenuItemClear});
            this.добавитьToolStripMenuItem.Name = "добавитьToolStripMenuItem";
            this.добавитьToolStripMenuItem.Size = new System.Drawing.Size(149, 43);
            this.добавитьToolStripMenuItem.Text = "Добавить";
            // 
            // ToolStripMenuItemSphere
            // 
            this.ToolStripMenuItemSphere.Name = "ToolStripMenuItemSphere";
            this.ToolStripMenuItemSphere.Size = new System.Drawing.Size(437, 42);
            this.ToolStripMenuItemSphere.Text = "Шар";
            this.ToolStripMenuItemSphere.Click += new System.EventHandler(this.ToolStripMenuItemSphere_Click);
            // 
            // toolStripMenuItemPlane
            // 
            this.toolStripMenuItemPlane.Name = "toolStripMenuItemPlane";
            this.toolStripMenuItemPlane.Size = new System.Drawing.Size(437, 42);
            this.toolStripMenuItemPlane.Text = "Самолет (по умолчанию)";
            this.toolStripMenuItemPlane.Click += new System.EventHandler(this.ToolStripMenuItemPlane_Click);
            // 
            // toolStripMenuItemBox
            // 
            this.toolStripMenuItemBox.Name = "toolStripMenuItemBox";
            this.toolStripMenuItemBox.Size = new System.Drawing.Size(437, 42);
            this.toolStripMenuItemBox.Text = "Кубик";
            this.toolStripMenuItemBox.Visible = false;
            this.toolStripMenuItemBox.Click += new System.EventHandler(this.toolStripMenuItemBox_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(434, 6);
            // 
            // toolStripMenuItemClear
            // 
            this.toolStripMenuItemClear.Name = "toolStripMenuItemClear";
            this.toolStripMenuItemClear.Size = new System.Drawing.Size(437, 42);
            this.toolStripMenuItemClear.Text = "Очистить";
            this.toolStripMenuItemClear.Click += new System.EventHandler(this.toolStripMenuItemClear_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnMLow);
            this.groupBox1.Controls.Add(this.btnMTop);
            this.groupBox1.Controls.Add(this.btnMRight);
            this.groupBox1.Controls.Add(this.btnMLeft);
            this.groupBox1.Controls.Add(this.btnMBack);
            this.groupBox1.Controls.Add(this.btnЬMForward);
            this.groupBox1.Location = new System.Drawing.Point(810, 48);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(236, 140);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Двигать камеру";
            // 
            // btnMLow
            // 
            this.btnMLow.Location = new System.Drawing.Point(82, 78);
            this.btnMLow.Name = "btnMLow";
            this.btnMLow.Size = new System.Drawing.Size(70, 23);
            this.btnMLow.TabIndex = 5;
            this.btnMLow.Text = "Вниз";
            this.btnMLow.UseVisualStyleBackColor = true;
            this.btnMLow.Click += new System.EventHandler(this.btnLow_Click);
            // 
            // btnMTop
            // 
            this.btnMTop.Location = new System.Drawing.Point(82, 48);
            this.btnMTop.Name = "btnMTop";
            this.btnMTop.Size = new System.Drawing.Size(70, 23);
            this.btnMTop.TabIndex = 4;
            this.btnMTop.Text = "Вверх";
            this.btnMTop.UseVisualStyleBackColor = true;
            this.btnMTop.Click += new System.EventHandler(this.btnTop_Click);
            // 
            // btnMRight
            // 
            this.btnMRight.Location = new System.Drawing.Point(158, 67);
            this.btnMRight.Name = "btnMRight";
            this.btnMRight.Size = new System.Drawing.Size(70, 23);
            this.btnMRight.TabIndex = 3;
            this.btnMRight.Text = "Вправо";
            this.btnMRight.UseVisualStyleBackColor = true;
            this.btnMRight.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // btnMLeft
            // 
            this.btnMLeft.Location = new System.Drawing.Point(6, 67);
            this.btnMLeft.Name = "btnMLeft";
            this.btnMLeft.Size = new System.Drawing.Size(70, 23);
            this.btnMLeft.TabIndex = 2;
            this.btnMLeft.Text = "Влево";
            this.btnMLeft.UseVisualStyleBackColor = true;
            this.btnMLeft.Click += new System.EventHandler(this.btnLeft_Click);
            // 
            // btnMBack
            // 
            this.btnMBack.Location = new System.Drawing.Point(8, 107);
            this.btnMBack.Name = "btnMBack";
            this.btnMBack.Size = new System.Drawing.Size(220, 23);
            this.btnMBack.TabIndex = 1;
            this.btnMBack.Text = "Назад";
            this.btnMBack.UseVisualStyleBackColor = true;
            this.btnMBack.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnЬMForward
            // 
            this.btnЬMForward.Location = new System.Drawing.Point(6, 19);
            this.btnЬMForward.Name = "btnЬMForward";
            this.btnЬMForward.Size = new System.Drawing.Size(220, 23);
            this.btnЬMForward.TabIndex = 0;
            this.btnЬMForward.Text = "Вперед";
            this.btnЬMForward.UseVisualStyleBackColor = true;
            this.btnЬMForward.Click += new System.EventHandler(this.btnForward_Click);
            // 
            // btnTopCamera
            // 
            this.btnTopCamera.Location = new System.Drawing.Point(8, 68);
            this.btnTopCamera.Name = "btnTopCamera";
            this.btnTopCamera.Size = new System.Drawing.Size(113, 32);
            this.btnTopCamera.TabIndex = 9;
            this.btnTopCamera.Text = "Вид сверху";
            this.btnTopCamera.UseVisualStyleBackColor = true;
            this.btnTopCamera.Click += new System.EventHandler(this.btnTopCamera_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnRRight);
            this.groupBox2.Controls.Add(this.btnRLeft);
            this.groupBox2.Controls.Add(this.btnRDown);
            this.groupBox2.Controls.Add(this.btnRForward);
            this.groupBox2.Location = new System.Drawing.Point(810, 201);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(186, 111);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Повернуть камеру";
            // 
            // btnRRight
            // 
            this.btnRRight.Location = new System.Drawing.Point(106, 48);
            this.btnRRight.Name = "btnRRight";
            this.btnRRight.Size = new System.Drawing.Size(70, 23);
            this.btnRRight.TabIndex = 3;
            this.btnRRight.Text = "Вправо";
            this.btnRRight.UseVisualStyleBackColor = true;
            this.btnRRight.Click += new System.EventHandler(this.btnRRight_Click);
            // 
            // btnRLeft
            // 
            this.btnRLeft.Location = new System.Drawing.Point(8, 48);
            this.btnRLeft.Name = "btnRLeft";
            this.btnRLeft.Size = new System.Drawing.Size(70, 23);
            this.btnRLeft.TabIndex = 2;
            this.btnRLeft.Text = "Влево";
            this.btnRLeft.UseVisualStyleBackColor = true;
            this.btnRLeft.Click += new System.EventHandler(this.btnRLeft_Click);
            // 
            // btnRDown
            // 
            this.btnRDown.Location = new System.Drawing.Point(8, 77);
            this.btnRDown.Name = "btnRDown";
            this.btnRDown.Size = new System.Drawing.Size(168, 23);
            this.btnRDown.TabIndex = 1;
            this.btnRDown.Text = "Вниз";
            this.btnRDown.UseVisualStyleBackColor = true;
            this.btnRDown.Click += new System.EventHandler(this.btnRDown_Click);
            // 
            // btnRForward
            // 
            this.btnRForward.Location = new System.Drawing.Point(8, 19);
            this.btnRForward.Name = "btnRForward";
            this.btnRForward.Size = new System.Drawing.Size(168, 23);
            this.btnRForward.TabIndex = 0;
            this.btnRForward.Text = "Вверх";
            this.btnRForward.UseVisualStyleBackColor = true;
            this.btnRForward.Click += new System.EventHandler(this.btnRForward_Click);
            // 
            // btnCamDefault
            // 
            this.btnCamDefault.Location = new System.Drawing.Point(8, 19);
            this.btnCamDefault.Name = "btnCamDefault";
            this.btnCamDefault.Size = new System.Drawing.Size(113, 32);
            this.btnCamDefault.TabIndex = 10;
            this.btnCamDefault.Text = "Вид по умолчанию";
            this.btnCamDefault.UseVisualStyleBackColor = true;
            this.btnCamDefault.Click += new System.EventHandler(this.btnCamDefault_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar1.Location = new System.Drawing.Point(800, 609);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(334, 15);
            this.progressBar1.TabIndex = 11;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnCamDefault);
            this.groupBox3.Controls.Add(this.btnTopCamera);
            this.groupBox3.Location = new System.Drawing.Point(1002, 201);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(127, 111);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Положение камеры";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(811, 330);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 29);
            this.label1.TabIndex = 13;
            // 
            // toolStripMenuItemLightSource
            // 
            this.toolStripMenuItemLightSource.Name = "toolStripMenuItemLightSource";
            this.toolStripMenuItemLightSource.Size = new System.Drawing.Size(437, 42);
            this.toolStripMenuItemLightSource.Text = "Источник света";
            this.toolStripMenuItemLightSource.Click += new System.EventHandler(this.toolStripMenuItemLightSource_Click);
            // 
            // frmMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(1134, 624);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(7);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Engine";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem менюToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnMRight;
        private System.Windows.Forms.Button btnMLeft;
        private System.Windows.Forms.Button btnMBack;
        private System.Windows.Forms.Button btnЬMForward;
        private System.Windows.Forms.ToolStripMenuItem btntoolExit;
        private System.Windows.Forms.ToolStripMenuItem добавитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemSphere;
        private System.Windows.Forms.Button btnMLow;
        private System.Windows.Forms.Button btnMTop;
        private System.Windows.Forms.Button btnTopCamera;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnRRight;
        private System.Windows.Forms.Button btnRLeft;
        private System.Windows.Forms.Button btnRDown;
        private System.Windows.Forms.Button btnRForward;
        private System.Windows.Forms.Button btnCamDefault;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemPlane;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemClear;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemBox;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemLightSource;
    }
}

