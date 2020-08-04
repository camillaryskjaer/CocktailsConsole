using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailsConsole.Tables
{
    class Container : EnityBase
    {
        public int maxAmount { get; set; }
        public string shape { get; set; }
        public Container()
        {

        }
        public Container(int maxAmount, string shape)
        {
            this.maxAmount = maxAmount;
            this.shape = shape;
        }

    }
}
