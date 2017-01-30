using System.Collections.Generic;

namespace Checkout.ShoppingList.Model
{
    public class ShoppingList
    {
        public int Count { get; set; }
        public List<ShoppingListItem> Data { get; set; }
    }
}
