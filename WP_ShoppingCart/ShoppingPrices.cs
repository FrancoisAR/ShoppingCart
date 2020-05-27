using System.Collections.Generic;
using System.Linq;

namespace WP_ShoppingCart
{
    //OK, this may not be the best way of doing it, but wanted it quick so settled on Dictionaries for data and objects.
    //Under certain circumstances it may be better to use seperate objects, for instance an Item object, containing properties and methods for stocklevel, Increment, Promotional price, conforming to the IItem interface which can be used to create the item, 
    //but in this case I opted not to as this is quite small scale
    public class ShoppingPrices
    {
        //Item Name, Single Price
        public Dictionary<string, double> PriceList;
        //Item Name, <item count, promotional price>
        public Dictionary<string, Dictionary<int, double>> Promotions;
        //Item Name, Stock level
        //public Dictionary<string, int> StockLevels;

        public ShoppingPrices()
        {
            initializePrices();
        }

        private void initializePrices()
        {
            PriceList = new Dictionary<string, double>();
            Promotions = new Dictionary<string, Dictionary<int, double>>();
            //StockLevels = new Dictionary<string, int>();


            //Just load the default data here.
            LoadDataFromDS();            
        }

        public void LoadDataFromDS()
        { 
            //Should be simple enough to replace these with calls to various data sources
            //A
            var itemName = "A";
            AddNewItem(itemName, 5D, 10);
            AddPromotion(itemName, 3, 13D);
            //AddPromotion(itemName, 5, 18D);

            //B
            itemName = "B";
            AddNewItem(itemName, 3D, 10);
            AddPromotion(itemName, 2, 4.5D);

            //C
            itemName = "C";
            AddNewItem(itemName, 2D, 10);

            //D
            itemName = "D";
            AddNewItem(itemName, 1.5D, 10);
        }

        //Add new item to the list
        public void AddNewItem(string itemName, double singlePrice, int stock)
        {
            if (PriceList.ContainsKey(itemName))
                PriceList[itemName] = singlePrice;
            else
                PriceList.Add(itemName, singlePrice);
            //StockLevels[itemName] = stock;

        }
        //Add a new promotion for an existing item
        public void AddPromotion(string itemName, int number, double promotionPrice)
        {
            var itemForProm = (Promotions.ContainsKey(itemName)) ? Promotions[itemName] : new Dictionary<int, double>();
            
            if (itemForProm.ContainsKey(number) && itemForProm.Count > 0)
            {
                Promotions[itemName][number] = promotionPrice;
            }
            else
            {
                if (itemForProm.Count == 0)
                {
                    var newItem = new Dictionary<int, double>();
                    newItem.Add(number, promotionPrice);
                    Promotions.Add(itemName, newItem);
                }
                else
                    Promotions[itemName].Add(number, promotionPrice);
            }
        }
        
        ////Add additional stock
        //private void AddStock(string itemName, int number)
        //{
        //    if (StockLevels.ContainsKey(itemName))
        //        StockLevels[itemName] += number;
        //}
        ////Remove stock from placed order
        //private void RemoveStock(string itemName, int number)
        //{
        //    if (StockLevels.ContainsKey(itemName))
        //        StockLevels[itemName] -= number;
        //}


    }
    
}
