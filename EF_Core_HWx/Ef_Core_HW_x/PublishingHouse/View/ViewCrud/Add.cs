using Ef_Core_HW_x.PublishingHouse.Control;
using Ef_Core_HW_x.PublishingHouse.Data;
using Ef_Core_HW_x.PublishingHouse.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Reflection.Metadata.BlobBuilder;

namespace Ef_Core_HW_x.PublishingHouse.View.ViewBook
{
    public partial class Add : Form
    {
        private PublishContext db() => new IFactoriContext().CreateDbContext();
        private Dictionary<string, ICrudPublishing> crudPublishin;
        private Book book;
        private Author author;
        private Publisher publisher;
        private TabControl _dGV;
        private string tabInncoming;
        public Add()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Load += AddBook_Load;

        }

        private void AddBook_Load(object? sender, EventArgs e)
        {
            crudPublishin = new Dictionary<string, ICrudPublishing>
            {
                { "Books", new BookControl() },
                { "Authors", new ControlAuthor()},
                { "Publishers", new PublishersControl()},

            };
            switch (tabInncoming)
            {
                case "Books":
                    label1.Text = "Title";
                    label2.Text = "Genre";
                    break;
                case "Authors":
                    label1.Text = "Name";
                    label2.Text = "Lname";
                    break;
                case "Publishers":
                    label1.Text = "Title";
                    label2.Text = "Adress";
                    break;
                default:
                    break;
            }

        }

        internal void SendTab(string tab)
        {
            tabInncoming = tab;

        }

        internal void SendTabControl(TabControl contr)
        {
            _dGV = contr;
        }
        private void confirmBookButton_Click(object sender, EventArgs e)
        {
            using (PublishContext db1 = db())
            {
                switch (tabInncoming)
                {
                    case "Books":
                        book = new Book { Title = TitleTextBox.Text, Genre = genreTextBox.Text, Description = descriptionTextBox.Text };
                        crudPublishin[tabInncoming].Add(db1, book);
                        var bG = _dGV.TabPages[0].Controls.Find("booksGridView", true);
                        DataGridView bookGrid = (DataGridView)bG[0];
                        bookGrid.DataSource = db1.Books.ToList();
                        break;
                    case "Authors":
                        author = new Author { Name = TitleTextBox.Text, Lname = genreTextBox.Text, Description = descriptionTextBox.Text };
                        crudPublishin[tabInncoming].Add(db1, author);
                        var aG = _dGV.TabPages[1].Controls.Find("authorsDataGridView", true);
                        DataGridView authorGrid = (DataGridView)aG[0];
                        authorGrid.DataSource = db1.Authors.ToList();
                        break;
                    case "Publishers":
                        publisher = new Publisher { Title = TitleTextBox.Text, Adress = genreTextBox.Text, Description = descriptionTextBox.Text };
                        crudPublishin[tabInncoming].Add(db1, publisher);
                        var pG = _dGV.TabPages[2].Controls.Find("publisherDataGridView", true);
                        DataGridView publishGrid = (DataGridView)pG[0];
                        publishGrid.DataSource = db1.Publishers.ToList();
                        break;
                    default:
                        break;
                }


            }

            MessageBox.Show(tabInncoming);
        }

        private void cencelBookButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
