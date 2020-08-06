using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CocktailsConsole.Tables;
using CocktailsConsole.Data;
using System.Runtime.Remoting.Contexts;
using System.Data.Entity;

namespace CocktailsConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            DataController data = new DataController();
            //data.AddIndgredients();
            Drink margerita = new Drink();
            //Hvorfor sender du ikke navnet med i konstruktøren? Kan man have en drink uden et navn? 
            margerita.name = "Margerita";
            margerita.Items = new List<Item>
            {
                new Item(60, new Liquid("green", false, "lime Jucie")),
                new Item(30, new Liquid("withe", false, "lriplesec")),
                new Item(60, new Liquid("yellow", true, "lequila")),
                new Item(1,new Accessory("rim", "salt")),
                new Item(1,new Accessory("crushed", "ice")),
                new Item(1, new Accessory("segment", "lime")) };
            margerita.container = new Container(350, "Small round Glas");
            data.CreateDrink(margerita);

            Drink maitai = new Drink();
            maitai.name = "Maitai";
            maitai.Items = new List<Item>
            {
                new Item(60, new Liquid("dark reed", true, "Dark Rum")),
                new Item(30, new Liquid("red", false, "Orange Curacao")),
                new Item(60, new Liquid("green", false, "Lime juice")),
                new Item(60, new Liquid("dark green", false, "Almond syrup")),
                new Item(1,new Accessory("rim", "salt")),
                new Item(1,new Accessory("section", "lime")),
                new Item(1, new Accessory("segment", "lime")) };
            maitai.container = new Container(350, "Small round Glas");
            data.CreateDrink(maitai);


            Console.WriteLine("!");
            Drink mar = data.GetDrink("Margerita");
            Console.WriteLine($"Name: {mar.name}\ncontainer: {mar.container.shape}\nAmount of items : {mar.Items.Count}");
            Console.Read();

        }
    }
}
