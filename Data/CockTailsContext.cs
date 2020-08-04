using CocktailsConsole.Tables;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocktailsConsole.Data
{
    class CockTailsContext : DbContext
    {
        public DbSet<Drink> drink { get; set; }
        public DbSet<Container> containerContext { get; set; }
        public DbSet<Item> itemContext { get; set; }
        public DbSet<Liquid> liquidContext { get; set; }
        public DbSet<Accessory> accessoriesContext { get; set; }
        public DbSet<Ingridient> ingridientContext { get; set; }
        public CockTailsContext(string database) : base(database)
        {

        }
    }
}
