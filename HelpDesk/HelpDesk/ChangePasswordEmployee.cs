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
    public partial class ChangePasswordEmployee : UserControl
    {
        Employee_Info emp = new Employee_Info();
        int Emp_Id;
        public ChangePasswordEmployee()
        {
            InitializeComponent();
        }
        public void setId(int id)
        {
            this.Emp_Id = id;
        }
        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            bool result = emp.passcheck(Emp_Id, bunifuMetroTextbox3.Text);
            if (result == false)
            {
                MessageBox.Show("Entered A Wrong Password");
            }
            else
            {
                if (bunifuMetroTextbox4.Text.Equals(bunifuMetroTextbox5.Text))
                {
                    bool respass = emp.UpdatePassword(Emp_Id, bunifuMetroTextbox4.Text);
                    if (respass == true)
                    {
                        MessageBox.Show("Password Updated");
                    }
                    else { MessageBox.Show("Database Problems"); }

                }
                else
                {
                    MessageBox.Show("New Passwords Doesn't Matched");
                }
            }
        }

        private void bunifuMetroTextbox3_OnValueChanged_1(object sender, EventArgs e)
        {
            if (bunifuMetroTextbox3.Text.Equals(""))
            {

                bunifuMetroTextbox3.isPassword = true;
            }
        }

        private void bunifuMetroTextbox4_OnValueChanged_1(object sender, EventArgs e)
        {
            if (bunifuMetroTextbox4.Text.Equals(""))
            {

                bunifuMetroTextbox4.isPassword = true;
            }
        }

        private void bunifuMetroTextbox5_OnValueChanged_1(object sender, EventArgs e)
        {
            if (bunifuMetroTextbox5.Text.Equals(""))
            {

                bunifuMetroTextbox5.isPassword = true;
            }
        }
    }
    }

