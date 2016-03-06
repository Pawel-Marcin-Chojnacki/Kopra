using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kopra
{
    public class RequestGenerator
    {
        private const string BaseAddress = "https://kokos.pl/webapi/";
        private const string DataType = "type=json";

        public Uri SearchAuction(Dictionary<string, string> search)
        {
            string requestAddress = BaseAddress + "search?";
            foreach (var item in search)
            {
                requestAddress += item.Key + "=" + item.Value + "&";
            }
            requestAddress += DataType;
            var result = new Uri(requestAddress);
            return result;
        }

        public Uri MostRecentAuctions()
        {
            string requestAddress = BaseAddress + "get-recent-auctions?";
            var sm = new SettingsManager();
            requestAddress += "key=" + sm.KokosWebApiKey + "&";
            requestAddress += DataType + "&";
            requestAddress += "records=3";
            
            var result = new Uri(requestAddress);
            return result;
        }



       
    }
}
