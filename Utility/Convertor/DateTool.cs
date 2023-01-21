using MD.PersianDateTime.Core;
using System;

namespace RadicalTherapy.Utility.Convertor
{
    public class DateTool
    {
        public static string MonthOfYear(PersianDateTime date)
        {
            string monthofyear;
            switch (date.Month)
            {
                case 1:
                    monthofyear = "فروردین"; break;
                case 2:
                    monthofyear = "اردیبهشت"; break;
                case 3:
                    monthofyear = "خرداد"; break;
                case 4:
                    monthofyear = "تیر"; break;
                case 5:
                    monthofyear = "مرداد"; break;
                case 6:
                    monthofyear = "شهریور"; break;
                case 7:
                    monthofyear = "مهر"; break;
                case 8:
                    monthofyear = "آبان"; break;
                case 9:
                    monthofyear = "آذر"; break;
                case 10:
                    monthofyear = "دی"; break;
                case 11:
                    monthofyear = "بهمن"; break;
                case 12:
                    monthofyear = "اسفند"; break;
                default:
                    monthofyear = "";
                    break;
            }
            return monthofyear;
        }
        public static string Dayofweek(DateTime date)
        {
            string dayofweek;
            switch (date.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    dayofweek = "یکشنبه"; break;
                case DayOfWeek.Monday:
                    dayofweek = "دو شنبه"; break;
                case DayOfWeek.Tuesday:
                    dayofweek = "سه شنبه"; break;
                case DayOfWeek.Wednesday:
                    dayofweek = "چهار شنبه"; break;
                case DayOfWeek.Thursday:
                    dayofweek = "پنج شنبه"; break;
                case DayOfWeek.Friday:
                    dayofweek = "جمعه"; break;
                case DayOfWeek.Saturday:
                    dayofweek = "شنبه"; break;
                default:
                    dayofweek = ""; break;
            }
            return dayofweek;
        }
    }

}
