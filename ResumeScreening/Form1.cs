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
using System.Threading;

namespace ResumeScreening
{
    public partial class MainForm : Form
    {
        #region 数据定义
        public List<ResumeData> resumeList = new List<ResumeData>();
        private string m_ExportExcelName = "简历筛选表.xlsx";
        private bool isAnalysis = false;
        #endregion

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

        /// <summary>
        /// 开始筛选按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void beginButton_Click(object sender, EventArgs e)
        {
            if (isAnalysis)
            {
                MsgBox.Text = "正在分析中！！！";
                return;
            }

            resumeList.Clear();

            if (File.Exists(SelectBox.Text))
            {
                AnalysisOne();
            }
            else if (Directory.Exists(SelectBox.Text))
            {
                if (!string.IsNullOrEmpty(SaveBox.Text))
                {
                    Thread childThread = new Thread(BatchAnalysis);
                    childThread.Start();                  
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

        #region 简历筛选方法
        /// <summary>
        /// 批量简历分析
        /// </summary>
        private void BatchAnalysis()
        {
            isAnalysis = true;
            int count = 0;
            int failCount = 0;
            string failName = "";

            var fileNames =  Directory.GetFiles(SelectBox.Text, "*.*", SearchOption.AllDirectories).Where(s => s.EndsWith(".doc") || s.EndsWith(".docx"));
            foreach(var fileName in fileNames)
            {
                count ++;
                FileInfo thisFile = new FileInfo(fileName);              
                Document thisDoc = new Document(thisFile.FullName);
                ResumeData thisResumeData = ResumeSelect.CheckResume(thisDoc);
                if (thisResumeData!= null)
                {
                    resumeList.Add(thisResumeData);
                    PrintMsg(thisFile.Name + "分析完毕！！！\n" + "已分析份数：" + count);
                }
                else
                {
                    failCount++;
                    failName += "\n" + fileName;
                }
            }

            ExportHelp.DataExport(resumeList, SaveBox.Text + "\\" + m_ExportExcelName);
            isAnalysis = false;           
            PrintMsg(string.Format("简历分析完毕,总共分析成功份数：{0}, 失败数：{1} \n 失败文件：\n{2}", count, failCount, failName));
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

        /// <summary>
        /// 线程安全输出日志
        /// </summary>
        /// <param name="logStr"></param>
        private void PrintMsg(string logStr)
        {
            if (MsgBox.InvokeRequired)
            {
                var d = new Action<string>(PrintMsg);
                MsgBox.Invoke(d, new object[] { logStr });
            }
            else
            {
                MsgBox.Text = logStr;
            }
        }
        #endregion
    }
}
