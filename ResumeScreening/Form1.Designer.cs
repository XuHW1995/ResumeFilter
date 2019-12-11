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
            this.MsgBoxTitle = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.selectResumeFile = new System.Windows.Forms.Button();
            this.SelectBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.selectPathTitle = new System.Windows.Forms.Label();
            this.BeginButton = new System.Windows.Forms.Button();
            this.MsgBox = new System.Windows.Forms.RichTextBox();
            this.SaveBox = new System.Windows.Forms.TextBox();
            this.SelectSaveFolder = new System.Windows.Forms.Button();
            this.outputPathTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // selectResumeFolder
            // 
            this.selectResumeFolder.Location = new System.Drawing.Point(337, 46);
            this.selectResumeFolder.Name = "selectResumeFolder";
            this.selectResumeFolder.Size = new System.Drawing.Size(110, 23);
            this.selectResumeFolder.TabIndex = 0;
            this.selectResumeFolder.Text = "选择简历目录";
            this.selectResumeFolder.UseVisualStyleBackColor = true;
            this.selectResumeFolder.Click += new System.EventHandler(this.selectResumeFolderButton_Click);
            // 
            // MsgBoxTitle
            // 
            this.MsgBoxTitle.AutoSize = true;
            this.MsgBoxTitle.Location = new System.Drawing.Point(26, 200);
            this.MsgBoxTitle.Name = "MsgBoxTitle";
            this.MsgBoxTitle.Size = new System.Drawing.Size(41, 12);
            this.MsgBoxTitle.TabIndex = 1;
            this.MsgBoxTitle.Text = "信息台";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // selectResumeFile
            // 
            this.selectResumeFile.Location = new System.Drawing.Point(453, 46);
            this.selectResumeFile.Name = "selectResumeFile";
            this.selectResumeFile.Size = new System.Drawing.Size(121, 23);
            this.selectResumeFile.TabIndex = 2;
            this.selectResumeFile.Text = "选择简历";
            this.selectResumeFile.UseVisualStyleBackColor = true;
            this.selectResumeFile.Click += new System.EventHandler(this.selectResumeFileButton_Click);
            // 
            // SelectBox
            // 
            this.SelectBox.Location = new System.Drawing.Point(28, 48);
            this.SelectBox.Name = "SelectBox";
            this.SelectBox.Size = new System.Drawing.Size(303, 21);
            this.SelectBox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 0;
            // 
            // selectPathTitle
            // 
            this.selectPathTitle.AutoSize = true;
            this.selectPathTitle.Location = new System.Drawing.Point(26, 23);
            this.selectPathTitle.Name = "selectPathTitle";
            this.selectPathTitle.Size = new System.Drawing.Size(65, 12);
            this.selectPathTitle.TabIndex = 4;
            this.selectPathTitle.Text = "简历根目录";
            // 
            // BeginButton
            // 
            this.BeginButton.Location = new System.Drawing.Point(251, 152);
            this.BeginButton.Name = "BeginButton";
            this.BeginButton.Size = new System.Drawing.Size(96, 49);
            this.BeginButton.TabIndex = 6;
            this.BeginButton.Text = "开始数据筛选";
            this.BeginButton.UseVisualStyleBackColor = true;
            this.BeginButton.Click += new System.EventHandler(this.beginButton_Click);
            // 
            // MsgBox
            // 
            this.MsgBox.Location = new System.Drawing.Point(25, 226);
            this.MsgBox.Name = "MsgBox";
            this.MsgBox.Size = new System.Drawing.Size(538, 263);
            this.MsgBox.TabIndex = 7;
            this.MsgBox.Text = "";
            // 
            // SaveBox
            // 
            this.SaveBox.Location = new System.Drawing.Point(28, 108);
            this.SaveBox.Name = "SaveBox";
            this.SaveBox.Size = new System.Drawing.Size(303, 21);
            this.SaveBox.TabIndex = 8;
            this.SaveBox.TextChanged += new System.EventHandler(this.SavePathBox_TextChanged);
            // 
            // SelectSaveFolder
            // 
            this.SelectSaveFolder.Location = new System.Drawing.Point(337, 108);
            this.SelectSaveFolder.Name = "SelectSaveFolder";
            this.SelectSaveFolder.Size = new System.Drawing.Size(237, 23);
            this.SelectSaveFolder.TabIndex = 9;
            this.SelectSaveFolder.Text = "选择数据导出目录";
            this.SelectSaveFolder.UseVisualStyleBackColor = true;
            this.SelectSaveFolder.Click += new System.EventHandler(this.SelectSaveFolderButton_Click);
            // 
            // outputPathTitle
            // 
            this.outputPathTitle.AutoSize = true;
            this.outputPathTitle.Location = new System.Drawing.Point(26, 84);
            this.outputPathTitle.Name = "outputPathTitle";
            this.outputPathTitle.Size = new System.Drawing.Size(77, 12);
            this.outputPathTitle.TabIndex = 10;
            this.outputPathTitle.Text = "数据导出目录";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 522);
            this.Controls.Add(this.outputPathTitle);
            this.Controls.Add(this.SelectSaveFolder);
            this.Controls.Add(this.SaveBox);
            this.Controls.Add(this.MsgBox);
            this.Controls.Add(this.BeginButton);
            this.Controls.Add(this.selectPathTitle);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SelectBox);
            this.Controls.Add(this.selectResumeFile);
            this.Controls.Add(this.MsgBoxTitle);
            this.Controls.Add(this.selectResumeFolder);
            this.Name = "MainForm";
            this.Text = "简历检索工具";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button selectResumeFolder;
        private System.Windows.Forms.Label MsgBoxTitle;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button selectResumeFile;
        private System.Windows.Forms.TextBox SelectBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label selectPathTitle;
        private System.Windows.Forms.Button BeginButton;
        private System.Windows.Forms.RichTextBox MsgBox;
        private System.Windows.Forms.TextBox SaveBox;
        private System.Windows.Forms.Button SelectSaveFolder;
        private System.Windows.Forms.Label outputPathTitle;
    }
}

