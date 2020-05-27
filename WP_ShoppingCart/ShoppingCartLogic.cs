using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WP_ShoppingCart
{
    //moved all the main logic here to make it easier to implement tests
    //Ideally you would add proper exception handling in here as well. However I have not encountered any exceptions other than those fixed for the dictionaries, and size and complexity wise it shouldn't be required for this app.
    //But obviously for proper apps you'll need to add logging and exception handling.
    public class ShoppingCartLogic
    {
        //All the items and their prices
        public ShoppingPrices shoppingData;
        //Item currently being added
        public DraftItem currentItem;
        //Current cart containing multiple items
        public ShoppingCart CurrentCart;

        public ShoppingCartLogic()
        {
            initialize();
        }
        public void initialize()
        {
            shoppingData = new ShoppingPrices();
            CurrentCart = new ShoppingCart();
        }

        public double ChangeOrderTotal(string selectedItem, decimal selectedNumber)
        {
            //currently the draftitem gets recreated each time as all calculations are done in here
            currentItem = new DraftItem(selectedItem);

            var singlePrice = shoppingData.PriceList[selectedItem];
            var hasPromotion = shoppingData.Promotions.ContainsKey(selectedItem);

            //get the applicable promotions
            //Promotions in a Dictionary <int, double>
            //key  = number of units
            //value = total price for number of units
            var itemPromotions = shoppingData.Promotions.Where(x => x.Key.Equals(selectedItem)).SelectMany(y => y.Value.Where(z => z.Key <= selectedNumber));

            //work out the breakdown
            //go through promotions, may be multiple promotions?. 
            //highest to lowest, apply promotions and repeat
            var totalNumberOrder = Convert.ToDouble(selectedNumber); //counter to track the total numer of items in order
            var totalItemPrice = 0D;
            foreach (var promotion in itemPromotions.OrderByDescending(x => x.Value).Select(y => y))
            {
                if (totalNumberOrder <= 1) //in this case only 1 or no items are left over, so unlikely to have multi buy promotion applied
                    break;

                //how many of the specific promotions to apply
                var promotionOrdered = Math.Truncate(totalNumberOrder / promotion.Key);
                if (promotionOrdered > 0)
                {
                    totalNumberOrder = totalNumberOrder - (promotion.Key * promotionOrdered);
                    totalItemPrice += promotionOrdered * promotion.Value;
                    currentItem.AddToOrder(promotion.Key, promotion.Value, Convert.ToInt32(promotionOrdered));
                }
            }
            //If there are any items left to add that's smaller than the smallest promotion
            if (totalNumberOrder > 0)
            {
                totalItemPrice += totalNumberOrder * singlePrice;
                currentItem.AddToOrder(1, singlePrice, Convert.ToInt32(totalNumberOrder));
            }

            return currentItem.GetOrderTotal();
        }

        public void AddToCart()
        {

            //Add the current draft item to the cart
            try
            {
                CurrentCart.AddToCart(currentItem);
            }
            catch (Exception ex)
            {
                //Add some error handling here. Have not had any failures as it's a small set and app, but should really add proper error handling and logging as well in bigger ones.
            }
        }
    }
}
