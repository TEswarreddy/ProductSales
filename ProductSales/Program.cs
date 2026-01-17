using ProductSales.ProductObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft;
using Newtonsoft.Json;
using System.Runtime.InteropServices;

namespace ProductSales
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Product Sales.......................");
            //retraiving product counter from file
            string text = File.ReadAllText("../../DataLayer/Counter.txt");
            int Counter = int.Parse(text);
            Product.product_counter= Counter;
            Console.WriteLine("Counter:" + Counter);
            Console.WriteLine("Product_counter" + Product.product_counter);
            

            List<Product> products = new List<Product>();
            do
            {
                Console.WriteLine("1. Add");
                Console.WriteLine("2. Display All");
                Console.WriteLine("3. Search");
                Console.WriteLine("4. Remove");
                Console.WriteLine("5. Sort");
                Console.WriteLine("6. save the Product");
                Console.WriteLine("7. retrive the Products");
                Console.WriteLine("8. Exit");

                Console.WriteLine("Enter your Choice .....");
                int choice=Convert.ToInt32(Console.ReadLine());

                if (choice == 1)
                {
                    Product obj = new Product();


                name_goto:
                    try
                    {
                        Console.WriteLine("Enter Product Name:");
                        obj.Name= Console.ReadLine();
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Name should be more than 3 characters ..");
                        goto name_goto;
                    }
                    finally
                    {
                        Console.WriteLine("Successfully taken...");
                    }

                purchaseDate_goto:
                    try
                    {
                        Console.WriteLine("Enter the product purchase date:");
                        obj.purchaseDate=Convert.ToDateTime(Console.ReadLine());
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("date should be today or next days and also must be in month/day/yerar");
                        goto purchaseDate_goto;
                    }
                    finally
                    {
                        Console.WriteLine("Successfully taken...");
                    }

                price_goto:
                    try
                    {
                        Console.WriteLine("Enter the Product price:");
                        obj.Price = Convert.ToInt32(Console.ReadLine());

                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Price should be in integer..");
                        goto price_goto;
                    }
                    finally
                    {
                        Console.WriteLine("Successfully taken...");
                    }

                discount_goto:
                    try
                    {
                        Console.WriteLine("enter the discount for the product");
                        obj.Discount = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Discount should be in integer..");
                        goto discount_goto;
                    }
                    finally
                    {
                        Console.WriteLine("Successfully taken...");
                    }

                gst_goto:
                    try
                    {
                        Console.WriteLine("Enter the Gst in 5,10,15 percentage");
                        obj.Gst = Convert.ToInt32(Console.ReadLine());

                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Gst must should in 5,10,15");
                        goto gst_goto;
                    }
                    finally
                    {
                        Console.WriteLine("Successfully taken...");
                    }

                quantity_goto:
                    try
                    {
                        Console.WriteLine("enter the product quantity:");
                        obj.Quantity= Convert.ToInt32(Console.ReadLine());
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Quantity should be in number like integer");
                        goto quantity_goto;
                    }
                    finally
                    {
                        Console.WriteLine("Successfully taken...");
                    }

                    //generate the ID
                    string id=obj.Generate_id();
                    Console.WriteLine($"The generated Product ID is : {id}");

                    products.Add(obj);

                }
                else if (choice == 2)
                {
                    if(products.Count==0)
                    {
                        Console.WriteLine("No products to display....");
                        continue;
                    }
                    Console.WriteLine("Displaying all products....");
                    foreach (Product prod in products)
                    {
                        prod.Display_productDetails();
                    }

                }
                else if(choice==3)
                {
                search_goto:
                    //Search using LINQ concept
                    Console.WriteLine("Which one can be used to Search the Product....below listed...");
                    Console.WriteLine("1. Search by ID");
                    Console.WriteLine("2. Search by Name");
                    Console.WriteLine("3. Search by Purchase Date");
                    
                    int search_choice=Convert.ToInt32(Console.ReadLine());
                    switch (search_choice)
                    {
                        case 1:
                            Console.WriteLine("Searching by ID.... ");
                            Console.WriteLine("Here below the listed IDs in Products:");
                            foreach(Product prod in products)
                            {
                                Console.WriteLine(prod.Id);
                            }
                            Console.WriteLine("Enter the Product ID to search:");
                            string search_id=Console.ReadLine();
                            IEnumerable<Product> search_by_id= from prod in products
                                                                where prod.Id == search_id
                                                                select prod;
                            if(search_by_id.Count()==0)
                            {
                                Console.WriteLine("No product found with the given ID...");
                            }
                            else
                            {
                                foreach(Product prod in search_by_id)
                                {
                                    prod.Display_productDetails();
                                }
                            }
                            break;

                        case 2:
                            Console.WriteLine("Enter the Product Name to search:");
                            string search_by_name = Console.ReadLine();
                            IEnumerable<Product> search_name = from prod in products
                                                              where prod.Name.ToLower() == search_by_name.ToLower()
                                                              select prod;

                            if (search_name.Count() == 0)
                            {
                                Console.WriteLine("No product found with the given Name...");
                            }
                            else
                            {
                                foreach (Product prod in search_name)
                                {
                                    prod.Display_productDetails();
                                }
                            }
                            break;

                        case 3:
                            Console.WriteLine("Enter the Purchase Date to search:");
                            DateTime search_by_date = Convert.ToDateTime(Console.ReadLine());
                            IEnumerable<Product> search_date = from prod in products
                                                              where prod.purchaseDate == search_by_date
                                                              select prod;
                            if (search_date.Count() == 0)
                            {
                                Console.WriteLine("No product found with the given Purchase Date...");
                            }
                            else
                            {
                                foreach (Product prod in search_date)
                                {
                                    prod.Display_productDetails();
                                }
                            }
                            break;
                        default:
                            Console.WriteLine("Invalid Search Choice....");
                            goto search_goto;
                            
                    }


                }
                else if(choice == 4)
                {
                    //remove product
                    Console.WriteLine("Enter the Product ID to remove:");
                    Console.WriteLine("Here below the listed IDs in Products:");
                    foreach (Product prod in products)
                    {
                        Console.WriteLine(prod.Id);
                    }
                    Console.WriteLine("Enter the Product ID to remove:");
                    string remove_id=Console.ReadLine();
                    IEnumerable<Product> remove_product = from prod in products
                                                        where prod.Id == remove_id
                                                        select prod;
                    if (remove_product.Count() == 0)
                    {
                        Console.WriteLine("No product found with the given ID to remove...");

                    }
                    else
                    {
                        foreach (Product prod in remove_product)
                        {
                            prod.Display_productDetails();
                        }
                        products.Remove(remove_product.First());
                        Console.WriteLine("Product removed successfully...");
                    }
                    break;

                }
                else if (choice == 5)
                {
                sort_goto:
                    //sort the products using LINQ
                    Console.WriteLine("Sorting the Products based on below options...");
                    Console.WriteLine("1. Sort by Price Ascending");
                    Console.WriteLine("2. Sort by Price Descending");
                    Console.WriteLine("3. Sort by Name Ascending");
                    Console.WriteLine("4. Sort by Name Descending");
                    Console.WriteLine("5. Sort by Purchase Date Ascending");
                    Console.WriteLine("6. Sort by Purchase Date Descending");
                    Console.WriteLine("7. Sort by Quantity Ascending");
                    Console.WriteLine("8. Sort by Quantity Descending");
                    Console.WriteLine("9. Sort by Id Ascending");
                    Console.WriteLine("10. Sort by Id Descending");

                    Console.WriteLine("Enter your choice for sorting:");

                    string sort_choice=Console.ReadLine();
                    switch(sort_choice)
                    {
                        case "1":
                            IEnumerable<Product> sorted_by_price_asc = from prod in products
                                                                       orderby prod.Price ascending
                                                                       select prod;
                            Console.WriteLine("Displaying the sorted Products by Price Ascending...");
                            foreach (Product prod in sorted_by_price_asc)
                            {
                                prod.Display_productDetails();
                            }
                            break;
                        case "2":
                            IEnumerable<Product> sorted_by_price_desc = from prod in products
                                                                        orderby prod.Price descending
                                                                        select prod;
                            Console.WriteLine("Displaying the sorted Products by Price Descending...");
                            foreach (Product prod in sorted_by_price_desc)
                            {
                                prod.Display_productDetails();
                            }
                            break;
                        case "3":
                            IEnumerable<Product> sorted_by_name_asc = from prod in products
                                                                      orderby prod.Name ascending
                                                                      select prod;
                            Console.WriteLine("Displaying the sorted Products by Name Ascending...");
                            foreach (Product prod in sorted_by_name_asc)
                            {
                                prod.Display_productDetails();
                            }
                            break;
                        case "4":
                            IEnumerable<Product> sorted_by_name_desc = from prod in products
                                                                       orderby prod.Name descending
                                                                       select prod;
                            Console.WriteLine("Displaying the sorted Products by Name Descending...");
                            foreach (Product prod in sorted_by_name_desc)
                            {
                                prod.Display_productDetails();
                            }
                            break;
                        case "5":
                            IEnumerable<Product> sorted_by_date_asc = from prod in products
                                                                      orderby prod.purchaseDate ascending
                                                                      select prod;
                            Console.WriteLine("Displaying the sorted Products by Purchase Date Ascending...");
                            foreach (Product prod in sorted_by_date_asc)
                            {
                                prod.Display_productDetails();
                            }
                            break;
                        case "6":
                            IEnumerable<Product> sorted_by_date_desc = from prod in products
                                                                       orderby prod.purchaseDate descending
                                                                       select prod;
                            Console.WriteLine("Displaying the sorted Products by Purchase Date Descending...");
                            foreach (Product prod in sorted_by_date_desc)
                            {
                                prod.Display_productDetails();
                            }
                            break;
                        case "7":
                            IEnumerable<Product> sorted_by_quantity_asc = from prod in products
                                                                         orderby prod.Quantity ascending
                                                                         select prod;
                            Console.WriteLine("Displaying the sorted Products by Quantity Ascending...");
                            foreach (Product prod in sorted_by_quantity_asc)
                            {
                                prod.Display_productDetails();
                            }
                            break;
                        case "8":
                            IEnumerable<Product> sorted_by_quantity_desc = from prod in products
                                                                          orderby prod.Quantity descending
                                                                          select prod;
                            Console.WriteLine("Displaying the sorted Products by Quantity Descending...");
                            foreach (Product prod in sorted_by_quantity_desc)
                            {
                                prod.Display_productDetails();
                            }
                            break;
                        case "9":
                            IEnumerable<Product> sorted_by_id_asc = from prod in products
                                                                   orderby prod.Id ascending
                                                                   select prod;
                            Console.WriteLine("Displaying the sorted Products by Id Ascending...");
                            foreach (Product prod in sorted_by_id_asc)
                            {
                                prod.Display_productDetails();
                            }
                            break;
                        case "10":
                            IEnumerable<Product> sorted_by_id_desc = from prod in products
                                                                    orderby prod.Id descending
                                                                    select prod;
                            Console.WriteLine("Displaying the sorted Products by Id Descending...");
                            foreach (Product prod in sorted_by_id_desc)
                            {
                                prod.Display_productDetails();
                            }
                            break;
                        default:
                            Console.WriteLine("Invalid Sort Choice....Sorting by Price Ascending by default...");
                            goto sort_goto;
                    }
                    

                    break;

                }
                else if(choice == 6)
                {
                    //saving the products to file using JSON serialization
                    string json_data=JsonConvert.SerializeObject(products,Formatting.Indented);
                    File.WriteAllText("../../DataLayer/AvailableProducts.json", json_data);
                    Console.WriteLine("Products saved successfully to file...");

                }
                else if (choice == 7)
                {
                    //retriving the products from file using JSON deserialization
                    string json_data=File.ReadAllText("../../DataLayer/AvailableProducts.json");
                    products=JsonConvert.DeserializeObject<List<Product>>(json_data);
                    Console.WriteLine("Products retrived successfully from file...");

                } 
                else
                {
                    Console.WriteLine("Show Downed..........Bye...");
                    break;
                }


                    
            } while (true);

            //stroring the product  counter in file
            Counter=Product.product_counter;
            Console.WriteLine(Product.product_counter);
            File.WriteAllText("../../DataLayer/Counter.txt", Counter.ToString());

        }
    }
}
