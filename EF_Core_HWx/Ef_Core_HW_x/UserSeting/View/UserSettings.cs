using Ef_Core_HW_x.UserSeting.Control;
using Ef_Core_HW_x.UserSeting.Data;
using Ef_Core_HW_x.UserSeting.Model;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Ef_Core_HW_x
{
    public partial class UserSettings : Form
    {

        ContextUser db() => new ApplicationContextFactory().CreateDbContext();
        ControlUserSetting controlUserSetting;
        public UserSettings()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Load += UserSettings_Load;


        }

        private void UserSettings_Load(object? sender, EventArgs e)
        {
            controlUserSetting = new ControlUserSetting();
            using (ContextUser db1 = db())
            {
                //db.Database.EnsureDeleted();
                db1.Database.EnsureCreated();
                ifoGridView.DataSource = controlUserSetting.SelectUserAndSetting(db1);
            }
        }

        private void addUserButton_Click(object sender, EventArgs e)
        {

            User user = new User { Name = userNameTextBox.Text, Email = userEmailTextBox.Text };
            SettingUser setting = new SettingUser { Loggin = userLogginTextBox.Text, Pass = userPassTextBox.Text, User = user };
            using (ContextUser db1 = db())
            {
                controlUserSetting.AddUserAndSetting(setting, db1);
                ifoGridView.DataSource = controlUserSetting.SelectUserAndSetting(db1);
            }
            userNameTextBox.Clear();
            userEmailTextBox.Clear();
            userLogginTextBox.Clear();
            userPassTextBox.Clear();
        }

        private void deleteUserById_Click(object sender, EventArgs e)
        {
            using (ContextUser db1 = db())
            {
                controlUserSetting.DeleteUserById(db1,Convert.ToInt32(userIdTextBox.Text));
                ifoGridView.DataSource = controlUserSetting.SelectUserAndSetting(db1);
            }
        }
    }
}
