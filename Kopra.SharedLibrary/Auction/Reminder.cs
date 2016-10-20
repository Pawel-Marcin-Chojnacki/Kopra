using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kopra.Model.Auction
{
	public sealed class Reminder
	{
		public string installmentId { get; set; }
		public string installmentDate { get; set; }
		public string remiderValue { get; set; }
		public string reminderType { get; set; }
		public string reminderDate { get; set; }
		public string monitType { get; set; }
		public string paymentStatus { get; set; }
		public string paymentDate { get; set; }
	}
}
