namespace Kopra.NewAuctionNotifier
{
    public sealed class Paging
    {
        public int page { get; set; }
        public string total { get; set; }
        public int pageSize { get; set; }
        public int pages { get; set; }
    }
}