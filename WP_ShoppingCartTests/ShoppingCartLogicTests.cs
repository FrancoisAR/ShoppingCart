using Microsoft.VisualStudio.TestTools.UnitTesting;
using WP_ShoppingCart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WP_ShoppingCart.Tests
{
    [TestClass()]
    public class ShoppingCartLogicTests
    {
        private ShoppingCartLogic Shopping = new ShoppingCartLogic();
        public ShoppingCartLogicTests()
        {
            Shopping = new ShoppingCartLogic();
            //
        }


        [TestMethod()]
        public void ShoppingCartLogicTest()
        {
           //
        }

        [TestMethod()]
        public void initializeTest()
        {
           //
        }

        /// <summary>
        /// A - 5 -- 3 for 13
        /// B - 3 -- 2 for 4.50
        /// C - 2
        /// D - 1.50
        /// </summary>

        [TestMethod()]
        public void OneItem_AddSingleNonPromotionalToCart()
        {
            Shopping.CurrentCart = new ShoppingCart();
            Shopping.ChangeOrderTotal("A", 1); //1*5
            Shopping.AddToCart();
            var cartTotal = Shopping.CurrentCart.GetOrderTotal();
            var result = (cartTotal != 5);
            Assert.IsFalse(result, "Total for 1*A should be 5 (1*5)");

        }

        [TestMethod()]
        public void OneItem_AddMultiNonPromotionalToCart()
        {
            Shopping.CurrentCart = new ShoppingCart();
            Shopping.ChangeOrderTotal("A", 2); //2*5
            Shopping.AddToCart();

            var cartTotal = Shopping.CurrentCart.GetOrderTotal();
            var result = (cartTotal != 10);
            Assert.IsFalse(result, "Total for 2*A should be 10 (2*5)");
        }

        [TestMethod()]
        public void OneItem_AddPromotionalToCart()
        {
            Shopping.CurrentCart = new ShoppingCart();
            Shopping.ChangeOrderTotal("A", 3); //3 for 13 promotion only
            Shopping.AddToCart();

            var cartTotal = Shopping.CurrentCart.GetOrderTotal();
            var result = (cartTotal != 13);
            Assert.IsFalse(result, "Total for 3*A should be 13 (promotion*1)");
        }

        [TestMethod()]
        public void OneItem_AddMixedToCart()
        {
            Shopping.CurrentCart = new ShoppingCart();
            Shopping.ChangeOrderTotal("A", 5); // 3 for 13 promotion + 2*5
            Shopping.AddToCart();

            var cartTotal = Shopping.CurrentCart.GetOrderTotal();
            var result = (cartTotal != 23);
            Assert.IsFalse(result, "Total for 5*A should be 23 (3 for 13 promotion, + 2*5)");
        }

        [TestMethod()]
        public void OneItem_AddMultiPromotionalToCart()
        {
            Shopping.CurrentCart = new ShoppingCart();
            Shopping.ChangeOrderTotal("A", 6); //3 for 13 promotion * 2
            Shopping.AddToCart();

            var cartTotal = Shopping.CurrentCart.GetOrderTotal();
            var result = (cartTotal != 26);
            Assert.IsFalse(result, "Total for 6*A should be 26 - 3 for 13 (promotion) * 2");
        }

        [TestMethod()]
        public void OneItem_AddMultiMixedToCart()
        {
            Shopping.CurrentCart = new ShoppingCart();
            Shopping.ChangeOrderTotal("A", 8); //(3 for 13) * 2 + 2*5
            Shopping.AddToCart();

            var cartTotal = Shopping.CurrentCart.GetOrderTotal();
            var result = (cartTotal != 36);
            Assert.IsFalse(result, "Total for 8*A should be 36 - (3 for 13 promotion * 2 + 2*5)");
        }       

        [TestMethod()]
        public void MultiItem_AddMultiNonPromotionalToCart()
        {
             
            Shopping.ChangeOrderTotal("A", 2); // 2 * 5 = 10
            Shopping.AddToCart();
            Shopping.ChangeOrderTotal("B", 1); //1 * 3 = 3
            Shopping.AddToCart();
            Shopping.ChangeOrderTotal("C", 3); //3 * 2 = 6
            Shopping.AddToCart();
            Shopping.ChangeOrderTotal("D", 4); //4 * 1.50 = 6
            Shopping.AddToCart();

            var cartTotal = Shopping.CurrentCart.GetOrderTotal();
            var result = (cartTotal != 25);
            Assert.IsFalse(result, "Total for 2*A  + 1*B + 3*C + 4*D should be 25 (A:2*5 + B:1*3 + C:3*2 + D:4*1.50)");
        }

        [TestMethod()]
        public void MultiItem_AddMultiMixedToCart()
        {
            Shopping.ChangeOrderTotal("A", 7); //3 for 13 promotion * 2 + 1*5 = 31
            Shopping.AddToCart();
            Shopping.ChangeOrderTotal("B", 3); //2 for 4.50 + 1*3 = 7.50
            Shopping.AddToCart();
            Shopping.ChangeOrderTotal("C", 3); //3 * 2 = 6
            Shopping.AddToCart();
            Shopping.ChangeOrderTotal("D", 4); //4 * 1.50 = 6
            Shopping.AddToCart();


            var cartTotal = Shopping.CurrentCart.GetOrderTotal();
            var result = (cartTotal != 50.50);
            Assert.IsFalse(result, "Total for 7*A + 3*B + 3*C + 4*D should be 50.50 (A:3 for 13 promotion*2 + 1*5 + B:2 for 4.50 promotion + 1*3 + C:3*2 + D: 4*1.50)");
        }
        
    }
}