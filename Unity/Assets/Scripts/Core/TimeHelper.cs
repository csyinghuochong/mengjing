using System;
using System.Collections.Generic;
using System.Globalization;

namespace ET
{
    public static class TimeHelper
    {
        public const long OneDay = 86400000;
        public const long Hour = 3600000;
        public const long Minute = 60000;
        public const long Second = 1000;

        /// <summary>
        /// 客户端时间
        /// </summary>
        /// <returns></returns>
        public static long ClientNow()
        {
            return TimeInfo.Instance.ClientNow();
        }

        public static long ClientNowSeconds()
        {
            return ClientNow() / 1000;
        }

        public static DateTime DateTimeNow()
        {
            return DateTime.Now;
        }

        public static long ServerNow()
        {
            return TimeInfo.Instance.ServerNow();
        }

        public static long ClientFrameTime()
        {
            return TimeInfo.Instance.ClientFrameTime();
        }

        public static long ServerFrameTime()
        {
            return TimeInfo.Instance.ServerFrameTime();
        }

        public static string ShowTimeDifferenceStr(DateTime dt1, DateTime dt2)
        {
            //Log.Info("dt1 = " + dt1.ToString() + " dt2 = " + dt2.ToString());
            TimeSpan dt = dt1 - dt2;
            string returnStr = "";
            if (dt.Days >= 1)
            {
                returnStr = dt.Days + "天";
            }

            if (dt.Hours >= 1)
            {
                returnStr += dt.Hours + "时";
            }

            if (dt.Minutes >= 1)
            {
                returnStr += dt.Minutes + "分";
            }

            return returnStr;
        }

        public static string TimeToShowCostTimeStr(long time, int addHours)
        {
            DateTime dt1 = TimeInfo.Instance.ToDateTime(time);
            dt1 = dt1.AddHours(addHours);
            DateTime dt2 = TimeHelper.DateTimeNow();
            //TimeSpan dt = dt1 - dt2;
            //Log.Info("dt1 = " + dt1.ToString() + " dt2 = " + dt2.ToString());
            return ShowTimeDifferenceStr(dt1, dt2);
        }

        public static string FormatSecondsToTime(long mseconds)
        {
            int seconds = (int)Math.Floor(mseconds * 0.001f);
            
            // 计算分钟数
            int minutes = seconds / 60;
            // 计算剩余的秒数
            int remainingSeconds = seconds % 60;

            // 使用字符串格式化将分钟和秒数转换为 00:00 格式
            return $"{minutes:D2}:{remainingSeconds:D2}";
        }
        
        public static string FormatTimestampToTime(long timestamp)
        {
            // 计算小时数
            DateTime dateTime = TimeInfo.Instance.ToDateTime(timestamp);
            int hours = dateTime.Hour;


            int minutes = dateTime.Minute;

            int seconds = dateTime.Second;

            // 使用字符串格式化输出 00:00:00 格式的时间
            return $"{hours:D2}:{minutes:D2}:{seconds:D2}";
        }
        
        public static string ShowLeftTime(long time)
        {
            string str = "";
            time = time / 1000;

            if (time > 24 * 60 * 60)
            {
                str += $"{time / (24 * 60 * 60)}天";
                time %= 24 * 60 * 60;
            }

            str += $"{time / (60 * 60)}时";
            time %= 60 * 60;
            str += $"{time / 60}分";
            str += $"{time % 60}秒";
            return str;
        }

        public static string ShowLeftTime2(long time)
        {
            string str = "";
            time = time / 1000;

            if (time > 24 * 60 * 60)
            {
                str += $"{time / (24 * 60 * 60)}天";
                time %= 24 * 60 * 60;
            }

            str += $"{Math.Ceiling(time * 1f/ (60 * 60))}时";
            return str;
        }

        public static string ShowLeftTime3(long seconds)
        {
            // int hours = (int)Math.Ceiling(time * 1f/ Hour);
            // int minutes =  (int)Math.Ceiling((time - hours * Hour) * 1f/ Minute);
            //
            // // 使用字符串格式化输出 00:00:00 格式的时间
            // return $"{hours:D2}:{minutes:D2}:{seconds:D2}";
            TimeSpan time = TimeSpan.FromSeconds(seconds);
            return time.ToString(@"hh\:mm\:ss");
        }
        
        public static bool IsInTime(List<int> openTime)
        {
            DateTime dateTime = TimeHelper.DateTimeNow();
            int openTime_1 = openTime[0];
            int openTime_2 = openTime[1];
            int closeTime_1 = openTime[2];
            int closeTime_2 = openTime[3];
            int startTime = openTime_1 * 100 + openTime_2;
            int endTime = closeTime_1 * 100 + closeTime_2;
            int curTime = dateTime.Hour * 100 + dateTime.Minute;
            bool inTime = curTime >= startTime && curTime <= endTime;
            return inTime;
        }

        public static int GetServeOpenDay(long openSerTime)
        {
            long serverNow = TimeHelper.ServerNow();
            if (openSerTime == 0 || serverNow < openSerTime)
            {
                return 0;
            }
        
            int openserverDay = TimeHelper.DateDiff_Time(serverNow, openSerTime);
            return openserverDay;
        }
        
        public static int DateDiff_Time(long time1, long time2)
        {
            DateTime d1 = TimeInfo.Instance.ToDateTime(time1);
            DateTime d2 = TimeInfo.Instance.ToDateTime(time2);
            DateTime d3 = Convert.ToDateTime(string.Format("{0}-{1}-{2}", d1.Year, d1.Month, d1.Day));
        
            DateTime d4 = Convert.ToDateTime(string.Format("{0}-{1}-{2}", d2.Year, d2.Month, d2.Day));
            int days = (d3 - d4).Days + 1;
            return days;
        }
        
        public static bool IsInTime(string openTime)
        {
            DateTime dateTime = TimeHelper.DateTimeNow();
            string[] openTimes = openTime.Split('@');
            int openTime_1 = int.Parse(openTimes[0].Split(';')[0]);
            int openTime_2 = int.Parse(openTimes[0].Split(';')[1]);
            int closeTime_1 = int.Parse(openTimes[1].Split(';')[0]);
            int closeTime_2 = int.Parse(openTimes[1].Split(';')[1]);
            int startTime = openTime_1 * 100 + openTime_2;
            int endTime = closeTime_1 * 100 + closeTime_2;
            int curTime = dateTime.Hour * 100 + dateTime.Minute;
            bool inTime = curTime >= startTime && curTime <= endTime;
            return inTime;
        }
    }
}