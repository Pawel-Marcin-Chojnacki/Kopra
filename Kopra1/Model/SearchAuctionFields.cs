using System.Collections.Generic;

namespace Kopra
{
    public class SearchAuctionFields
    {
        public string user_id { get; set; }
        public string user { get; set; }
        public string title { get; set; }
        public string status { get; set; }
        public string valueFrom { get; set; }
        public string valueTo { get; set; }
        public string periodFrom { get; set; }
        public string periodTo { get; set; }
        public string percentFrom { get; set; }
        public string percentTo { get; set; }
        public string completedFrom { get; set; }
        public string completedTo { get; set; }
        public string investorsFrom { get; set; }
        public string investorsTo { get; set; }
        public List<string> rating { get; set; }
        public List<string> province { get; set; }
        public List<string> insuranceNumber { get; set; }
        public List<string> insuranceFirm { get; set; }
        public string isAllegroVerified { get; set; }
        public List<string> intent { get; set; }
    }
}
