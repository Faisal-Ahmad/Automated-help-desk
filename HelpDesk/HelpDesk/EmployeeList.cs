using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelpDesk
{
    public partial class EmployeeList : UserControl
    {
        public EmployeeList()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            SeekHelpForm s1 = new SeekHelpForm();
          //  GoSeekHelp s2 = new GoSeekHelp();
          //  s2.Show();
            s1.Close();
        }
    }
}
