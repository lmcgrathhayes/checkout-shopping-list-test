using Checkout.ShoppingList.Model;
using System.Collections.Generic;

namespace Checkout.ShoppingList.Core.Infrastructure.Interfaces
{
    public interface IShoppingListRepository
    {
        List<ShoppingListItem> Get(int pageIndex, int pageSize);
        ShoppingListItem GetByName(string name);
        void Add(ShoppingListItem item);
        void Update(ShoppingListItem item);
        void DeleteByName(string name);
        bool Exists(ShoppingListItem item);
    }
}
