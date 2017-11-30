using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace EventPractice
{
    /// <summary>
    /// Class to raise an event
    /// </summary>
    public class ShowEvent
    {
        // A varianle to detect if event has been raised.
        public bool checkFlag = false;

        /// <summary>
        /// Creates instance of a product class and raises event.
        /// </summary>
        public void RaiseEvent()
        {
            // Create instance         
            var instance = Activator.CreateInstance<Product>();
            decimal pr = 9.99m;

            // Subsribe to an event
            instance.PriceChanged += new EventHandler<PriceChangedEventArgs>(HandleEvent);

            // Raise event via price change
            PropertyInfo propertyInfo = instance.GetType().GetProperty("Price");
            propertyInfo.SetValue(instance, pr);
        }

        /// <summary>
        /// Event handler
        /// </summary>
        public void HandleEvent(object sender, PriceChangedEventArgs e)
        {
            checkFlag = true;
            Console.WriteLine("Price has been changed.");
        }
    }
}
