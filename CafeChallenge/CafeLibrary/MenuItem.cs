using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


//Defining the items
namespace CafeLibrary
{
    public class MenuItem
    {
        public MenuItem() {}

        public MenuItem(int number, string name, string description, List<string> ingredients, decimal price)
        {
            Number = number;
            Name = name;
            Description = description;
            Ingredients = ingredients;
            Price = price;
        }

        public int Number { get; set; } 
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> Ingredients { get; set; } = new List<string>();
        public decimal Price { get; set; }
    }
}