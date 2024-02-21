using Ef_Core_HW_x.PublishingHouse.Data;
using Ef_Core_HW_x.PublishingHouse.Model;
using Microsoft.EntityFrameworkCore;


namespace Ef_Core_HW_x.PublishingHouse.Control
{
    internal class PublishersControl : ICrudPublishing
    {
        public void Add(PublishContext db, object obj)
        {
            Publisher publisher = (Publisher)obj;
            db.Add(publisher);
            db.SaveChanges();
        }

        public void Delete(PublishContext db, int id)
        {
            db.Database.ExecuteSqlRaw($"DELETE dbo.[Publishers] WHERE dbo.[Publishers].[Id]={id}");
            db.SaveChanges();
        }

        public void Edit(PublishContext db, int id)
        {
            throw new NotImplementedException();
        }
    }
}
