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
    public partial class SeeVisitorList : UserControl
    {
        Employee_Info emp = new Employee_Info();
        public SeeVisitorList()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public void refresh()
        {
            bunifuCustomDataGrid1.DataSource = emp.retAppData();
        }
        private void SeeVisitorList_Load(object sender, EventArgs e)
        {
            refresh();
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are You Sure To Delete This Information","Confirmation",MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                string id = bunifuCustomDataGrid1.Rows[bunifuCustomDataGrid1.SelectedCells[0].RowIndex].Cells[0].Value.ToString();
                emp.deleteAppData(int.Parse(id));
                MessageBox.Show("Deleted SuccessFully");
                refresh();
            }
            
        }

        private void bunifuCustomDataGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
