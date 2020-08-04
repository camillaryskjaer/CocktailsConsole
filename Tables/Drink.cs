using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CocktailsConsole.Tables
{
    class Drink
    {
        [Key]
        public int drinkId { get; set; }
        public string name { get; set; }
        public Container container { get; set; }
        public List<Item> Items { get; set; }
        public Drink()
        {
            
        }        
    }
}
