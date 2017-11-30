using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPractice
{
    /// <summary>
    /// Product class
    /// </summary>
    public class Product
    {
        // Price change event
        public event EventHandler<PriceChangedEventArgs> PriceChanged;

        // Product name
        private string _name;

        // Product price
        private decimal _price;

        /// <summary>
        /// Encapsulated field of name
        /// </summary>
        public string Name { get => _name; set => _name = value; }

        /// <summary>
        /// Encapsulated field of price
        /// </summary>
        public decimal Price
        {
            get => _price;
            set
            {
                if (value != _price)
                {
                    _price = value;
                    OnPriceChanged(Price);
                }
            }
        }

        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="name">Product name</param>
        /// <param name="price">Product price</param>
        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public Product() { }

        /// <summary>
        /// Default list of products
        /// </summary>
        /// <returns>List of products</returns>
        public static List<Product> GetSampleProducts()
        {
            return new List<Product>
            {
            new Product{Name="West Side Story", Price=9.99m },
            new Product { Name="Assassins", Price=14.99m },
            new Product{Name="Frogs", Price=13.99m},
            new Product { Name="Sweeney Todd", Price=10.99m }
            };
        }

        /// <summary>
        /// Send data for event raising
        /// </summary>
        /// <param name="propName"></param>
        public void OnPriceChanged(decimal propName)
        {
            OnPriceChanged(new PriceChangedEventArgs(propName));
        }   

        /// <summary>
        /// Price change event invocation
        /// </summary>
        /// <param name="e"></param>
        public void OnPriceChanged(PriceChangedEventArgs e)
        {
            PriceChanged?.Invoke(this, e);
        }

        /// <summary>
        /// Changes price of a product
        /// </summary>
        /// <param name="money">Money to add to original price</param>
        public void AddPrice(decimal money)
        {
            Price += money;
            OnPriceChanged(new PriceChangedEventArgs(Price));
        }
    }

    /// <summary>
    /// EventArgs for price changing
    /// </summary>
    public class PriceChangedEventArgs : EventArgs
    {
        public readonly decimal NewPrice;

        public PriceChangedEventArgs(decimal newPrice)
        {
            NewPrice = newPrice;
        }
    }
}
