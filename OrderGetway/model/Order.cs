namespace OrderGetway.model
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public List<OrderItem> Items { get; set; }= new List<OrderItem>();
    }
}
