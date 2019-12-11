using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ResumeScreening
{
    public static class ResumeFormatHelp
    {
        public static string DefaultFormat(string sourceStr)
        {
            sourceStr = sourceStr.Replace("\a", "");
            sourceStr = sourceStr.Replace(" ", "");
            sourceStr = sourceStr.Replace("：", ":");
            return sourceStr;
        }

        //格式化简历编号
        //简历编号:f6d3659bA26a26447
        public static string FormatResumeId(string idstr)
        {         
            string[] resultStr = DefaultFormat(idstr).Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);          
            return resultStr[1];
        }       
    }
}
