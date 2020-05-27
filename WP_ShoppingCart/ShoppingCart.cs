using System.Collections.Generic;
using System.Linq;

namespace WP_ShoppingCart
{
    //Main shopping cart
    public class ShoppingCart
    {
        public Dictionary<string, DraftItem> Items { get; set; } //Dictionary of Item name, Draft Item

        public ShoppingCart()
        {
            Items = new Dictionary<string, DraftItem>();
        }
        // Add a new draft to the cart if not exists, otherwise updates existing
        public void AddToCart(DraftItem item)
        {
            if (Items.Keys.Contains(item.ItemName))
                Items[item.ItemName] = item;
            else
                Items.Add(item.ItemName, item);

        }
        //Get the number of items int he order
        public int GetItemCount()
        {
            var itemCount = Items.Sum(x => x.Value.NumberOfItems);
            return itemCount;
        }
        //Get the Order total
        public double GetOrderTotal()
        {
            var orderTotal = Items.Sum(x => x.Value.GetOrderTotal());
            return orderTotal;
        }
    }
}
