using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExceptionLayer;
namespace ProductSales.ProductObjects
{

    
    public class Product
    {
        public static int product_counter;
        
        private string product_id;

        public string Id
        {
            get
            {
                return this.product_id;
            }
            set
            {
                this.product_id = value;
            }
            
        }

        private string product_name;

        public string Name
        {
            get
            {
                return product_name;
            }
            set
            {
                if (value.Length > 3)
                {
                    this.product_name = value;
                }
                else
                {
                    throw new InvalidNameException("invalid name");
                }
            }

        }

        private DateTime product_expireDate;
        public DateTime expireDate
        {
            get
            {
                return this.product_expireDate;
            }

        }

        private DateTime product_purchaseDate;
        public DateTime purchaseDate
        {
            get
            {
                return product_purchaseDate;
            }
            set
            {
                if (value >= DateTime.Today)
                {
                    this.product_purchaseDate = value;
                    this.product_expireDate = value.AddYears(2);

                }
                else
                {
                    throw new InvalidPurchaseDateException("Invalid Date..");
                }
            }
        }
        private int product_gst;
        public int Gst
        {
            get
            {
                return this.product_gst;
            }
            set
            {
                if(value==5 || value==10 || value == 15)
                {
                    this.product_gst = value;
                }
                else
                {
                    throw new InvalidGSTException("Invalid Gst...");
                }
            }
        }

        private int product_discount;
        public int Discount
        {
            get
            {
                return this.product_discount;
            }
            set
            {
                if( value > 0 && value<=20)
                {
                    this.product_discount = value;
                }
                else
                {
                    throw new InvalidDiscountException("Invalid Discount");
                }
            }
        }

        private int product_price;

        public int Price
        {
            get
            {
                return this.product_price;
            }
            set
            {
                this.product_price = value;
            }
        }

        private int product_quantity;

        public int Quantity
        {
            get
            {
                return this.product_quantity;
            }
            set
            {
                this.product_quantity = value; 
            }
        }



        //product id generation
        public string Generate_id()
        {
            string id = this.Name.Substring(0, 3);
            id += this.product_purchaseDate.Year;
            id += this.product_purchaseDate.Month;
            id += Product.product_counter;
            Product.product_counter++;
            this.product_id = id;
            return id;

        }

        //display the product Details
        public void Display_productDetails()
        {
            Console.WriteLine("Product ID: " + this.product_id);
            Console.WriteLine("Product Name: " + this.product_name);
            Console.WriteLine("Product Purchase Date: " + this.product_purchaseDate);
            Console.WriteLine("Product Price: " + this.product_price);
            Console.WriteLine("Product ExpireDate: " + this.product_expireDate);
            Console.WriteLine("Product Discount: " + this.product_discount);
            Console.WriteLine("Product Gst: " + this.product_gst);
            Console.WriteLine("Product Quantity: " + this.product_quantity);
            Console.WriteLine("-----------------------------------");
        }

    }
}
