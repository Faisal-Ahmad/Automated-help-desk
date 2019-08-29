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
    public partial class ChangeRoom : UserControl
    {
       
        Employee_Info emp = new Employee_Info();
        int E_Id;
        public ChangeRoom()
        {
            InitializeComponent();
            textBox1.Enabled = false;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public void set_Emp_Id(int id)
        {
            this.E_Id = id;
            string RoomNo = emp.ret_Emp_Room(id);
            textBox1.Text = RoomNo;
            List<int> rooms = emp.Ret_Empty_Room();
            foreach (int room in rooms)
            {
                comboBox1.Items.Add(room.ToString());
            }
        }
        private void ChangeRoom_Load(object sender, EventArgs e)
        {
          
           
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            if(comboBox1.Text.Length==0)
            {
                MessageBox.Show("Select A Room First");
            }
            else
            {
                string result;
                if (textBox1.Text == "00")
                {
                    result= emp.setEmpRoom(this.E_Id, int.Parse(comboBox1.Text));
                }
                else
                {
                     result = emp.UpdateEmpRoom(this.E_Id, int.Parse(comboBox1.Text));
                }
                MessageBox.Show(result);
            }
        }
    }
}
