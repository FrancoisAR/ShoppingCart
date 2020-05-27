namespace WP_ShoppingCart
{
    partial class ShoppingCartForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.NewOrder = new System.Windows.Forms.Button();
            this.textItemTotal = new System.Windows.Forms.TextBox();
            this.nudNumber = new System.Windows.Forms.NumericUpDown();
            this.AddToCart = new System.Windows.Forms.Button();
            this.comboItems = new System.Windows.Forms.ComboBox();
            this.lvCart = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // NewOrder
            // 
            this.NewOrder.Location = new System.Drawing.Point(12, 12);
            this.NewOrder.Name = "NewOrder";
            this.NewOrder.Size = new System.Drawing.Size(75, 21);
            this.NewOrder.TabIndex = 19;
            this.NewOrder.Text = "New Order";
            this.NewOrder.UseVisualStyleBackColor = true;
            this.NewOrder.Click += new System.EventHandler(this.NewOrder_Click);
            // 
            // textItemTotal
            // 
            this.textItemTotal.Location = new System.Drawing.Point(206, 56);
            this.textItemTotal.Name = "textItemTotal";
            this.textItemTotal.Size = new System.Drawing.Size(75, 20);
            this.textItemTotal.TabIndex = 23;
            // 
            // nudNumber
            // 
            this.nudNumber.Location = new System.Drawing.Point(131, 55);
            this.nudNumber.Name = "nudNumber";
            this.nudNumber.Size = new System.Drawing.Size(49, 20);
            this.nudNumber.TabIndex = 22;
            this.nudNumber.ValueChanged += new System.EventHandler(this.nudNumber_ValueChanged);
            // 
            // AddToCart
            // 
            this.AddToCart.Location = new System.Drawing.Point(287, 55);
            this.AddToCart.Name = "AddToCart";
            this.AddToCart.Size = new System.Drawing.Size(75, 23);
            this.AddToCart.TabIndex = 21;
            this.AddToCart.Text = "Add To Cart";
            this.AddToCart.UseVisualStyleBackColor = true;
            this.AddToCart.Click += new System.EventHandler(this.AddToCart_Click);
            // 
            // comboItems
            // 
            this.comboItems.FormattingEnabled = true;
            this.comboItems.Location = new System.Drawing.Point(12, 55);
            this.comboItems.Name = "comboItems";
            this.comboItems.Size = new System.Drawing.Size(89, 21);
            this.comboItems.TabIndex = 20;
            this.comboItems.SelectedIndexChanged += new System.EventHandler(this.comboItems_SelectedIndexChanged);
            // 
            // lvCart
            // 
            this.lvCart.HideSelection = false;
            this.lvCart.Location = new System.Drawing.Point(12, 84);
            this.lvCart.Name = "lvCart";
            this.lvCart.Size = new System.Drawing.Size(350, 464);
            this.lvCart.TabIndex = 24;
            this.lvCart.UseCompatibleStateImageBehavior = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "Item";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(128, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "No of items";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(203, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = "Sub Total";
            // 
            // ShoppingCartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 564);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lvCart);
            this.Controls.Add(this.textItemTotal);
            this.Controls.Add(this.nudNumber);
            this.Controls.Add(this.AddToCart);
            this.Controls.Add(this.comboItems);
            this.Controls.Add(this.NewOrder);
            this.Name = "ShoppingCartForm";
            this.Text = "Shopping Cart";
            this.Load += new System.EventHandler(this.ShoppingCartForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudNumber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button NewOrder;
        private System.Windows.Forms.TextBox textItemTotal;
        private System.Windows.Forms.NumericUpDown nudNumber;
        private System.Windows.Forms.Button AddToCart;
        private System.Windows.Forms.ComboBox comboItems;
        private System.Windows.Forms.ListView lvCart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

