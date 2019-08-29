using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Data_Access_Layer;
using Business_logic_Layer;

namespace HelpDesk
{
    public partial class Enquiry : UserControl
    {
        public SeekHelpForm temp;
        Employee_Info a = new Employee_Info();
        public Enquiry()
        {
            InitializeComponent();

        }
        public void setSeekhelp(SeekHelpForm temp)
        {
            this.temp = temp;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private  void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            try
            {
                string id = bunifuCustomDataGrid1.Rows[bunifuCustomDataGrid1.SelectedCells[0].RowIndex].Cells[0].Value.ToString();
                GoSeekHelp log = new GoSeekHelp(int.Parse(id));
                log.Show();
                temp.Close();
            }
            catch(Exception)
            {
                MessageBox.Show("Select An Employee First");
            }
        }

        private void Enquiry_Load(object sender, EventArgs e)
        {

        }

        private void bunifuMetroTextbox3_KeyUp(object sender, KeyEventArgs e)
        {
            string t = bunifuMetroTextbox3.Text;
           

          
            bunifuCustomDataGrid1.DataSource = a.getEmployeeInfo(t);

        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCustomDataGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


          


        }

        private void bunifuMetroTextbox3_OnValueChanged(object sender, EventArgs e)
        {

        }
    }
}
