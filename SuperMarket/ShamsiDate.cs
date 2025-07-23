using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class ShamsiDate
    {
        public static string m2shamsi(DateTime d)
        {
            PersianCalendar percalender = new PersianCalendar();
            StringBuilder sb = new StringBuilder();
            sb.Append(percalender.GetYear(d).ToString("00"));
            sb.Append("/");
            sb.Append(percalender.GetMonth(d).ToString("00"));
            sb.Append("/");
            sb.Append(percalender.GetDayOfMonth(d).ToString("00"));
            return sb.ToString();   

        }
    }
}
