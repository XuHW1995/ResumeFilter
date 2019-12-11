using Aspose.Cells;
using System;
using System.Collections.Generic;
using System.IO;

namespace ResumeScreening
{
    public static class ExportHelp
    {
        public static void ExportExcel(string Path)
        {

        }

        /// <summary>
        /// 表头信息
        /// int:列数
        /// string:列名
        /// </summary>
        public static Dictionary<int, string> ExcelHeadDic = new Dictionary<int, string>
        {
            { 1, "期望地点" },
            { 2, "简历编号" },
            { 3, "姓名" },
            { 4, "性别" },
            { 5, "年龄" },
            { 6, "手机号码" },
            { 7, "电子邮件" },
            { 8, "公司名称" },
            { 9, "教育经历" }
        };

        public static void DataExport(List<ResumeData> dataList, string filepath)
        {
            Workbook book = new Workbook(); //创建工作簿
            Worksheet sheet = book.Worksheets[0]; //创建工作表
            sheet.Name = "简历筛选";
            Cells cells = sheet.Cells; //单元格

            //创建表头
            for (int i = 0; i<= ExcelHeadDic.Count-1; i++)
            {
                cells[0, i].PutValue(ExcelHeadDic[i+1]);
            }

            //生成数据行（从第2行开始，第一行为列名）
            for (int row = 0; row < dataList.Count; row++)
            {
                //期望地
                cells[1 + row, 0].PutValue(dataList[row].TargetPlace);
                //简历编号
                cells[1 + row, 1].PutValue(dataList[row].ResumeId);
                //姓名
                cells[1 + row, 2].PutValue(dataList[row].Name);
                //性别
                cells[1 + row, 3].PutValue(dataList[row].Gender);
                //年龄
                cells[1 + row, 4].PutValue(dataList[row].Age);
                //手机号
                cells[1 + row, 5].PutValue(dataList[row].PhoneNumber);
                //邮箱
                cells[1 + row, 6].PutValue(dataList[row].EmailAddress);
                //公司名字
                cells[1 + row, 7].PutValue(dataList[row].CurrentCompanyName);
                //学校名字
                cells[1 + row, 8].PutValue(dataList[row].MaxEducationInfo.SchoolName);
                //专业
                cells[1 + row, 9].PutValue(dataList[row].MaxEducationInfo.Specialty);
                //学历名
                cells[1 + row, 10].PutValue(dataList[row].MaxEducationInfo.LevelName);
            }

            sheet.AutoFitColumns();
            book.Save(filepath);
            GC.Collect();
            }
    }
}


