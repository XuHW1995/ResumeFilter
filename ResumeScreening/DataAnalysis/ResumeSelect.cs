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
            IdContent,
            PersonInfo ,
            CurWorkInfo,
            WorkFuture,
            Education,
        }

        /// <summary>
        /// 分析当前简历，确认表格ID划分
        /// </summary>
        /// <returns></returns>
        private static Dictionary<ResumeContentEnum, Table> GetInfoName2TableDic(Document resumeDoc)
        {
            Dictionary<ResumeContentEnum, Table> infoName2Table = new Dictionary<ResumeContentEnum, Table>();

            for (int sectionIndex = 0; sectionIndex < resumeDoc.Sections.Count; sectionIndex++)
            {
                TableCollection thisSectionTables = resumeDoc.Sections[sectionIndex].Body.Tables;
                for (int tableIndex = 0; tableIndex < thisSectionTables.Count; tableIndex ++)
                {
                    //简历编号默认在第0章节第0个表
                    if (sectionIndex == 0 && tableIndex == 0)
                    {
                        infoName2Table.Add(ResumeContentEnum.IdContent, thisSectionTables[tableIndex]);
                    }

                    string tableStr = ResumeFormatHelp.DefaultFormat(thisSectionTables[tableIndex].GetText());
                    //TODO 个人信息和下面的三栏不在一个段落里识别不了，是个bug
                    if (tableStr == "个人信息")
                    {
                        if (thisSectionTables.Count > tableIndex + 3)
                        {
                            infoName2Table.Add(ResumeContentEnum.PersonInfo, thisSectionTables[tableIndex + 1]);
                            infoName2Table.Add(ResumeContentEnum.CurWorkInfo, thisSectionTables[tableIndex + 2]);
                            infoName2Table.Add(ResumeContentEnum.WorkFuture, thisSectionTables[tableIndex + 3]);
                        }
                    }

                    //TODO 教育经历和 学校不在一个段落里识别不了，是个bug
                    if (tableStr == "教育经历")
                    {
                        if (thisSectionTables.Count >tableIndex + 1)
                        {
                            infoName2Table.Add(ResumeContentEnum.Education, thisSectionTables[tableIndex + 1]);
                        }
                    }

                }
            }

            return infoName2Table;
        }

        /// <summary>
        /// 检查简历，返回所需简历数据
        /// </summary>
        /// <param name="resumeDoc"></param>
        /// <returns></returns>
        public static ResumeData CheckResume(Document resumeDoc)
        {
            try
            {
                ResumeData thisData = new ResumeData();
                Dictionary<ResumeContentEnum, Table> thisResumeTable = GetInfoName2TableDic(resumeDoc);

                //期望地点
                if (thisResumeTable.ContainsKey(ResumeContentEnum.WorkFuture))
                {
                    thisData.TargetPlace = ResumeFormatHelp.DefaultFormat(thisResumeTable[ResumeContentEnum.WorkFuture].Rows[3].Cells[1].GetText());
                }

                //简历编号
                if (thisResumeTable.ContainsKey(ResumeContentEnum.IdContent))
                {                
                    thisData.ResumeId = ResumeFormatHelp.FormatResumeId(thisResumeTable[ResumeContentEnum.IdContent].Rows[1].Cells[0].GetText());
                }

                //基本信息
                if (thisResumeTable.ContainsKey(ResumeContentEnum.PersonInfo))
                {
                    //姓名
                    thisData.Name = ResumeFormatHelp.DefaultFormat(thisResumeTable[ResumeContentEnum.PersonInfo].Rows[0].Cells[1].GetText());

                    //性别
                    thisData.Gender = ResumeFormatHelp.DefaultFormat(thisResumeTable[ResumeContentEnum.PersonInfo].Rows[0].Cells[3].GetText());

                    //手机
                    thisData.PhoneNumber = ResumeFormatHelp.DefaultFormat(thisResumeTable[ResumeContentEnum.PersonInfo].Rows[1].Cells[1].GetText());

                    //年龄
                    thisData.Age = ResumeFormatHelp.DefaultFormat(thisResumeTable[ResumeContentEnum.PersonInfo].Rows[1].Cells[3].GetText());

                    //电子邮箱
                    thisData.EmailAddress = ResumeFormatHelp.DefaultFormat(thisResumeTable[ResumeContentEnum.PersonInfo].Rows[2].Cells[1].GetText());
                }

                //教育经历
                if (thisResumeTable.ContainsKey(ResumeContentEnum.Education))
                {
                    thisData.MaxEducationInfo = GetMaxEducationData(thisResumeTable[ResumeContentEnum.Education]);
                }

                //当前公司名字
                if (thisResumeTable.ContainsKey(ResumeContentEnum.CurWorkInfo))
                {
                    thisData.CurrentCompanyName = ResumeFormatHelp.DefaultFormat(thisResumeTable[ResumeContentEnum.CurWorkInfo].Rows[1].Cells[3].GetText());
                }

                return thisData;
            }
            catch
            {
                return null;
            }           
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
