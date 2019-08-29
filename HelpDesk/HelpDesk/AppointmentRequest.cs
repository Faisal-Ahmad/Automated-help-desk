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
    public partial class AppointmentRequest : UserControl
    {
        Employee_Info emp = new Employee_Info();
        int e_id;
        string id ;
       public AppointmentRequest()
        {
            InitializeComponent();
      
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
      public void setId(int id)
        {
            this.e_id = id;
           
        }
        public void refresh()
        {
            bunifuCustomDataGrid1.DataSource = emp.retAppData(this.e_id);
        }
        private void AppointmentRequest_Load(object sender, EventArgs e)
        {
            refresh();
            panel1.Hide();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            try
            {
                id = bunifuCustomDataGrid1.Rows[bunifuCustomDataGrid1.SelectedCells[0].RowIndex].Cells[0].Value.ToString();

                panel1.Show();
            }
            catch(Exception)
            {
                MessageBox.Show("Select An Id First");
            }
        }

        private void appointmentDetails1_Load(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
          //  MessageBox.Show(this.id);
          MessageBox.Show( emp.acceptRequest(int.Parse(id)));
            panel1.Hide();

        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            panel1.Hide();
            MessageBox.Show(emp.rejectRequest(int.Parse(id)));
            refresh();
        }

        private void bunifuThinButton25_Click(object sender, EventArgs e)
        {
            panel1.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            try
            {
               
                object result = emp.retAppInfo(int.Parse(id));
                Appointment_Table ap = (Appointment_Table)result;
                DateTime date =(DateTime) ap.Date;
                var d = date.Date;
                label7.Text = d.Day.ToString()+"/"+d.Month.ToString()+"/"+d.Year.ToString();
                richTextBox1.Text = ap.Purpose;
                label1.Text = ap.Time;
                refresh();
            }
            catch (Exception)
            {
               
            }
        }

        private void bunifuCustomDataGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
