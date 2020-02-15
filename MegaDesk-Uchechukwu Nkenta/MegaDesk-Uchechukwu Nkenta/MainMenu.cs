using System;
using System.Windows.Forms;

namespace MegaDesk_Uchechukwu_Nkenta
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {

        }

        private void Desk_Click(object sender, EventArgs e)
        {

        }

        private void AddNewQuoteBtn_Click(object sender, EventArgs e)
        {
            AddQuote addnewQuote = new AddQuote
            {
                Tag = this
            };
            addnewQuote.Show(this);
            Hide();
        }

        private void ViewQuotesBtn_Click(object sender, EventArgs e)
        {
            ViewAllQuotes viewQuotes = new ViewAllQuotes
            {
                Tag = this
            };
            viewQuotes.Show(this);
            Hide();
        }

        private void SearchQuotesBtn_Click(object sender, EventArgs e)
        {
            SearchQuotes searchQuotes = new SearchQuotes
            {
                Tag = this
            };
            searchQuotes.Show(this);
            Hide();
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
