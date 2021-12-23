using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject
{
    public class Item
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public Category Category { get; private set; }
        public int Quantity { get; private set; }
        public string Description { get; private set; }
        public double Price { get; private set; }
        public int SellerId { get; private set; }

        public Item(IDataRecord itemData)
        {
            Id = itemData.GetInt32(0);
            Name = itemData.GetString(1);
            Category = (Category)Enum.Parse(typeof(Category), itemData.GetString(2), true);
            Quantity = itemData.GetInt32(3);
            Description = itemData.GetString(5);
            Price = itemData.GetDouble(6);
            SellerId = itemData.GetInt32(4);
        }

        public User GetSeller()
        {
            return SQLprocedure.GetUser(SellerId);
        }
    }

    public enum Category { All, Undefined, Defined, Other }
}
