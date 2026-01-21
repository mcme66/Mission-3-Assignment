using System;
using System.Collections.Generic;
using System.Text;

namespace Mission_3_Assignment
{
    internal class FoodItem
    {
        public string Name;
        public string Category;
        public int quantity;
        public DateTime ExpirationDate;
        public FoodItem(string inName, string inCat, int inQuan, DateTime inExpire) 
        {
            Name = inName;
            Category = inCat;
            quantity = inQuan;
            ExpirationDate = inExpire;
        }
    }
}
