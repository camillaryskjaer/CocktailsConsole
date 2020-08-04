using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CocktailsConsole.Tables
{
    [Table("Ingridient")]
    class Ingridient : EnityBase
    {
        public string name { get; set; }
        public Ingridient()
        {

        }
        public Ingridient(string name)
        {
            this.name = name;
        }

    }
}
