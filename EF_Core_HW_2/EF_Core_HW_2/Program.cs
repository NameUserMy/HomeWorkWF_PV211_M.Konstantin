
using EF_Core_HW_2.Education;
using EF_Core_HW_2.Education.Menu;
using EF_Core_HW_2.ShopMigration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Data.SqlTypes;
using System.Runtime.Serialization;

namespace EF_Core_HW_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Shop
            using (MigrationContext db = new MigrationContext())
            {
                ManagmentShop managmentShop = new ManagmentShop(db);
                List<Product> products = new List<Product>() {

                new Product{Title="some product 1",Description=" any",Price=25},
                new Product{Title="some product 2",Description=" any",Price=5},
                new Product{Title="some product 3",Description=" any",Price=17},

                };
                var forAddOrder = db.Products.First();
                managmentShop.AddOrder("Myfirst order", forAddOrder);

                var forAddManyOrder = db.Products;
                managmentShop.AddOrder("Many products order", forAddManyOrder.ToArray());

                managmentShop.DeleteOrderById(2);
                managmentShop.GetorderById(5);


            }
            #endregion

            #region Education
            using (ContextEducation db=new ContextEducation())
            {
                ManagementEducation management = new ManagementEducation(db);
                 db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                Menu menu = new Menu(management);
                menu.choice();
            }
            #endregion
        }
    }
}
