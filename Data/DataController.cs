using CocktailsConsole.Tables;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace CocktailsConsole.Data
{
    /// <summary>
    /// This have the responsalibty for running the crud oprationses.
    /// </summary>
    class DataController
    {

        /// <summary>
        /// creates a drink using the provided drink object.
        /// </summary>
        /// <param name="newDrink"></param>
        public void CreateDrink(Drink newDrink)
        {
            UpdateDrrink(newDrink);
        }
        /// <summary>
        /// Updates the drink using the provided drink.
        /// </summary>
        /// <param name="NewDrink"></param>
        public void UpdateDrrink(Drink NewDrink)
        {
            using (CockTailsContext context = new CockTailsContext(@"Cocktails"))
            {

                if (!context.drink.Any(e => e.name == NewDrink.name))
                {
                    context.drink.AddOrUpdate(NewDrink);
                    context.SaveChanges();
                }
            }
        }
        /// <summary>
        /// Use to find a drink from the database.
        /// 
        /// </summary>
        /// <param name="parmesToUseToFindDrink">use this to speific what drink you want to get. eg."Margarita","voka",Drink,2 and so on more then one can be used </param>
        /// <returns>a Drink object</returns>
        public Drink GetDrink(params object[] parmesToUseToFindDrink)
        {
            using (CockTailsContext context = new CockTailsContext(@"Cocktails"))
            {
                foreach (var item in parmesToUseToFindDrink)
                {
                    if (item is Drink)
                    {
                        Drink temp = item as Drink;
                        return context.drink.Where(x => x.name == temp.name).Include("Items").Include("Container").FirstOrDefault();
                    }
                    else
                    {
                        if (item is string)
                        {
                            foreach (var stringItem in parmesToUseToFindDrink)
                            {
                                string tempString = stringItem as string;
                                bool found = context.drink.Any(x => x.name == tempString);
                                if (found)
                                {
                                    Drink temp = context.drink.Where(x => x.name == tempString).Include("Items").Include("Container").FirstOrDefault();
                                    if (temp != null)
                                    {
                                        return temp;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return null;
        }
        /// <summary>
        /// Delets the drink
        /// </summary>
        /// <param name="name"></param>
        /// <param name="drink"></param>
        /// <returns></returns>
        public bool DeleteDrink(string name = "", Drink drink = null)
        {
            using (CockTailsContext context = new CockTailsContext(@"Cocktails"))
            {
                if (drink == null)
                {
                    if (name != "")
                    {
                        context.drink.Remove(GetDrink(name));
                        return true;
                    }
                    context.drink.Remove(drink);
                }
                return false;
            }
        }
        /// <summary>
        /// Adds ingredients if there is not one in the database.
        /// </summary>
        /// <param name="ingridient"></param>
        public void AddIndgredients(Iingridient ingridient = null)
        {
            if (ingridient == null)
            {

                using (CockTailsContext context = new CockTailsContext(@"Cocktails"))
                {
                    List<Liquid> liquids = new List<Liquid> {
                    new Liquid("green", false, "lime jucie"),
                    new Liquid("white", false, "triplesec"),
                    new Liquid("yellow", true, "tequila") };
                    foreach (var item in liquids)
                    {

                        if (!context.liquidContext.Any(e => e.Name == item.Name))
                        {
                            Console.WriteLine("Added " + item.Name);
                            context.liquidContext.AddOrUpdate(item);
                        }
                    }
                    

                    List<Accessory> accessories = new List<Accessory> {
                    new Accessory("rim", "salt"),
                    new Accessory("crushed", "ice"),
                    new Accessory("segment", "lime")
                    };
                    foreach (var item in accessories)
                    {

                        if (!context.accessoriesContext.Any(e => e.Name == item.Name))
                        {
                            Console.WriteLine("Added " + item.Name);
                            context.accessoriesContext.AddOrUpdate(item);
                        }
                    }
                    context.SaveChanges();

//Hvad skal alle disse tomme linier? Det gør din kode sværere at læse!

                }
            }
            else
            {
                using (CockTailsContext context = new CockTailsContext(@"Cocktails"))
                {
                    switch (ingridient)
                    {
                        case Liquid l:
                            var temp = ingridient as Liquid;
                            if (!context.liquidContext.Any(e => e.Name == temp.Name))
                            {                              
                                context.liquidContext.AddOrUpdate(temp);
                            }
                            break;
                        case Accessory a:
                            var tempA = ingridient as Accessory;
                            if (!context.accessoriesContext.Any(e => e.Name == tempA.Name))
                            {                                
                                context.accessoriesContext.AddOrUpdate(tempA);
                            }
                            break;
                        default:
                            break;
                    }
                    context.SaveChanges();
                }
            }
        }
    }
}
