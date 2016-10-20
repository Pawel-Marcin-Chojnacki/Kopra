using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kopra1.Model.Auction
{
	public class PBcopy
	{
		public int userId { get; set; }
		public int isRemoved { get; set; }
		public string user { get; set; }
		public string type { get; set; }
		public DateTime? startDate { get; set; }
		public int age { get; set; }
		public string city { get; set; }
		public string province { get; set; }
		public string condition { get; set; }
		public string profession { get; set; }
		public string employer { get; set; }
		public DateTime? lastLoginDate { get; set; }
		public double income { get; set; }
		public double expenses { get; set; }
		public double credits { get; set; }
		public int rating { get; set; }
		public DateTime? phoneVerificationDate { get; set; }
		public string phoneVerificationDescription { get; set; }
		public bool isHomeAddressVerified { get; set; }
		public DateTime? homeAddressVerificationDate { get; set; }
		public string homeAddressVerificationDescription { get; set; }
		public bool isEmployerVerified { get; set; }
		public DateTime? employerVerificationDate { get; set; }
		public string employerVerificationDescription { get; set; }
		public bool isIdentityCardVerified { get; set; }
		public DateTime? identityCardVerificationDate { get; set; }
		public string identityCardVerificationDescription { get; set; }
		public bool isBillVerified { get; set; }
		public DateTime? billVerificationDate { get; set; }
		public string billVerificationDescription { get; set; }
		public bool isIMVerified { get; set; }
		public DateTime? imVerificationDate { get; set; }
		public string imVerificationDescription { get; set; }
		public bool isKRDVerified { get; set; }
		public DateTime? krdVerificationDate { get; set; }
		public string krdVerificationDescription { get; set; }
		public bool isERIFVerified { get; set; }
		public DateTime? erifVerificationDate { get; set; }
		public string erifVerificationDescription { get; set; }
		public bool isFirmOnlineVerified { get; set; }
		public DateTime? firmOnlineVerificationDate { get; set; }
		public string firmOnlineVerificationDescription { get; set; }
		public bool isFirmOfflineVerified { get; set; }
		public DateTime? firmOfflineVerificationDate { get; set; }
		public string firmOfflineVerificationDescription { get; set; }
		public int isPersonalVerified { get; set; }
		public DateTime? personalVerificationDate { get; set; }
		public string personalVerificationDescription { get; set; }
		public bool isIdentityVerified { get; set; }
		public DateTime? identityVerificationDate { get; set; }
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
		public int overdueDays { get; set; }
		public int beforeDays { get; set; }
		public double maxMonthlyInstallment { get; set; }
		public double maxVerifyMonthlyInstallment { get; set; }
		public int positiveRecomendations { get; set; }
		public int neutralRecomendations { get; set; }
		public int negativeRecomendations { get; set; }

	}
}
