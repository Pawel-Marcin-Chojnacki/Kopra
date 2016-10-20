using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kopra.Model.Auction
{
	public sealed class Verify
	{
		public string who { get; set; }
		public string finishDate { get; set; }
		public string limit { get; set; }
		public string maxSumInstallment { get; set; }
		public string investAfterVerify { get; set; }
	}
}
