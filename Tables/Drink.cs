using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailsConsole.Tables
{
    class Drink : EnityBase
    {
        
        public string name { get; set; }
        public Container container { get; set; }
        public ICollection<Item> Items { get; set; }
        public Drink()
        {
            
        }        
    }
}
