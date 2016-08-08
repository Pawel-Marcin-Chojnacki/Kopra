using System;
using System.Collections.Generic;
using Kopra.Common;
using Kopra.ViewModel;
using Kopra1.Model.Auction;
using Newtonsoft.Json;

namespace Kopra.Model.Auction
{
	public class Auction
	{
		public string id { get; set; }
		public string title { get; set; }
		public string value { get; set; }
		public string period { get; set; }
		public string percent { get; set; }
		public string createDate { get; set; }
		public string timeToEnd { get; set; }
		public string finishDate { get; set; }
		public string numberOfOffers { get; set; }
		public string insuranceNumber { get; set; }
		public string insuranceFirm { get; set; }
		public string isVindicated { get; set; }
		public string paid { get; set; }
		public string monthlyInstallment { get; set; }
		public string firstPayData { get; set; }
		public string status { get; set; }
		public string isFromPartner { get; set; }
		public string description1 { get; set; }
		public string description2 { get; set; }
		public string description3 { get; set; }
		public string isPromoted { get; set; }
		public string isGuarantee { get; set; }
		public string investmentPercentWithGuarantee { get; set; }
		public string guaranteePercent { get; set; }
		public string lastLoginEncodeIP { get; set; }
		public string gracePeriod { get; set; }
		public PB PB { get; set; }
		public Financialverifies financialverifies { get; set; }
		[JsonConverter(typeof(SingleValueArrayConverter<Investments>))]
		public List<Investments> investments { get; set; }
		public List<Comments> comments { get; set; }
		[JsonConverter(typeof(SingleValueArrayConverter<Connections>))]
		public List<Connections> connections { get; set; }
		public PaybackSchedule paybackSchedule { get; set; }
		public List<Reminders> reminders { get; set; }
	}
}