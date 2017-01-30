using System;

namespace Checkout.ShoppingList.Model
{
    public class ShoppingListItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
    }
}