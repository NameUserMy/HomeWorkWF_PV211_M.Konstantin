using Ef_Core_HW_x.UserSeting.Data;
using Ef_Core_HW_x.UserSeting.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Ef_Core_HW_x.UserSeting.Control
{
    
    internal class ControlUserSetting
    {
        

        public void AddUserAndSetting(SettingUser setting, ContextUser db)
        {

            db.Add(setting);
            db.SaveChanges();
            
        }
        public List<UsJoin> SelectUserAndSetting(ContextUser db)
        {

            List<UsJoin> any = db.Users.Join(db.SettingUsers, e => e.Id, e => e.UserId, (u, s) => new UsJoin
            {

                Id = u.Id,
                Name = u.Name,
                Email = u.Email,
                Loggin = s.Loggin,
                Pass = s.Pass,
            }).ToList() ;

            return any;
        }
        public  void DeleteUserById(ContextUser db,int id)
        {
            db.Database.ExecuteSqlRaw($"DELETE dbo.[Users] WHERE [Users].[Id]={id}");
            db.SaveChanges();
        }
    }
}
