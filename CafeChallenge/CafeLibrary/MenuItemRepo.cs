using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeLibrary
{
    public class MenuItemRepo
    {
        private readonly List<MenuItem> menu = new List<MenuItem>();

        public bool AddItemsToMenu(MenuItem items)
        {
            int startingCount = menu.Count;
            menu.Add(items);

            return menu.Count > startingCount;
        }

        public List<MenuItem> GetMenuItems()
        {
            return menu;
        }

        public bool DeleteMenuItems(MenuItem menuItems)
        {
            return menu.Remove(menuItems);
        }
    }
}