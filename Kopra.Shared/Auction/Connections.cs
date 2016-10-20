using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kopra.Model.Auction;
using Newtonsoft.Json;
namespace Kopra.Model.Auction
{
	public sealed class Connections
	{
		public IList<Connection> connection { get; set; }
	}
}