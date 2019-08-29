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
    public partial class SendAppointmentRequest : UserControl
    {
        Employee_Info emp = new Employee_Info();
        int E_Id;
        public SendAppointmentRequest()
        {
            InitializeComponent();
       
        }
        public void setId(int id)
        {
            this.E_Id = id;
        }
        private void label3_Click(object sender, EventArgs e)
        {
           
            Application.Exit();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            DateTime reqdate = dateTimePicker1.Value.Date;
            if (reqdate <DateTime.Today)
            {
                MessageBox.Show("Select Valid Date and Time");
            }
            if(textBox1.Text.Length==0)
            {
                MessageBox.Show("Enter The Purpose");
            }
            else
            {
                string result = emp.AppRequest(this.E_Id, textBox1.Text, reqdate);
                MessageBox.Show(result);
                bunifuThinButton21.Enabled = false;
            }
        }
    }
}
