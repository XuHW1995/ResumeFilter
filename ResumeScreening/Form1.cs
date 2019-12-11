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

        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Text = folderBrowserDialog1.SelectedPath;

                DirectoryInfo folder = new DirectoryInfo(folderBrowserDialog1.SelectedPath);
                FileInfo[] fils = folder.GetFiles("*.doc;*.docx");
                //DirectoryInfo[] diis = folder.GetDirectories();

                foreach (FileInfo file in fils)
                {
                    Document thisdoc = new Document(file.FullName);
                    ResumeData thisResume = ResumeSelect.CheckResume(thisdoc);
                    resumeList.Add(thisResume);
                }


                ExportHelp.DataExport(resumeList, SaveBox.Text + "\\a.xls");
            }
        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            textBox1.Text = openFileDialog1.FileName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void MsgBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BeginButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                Document thisdoc = new Document(textBox1.Text);

                string log = "******************筛选开始****************\n";
                ResumeData thisResume = ResumeSelect.CheckResume(thisdoc);
                log += thisResume.ToString() + "\n";
                log += "******************筛选结束****************";
                richTextBox1.Text = log;
            }           
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                SaveBox.Text = folderBrowserDialog1.SelectedPath;               
            }
        }
    }
}
