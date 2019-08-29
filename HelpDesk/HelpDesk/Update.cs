using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using Data_Access_Layer;
using Business_logic_Layer;
using System.Text.RegularExpressions;
namespace HelpDesk
{
    public partial class Update : UserControl
    {
        int emp_Id;
        Employee_Info emp = new Employee_Info();
        string img=null;
        public Update()
        {
            InitializeComponent();
            bunifuMetroTextbox2.Enabled = false;
        }
        public void receiveId(int id)
        {
            this.emp_Id = id;
            object result = emp.ReturnEmployee(this.emp_Id);
            Emp_Table emp_data = (Emp_Table)result;
            byte[] data = emp_data.Image.ToArray();
            MemoryStream stream = new MemoryStream(data);
            pictureBox2.Image = Image.FromStream(stream);
            bunifuMetroTextbox1.Text = emp_data.Name;
            bunifuMetroTextbox2.Text = emp_data.Id.ToString();
            bunifuMetroTextbox3.Text = emp_data.Phone;
            bunifuMetroTextbox4.Text = emp_data.Email;
            richTextBox1.Text = emp_data.Address;
            richTextBox2.Text = emp_data.Qualification;
            if(emp_data.Gender==true)
            {
                radioButton1.Checked = true;
            }
            else
            {
                radioButton2.Checked = true;
            }
        }
        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Update_Load(object sender, EventArgs e)
        {
          
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

        public void refreshAll()
        {
            bunifuMetroTextbox1.Text = "";
            bunifuMetroTextbox3.Text = "";
            bunifuMetroTextbox4.Text = "";
            richTextBox1.Text = "";
            richTextBox2.Text = "";
            bunifuMetroTextbox2.Text = "";
            img = null;
        }
        public void disablebutton()
        {
            bunifuThinButton21.Enabled = false;
        }
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            try
            {
                if (bunifuMetroTextbox3.Text.Length < 11 || bunifuMetroTextbox3.Text.Length > 13)
                {
                    MessageBox.Show("Enter Full Phnone Number");
                    double Number = int.Parse(bunifuMetroTextbox3.Text);

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
                                if (!((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z') || c == '.'))
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
                                    string result = emp.UpdateEmployee(this.emp_Id, bunifuMetroTextbox1.Text, bunifuMetroTextbox3.Text, bunifuMetroTextbox4.Text, richTextBox1.Text, g, richTextBox2.Text, img);
                                    MessageBox.Show(result);
                                    refreshAll();
                                   // bunifuThinButton21.Enabled = false;
                                }
                                catch (Exception)
                                {
                                    MessageBox.Show("Error !");
                                }
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
}
