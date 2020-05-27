using System;
using System.Collections.Generic;

namespace WP_ShoppingCart
{
    //Draft item is used after selecting an item in the combo box and added to the order when clicking on the Add to Order button.
    //Gets recreated when the item count gets changed.
    public class DraftItem 
    {
        public string ItemName { get; set; } //Name of item
        public int NumberOfItems { get; set; } //Number of given item in total
        private double OrderTotal { get; set; } //Total for given Item
        /// <summary>
        /// List<TUPLE>
        /// int     -   number of items (for non promotional 1, for promotional the number in promotion)
        /// double  -   The price of item (for non promotional single price, for promotional the promotion price)
        /// int     -   number of items in the draft
        /// double  -   total for all items in the draft
        /// </summary>
        private List<(int, double, int, double)> Breakdown { get; set; }

        private DraftItem()
        {
            //Should only create a draft item with the Item name
        }
        public DraftItem(string itemName)
        {
            ItemName = itemName;
            Breakdown = new List<(int, double, int, double)>();
        }
        //The breakdown, i.e. how many single items, any promotions etc.
        public List<(int, double, int, double)> GetBreakDown()
        {
            return Breakdown;
        }

        //Total for all Items in this draft
        public double GetOrderTotal()
        {
            return OrderTotal;
        }

        //Adds new items to the draft
        public void AddToOrder(int number, double price, int totalNumber)
        {
            OrderTotal += Math.Round((price * totalNumber), 2);
            Breakdown.Add((number, price, totalNumber, OrderTotal));
            NumberOfItems += number * totalNumber;
        }

    }
}
