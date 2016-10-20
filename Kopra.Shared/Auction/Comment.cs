using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.AtomPub;

namespace Kopra.Model.Auction
{
	public sealed class Comment
	{
		public string user_id { get; set; }
		public string user { get; set; }
		public string date { get; set; }
		public string description { get; set; }
		public string answerData { get; set; }
		public string answerDescription { get; set; }
	}
}
