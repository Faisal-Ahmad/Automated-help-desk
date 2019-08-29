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
    public partial class NoticeBoard : UserControl
    {
        Employee_Info emp = new Employee_Info();
        public NoticeBoard()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void NoticeBoard_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = emp.retLastNotice(10005);
        }
    }
}
