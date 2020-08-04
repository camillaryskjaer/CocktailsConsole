using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CocktailsConsole.Tables;
using CocktailsConsole.Data;

namespace CocktailsConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //using (EnityBase ctx = new EnityBase())
            //{
            //    var test = ctx.drink.Include("Items").Include("container").ToList<Drink>();
            //    Console.Read();
            //    Drink drink = new Drink("a",new Container(10,"Big"), new List<Item> { new Item(10, new Ingridient("test"))});

            //    ctx.drink.Add(drink);
            //    ctx.SaveChanges();
            //}

            using (CockTailsContext context = new CockTailsContext(@"Cocktails"))
            {


                Liquid limeJucie = new Liquid("Green", false, "Lime Jucie");
                Liquid triplesec = new Liquid("White", false, "Triplesec");
                Liquid tequila = new Liquid("Yellow", true, "tequila");
                Accessory saltRim = new Accessory("Rim", "Salt");
                Accessory crushIce = new Accessory("Crushed", "Ice");
                Accessory limeSegment = new Accessory("Segment", "Lime");

                context.liquidContext.Add(limeJucie);
                context.liquidContext.Add(triplesec);

                context.accessoriesContext.Add(saltRim);
                context.accessoriesContext.Add(crushIce);
                context.accessoriesContext.Add(limeSegment);
                context.SaveChanges();

                Drink margarita = new Drink()
                {
                    name = "Margarita",
                    container = new Container(),
                    Items = new List<Item>() { 
                        new Item(60,(Ingridient)context.liquidContext.Where(x => x.name == "Lime Jucie")),
                        new Item(30, (Ingridient)context.liquidContext.Where(x => x.name == "Triplesec")),
                        new Item(60,(Ingridient)context.liquidContext.Where(x => x.name == "tequila")) }
                };
                context.drink.Add(margarita);
                context.SaveChanges();
                Drink margaritaOld = context.drink.Where(x => x.name == "margarita").FirstOrDefault();
                Console.WriteLine();
            }
        
            
        }
    }
}
