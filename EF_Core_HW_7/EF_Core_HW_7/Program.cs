using EF_Core_HW_7.BookFastPrice.Control;
using EF_Core_HW_7.BookFastPrice.Data;
using EF_Core_HW_7.BookFastPrice.Model;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;


namespace EF_Core_HW_7
{
    internal class Program
    {
        static void Main(string[] args)
        {

            BookContext ConnectDb() => new ApplicationContextFactory().CreateDbContext();
            #region SP_Price

            //using (BookContext db = ConnectDb())
            //{
            //    #region fill data
            //    //db.Database.EnsureDeleted();
            //    //db.Database.EnsureCreated();

            //    //List<Book> Johnbooks = new List<Book>() {
            //    //new Book{Title="First",Price=25},
            //    //new Book{Title="Second",Price=25},
            //    //};
            //    //List<Book> Devidbooks = new List<Book>() {
            //    //new Book{Title="First",Price=70},
            //    //new Book{Title="Second",Price=25},
            //    //};

            //    //List<Author> authors = new List<Author>()
            //    //{
            //    //    new Author{Name="John",Books=Johnbooks},
            //    //    new Author{Name="Devid",Books=Devidbooks},
            //    //};

            //    //db.AddRange(authors);
            //    //db.SaveChanges();
            //    #endregion

            //    ManagmentBooks managmentBooks = new ManagmentBooks(db);

            //    managmentBooks.ChangePriceByAuthor(1, 20);

            //    var info = db.Authors.Join(db.Books, e => e.Id, e => e.Authors[0].Id, (a, b) => new
            //    {
            //        Name = a.Name,
            //        TiteB = b.Title,
            //        Price = b.Price,
            //        Id=a.Id,

            //    }).Where(e=>e.Id==1);

            //    foreach (var item in info)
            //    {
            //        Console.WriteLine($"{item.Name}, {item.Price} {item.TiteB} ");
            //    }

            //}
            #endregion

            #region order 
            //using (BookContext db = ConnectDb())
            //{
            //    #region fill data

            //    //List<Customer> customers = new List<Customer>()
            //    //    {
            //    //        new Customer {Name="Kris"},
            //    //        new Customer {Name="Valery"},
            //    //        new Customer {Name="Edd"},
            //    //        new Customer {Name="John"},
            //    //        new Customer {Name="Bob"},
            //    //        new Customer {Name="Ann"}
            //    //    };
            //    //List<Orders> orders = new List<Orders>()
            //    //    {
            //    //        new Orders{OrderDate=new DateTime(2024,01,07,18,17,0),TotalCount=31,Customer=customers[0]},
            //    //        new Orders{OrderDate=new DateTime(2024,01,13,18,17,0),TotalCount=750,Customer=customers[0]},
            //    //        new Orders{OrderDate=DateTime.Now,TotalCount=200,Customer=customers[0]},

            //    //        new Orders{OrderDate=new DateTime(2024,01,07,18,17,0),TotalCount=31,Customer=customers[1]},
            //    //        new Orders{OrderDate=new DateTime(2024,01,13,18,17,0),TotalCount=700,Customer=customers[1]},
            //    //        new Orders{OrderDate=DateTime.Now,TotalCount=200,Customer=customers[1]},

            //    //        new Orders{OrderDate=new DateTime(2024,01,07,18,17,0),TotalCount=31,Customer=customers[2]},
            //    //        new Orders{OrderDate=new DateTime(2024,01,13,18,17,0),TotalCount=700,Customer=customers[2]},
            //    //        new Orders{OrderDate=DateTime.Now,TotalCount=200,Customer=customers[2]},


            //    //        new Orders{OrderDate=new DateTime(2024,01,07,18,17,0),TotalCount=30,Customer=customers[3]},
            //    //        new Orders{OrderDate=new DateTime(2024,01,13,18,17,0),TotalCount=700,Customer=customers[3]},
            //    //        new Orders{OrderDate=DateTime.Now,TotalCount=200,Customer=customers[3]},

            //    //        new Orders{OrderDate=new DateTime(2024,01,07,18,17,0),TotalCount=200,Customer=customers[4]},
            //    //        new Orders{OrderDate=new DateTime(2024,01,13,18,17,0),TotalCount=700,Customer=customers[4]},
            //    //        new Orders{OrderDate=DateTime.Now,TotalCount=500,Customer=customers[4]},

            //    //         new Orders{OrderDate=new DateTime(2024,01,07,18,17,0),TotalCount=200,Customer=customers[5]},
            //    //        new Orders{OrderDate=new DateTime(2024,01,10,18,17,0),TotalCount=700,Customer=customers[5]},
            //    //        new Orders{OrderDate=DateTime.Now,TotalCount=500,Customer=customers[5]},
            //    //    };
            //    //db.AddRange(orders);
            //    //db.SaveChanges();
            //    #endregion
            //    var kss = db.Customers.FromSqlRaw("dbo.sp_GetTop5").ToList();
            //    foreach (var item in kss)
            //    {
            //        Console.WriteLine(item.Name);

            //    }
            //}
            #endregion
        }
    }

}
