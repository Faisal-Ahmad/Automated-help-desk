using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business_logic_Layer;

namespace HelpDesk
{
    public partial class GoSeekHelp : Form
    {
        int E_id;
        Employee_Info emp = new Employee_Info();
        public GoSeekHelp(int id)
        {
            InitializeComponent();
            this.E_id = id;
            detailsEmployee1.setId(id);
            sendAppointmentRequest1.setId(id);
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
         
            detailsEmployee1.BringToFront();
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            sendAppointmentRequest1.BringToFront();
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            SeekHelpForm s1 = new SeekHelpForm();
            this.Hide();
            s1.Show();
          
        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("You Want To Leave the System", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Form1 f1 = new Form1();
                this.Hide();
                f1.Show();
            }

        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            string room = emp.ret_Emp_Room(this.E_id);
            RoomMap rm = new RoomMap(int.Parse(room));
            rm.Show();
        }
    }
}
