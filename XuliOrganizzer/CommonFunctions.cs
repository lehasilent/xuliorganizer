using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

/* 
 * 
 * 
 * 
 * 
 * 
 */

public enum FormBehavior
{
    Hide = 0,
    Close = 1
}
namespace XuliOrganizzer
{
    public static class CommonFunctions
    {
        public static NotifyIcon globalNI = null;
        public static Icon[] niIcons16 = new Icon[] 
                        {   
                            XuliOrganizzer.Properties.Resources.Clock1,
                            XuliOrganizzer.Properties.Resources.Clock2,
                            XuliOrganizzer.Properties.Resources.Clock3,
                            XuliOrganizzer.Properties.Resources.Clock4,
                        };
        public static int GetSecounds(int H, int M, int S)
        {
            return H * 60 * 60 + M * 60 + S;
        }

        public static string TempFileWrite(byte[] buf)
        {
            string FileName = Path.GetTempPath() + Path.GetRandomFileName();

            try
            {
                File.WriteAllBytes(FileName, buf);                       
                return FileName;
            }
            catch
            {
                return string.Empty;
            }
        }

        #region AllRecordsFunc
        public static string AtCRLF(string Orig)
        {            
            string[] sep = new string[] { "\r\n" };
            string[] CRLFstrings = Orig.Split(sep, StringSplitOptions.None);

            for (int i = 0; i < CRLFstrings.Length; i++)
            {
                CRLFstrings[i] = CRLFstrings[i].Replace("\n", "\r\n");
            }

            return string.Join("\r\n", CRLFstrings);
        }

        public static string AddToSize(string Str, char AddChr, int Size, bool Right)
        {
            if (Str.Length >= Size) return Str;

            if (Right)
            {
                Str = Str.PadRight(Size, AddChr);
            }
            else
            {
                Str = Str.PadLeft(Size, AddChr);
            }

            return Str;
        }

        public static string EscapeLikeValue(string valueWithoutWildcards)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < valueWithoutWildcards.Length; i++)
            {
                char c = valueWithoutWildcards[i];
                if (c == '*' || c == '%' || c == '[' || c == ']')
                    sb.Append("[").Append(c).Append("]");
                else if (c == '\'')
                    sb.Append("''");
                else
                    sb.Append(c);
            }
            return sb.ToString();
        }
        #endregion


        public static void ErrMessage(string Mess)
        {
            MessageBox.Show(Mess, "Error", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        public static void InfoMessage(string Message, string Caption)
        {
            MessageBox.Show(Message, Caption, MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }


        public static string GetDayName (DayOfWeek dow)
        {
            switch (dow)
            {
                case DayOfWeek.Friday: return "Пятница";
                case DayOfWeek.Monday: return "Понедельник";
                case DayOfWeek.Saturday: return "Суббота";
                case DayOfWeek.Sunday: return "Воскресенье";
                case DayOfWeek.Thursday: return "Четверг";
                case DayOfWeek.Tuesday: return "Вторник";
                case DayOfWeek.Wednesday: return "Среда";
                default: return string.Empty; 
            }
        }

        public static int GetDayNumber(string DayName)
        {
            switch (DayName)
            {
                case "Понедельник": return 1;
                case "Вторник": return 2;
                case "Среда": return 3;
                case "Четверг": return 4;
                case "Пятница": return 5;
                case "Суббота": return 6;
                case "Воскресенье": return 7;
                default: return -1;
            }
        }
        
        public static DayOfWeek GetDayOfWeek(string DayName)
        {
            switch (DayName)
            {
                case "Понедельник": return DayOfWeek.Monday;
                case "Вторник": return DayOfWeek.Tuesday;
                case "Среда": return DayOfWeek.Wednesday;
                case "Четверг": return DayOfWeek.Thursday;
                case "Пятница": return DayOfWeek.Friday;
                case "Суббота": return DayOfWeek.Saturday;
                case "Воскресенье": return DayOfWeek.Sunday;
                default: return DayOfWeek.Monday;
            }
        }

        public static int GetMonthNumber(string MounthName)
        {
            switch (MounthName)
            {
                case "Январь": return 1;
                case "Февраль": return 2;
                case "Март": return 3;
                case "Апрель": return 4;
                case "Май": return 5;
                case "Июнь": return 6;
                case "Июль": return 7;
                case "Август": return 8;
                case "Сентябрь": return 9;
                case "Октябрь": return 10;
                case "Ноябрь": return 11;
                case "Декабрь": return 12;
                default: return -1;
            }
        }

        public static string GetMonthName(int Number)
        {
            switch (Number)
            {
                case 1: return "Январь";
                case 2: return "Февраль";
                case 3: return "Март";
                case 4: return "Апрель";
                case 5: return "Май";
                case 6: return "Июнь";
                case 7: return "Июль";
                case 8: return "Август";
                case 9: return "Сентябрь";
                case 10: return "Октябрь";
                case 11: return "Ноябрь";
                case 12: return "Декабрь";
                default: return string.Empty;
            }
        }
        
        
    }
}
