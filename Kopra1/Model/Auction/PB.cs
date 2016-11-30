namespace Kopra.Model.Auction
{
	public sealed class PB
	{
		private string _maxMonthlyInstallment;
		private string _maxVerifyMonthlyInstallment;
		private string _income;
		private string _expenses;
		private string _credits;
		public string userId { get; set; }
		public string isRemoved { get; set; }
		public string user { get; set; }
		public string type { get; set; }
		public string startDate { get; set; }
		public string age { get; set; }
		public string city { get; set; }
		public string province { get; set; }
		public string condition { get; set; }
		public string profession { get; set; }
		public string employer { get; set; }
		public string lastLoginDate { get; set; }

		public string income
		{
			get {
				if (string.IsNullOrWhiteSpace(_income))
				{
					return "0.00 zł";
				}
				return _income + " zł";
			}
			set { _income = value; }
		}

		public string expenses
		{
			get {
				if (string.IsNullOrWhiteSpace(_expenses))
				{
					return "0.00 zł";
				}
				return _expenses + " zł";
			}
			set { _expenses = value; }
		}

		public string credits
		{
			get {
				if (string.IsNullOrWhiteSpace(_credits))
				{
					return "0.00 zł";
				}
				return _credits + " zł";
			}
			set { _credits = value; }
		}

		public string rating { get; set; }
		public string phoneVerificationDate { get; set; }
		public string phoneVerificationDescription { get; set; }
		public string isHomeAddressVerified { get; set; }
		public string homeAddressVerificationDate { get; set; }
		public string homeAddressVerificationDescription { get; set; }
		public string isEmployerVerified { get; set; }
		public string employerVerificationDate { get; set; }
		public string employerVerificationDescription { get; set; }
		public string isIdentityCardVerified { get; set; }
		public string identityCardVerificationDate { get; set; }
		public string identityCardVerificationDescription { get; set; }
		public string isBillVerified { get; set; }
		public string billVerificationDate { get; set; }
		public string billVerificationDescription { get; set; }
		public string isIMVerified { get; set; }
		public string imVerificationDate { get; set; }
		public string imVerificationDescription { get; set; }
		public string isKRDVerified { get; set; }
		public string krdVerificationDate { get; set; }
		public string krdVerificationDescription { get; set; }
		public string isERIFVerified { get; set; }
		public string erifVerificationDate { get; set; }
		public string erifVerificationDescription { get; set; }
		public string isFirmOnlineVerified { get; set; }
		public string firmOnlineVerificationDate { get; set; }
		public string firmOnlineVerificationDescription { get; set; }
		public string isFirmOfflineVerified { get; set; }
		public string firmOfflineVerificationDate { get; set; }
		public string firmOfflineVerificationDescription { get; set; }
		public string isPersonalVerified { get; set; }
		public string personalVerificationDate { get; set; }
		public string personalVerificationDescription { get; set; }
		public string isIdentityVerified { get; set; }
		public string identityVerificationDate { get; set; }
		public string identityVerificationDescription { get; set; }
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
		public string overdueDays { get; set; }
		public string beforeDays { get; set; }

		public string maxMonthlyInstallment
		{
			get
			{
				if (string.IsNullOrWhiteSpace(_maxMonthlyInstallment))
				{
					return "0.00 zł";
				}
				return _maxMonthlyInstallment + " zł";
			}
			set { _maxMonthlyInstallment = value; }
		}

		public string maxVerifyMonthlyInstallment
		{
			get
			{
				if (string.IsNullOrWhiteSpace(_maxVerifyMonthlyInstallment))
				{
					return "0.00 zł";
				}
				return _maxVerifyMonthlyInstallment +  " zł";
			}
			set { _maxVerifyMonthlyInstallment = value; }
		}

		public string positiveRecomendations { get; set; }
		public string neutralRecomendations { get; set; }
		public string negativeRecomendations { get; set; }

	}
}
