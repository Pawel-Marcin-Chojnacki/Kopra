using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Kopra
{
    public class SearchAuctionResult
    {
        public Response Response { get; set; }
    }

    public abstract class Paging
    {
        public int Page { get; set; }
        public string Total { get; set; }
        public int PageSize { get; set; }
        public int Pages { get; set; }
    }

    public class Auction
    {
        
        public string Id { get; set; }
        public string UserId { get; set; }
        public string User { get; set; }
        public string Title { get; set; }
        public string Value { get; set; }
        public string Period { get; set; }
        public string Percent {
            get
            {
                double a = Convert.ToDouble(_percent);
                return Math.Round(a)+"%";
            }
             set
            {
                _percent = value;
            }

        }

        /// <summary>
        /// 
        /// </summary>
        public string CreateDate {
            get
            {
                DateTime niceDate = new DateTime();
                niceDate = Convert.ToDateTime(_date).ToUniversalTime();
                Debug.WriteLine("niceDate: " +niceDate);
                return FormatDate(niceDate);
            }
            set
            {
                _date = value;
            }
        }

        private string _percent;
        private string _date;

        private TimeSpan UtcTimeToLocalTime(TimeSpan localTime)
        {
            DateTime utc = new DateTime();
            try
            {
                Debug.WriteLine("localTime: " + localTime);
                var dt = new DateTime(localTime.Ticks);
                Debug.WriteLine("dt: " + dt);
                utc = dt.ToLocalTime();
                Debug.WriteLine("utc: " + utc);
            }
            catch (Exception) { }
            return new TimeSpan(utc.Ticks);
        }

        private string FormatDate(DateTime datetimeUtc)
        {
            var difference = UtcTimeToLocalTime(DateTime.UtcNow.Subtract(datetimeUtc));
            Debug.WriteLine(difference);
            if (difference.TotalDays > 30)
                return datetimeUtc.ToLocalTime().ToString("yyyy-MM-dd");
            if (difference.TotalDays > 1)
                return String.Format("{0} dni temu", difference.TotalDays.ToString("0"));

            if (difference.TotalDays == 1)
                return string.Format("wczoraj", difference.TotalDays.ToString("0"));
            if (difference.TotalHours >= 22)
                return string.Format("{0} godziny temu", difference.TotalHours.ToString("0"));
            if (difference.TotalHours >=5)
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

        public int TimeToEnd { get; set; }
        public string NumberOfOffers { get; set; }
        public string InsuranceNumber { get; set; }
        public string InsuranceFirm { get; set; }
        public string Paid { get; set; }
        public string MonthlyInstallment { get; set; }
        public string FirstPayData { get; set; }
        public object Status { get; set; }
        public string Rating { get; set; }
        public string Gg { get; set; }
        public string Skype { get; set; }
        public string Linkedin { get; set; }
        public string Goldenline { get; set; }
        public string Facebook { get; set; }
        public string Nk { get; set; }
        public string Www { get; set; }
        public string ProfilSlPozycz { get; set; }
        public string ProfilSlZakra { get; set; }
        public string ProfilSlSekrata { get; set; }
        public string ProfilSlFinansowo { get; set; }
        public string ProfilAllegro { get; set; }
        public string ProfilSlOther { get; set; }
        public string FinishDate { get; set; }
    }

    public class Auctions
    {
        public List<Auction> Auction { get; set; }
    }

    public class Response
    {
        public Paging Paging { get; set; }
        public Auctions Auctions { get; set; }
    }

    //public class RootObject
    //{
        
    //}
}
