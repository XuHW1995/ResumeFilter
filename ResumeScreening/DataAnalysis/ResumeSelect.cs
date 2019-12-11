using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aspose.Words;
using Aspose.Words.Tables;

namespace ResumeScreening
{
    public static class ResumeSelect
    {
        /* 简历表构成
         0:简历编号，更新日期
         1：个人信息（标题）
         2：个人信息内容
         3：目前职业情况
         4：职业发展意向
         5：工作经历（标题）
         6：工作经历内容
         7：项目经历（标题）
         8：项目经历内容
         9：教育经历（标题）
         10：教育经历内容
        */
        /// <summary>
        /// 简历表内容枚举
        /// </summary>
        public enum ResumeContentEnum
        {
            IdContent = 0,
            PersonInfo = 2,
            CurWorkInfo = 3,
            WorkFuture = 4,
            Education = 10,
        }

        /// <summary>
        /// 检查简历，返回所需简历数据
        /// </summary>
        /// <param name="resumeDoc"></param>
        /// <returns></returns>
        public static ResumeData CheckResume(Document resumeDoc)
        {
            Body docContent = resumeDoc.FirstSection.Body;
            ResumeData thisData = new ResumeData();
            //简历编号
            thisData.ResumeId = ResumeFormatHelp.FormatResumeId(docContent.Tables[(int)ResumeContentEnum.IdContent].Rows[1].Cells[0].GetText());

            //姓名
            thisData.Name = ResumeFormatHelp.DefaultFormat(docContent.Tables[(int)ResumeContentEnum.PersonInfo].Rows[0].Cells[1].GetText());

            //性别
            thisData.Gender = ResumeFormatHelp.DefaultFormat(docContent.Tables[(int)ResumeContentEnum.PersonInfo].Rows[0].Cells[3].GetText());

            //手机
            thisData.PhoneNumber = ResumeFormatHelp.DefaultFormat(docContent.Tables[(int)ResumeContentEnum.PersonInfo].Rows[1].Cells[1].GetText());

            //年龄
            thisData.Age = ResumeFormatHelp.DefaultFormat(docContent.Tables[(int)ResumeContentEnum.PersonInfo].Rows[1].Cells[3].GetText());

            //电子邮箱
            thisData.EmailAddress = ResumeFormatHelp.DefaultFormat(docContent.Tables[(int)ResumeContentEnum.PersonInfo].Rows[2].Cells[1].GetText());

            //教育经历
            thisData.MaxEducationInfo = GetMaxEducationData(docContent.Tables[(int)ResumeContentEnum.Education]);

            //当前公司名字
            thisData.CurrentCompanyName = ResumeFormatHelp.DefaultFormat(docContent.Tables[(int)ResumeContentEnum.CurWorkInfo].Rows[1].Cells[3].GetText());

            return thisData;
        }

        /// <summary>
        /// 获取最高学历信息
        /// </summary>
        /// <param name="educationTable"></param>
        /// <returns></returns>
        private static EducationInfo GetMaxEducationData(Table educationTable)
        {
            EducationInfo maxEducationInfo = null;
            EducationLevel maxlevel = EducationLevel.Senior;

            for (int i = 0; i<= educationTable.Rows.Count-1; i++)
            {
                string levelName = ResumeFormatHelp.DefaultFormat(educationTable.Rows[i].Cells[2].GetText());
                EducationLevel thisLevel = GetEducationLevel(levelName);

                if (thisLevel > maxlevel)
                {
                    maxlevel = thisLevel;
                    string schoolName = ResumeFormatHelp.DefaultFormat(educationTable.Rows[i].Cells[0].GetText());
                    string specialty = ResumeFormatHelp.DefaultFormat(educationTable.Rows[i].Cells[1].GetText());

                    maxEducationInfo = new EducationInfo(schoolName, specialty, maxlevel, levelName);
                }
            }

            return maxEducationInfo;
        }

        /// <summary>
        /// 根据学历名字获取学历等级
        /// </summary>
        /// <param name="levelName"></param>
        /// <returns></returns>
        private static EducationLevel GetEducationLevel(string levelName)
        {
            if (levelName == "专科" || levelName == "大专")
            {
                return EducationLevel.Junior;
            }
            else if (levelName == "本科")
            {
                return EducationLevel.Regular;
            }
            else if (levelName == "硕士")
            {
                return EducationLevel.Master;
            }
            else if (levelName == "博士")
            {
                return EducationLevel.Doctor;
            }
            else
            {
                return EducationLevel.Senior;
            }
        }

    }
}
