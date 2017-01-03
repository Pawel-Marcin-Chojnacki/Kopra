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
	    private string _ispaid = string.Empty;

	    public string isPaid
	    {
	        get
	        {
	            if (_ispaid.StartsWith("1"))
	                return "Tak";
	            return "Nie";
	        }
            set { _ispaid = value; }
	    }
		public string isGuaranteed { get; set; }
		public string isAccepted { get; set; }
		public string isSold { get; set; }
		public string userMarkAsRepaid { get; set; }
		public string assigneeMarkAsRepaid { get; set; }
	}
}
