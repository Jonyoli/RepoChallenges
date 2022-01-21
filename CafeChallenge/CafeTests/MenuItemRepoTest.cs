using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CafeLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CafeTests
{
    [TestClass]
    public class CafeUITest
    {
        [TestMethod]
        public void TestAddItemsToMenu()
        {
            //Arrange
            MenuItem items = new MenuItem();
            MenuItemRepo repo = new MenuItemRepo();
            
            //Act
            bool result = repo.AddItemsToMenu(items);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GetMenuItems()
        {
            //Arrange
            MenuItem items = new MenuItem();
            MenuItem food = new MenuItem();
            MenuItemRepo repo = new MenuItemRepo();
            repo.AddItemsToMenu(items);
            repo.AddItemsToMenu(food);

            //Act
            List<MenuItem> result = repo.GetMenuItems();

            //Assert
            Assert.AreEqual(2, result.Count);
            Assert.IsTrue(result.Contains(food));
        }

        [TestMethod]
        public void DeleteMenuItems()
        {
            // Act
            bool result = _repo.DeleteMenuItems(_items);

            //Assert
            Assert.IsTrue(result);

            List<MenuItem> resultList = _repo.GetMenuItems();
            Assert.IsFalse(resultList.Contains(_items));
        }

        //Test Initialize

        private MenuItem _items;
        private MenuItemRepo _repo;
        
        [TestInitialize]
        public void Arrange()
        {
            _items = new MenuItem(5, "Hot Dog", "A hot dog on a bun", new List<string>() {"Ketchup", "Relish", "Onions"},  3.00m);
            _repo = new MenuItemRepo();

            _repo.AddItemsToMenu(_items);
        }
    
    }
}