using Checkout.ShoppingList.Core.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using Checkout.ShoppingList.Model;
using System.Linq;

namespace Checkout.ShoppingList.Core.Infrastructure
{
    public class ShoppingListRepository : IShoppingListRepository
    {
        private static List<ShoppingListItem> shoppingList;

        public ShoppingListRepository()
        {
            shoppingList = new List<ShoppingListItem>();
        }

        public List<ShoppingListItem> Get(int pageNumber, int pageSize)
        {
            return shoppingList.Skip(pageNumber * pageSize).Take(pageSize).ToList();
        }

        public ShoppingListItem GetByName(string name)
        {
            if (!String.IsNullOrEmpty(name))
                return shoppingList.Find(s => s.Name.ToLower() == name.ToLower());
            return null;
        }

        public void Add(ShoppingListItem item)
        {
            shoppingList.Add(item);
        }

        public void Update(ShoppingListItem item)
        {
            var idx = shoppingList.FindIndex(s => s.Name.ToLower() == item.Name.ToLower());

            if (idx >= 0)
                shoppingList.RemoveAt(idx);

            shoppingList.Add(item);
        }

        public void DeleteByName(string name)
        {
            shoppingList.RemoveAll(s => s.Name.ToLower() == name.ToLower());
        }

        public bool Exists(ShoppingListItem item)
        {
            return shoppingList.Contains(item);
        }
    }
}
