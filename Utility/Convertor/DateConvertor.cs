using MD.PersianDateTime.Core;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace RadicalTherapy.Utility.Convertor
{
    public static class DateConvertor
    {
        public static DateTime ToShamsi(this DateTime dt)
        {
            PersianCalendar pc = new PersianCalendar();
            return new DateTime(pc.GetYear(dt), pc.GetMonth(dt), pc.GetDayOfMonth(dt), pc.GetHour(dt), pc.GetMinute(dt), pc.GetSecond(dt));
        }
        public static PersianDateTime ToShamsi1(this DateTime dt)
        {
            PersianCalendar pc = new PersianCalendar();
            PersianDateTime datetimePersianDateTime=new PersianDateTime(pc.GetYear(dt), pc.GetMonth(dt), pc.GetDayOfMonth(dt), pc.GetHour(dt), pc.GetMinute(dt), pc.GetSecond(dt));

            return datetimePersianDateTime;
         }
    }
}
