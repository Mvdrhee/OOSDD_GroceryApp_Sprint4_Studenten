namespace Grocery.Core.Models
{
    public class Product : Model
    {
        public int Stock { get; set; }
        public DateOnly? Tht { get; set; }

        // Producten die niet meer op voorraad zijn of eeuwig houdbaar maken geen gebruik van de tht-datum
        public Product(int id, string name, int stock) : base(id, name)
        {
            Stock = stock;
        }
        public Product(int id, string name, int stock, DateOnly tht) : base(id, name)
        {
            Stock = stock;
            Tht = tht;
        }
    }
}
