using System;
using System.Collections.Generic;
using Kopra1.Model.Auction;

namespace Kopra.Model.Auction
{
	public class AuctionCopy
	{
		public int id { get; set; }
		public string title { get; set; }
		public string value { get; set; }
		public int period { get; set; }
		public double percent { get; set; }
		public DateTime? createDate { get; set; }
		public int timeToEnd { get; set; }
		public DateTime? finishDate { get; set; }
		public int numberOfOffers { get; set; }
		public int insuranceNumber { get; set; }
		public string insuranceFirm { get; set; }
		public int isVindicated { get; set; }
		public double paid { get; set; }
		public double monthlyInstallment { get; set; }
		public DateTime? firstPayData { get; set; }
		public int status { get; set; }
		public int isFromPartner { get; set; }
		public string description1 { get; set; }
		public string description2 { get; set; }
		public string description3 { get; set; }
		public int isPromoted { get; set; }
		public string isGuarantee { get; set; }
		public double investmentPercentWithGuarantee { get; set; }
		public double guaranteePercent { get; set; }
		public string lastLoginEncodeIP { get; set; }
		public int gracePeriod { get; set; }
		public PB PB { get; set; }
		public Financialverifies financialverifies { get; set; }
		public Investments investments { get; set; }
		public List<Comments> comments { get; set; }	
		public List<Connections> connections { get; set; }
		public PaybackSchedule paybackSchedule { get; set; }
		public List<Reminders> reminders { get; set; }
	}
}