using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Access_Layer;
using Business_logic_Layer;
using System.Windows.Forms;

namespace HelpDesk
{
    public partial class Form9 : Form
    {
        int emp_Id;
        Employee_Info emp = new Employee_Info();
        Form8 temp;
        public Form9(int id,Form8 temp)
        {
            InitializeComponent();
            this.emp_Id = id;
            this.temp = temp;
        }

        private void changeRoom1_Load(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            changeRoom1.set_Emp_Id(emp_Id);
            changeRoom1.BringToFront();     
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            deleteEmployee1.setId(this.emp_Id);
            deleteEmployee1.BringToFront();
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            
           Form8 f8 = new Form8(this.emp_Id);
            this.Hide();
            f8.Show();
            
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            update1.BringToFront();
            
        }

        private void update1_Load(object sender, EventArgs e)
        {
            update1.receiveId(emp_Id);
            
        }

        private void changeRoom1_Load_1(object sender, EventArgs e)
        {

        }

        private void Form9_Load(object sender, EventArgs e)
        {
            update1.receiveId(emp_Id);
        }
    }
}
