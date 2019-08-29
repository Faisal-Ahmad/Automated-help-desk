using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business_logic_Layer;
using System.Windows.Forms;

namespace HelpDesk
{
    public partial class CurrentStatus : UserControl
    {
        Employee_Info emp = new Employee_Info();
        int E_Id;
        public CurrentStatus()
        {
            InitializeComponent();
            
        }
        public int setId(int id)
        {
            this.E_Id = id;
           // MessageBox.Show(id.ToString());
            return id;
        }
        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            //panel1.Show();
          
                int status=0;
         
                if (radioButton1.Checked == true)
                {
                    status = 1;
                }
                if (radioButton6.Checked == true)
                {
                    status = 6;
                }
                
           
                if (radioButton2.Checked == true)
                {
                    status = 2;
                   
                }

                if (radioButton3.Checked == true)
                {
                    status = 3;
                  
                }
                if (radioButton4.Checked == true)
                {
                    status = 4;
                   
                }
                if (radioButton5.Checked == true)
                {
                  
                    status = 5;
                }
            

            string result = emp.setStatus(E_Id, status);
            MessageBox.Show(result);
            // MessageBox.Show(E_Id.ToString());
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            //radioButton1.Checked = true;
        }

        private void CurrentStatus_Load(object sender, EventArgs e)
        {
            
            int status = emp.retStatus(E_Id);
            if(status==1)
            {
                radioButton1.Checked = true;
            }
            if (status == 2)
            {
                radioButton2.Checked = true;
             
            }
            if (status == 3)
            {
                radioButton3.Checked = true;
             
            }
            if (status == 4)
            {
                radioButton4.Checked = true;
               
            }
            if (status == 5)
            {
                radioButton5.Checked = true;
              
            }
            if (status == 6)
            {
                radioButton6.Checked = true;
            }
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
           
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
        
        }
    }
}
