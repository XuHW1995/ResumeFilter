namespace ResumeScreening
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.selectResumeFolder = new System.Windows.Forms.Button();
            this.log = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.selectResumeButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BeginButton = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.SaveBox = new System.Windows.Forms.TextBox();
            this.SelectSaveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // selectResumeFolder
            // 
            this.selectResumeFolder.Location = new System.Drawing.Point(28, 75);
            this.selectResumeFolder.Name = "selectResumeFolder";
            this.selectResumeFolder.Size = new System.Drawing.Size(154, 23);
            this.selectResumeFolder.TabIndex = 0;
            this.selectResumeFolder.Text = "选择简历目录";
            this.selectResumeFolder.UseVisualStyleBackColor = true;
            this.selectResumeFolder.Click += new System.EventHandler(this.button1_Click);
            // 
            // log
            // 
            this.log.AutoSize = true;
            this.log.Location = new System.Drawing.Point(27, 203);
            this.log.Name = "log";
            this.log.Size = new System.Drawing.Size(41, 12);
            this.log.TabIndex = 1;
            this.log.Text = "信息台";
            this.log.Click += new System.EventHandler(this.label1_Click);
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.HelpRequest += new System.EventHandler(this.folderBrowserDialog1_HelpRequest);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // selectResumeButton
            // 
            this.selectResumeButton.Location = new System.Drawing.Point(278, 75);
            this.selectResumeButton.Name = "selectResumeButton";
            this.selectResumeButton.Size = new System.Drawing.Size(155, 23);
            this.selectResumeButton.TabIndex = 2;
            this.selectResumeButton.Text = "选择简历";
            this.selectResumeButton.UseVisualStyleBackColor = true;
            this.selectResumeButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(28, 48);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(405, 21);
            this.textBox1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "选择简历目录或文件";
            // 
            // BeginButton
            // 
            this.BeginButton.Location = new System.Drawing.Point(146, 192);
            this.BeginButton.Name = "BeginButton";
            this.BeginButton.Size = new System.Drawing.Size(160, 23);
            this.BeginButton.TabIndex = 6;
            this.BeginButton.Text = "开始数据筛选";
            this.BeginButton.UseVisualStyleBackColor = true;
            this.BeginButton.Click += new System.EventHandler(this.BeginButton_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(25, 228);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(405, 261);
            this.richTextBox1.TabIndex = 7;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // SaveBox
            // 
            this.SaveBox.Location = new System.Drawing.Point(29, 143);
            this.SaveBox.Name = "SaveBox";
            this.SaveBox.Size = new System.Drawing.Size(401, 21);
            this.SaveBox.TabIndex = 8;
            this.SaveBox.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // SelectSaveButton
            // 
            this.SelectSaveButton.Location = new System.Drawing.Point(106, 114);
            this.SelectSaveButton.Name = "SelectSaveButton";
            this.SelectSaveButton.Size = new System.Drawing.Size(239, 23);
            this.SelectSaveButton.TabIndex = 9;
            this.SelectSaveButton.Text = "选择数据导出目录";
            this.SelectSaveButton.UseVisualStyleBackColor = true;
            this.SelectSaveButton.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 522);
            this.Controls.Add(this.SelectSaveButton);
            this.Controls.Add(this.SaveBox);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.BeginButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.selectResumeButton);
            this.Controls.Add(this.log);
            this.Controls.Add(this.selectResumeFolder);
            this.Name = "MainForm";
            this.Text = "简历检索工具";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button selectResumeFolder;
        private System.Windows.Forms.Label log;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button selectResumeButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BeginButton;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TextBox SaveBox;
        private System.Windows.Forms.Button SelectSaveButton;
    }
}

