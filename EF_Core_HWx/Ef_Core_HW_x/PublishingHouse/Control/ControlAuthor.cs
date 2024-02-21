using Ef_Core_HW_x.PublishingHouse.Data;
using Ef_Core_HW_x.PublishingHouse.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ef_Core_HW_x.PublishingHouse.Control
{
    internal class ControlAuthor : ICrudPublishing
    {
        public void Add(PublishContext db, object obj)
        {
            Author author = (Author)obj;
            db.Add(author);
            db.SaveChanges();
        }

        public void Delete(PublishContext db, int id)
        {
            db.Database.ExecuteSqlRaw($"DELETE dbo.[Autors] WHERE [Autors].Id={id}");
            db.SaveChanges();
        }

        public void Edit(PublishContext db, int id)
        {
            throw new NotImplementedException();
        }
    }
}
