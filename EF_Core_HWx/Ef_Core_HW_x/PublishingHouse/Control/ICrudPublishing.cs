using Ef_Core_HW_x.PublishingHouse.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ef_Core_HW_x.PublishingHouse.Control
{
    internal interface ICrudPublishing
    {
        public void Add(PublishContext db,object obj);
        public void Delete(PublishContext db, int id);
        public void Edit(PublishContext db, int id);

    }
}
