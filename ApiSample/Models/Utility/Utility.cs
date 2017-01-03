using ApiSample.Models.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;


namespace ApiSample.Models
{
    public static class Utility
    {
        public static string MessageBox(MassageType Status, string OutPut = "", string result = "")
        {
            switch (Status)
            {
                case MassageType.Success:
                    return "<div class='alert alert-success fade in'><a href = '#' class='close' data-dismiss='alert' aria-label='close'>&times;</a> <strong > عملیات موفق ! </ strong >&nbsp&nbsp&nbsp ( " + OutPut + " : " + result + " )</div>";
                case MassageType.Error:
                    return "<div class='alert alert-danger fade in'><a href = '#' class='close' data-dismiss='alert' aria-label='close'>&times;</a> <strong > عملیات ناموفق ! </ strong >متاسفانه عملیات انجام نشد لطفا مقادیر ورودی خود را کنترل کنید.</div>";
                case MassageType.exception:
                    return "<div class='alert alert-danger fade in'><a href = '#' class='close' data-dismiss='alert' aria-label='close'>&times;</a> <strong > عملیات ناموفق ! </ strong >&nbsp&nbsp&nbsp ( " + OutPut + " )</div>";
                default:
                    return "<div class='alert alert-danger fade in'><a href = '#' class='close' data-dismiss='alert' aria-label='close'>&times;</a> <strong > عملیات ناموفق ! </ strong >متاسفانه عملیات انجام نشد لطفا مقادیر ورودی خود را کنترل کنید.</div>";
            }
        }

        public static string GeneralUrl()
        {
            return "http://api.smsapp.ir/";
        }

        public static double ConvertDatetimeToUnixTimeStamp(DateTime date, int Time_Zone = 0)
        {
            DateTime EPOCH = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
            TimeSpan The_Date = (date - EPOCH);
            return Math.Floor(The_Date.TotalSeconds) - (Time_Zone * 3600);
        }

        public static DateTime ConvertToDatetime(string DataTime)
        {
            DateTime dt = Convert.ToDateTime(DataTime);
            PersianCalendar pc = new PersianCalendar();
            DateTime DateTime = pc.ToDateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second, dt.Millisecond);
            return DateTime;
        }

        public static string TempFilePath()
        {
            return System.Web.Hosting.HostingEnvironment.MapPath("~\\App_Data\\Temp");
        }


    }
}