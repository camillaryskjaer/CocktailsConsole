using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CocktailsConsole.Tables
{
    [Table("Accessory")]
    class Accessory : Ingridient
    {
        public string type { get; set; }
        public string Name { get; set; }


        public Accessory()
        {

        }
        public Accessory(string type, string name)
        {
            Name = name.ToLower();
            this.type = type;
        }

    }
}
