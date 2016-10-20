using Newtonsoft.Json;

namespace Kopra.Model.Auction
{
	public sealed class Investment
	{
		public string investmentId { get; set; }
		public string user { get; set; }
		public string userId { get; set; }
		public string amount { get; set; }
		public string percent { get; set; }
		public string date { get; set; }
		public string isPaid { get; set; }
		public string isGuaranteed { get; set; }
		public string isAccepted { get; set; }
		public string isSold { get; set; }
		public string userMarkAsRepaid { get; set; }
		public string assigneeMarkAsRepaid { get; set; }
	}
}
