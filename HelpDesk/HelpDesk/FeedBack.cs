using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business_logic_Layer;

namespace HelpDesk
{
    public partial class FeedBack : UserControl
    {
        Employee_Info emp = new Employee_Info();
        public FeedBack()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
           string result = emp.SaveFeedBack(richTextBox1.Text);
            MessageBox.Show(result);
        }
    }
}
