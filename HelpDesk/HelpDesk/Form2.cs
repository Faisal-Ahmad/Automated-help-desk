using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business_logic_Layer;

namespace HelpDesk
{
    public partial class Form2 : Form
    {
        Employee_Info emp = new Employee_Info();
        int E_Id;
        public Form2(int id)
        {
            InitializeComponent();
            E_Id = id;
            currentStatus1.setId(id);
            appointmentRequest1.setId(id);
            currentStatus1.BringToFront();

        }

        private void noticeBoard1_Load(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            currentStatus1.BringToFront();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            appointmentRequest1.setId(this.E_Id);
            appointmentRequest1.BringToFront();
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            noticeBoard1.BringToFront();
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            changePasswordEmployee1.setId(this.E_Id);
            changePasswordEmployee1.BringToFront();
        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            
            Form1 f2 = new Form1();
            this.Hide();
           
            f2.Show();
            
        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
            postNoticeEmployee1.setId(this.E_Id);
            postNoticeEmployee1.BringToFront();
        }

        private void currentStatus1_Load(object sender, EventArgs e)
        {
            
        }

        private void bunifuFlatButton7_Click(object sender, EventArgs e)
        {
            panel2.BringToFront();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            bunifuCustomDataGrid1.DataSource = emp.RetAllAppData(this.E_Id);
        }
    }
}
