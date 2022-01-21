using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CafeLibrary;

namespace CafeUI
{
    public class UserInterface
    {
        private readonly MenuItemRepo menu = new MenuItemRepo();
        public void Display()
        {
            BasicMenu();
            DisplayMenu();
        }

        private void BasicMenu()
        {
            MenuItem burger = new MenuItem( 1, "Burger", "Hamburger meat between two buns", new List<string>() {"Tomato", "Lettuce", "Pickle", "Ketchup", "Cheese"}, 4.00m);
            MenuItem chickenSandwhich = new MenuItem(2, "Chicken Sandwhick", "Chicken between two buns", new List<string>() {"Pickles", "Cheese", "Ketchup"}, 3.50m);
            MenuItem frenchFries = new MenuItem(3, "French Fries", "Seasoned fried potatoes", new List<string>() {"seasoning"}, 1.50m);

            menu.AddItemsToMenu(burger);
            menu.AddItemsToMenu(chickenSandwhich);
            menu.AddItemsToMenu(frenchFries);
        }

        //User Choosing from the menu
        //Menu creation
        private void DisplayMenu()
        {
            bool isDisplaying = true;
            while (isDisplaying)
            {
                Console.Clear();

                Console.WriteLine(
                    "Which action would like you like to take?\n" +
                    "1. Add a new item to the Menu\n" +
                    "2. View menu items\n" +
                    "3. Delete an item from the menu"
                );

                string userSelection = Console.ReadLine();

                switch (userSelection.ToLower())
                {
                    case "1":
                    case "add a new item to the menu":
                        Console.Clear();
                        Console.WriteLine("You have chosen to add a new item to the menu. Press any key to continue...");
                        Console.ReadKey();
                        AddMenuItems();
                        break;
                    case "2":
                    case "view menu items":
                        Console.Clear();
                        Console.WriteLine("You have chosen to view all menu items. Press any key to continue...");
                        Console.ReadKey();
                        ViewAllMenuItems();
                        break;
                    case "3":
                    case "delete an item from the menu":
                        Console.WriteLine("You have chosen to delete an item from the menu. Press any key to continue...");
                        DeleteMenuItems();
                        Console.ReadKey();
                        break;
                }
            }
        }
        //End of Menu Creation

        private void AddMenuItems()
        {
            Console.Clear();

            MenuItem items = new MenuItem();

            //Order Number
            Console.WriteLine("Enter the order number for your new menu item");
            items.Number = int.Parse(Console.ReadLine());

            //Menu Item Name
            Console.Clear();
            Console.WriteLine("Enter the name for your menu item");
            items.Name = Console.ReadLine();

            //Description
            Console.Clear();
            Console.WriteLine("Enter a description for your menu item");
            items.Description = Console.ReadLine();

            //Ingredients
            Console.Clear();
            Console.WriteLine("Enter the ingredients for your menu item");
            items.Ingredients.Add(Console.ReadLine());

            bool moreIngredients = true;
            while (moreIngredients)
            {
                Console.Clear();
                string userSelection2 = "";
                Console.WriteLine("Are there any more ingredients you would like to add?");
                Console.WriteLine(
                    "1. Yes\n" +
                    "2. No"
                );

                userSelection2 = Console.ReadLine();
                switch (userSelection2.ToLower())
                {
                    case "1":
                    case "yes":
                        Console.Clear();
                        Console.WriteLine("What ingredient would you like to add?");
                        items.Ingredients.Add(Console.ReadLine());
                        moreIngredients = true;
                        break;

                    case "2":
                    case "no":
                        Console.Clear();
                        Console.WriteLine("You have entered in all your ingredients. Press any key to continue...");
                        Console.ReadKey();
                        moreIngredients = false;
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Sorry, I don't understand that. Please select yes or no. Press any key to continue...");
                        Console.ReadKey();
                        break;
                }

                menu.AddItemsToMenu(items);
            }

            Console.Clear();
            Console.WriteLine("Enter the price for this menu item");
            Console.Write("$");
            items.Price = decimal.Parse(Console.ReadLine());

        }
        //End of Adding New Menu Items

        //Display All Menu Items

        private void ViewAllMenuItems()
        {
            Console.Clear();
            List<MenuItem> listofItems = menu.GetMenuItems();

            foreach (MenuItem items in listofItems)
            {
                Console.WriteLine(
                    $"Number: {items.Number} \n" +
                    $"Name: {items.Name} \n" +
                    $"Description {items.Description} \n" +
                    $"Price $ {items.Price} \n" +
                    $"Ingredients:"
                );
                foreach (string listofIngredients in items.Ingredients)
                {
                    Console.WriteLine(
                        listofIngredients
                    );
                }

            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        //Delete Menu Items

        private void DeleteMenuItems()
        {
            Console.Clear();
            Console.WriteLine("Select the item you want to remove from the menu:");
            List<MenuItem> menuList = menu.GetMenuItems();
            int counter = 1;

            foreach (MenuItem items in menuList)
            {
                Console.WriteLine(counter + ". " + items.Name);
                counter++;
            }

            int menuItemSelection = int.Parse(Console.ReadLine());
            int targetIndex = menuItemSelection - 1;

            if (targetIndex >= 0 && targetIndex < menuList.Count)
            {
                MenuItem targetMenu = menuList[targetIndex];

                if (menu.DeleteMenuItems(targetMenu))
                {
                    Console.WriteLine($"{targetMenu.Name} was removed");
                }
                else
                {
                    Console.WriteLine("Something went wrong");
                }
            }
            else
            {
                Console.WriteLine("Not a valid selection");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }


    }
}