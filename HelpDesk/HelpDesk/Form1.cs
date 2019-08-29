using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business_logic_Layer;
using Data_Access_Layer;
using System.Windows.Forms;
using HelpDesk.Properties;
using System.Text.RegularExpressions;

namespace HelpDesk
{
    public partial class Form1 : Form
    {
        Employee_Info emp = new Employee_Info();
        public Form1()
        {
            InitializeComponent();
        }
        private void form1_loader(object sender, EventArgs e)
        {
           
           panel3.Visible = false;
           panel4.Visible = false;
           //panel5.Visible = false;
           
        
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
           // panel3.Visible = true;
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //panel3.Visible = false;

        }

        private void button2_Click(object sender, EventArgs e)
        {
           
           // panel4.Visible = true;

            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //panel4.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //panel5.Visible = true;
           // panel5.Visible = true;
            Form1 f1 = new Form1();
            //Form6 f6 = new Form6();
            //f6.Show();
            f1.Close();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void bunifuMaterialTextbox3_OnValueChanged(object sender, EventArgs e)
        {
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
           // Form8 f1 = new Form8();
           // f1.Show();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            panel4.Visible = false;
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            panel3.Visible = false;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            panel4.Visible = true;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            panel3.Visible = true;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            bunifuMaterialTextbox3.Text = bunifuMaterialTextbox3.Text.Trim(' ');
            bunifuMaterialTextbox5.Text = bunifuMaterialTextbox5.Text.Trim(' ');
                try
                {
                    int e_id = int.Parse(bunifuMaterialTextbox3.Text);
                      bool idflag = emp.CheckId(e_id);
                    
                    if (idflag == true)
                    {
                        object employee = emp.ReturnEmployee(e_id);
                        Data_Access_Layer.Emp_Table user_emp = (Data_Access_Layer.Emp_Table)employee;
                        if (user_emp.Password == bunifuMaterialTextbox5.Text)
                        {
                            if (bunifuCheckbox1.Checked == true)
                            {
                                Settings.Default["U_Name"] = bunifuMaterialTextbox3.Text;
                                Settings.Default["U_Pass"] = bunifuMaterialTextbox5.Text;
                                Settings.Default["Remember"] = true;
                                Settings.Default.Save();
                            }
                            else
                            {
                                Settings.Default["U_Name"] = null;
                                Settings.Default["U_Pass"] = null;
                                Settings.Default["Remember"] = false;
                                Settings.Default.Save();

                            }
                            this.Hide();
                            if (user_emp.Admin == true)
                            {
                                Form8 f8 = new Form8(e_id);
                                this.Hide();
                                f8.Show();
                            }
                            else
                            {
                                Form2 f2 = new Form2(e_id);
                                this.Hide();
                                f2.Show();
                            }
                        }
                        else
                        {
                            MessageBox.Show("You Entered A Wrong Password");
                        }
                    }
                    else
                    {
                        MessageBox.Show("You Entered A Wrong Id");
                    }
                }
                catch (Exception x)
                {
                    MessageBox.Show(x.ToString());
                }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
           
            bunifuMaterialTextbox1.Text.Trim(' ');
            bunifuMaterialTextbox2.Text.Trim(' ');
            bunifuMaterialTextbox4.Text.Trim(' ');
            if (bunifuMaterialTextbox1.Text.Length == 0 || bunifuMaterialTextbox2.Text.Length == 0 || bunifuMaterialTextbox4.Text.Length == 0)
            {
                MessageBox.Show("Enter All Information First");
            }
            else
            {
                try
                {
                    double Number = double.Parse(bunifuMaterialTextbox2.Text);
                    if (bunifuMaterialTextbox2.Text.Length < 11 || bunifuMaterialTextbox2.Text.Length > 13)
                    {
                        MessageBox.Show("Enter Full Phone Number");

                    }

                    else
                    {   
                        if (bunifuMaterialTextbox4.Text.Contains("@") && bunifuMaterialTextbox4.Text.Contains(".com"))
                        {
                            int cc = 0, ac = 0;
                            foreach (Match m in Regex.Matches(bunifuMaterialTextbox4.Text, ".com"))
                            {
                                cc++;
                            }
                            foreach (Match m in Regex.Matches(bunifuMaterialTextbox4.Text, "@"))
                            {
                                ac++;
                            }
                            if (cc == 1 && ac == 1)
                            {
                                bool accepetName = true;

                                string name = bunifuMaterialTextbox1.Text;
                                foreach (char c in name)
                                {
                                    if (!((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z') || c == '.' || c == ' '))
                                    {
                                        accepetName = false;
                                        break;

                                    }
                                }
                                if (accepetName == true)
                                {
                                    bool result =emp.SaveUser(bunifuMaterialTextbox1.Text,bunifuMaterialTextbox2.Text,bunifuMaterialTextbox4.Text);
                           
                                    SeekHelpForm sh = new SeekHelpForm();
                                    this.Hide();
                                    sh.Show();
                                }
                                else
                                {
                                    MessageBox.Show("Only letters and '.' are accepted");
                                }


                            }
                            else
                            {
                                MessageBox.Show("Enter Correct Email Address");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Enter A valid Email Address");
                        }

                    }

                }
                catch (FormatException)
                {
                    MessageBox.Show("Enter A valid Phone Number");
                }
            }


        }

        private void label3_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            if (Settings.Default["Remember"].Equals(true))
            {
                bunifuCheckbox1.Checked = true;
                bunifuMaterialTextbox3.Text = Settings.Default["U_Name"].ToString();
                bunifuMaterialTextbox5.isPassword = true;
                bunifuMaterialTextbox5.Text = Settings.Default["U_Pass"].ToString();
            }
            else
            {
                bunifuCheckbox1.Checked = false;
            }
        }

        private void bunifuMaterialTextbox5_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
