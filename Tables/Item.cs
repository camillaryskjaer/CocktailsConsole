using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CocktailsConsole.Tables
{
    class Item
    {
        [Key]
        public int ItemId { get; set; }
        public int Unit { get; set; }
        public Ingridient ingridient{get;set;}

        public Item()
        {

        }
        public Item(int unit, Iingridient ingridient)
        {
            Unit = unit;
            this.ingridient = ingridient as Ingridient;
        }

    }
}

