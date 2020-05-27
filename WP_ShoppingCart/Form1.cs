using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WP_ShoppingCart
{
    public partial class ShoppingCartForm : Form
    {
        private ShoppingCartLogic Shopping = new ShoppingCartLogic();
        public ShoppingCartForm()
        {
            InitializeComponent();
        }

        private void ShoppingCartForm_Load(object sender, EventArgs e)
        {
            refreshItems();
            SetupLvw();
        }
        //Setup List view and columns. Could have gone with Textbox and stringbuilder instead as well.
        private void SetupLvw()
        {
            lvCart.View = View.Details;
            lvCart.Columns.Add("Name", 50);
            lvCart.Columns.Add("Number", 50);
            lvCart.Columns.Add("Price", 50);
            lvCart.Columns.Add("Promotion", 70);
            lvCart.Columns.Add("SubTotal", 65);
            lvCart.Columns.Add("Total", 65);
        }
        //Currently only used on app start as item list doesn't change as yet. Would need to be called after loading updated list details though
        private void refreshItems()
        {
            var bindingSource = new BindingSource();
            var Items = Shopping.shoppingData.PriceList.Keys;
            bindingSource.DataSource = Items;
            comboItems.DataSource = bindingSource;
        }

        private void NewOrder_Click(object sender, EventArgs e)
        {
            //New order, so clear everything
            lvCart.Items.Clear();
            Shopping.CurrentCart = new ShoppingCart();
        }

        private void comboItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            Shopping.currentItem = new DraftItem(comboItems.Text);
            nudNumber.Value = 0;
            textItemTotal.Text = string.Empty;
        }

        private void nudNumber_ValueChanged(object sender, EventArgs e)
        {
            //Was thinking of additional functionality including stock levels, dynamically adding items and promotions, but that was outside the scope of the requirements, and want to spend more time on the testing etc, so might get back to that if time allows.
            //But for now just create and populate a draft item each time the numeric value gets changed. In an app with small spec such as this there shouldn't be a massive impact on perfiormance.
            var selectedItem = comboItems.Text;
            var selectedNumber = nudNumber.Value;
            
            //The stock check works, just commented out as not part of the requirements, and wanted to get stock management done as well first.
            //var stock = Shopping.shoppingData.StockLevels[selectedItem];
            ////The implementation of the stock levels. Not requirement but would be a logical next step in an app like this.
            //if (selectedNumber > stock)
            //{
            //    nudNumber.Value = stock;
            //    return;
            //}

            //calculate the breakdown for the items comprising the current order item
            var total = Shopping.ChangeOrderTotal(selectedItem, selectedNumber);

            textItemTotal.Text = total.ToString();
        }

        private void AddToCart_Click(object sender, EventArgs e)
        {
            var selectedItem = comboItems.Text;
            //Add to the cart
            Shopping.AddToCart();
            //Disaply breakdown
            UpdateListView();
        }
        
        //For the Forms project just add the output to the Listview
        private void UpdateListView()
        {
            lvCart.Items.Clear();
            foreach (var item in Shopping.CurrentCart.Items.Values)
            {
                var name = item.ItemName;
                var breakdown = item.GetBreakDown();
                var subtotal = item.GetOrderTotal();
                var subNumber = item.NumberOfItems;

                var lvi = new ListViewItem(name);
                lvi.BackColor = Color.White;
                lvi.SubItems.Add(subNumber.ToString());
                lvi.SubItems.Add("");
                lvi.SubItems.Add("");
                lvi.SubItems.Add("");
                lvi.SubItems.Add(subtotal.ToString());
                lvCart.Items.Add(lvi);

                foreach (var x in breakdown)
                {
                    lvi = new ListViewItem("");
                    var subSpecNumber = x.Item1;
                    var subSpecPrice = x.Item2;
                    var subOrderItems = x.Item3;
                    var subOrderTotal = x.Item4;
                    lvi.BackColor = Color.LightGray;
                    lvi.SubItems.Add(subOrderItems.ToString());
                    if (subSpecNumber > 1)
                    {
                        //promotion
                        lvi.SubItems.Add("");
                        lvi.SubItems.Add($@"{subSpecNumber} for {subSpecPrice}");
                        lvi.SubItems.Add($@"{subSpecPrice}");
                    }
                    else
                    {
                        //standard
                        lvi.SubItems.Add(subSpecPrice.ToString());
                        lvi.SubItems.Add("");
                        lvi.SubItems.Add($@"{subOrderItems * subSpecPrice}");
                    }

                    lvi.SubItems.Add("");
                    lvCart.Items.Add(lvi);
                }
            }

            //The totals Row
            var lviMain = new ListViewItem("Total");
            lviMain.BackColor = Color.Orange;
            lviMain.SubItems.Add("");
            lviMain.SubItems.Add("");
            lviMain.SubItems.Add("");
            lviMain.SubItems.Add("");
            lviMain.SubItems.Add(Shopping.CurrentCart.GetOrderTotal().ToString());
            lvCart.Items.Add(lviMain);
        }
    }
}
