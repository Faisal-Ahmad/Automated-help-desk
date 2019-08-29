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
    public partial class Form8 : Form
    {
        int E_id;
        public Form8(int id)
        {
            InitializeComponent();
            this.E_id = id;
            
        }

        private void bunifuCustomLabel1_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            addEmployee1.BringToFront();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            searchEmplyee1.refresh();
            searchEmplyee1.BringToFront();
            searchEmplyee1.takeRef(this);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            seeVisitorList1.BringToFront();
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            changePassword1.setId(this.E_id);
            changePassword1.BringToFront();
        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            
            
            Form1 f1 = new Form1();

            this.Hide();
            
            f1.Show();
            
            
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuMetroTextbox3_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
            postNotice1.BringToFront();
            postNotice1.setId(E_id);
        }

        private void Form8_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void addEmployee1_Load(object sender, EventArgs e)
        {

        }
    }
}
