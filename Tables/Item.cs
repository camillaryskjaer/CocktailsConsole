using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailsConsole.Tables
{
    class Item : EnityBase
    {
        public int Unit { get; set; }
        public Ingridient ingridient{get;set;}
        public Item()
        {

        }
        public Item(int unit, Ingridient ingridient)
        {
            Unit = unit;
            this.ingridient = ingridient;
        }

    }
}

