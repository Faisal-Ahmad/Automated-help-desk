using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelpDesk
{
    public partial class SeekHelpForm : Form
    {
        public SeekHelpForm()
        {
            InitializeComponent();
            enquiry1.setSeekhelp(this);
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
          
            enquiry1.BringToFront();
           
        }

        private void bunifuFlatButton3_Click_1(object sender, EventArgs e)
        {
           // employeeList1.BringToFront();
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
           DialogResult result = MessageBox.Show("You Want To Leave the System","Confirmation",MessageBoxButtons.YesNo);
            if(result== DialogResult.Yes)
            {
                Form1 f1 = new Form1();
                this.Hide();
                f1.Show();
            }
        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            feedBack1.BringToFront();
        }

        private void enquiry1_Load(object sender, EventArgs e)
        {
            
        }

        private void enquiry1_Load_1(object sender, EventArgs e)
        {
            
        }

        private void feedBack1_Load(object sender, EventArgs e)
        {

        }
    }
}
