using System.Collections.Generic;

namespace trade_app
{
    public class CartItem
    {
        public string Article;
        public string Name;
        public decimal Price;
        public int Quantity;
        public int Discount;
        public string Photo;
        public int Stock;

        public decimal TotalNoDiscount() 
        { 
            return Price * Quantity; 
        }
        public decimal TotalWithDiscount() 
        { 
            return Price * Quantity * (100 - Discount) / 100;
        }
        public decimal DiscountSum() 
        { 
            return TotalNoDiscount() - TotalWithDiscount(); 
        }
    }

    public static class Cart
    {
        public static List<CartItem> Items = new List<CartItem>();

        public static void Add(string article, string name, decimal price,
                               int quantity, int discount, string photo, int stock)
        {
            for (int i = 0; i < Items.Count; i++)
            {
                if (Items[i].Article == article) 
                { 
                    Items[i].Quantity += quantity; 
                    return; 
                }
            }

            CartItem item = new CartItem();
            item.Article = article; item.Name = name; item.Price = price;
            item.Quantity = quantity; item.Discount = discount;
            item.Photo = photo; item.Stock = stock;
            Items.Add(item);
        }

        public static void Remove(string article)
        {
            for (int i = 0; i < Items.Count; i++)
                if (Items[i].Article == article) 
                { 
                    Items.RemoveAt(i); 
                    return;
                }
        }

        public static void Clear() 
        { 
            Items.Clear();
        }

        public static int Count() 
        {
            return Items.Count; 
        }

        public static decimal SumNoDiscount()
        {
            decimal s = 0;
            for (int i = 0; i < Items.Count; i++) s += Items[i].TotalNoDiscount();
            return s;
        }

        public static decimal SumDiscount()
        {
            decimal s = 0;
            for (int i = 0; i < Items.Count; i++) s += Items[i].DiscountSum();
            return s;
        }

        public static decimal SumTotal()
        {
            decimal s = 0;
            for (int i = 0; i < Items.Count; i++) s += Items[i].TotalWithDiscount();
            return s;
        }

        public static int DeliveryDays()
        {
            for (int i = 0; i < Items.Count; i++)
                if (Items[i].Stock < 3) return 6;
            return 3;
        }
    }
}