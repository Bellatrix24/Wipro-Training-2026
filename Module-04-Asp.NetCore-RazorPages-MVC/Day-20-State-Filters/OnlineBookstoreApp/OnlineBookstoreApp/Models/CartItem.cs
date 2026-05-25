namespace OnlineBookstoreApp.Models
{
    public class CartItem
    {
        public Book Book { get; set; } = new Book();
        public int Quantity { get; set; }
    }
}
