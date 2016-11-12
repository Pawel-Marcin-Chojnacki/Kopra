namespace Kopra.NewAuctionNotifier
{
    public sealed class Response
    {
        public Paging paging { get; set; }
        public Auctions auctions { get; set; }
    }
}