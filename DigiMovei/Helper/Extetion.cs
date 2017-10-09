using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace DigiMovei.Helper
{
    public static class Extetion
    {
        
            public static String ToPersian(this DateTime dt)
            {
                PersianCalendar pc = new PersianCalendar();
                int year = pc.GetYear(dt);
                int month = pc.GetMonth(dt);
                int day = pc.GetDayOfMonth(dt);
                int hour = pc.GetHour(dt);
                int min = pc.GetMinute(dt);

                DateTime PersianDateTime = new DateTime(year, month, day, hour, min, 0);

                return PersianDateTime.ToString("yyyy/MM/dd HH:mm");
            }

            public static DateTime ToMiladi(this DateTime dt)
            {
                PersianCalendar pc = new PersianCalendar();
                return pc.ToDateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, 0, 0);
            }

            public static T CastTo<T>(this object obj)
            {
                return (T)obj;
            }


        }

    }
