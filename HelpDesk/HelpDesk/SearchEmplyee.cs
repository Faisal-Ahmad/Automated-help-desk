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
    public partial class SearchEmplyee : UserControl
    {
        public Form8 temp;
        public SearchEmplyee()
        {
            InitializeComponent();
            
        }

        public void takeRef(Form8 temp)
        {
            this.temp = temp;
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text.Length == 0)
            {
                MessageBox.Show("Select An Id First");
            }
            else
            {
                Form9 f9 = new Form9(int.Parse(comboBox1.Text),this.temp);
                temp.Close();
                f9.Show();
            } 
            
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public void refresh()
        {
            comboBox1.Items.Clear();
            List<int> id = new Employee_Info().Ret_Emp_Id();
            foreach (int ids in id)
            {
                comboBox1.Items.Add(ids.ToString());
            }
        }
        private void SearchEmplyee_Load(object sender, EventArgs e)
        {
            
        }
    }
}
