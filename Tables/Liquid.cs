using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CocktailsConsole.Tables
{
    [Table("Liquid")]
    class Liquid : Ingridient
    {

       public string Color { get; set; }
       public bool Alcohol { get; set; }
        public Liquid()
        {

        }
        public Liquid(string color, bool alcohol , string name) : base(name)
        {
            Color = color;
            Alcohol = alcohol;
        }     

       
    }
}
