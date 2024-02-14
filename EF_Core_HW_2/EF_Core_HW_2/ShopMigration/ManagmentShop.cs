using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_HW_2.ShopMigration
{
    internal class ManagmentShop
    {
        private readonly MigrationContext _db;
        public void AddOrder(string nameOrder,params Product[] products)
        {
            _db.Add(new Order { Title = nameOrder, Products = products.ToList() });
            _db.SaveChanges();
        }
        public void DeleteOrderById(int id) {
            var currentOrder=_db.Orders.FirstOrDefault(e => e.Id == id);
            if(currentOrder is not null)
            {
                _db.Remove(currentOrder);
                _db.SaveChanges();
            }
        }


        public void GetorderById(int orderId)
        {
            var currentOrder = _db.Orders.Include(e=>e.Products).FirstOrDefault(e => e.Id == orderId);
            if (currentOrder is not null)
            {
                Console.WriteLine($"Name order {currentOrder.Title}\n");
                foreach (var item in currentOrder.Products)
                {
                    Console.WriteLine($"Name product {item.Title} Price {item.Price}\n");
                }
            }
        }

        public ManagmentShop(MigrationContext db)=>_db = db;
        
    }
}
