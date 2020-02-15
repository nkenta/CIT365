using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MegaDesk_Uchechukwu_Nkenta
{
    public partial class ViewAllQuotes : Form
    {
           public ViewAllQuotes()
        {
            InitializeComponent();
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ViewAllQuotes_FormClosed(object sender, FormClosedEventArgs e)
        {
            var mainMenu = (MainMenu)Tag;
            mainMenu.Show();
        }

        private void ViewAllQuotes_Load(object sender, EventArgs e)
        {
            
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
             MainMenu mainMenuForm = (MainMenu)Tag;
            mainMenuForm.Show();
            Close();
        }
    }
}
