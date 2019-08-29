using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business_logic_Layer;
using Data_Access_Layer;

namespace HelpDesk
{
 
    public partial class DetailsEmployee : UserControl
    {
        
        int E_id;
        Employee_Info emp = new Employee_Info();
        public DetailsEmployee()
        {
            InitializeComponent();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public void setId(int id)
        {
            this.E_id = id;
        }
        private void DetailsEmployee_Load(object sender, EventArgs e)
        {
            
           object result = emp.ReturnEmployee(this.E_id);
            Emp_Table emp_data = (Emp_Table)result;
            byte[] data = emp_data.Image.ToArray();
            MemoryStream stream = new MemoryStream(data);
            pictureBox2.Image = Image.FromStream(stream);
            label5.Text = emp_data.Address;
            label6.Text = emp_data.Qualification;
            int status = emp.retStatus(this.E_id);
            if (status == 1)
            {
                bunifuFlatButton1.ButtonText = "Active";
                bunifuFlatButton1.BackColor =Color.Green;
                bunifuFlatButton1.OnHovercolor = Color.Green; 
            }
            if (status == 2)
            {
                bunifuFlatButton1.ButtonText = "Busy";
                bunifuFlatButton1.BackColor = Color.Red;
                bunifuFlatButton1.OnHovercolor = Color.Red;
            }
            if (status == 3)
            {
                bunifuFlatButton1.ButtonText = "On Meeting";
                bunifuFlatButton1.BackColor = Color.RosyBrown;
                bunifuFlatButton1.OnHovercolor = Color.RosyBrown;
            }
            if (status == 4)
            {
                bunifuFlatButton1.ButtonText = "On Break";
                bunifuFlatButton1.BackColor = Color.Blue;
                bunifuFlatButton1.OnHovercolor = Color.Blue;

            }
            if (status == 5)
            {
                bunifuFlatButton1.ButtonText = "On Vacation";
                bunifuFlatButton1.BackColor = Color.Cyan;
                bunifuFlatButton1.OnHovercolor = Color.Cyan;
            }
            if (status == 6)
            {
                bunifuFlatButton1.ButtonText = "Out Of Office";
                bunifuFlatButton1.BackColor = Color.Cyan;
                bunifuFlatButton1.OnHovercolor = Color.Cyan;
            }
            string notice = emp.retLastNotice(this.E_id);
            richTextBox1.Text = notice;
            int room = int.Parse(emp.ret_Emp_Room(this.E_id));
            label4.Text = room.ToString();
        }
    }
}
