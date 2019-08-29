using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business_logic_Layer;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace HelpDesk
{
    public partial class AddEmployee : UserControl
    {

        string img;
        Employee_Info emp = new Employee_Info();
        public AddEmployee()
        {
            InitializeComponent();
            bunifuThinButton21.Enabled = true;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "JPG Files (*.jpg) |*.jpg | PNG Files (*.png) |*.png";

            if (dlg.ShowDialog() == DialogResult.OK)
            {

                img = dlg.FileName.ToString();
                pictureBox2.ImageLocation = img;
            }
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            
            if (bunifuMetroTextbox1.Text.Equals("Full Name") || bunifuMetroTextbox3.Text.Equals("Phone") || bunifuMetroTextbox4.Text.Equals("Email") || bunifuCustomTextbox1.Text.Equals("Address")|| img == null || bunifuCustomTextbox2.Text.Equals("Qualification") || radioButton1.Checked == false || radioButton1.Checked == false)
            {
                MessageBox.Show("Fill All Information First!");
            }
            else
            {
                bunifuMetroTextbox1.Text.Trim(' ');
                bunifuMetroTextbox3.Text.Trim(' ');
                bunifuMetroTextbox4.Text.Trim(' ');
                bunifuCustomTextbox1.Text.Trim(' ');
                bunifuCustomTextbox2.Text.Trim(' ');
                try
                {
                    if (bunifuMetroTextbox3.Text.Length < 11 || bunifuMetroTextbox3.Text.Length > 13)
                    {
                        MessageBox.Show("Enter Full Phnone Number");
                        int Number = int.Parse(bunifuMetroTextbox3.Text);

                    }

                    else
                    {
                        if (bunifuMetroTextbox4.Text.Contains("@") && bunifuMetroTextbox4.Text.Contains(".com"))
                        {
                            int cc = 0, ac = 0;
                            foreach (Match m in Regex.Matches(bunifuMetroTextbox4.Text, ".com"))
                            {
                                cc++;
                            }
                            foreach (Match m in Regex.Matches(bunifuMetroTextbox4.Text, "@"))
                            {
                                ac++;
                            }
                            if (cc == 1 && ac == 1)
                            {
                                bool accepetName = true;

                                string name = bunifuMetroTextbox1.Text;
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
                                    try
                                    {

                                        bool g;
                                        if (radioButton1.Checked == true)
                                        {
                                            g = true;
                                        }
                                        else { g = false; }
                                        string result = emp.AddEmployee(bunifuMetroTextbox1.Text, bunifuMetroTextbox3.Text, bunifuMetroTextbox4.Text, bunifuCustomTextbox1.Text, g, bunifuCustomTextbox2.Text, img);
                                        MessageBox.Show(result);
                                        bunifuMetroTextbox1.Text = "";
                                        bunifuMetroTextbox3.Text = "";
                                        bunifuMetroTextbox4.Text = "";
                                        bunifuCustomTextbox1.Text = "";
                                        bunifuCustomTextbox2.Text = "";
                                        bunifuCustomTextbox1.Text = "";
                                        img = null;
                                        pictureBox2.ImageLocation = null;
                                    }
                                    catch (Exception)
                                    {
                                        MessageBox.Show("Error !");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Only letters and '.' and space are accepted");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Enter Correct Email Address");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Enter A valid Email ASddress");
                        }

                    }

                }
                catch (FormatException)
                {
                    MessageBox.Show("Enter A valid Phone Number");
                }
            }
        }

        private void bunifuMetroTextbox1_OnValueChanged(object sender, EventArgs e)
        {
            
        }

        private void bunifuMetroTextbox1_Click(object sender, EventArgs e)
        {
            if (bunifuMetroTextbox1.Text== "Name")
            {
                bunifuMetroTextbox1.Text = string.Empty;
            }
        }

        private void bunifuCustomTextbox1_Click(object sender, EventArgs e)
        {
            if (bunifuMetroTextbox1.Text == "Address")
            {
                bunifuMetroTextbox1.Text = string.Empty;
            }
        }
    }
}
