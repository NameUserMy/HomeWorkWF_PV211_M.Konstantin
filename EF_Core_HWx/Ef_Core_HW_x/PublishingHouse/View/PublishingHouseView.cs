using Ef_Core_HW_x.PublishingHouse.Control;
using Ef_Core_HW_x.PublishingHouse.Data;

using Ef_Core_HW_x.PublishingHouse.View.ViewBook;
using Ef_Core_HW_x.PublishingHouse.View.ViewCrud;
using Ef_Core_HW_x.UserSeting.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ef_Core_HW_x.PublishingHouse.View
{
    public partial class PublishingHouseView : Form
    {
        PublishContext db() => new IFactoriContext().CreateDbContext();
        string tab;
        public PublishingHouseView()
        {
            InitializeComponent();
            this.Load += PublishingHouseView_Load;

        }

        private void PublishingHouseView_Load(object? sender, EventArgs e)
        {

            tab = "Books";
            using (PublishContext db1 = db())
            {
                db1.Database.EnsureDeleted();
                db1.Database.EnsureCreated();
                var books = db1.Books.ToList();
                var authors = db1.Authors.ToList();
                var publishers = db1.Publishers.ToList();
                booksGridView.DataSource = books;
                authorsDataGridView.DataSource = authors;
                publisherDataGridView.DataSource = publishers;
            }
        }
        private void tabPublishControl_Selected(object sender, TabControlEventArgs e)
        {
            tab = e.TabPage.Tag.ToString();
        }

        private void addBookButton_Click(object sender, EventArgs e)
        {
            Add bg = new Add();
            bg.SendTab(tab);
            bg.SendTabControl(tabPublishControl);
            bg.ShowDialog();
        }

        private void deleteBookButton_Click(object sender, EventArgs e)
        {
            Delete bg = new Delete();
            bg.SendTab(tab);
            bg.SendTabControl(tabPublishControl);
            bg.ShowDialog();
        }
    }
}
