using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Aspose.Words;
using System.IO;

namespace ResumeScreening
{
    public partial class MainForm : Form
    {
        public List<ResumeData> resumeList = new List<ResumeData>();
        private string m_ExportExcelName = "简历筛选表.xlsx"; 

        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 选择简历文件夹
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void selectResumeFolderButton_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                SelectBox.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        /// <summary>
        /// 选择文件对话框OK回调
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            SelectBox.Text = openFileDialog1.FileName;
        }

        /// <summary>
        /// 选择单个简历文件按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void selectResumeFileButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        /// <summary>
        /// 开始筛选按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void beginButton_Click(object sender, EventArgs e)
        {
            if (File.Exists(SelectBox.Text))
            {
                AnalysisOne();
            }
            else if (Directory.Exists(SelectBox.Text))
            {
                if (!string.IsNullOrEmpty(SaveBox.Text))
                {
                    BatchAnalysis();
                }
                else
                {
                    MsgBox.Text = "不选输出目录分析完存哪？？？";
                }
            }
            else
            {
                MsgBox.Text = "选择目录或文件不合法！！！";
            }
        }

        private void SavePathBox_TextChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 选择导出表目录按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectSaveFolderButton_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                SaveBox.Text = folderBrowserDialog1.SelectedPath;               
            }
        }

        #region
        /// <summary>
        /// 批量简历分析
        /// </summary>
        private void BatchAnalysis()
        {
            DirectoryInfo folder = new DirectoryInfo(SelectBox.Text);
            FileInfo[] docFiles = folder.GetFiles("*.doc");

            foreach (FileInfo file in docFiles)
            {
                Document thisDoc = new Document(file.FullName);
                ResumeData thisResumeData = ResumeSelect.CheckResume(thisDoc);
                resumeList.Add(thisResumeData);
            }

            FileInfo[] docxFiles = folder.GetFiles("*.docx");
            foreach (FileInfo file in docxFiles)
            {
                Document thisDoc = new Document(file.FullName);
                ResumeData thisResumeData = ResumeSelect.CheckResume(thisDoc);
                resumeList.Add(thisResumeData);
            }

            ExportHelp.DataExport(resumeList, SaveBox.Text + "\\" + m_ExportExcelName);


            MsgBox.Text = "******************简历筛选完毕*****************\n共筛选简历份数："+ resumeList.Count;
        }

        /// <summary>
        /// 单个简历分析直接输出数据到控制台
        /// </summary>
        private void AnalysisOne()
        {
            Document thisdoc = new Document(SelectBox.Text);
            ResumeData thisResume = ResumeSelect.CheckResume(thisdoc);
            MsgBox.Text = thisResume.ToString();
        }

        #endregion
    }
}
