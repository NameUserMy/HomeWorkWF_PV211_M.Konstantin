using Ef_Core_HW_x.PublishingHouse.Control;
using Ef_Core_HW_x.PublishingHouse.Data;
using Ef_Core_HW_x.PublishingHouse.Model;
namespace Ef_Core_HW_x.PublishingHouse.View.ViewCrud
{




    public partial class Delete : Form
    {
        private PublishContext db() => new IFactoriContext().CreateDbContext();
        private Dictionary<string, ICrudPublishing>? crudPublishin;
        private string? tabInncoming;
        private TabControl _dGV;
        public Delete()
        {
            InitializeComponent();
            this.Load += Delete_Load;
        }

        private void Delete_Load(object? sender, EventArgs e)
        {
            crudPublishin = new Dictionary<string, ICrudPublishing>
            {
                { "Books", new BookControl() },
                { "Authors", new ControlAuthor()},
                { "Publishers", new PublishersControl()},

            };
        }


        internal void SendTabControl(TabControl contr)
        {
            _dGV = contr;
        }
        internal void SendTab(string tab)
        {
            tabInncoming = tab;

        }
        private void confirmDeleteButton_Click(object sender, EventArgs e)
        {
            using (PublishContext db1 = db())
            {
                switch (tabInncoming)
                {
                    case "Books":

                        crudPublishin[tabInncoming].Delete(db1, Convert.ToInt32(idTextBox.Text));
                        var bG = _dGV.TabPages[0].Controls.Find("booksGridView", true);
                        DataGridView bookGrid = (DataGridView)bG[0];
                        bookGrid.DataSource = db1.Books.ToList();
                        break;
                    case "Authors":
                        crudPublishin[tabInncoming].Delete(db1, Convert.ToInt32(idTextBox.Text));
                        var aG = _dGV.TabPages[1].Controls.Find("authorsDataGridView", true);
                        DataGridView authorGrid = (DataGridView)aG[0];
                        authorGrid.DataSource = db1.Authors.ToList();
                        break;
                    case "Publishers":
                        crudPublishin[tabInncoming].Delete(db1, Convert.ToInt32(idTextBox.Text));
                        var pG = _dGV.TabPages[2].Controls.Find("publisherDataGridView", true);
                        DataGridView publishGrid = (DataGridView)pG[0];
                        publishGrid.DataSource = db1.Publishers.ToList();
                        break;
                    default:
                        break;
                }
            }
        }

        private void cencelDeleteButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
