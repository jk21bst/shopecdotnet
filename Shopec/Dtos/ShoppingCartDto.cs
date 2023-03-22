using System.Collections.Generic;

namespace Shopec.Data
{
    public class ShoppingCartDto
    {

        public string orderId { get; set; }
        public int userId { get; set; }
        public List<CartItem> items { get; set; }
        public string deliveryOptionCode { get; set; }
        public double grossTotal { get; set; } = 0.0;
        public double deliveryTotal { get; set; } = 0.0;
        public double itemsTotal { get; set; } = 0.0;
    }

    public class CartItem
    {
        public int productId { get; set; }
        public int quantity { get; set; }
        public double price { get; set; }
    }
}