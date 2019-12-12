using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ResumeScreening
{
    public enum EducationLevel
    {
        //高中及以下
        Senior = 0, 
        //专科
        Junior = 1,
        //本科
        Regular = 2,
        //硕士
        Master = 3,
        //博士
        Doctor = 4,
    }

    public class EducationInfo
    {
        /// <summary>
        /// 学校名字
        /// </summary>
        public string SchoolName = "";
        /// <summary>
        /// 在校时间
        /// </summary>
        public string Time = "";
        /// <summary>
        /// 专业名
        /// </summary>
        public string Specialty = "";
        /// <summary>
        /// 教育等级
        /// </summary>
        public EducationLevel Level = EducationLevel.Senior;
        /// <summary>
        /// 教育名字
        /// </summary>
        public string LevelName = "";

        public EducationInfo(string schoolName, string specialty, EducationLevel level, string levelName)
        {
            SchoolName = schoolName;
            Specialty = specialty;
            Level = level;
            LevelName = levelName;
        }
    }

    public class ResumeData
    {
        /// <summary>
        /// 期望工作地
        /// </summary>
        public string TargetPlace = "";

        /// <summary>
        /// 简历标号
        /// </summary>
        public string ResumeId = "";

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name = "";

        /// <summary>
        /// 性别
        /// </summary>
        public string Gender = "";

        /// <summary>
        /// 年龄
        /// </summary>
        public string Age = "";

        /// <summary>
        /// 手机号
        /// </summary>
        public string PhoneNumber = "";

        /// <summary>
        /// 电子邮箱
        /// </summary>
        public string EmailAddress = "";

        /// <summary>
        /// 教育信息
        /// </summary>
        public EducationInfo[] EducationInfos;

        /// <summary>
        /// 当前公司名字
        /// </summary>
        public string CurrentCompanyName = "";

        /// <summary>
        /// 最高学历信息
        /// </summary>
        public EducationInfo MaxEducationInfo = new EducationInfo("","",EducationLevel.Senior,"");

        public override string ToString()
        {
            string content = "";
            content += "简历编号：" + ResumeId + "\n";
            content += "姓名：" + Name + "\n";
            content += "性别：" + Gender + "\n";
            content += "年龄：" + Age + "\n";
            content += "电话：" + PhoneNumber + "\n";
            content += "Email：" + EmailAddress + "\n";
            content += "当前公司：" + CurrentCompanyName + "\n";
            content += "最高学历：" + MaxEducationInfo.LevelName + "\n";
            content += "最高学历学校：" + MaxEducationInfo.SchoolName+ "\n";
            content += "最高学历专业：" + MaxEducationInfo.Specialty + "\n";
            return content;
        }
    }
}
