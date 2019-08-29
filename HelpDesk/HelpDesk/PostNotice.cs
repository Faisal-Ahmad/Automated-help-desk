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
   
    
    public partial class PostNotice : UserControl
    {
        Employee_Info emp = new Employee_Info();
        int Emp_Id;
        public PostNotice()
        {
            InitializeComponent();
            richTextBox2.Enabled = false;
        }
        public void setId(int id)
        {
            this.Emp_Id = id;
            richTextBox2.Text = emp.retLastNotice(this.Emp_Id);
        }
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if(richTextBox1.Text.Length==0)
            {
                MessageBox.Show("Enter A Notice First");
            }
            else
            {
               
               string result = emp.postNotice(this.Emp_Id,richTextBox1.Text);
                MessageBox.Show(result);
                richTextBox2.Text = richTextBox1.Text;
                richTextBox1.Text = "";
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void PostNotice_Load(object sender, EventArgs e)
        {
         
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            emp.postNotice(this.Emp_Id, "   ");
            richTextBox2.Text = "";
        }
    }
}
