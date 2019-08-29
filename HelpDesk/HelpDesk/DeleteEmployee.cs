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
    public partial class DeleteEmployee : UserControl
    {
        int E_id;
        Employee_Info emp = new Employee_Info();
        public DeleteEmployee()
        {
            InitializeComponent();
        }
        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public void setId(int id)
        {
            this.E_id = id;
        }
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            string result = emp.DeleteEmployee(this.E_id);
            MessageBox.Show(result);
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
           
        }
    }
}
