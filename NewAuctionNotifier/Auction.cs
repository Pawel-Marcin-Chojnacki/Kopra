using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kopra.NewAuctionNotifier
{
    public sealed class Auction
    {
            public string id { get; set; }
            public string user_id { get; set; }
            public string user { get; set; }
            public string title { get; set; }
            public string value { get; set; }
            public string period { get; set; }
            public string percent
            {
                get
                {
                    double a = Double.Parse(_percent, CultureInfo.InvariantCulture);
                    return Math.Round(a) + "%";
                }
                set
                {
                    _percent = value;
                }

            }
            public string createDate
            {
                get
                {
                    DateTime niceDate = new DateTime();
                    niceDate = Convert.ToDateTime(_date).ToUniversalTime();
                    Debug.WriteLine("niceDate: " + niceDate);
                    return FormatDate(niceDate);
                }
                set
                {
                    _date = value;
                }
            }
            public int timeToEnd { get; set; }
            public string numberOfOffers { get; set; }
            public string insuranceNumber { get; set; }
            public string insuranceFirm { get; set; }
            public string paid { get; set; }
            public string monthlyInstallment { get; set; }
            public string firstPayData { get; set; }
            public string status { get; set; }
            public string rating { get; set; }
            public string gg { get; set; }
            public string skype { get; set; }
            public string linkedin { get; set; }
            public string goldenline { get; set; }
            public string facebook { get; set; }
            public string nk { get; set; }
            public string www { get; set; }
            public string profilSLPozycz { get; set; }
            public string profilSLZakra { get; set; }
            public string profilSLSekrata { get; set; }
            public string profilSLFinansowo { get; set; }
            public string profilAllegro { get; set; }
            public string profilSLOther { get; set; }
            public string finishDate { get; set; }

            private string _percent;
            private string _date;

            private TimeSpan UTCTimeToLocalTime(TimeSpan localTime)
            {
                DateTime utc = new DateTime();
                try
                {
                    Debug.WriteLine("localTime: " + localTime);
                    var dt = new DateTime(localTime.Ticks);
                    //Debug.WriteLine("dt: " + dt);
                    utc = dt.ToLocalTime();
                    //Debug.WriteLine("utc: " + utc);
                }
                catch (Exception) { }
                return new TimeSpan(utc.Ticks);
            }

            private string FormatDate(DateTime datetimeUTC)
            {
                var difference = UTCTimeToLocalTime(datetimeUTC.TimeOfDay);
                Debug.WriteLine(difference);
                if (difference.TotalDays > 30)
                    return datetimeUTC.ToLocalTime().ToString("yyyy-MM-dd");
                if (difference.TotalDays > 1)
                    return String.Format("{0} dni temu", difference.TotalDays.ToString("0"));

                if (difference.TotalDays == 1)
                    return string.Format("wczoraj", difference.TotalDays.ToString("0"));
                if (difference.TotalHours >= 22)
                    return string.Format("{0} godziny temu", difference.TotalHours.ToString("0"));
                if (difference.TotalHours >= 5)
                    return string.Format("{0} godzin temu", difference.TotalHours.ToString("0"));
                if (difference.TotalHours >= 2)
                    return string.Format("{0} godziny temu", difference.TotalHours.ToString("0"));
                if (difference.TotalHours == 1)
                    return "godzinę temu";

                if (difference.TotalMinutes >= 2)
                {
                    if (difference.TotalMinutes % 10 >= 5 || difference.TotalMinutes % 10 <= 1)
                        return string.Format("{0} minut temu", difference.TotalHours.ToString("0"));
                    return string.Format("{0} minuty temu", difference.TotalHours.ToString("0"));
                }
                if (difference.TotalMinutes == 1) return "minutę temu";

                return "w ciągu ostatniej minuty";
            }
    }
}
