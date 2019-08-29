using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Access_Layer;
using System.Drawing;



namespace Business_logic_Layer
{
    public class Employee_Info
    {
        static DataAccess database = new DataAccess();
        int id;
        string name;
        string phone;
        string email;
        string address;
        bool gender;
        string qualification;
        string img_path;
        int roomNo;
        public int Id
        {
            set { this.id = value; }
            get { return this.id; }
        }
        public string Name
        {
            set { this.name = value; }
            get { return this.name; }
        }
        public string Phone
        {
            set { this.phone = value; }
            get { return this.phone; }
        }
        public string Email
        {
            set { this.email = value; }
            get { return this.email; }
        }
        public string Address
        {
            set { this.address = value; }
            get { return this.address; }
        }
        public string Qualification
        {
            set { this.qualification = value; }
            get { return this.qualification; }
        }
        public string Img_path
        {
            set { this.img_path = value; }
            get { return this.img_path; }
        }
        public bool Gender
        {
            set { this.gender = value; }
            get { return this.gender; }
        }
        public int RoomNo
        {
            set { this.roomNo = value; }
            get { return this.roomNo; }
        }
   
        public string AddEmployee(string name, string phone, string email, string address, bool gender, string qualification, string img_path)
        {
            string result = database.AddEmployee(name, phone, email, address, gender, qualification, img_path);
       
            return result;

        }
        public string UpdateEmployee(int id,string name, string phone, string email, string address, bool gender, string qualification, string img_path)
        {
            string result = database.UpdateEmployee(id,name, phone, email, address, gender, qualification, img_path);

            return result;

        }
        public object ReturnEmployee(int id)
        {
            object result = database.ReturnEmployee(id);
            return result;
        }
        public List<int> Ret_all_Emp_Id()
        {
            List<int> id = database.Ret_all_Emp_Id();
            return id;
        }
        public bool CheckId(int id)
        {
            List<int> allid = database.Ret_all_Emp_Id();
            foreach (int ids in allid)
            {
                if (id== ids)
                {
                    return true;
                }
            }
            return false;
        }
        public List<int> Ret_Emp_Id()
        {
            List<int> id = database.Ret_Emp_Id();
            return id;
        }
        public List<int> Ret_Empty_Room()
        {
            List<int> room = database.ret_Empty_Room();
            return room;
        }
        public string ret_Emp_Room(int id)
        {
            int room = database.ret_Emp_Room(id);
           
            if(room==0)
            {
                return "00";
            }
            else
            {
                return room.ToString();
            }      
        }
        public string setStatus(int id ,int bit)
        {
            bool data = database.setStatus(id, bit);
            if(data == true)
            {
                return "Status Updated";
            }
            else
            {
                return "Database Problems";
            }
        }
        public int retStatus(int id)
        {
            return database.retStatus(id);
        }
        public string postNotice(int id,string Notice)
        {
            bool result = database.postNotice(id, Notice);
            if(result==true)
            {
                return "Your Notice Has Posted";
            }
            else
            {
                return "Notice Post Failed";
            }
        }
        public bool passcheck(int id,string password)
        {
            return database.passcheck(id, password);
           
        }
        public bool UpdatePassword(int id,string password)
        {
            return database.UpdatePassword(id, password);
           
        }
        public string retLastNotice(int id)
        {

            return database.retLastNotice(id);
        }
        public string SaveFeedBack(string feedback)
        {
            return database.SaveFeedBack(feedback);
        }
     public string setEmpRoom(int id,int room)
        {
            bool result = database.setEmpRoom(id, room);
           if(result==true)
            {
                return "Employee Room Updated";
            }
            else
            {
                return "Room Set Failed";
            }
        }
        public string UpdateEmpRoom(int id, int room)
        {
            return database.UpdateEmpRoom(id, room);
        }
        public string DeleteEmployee(int id)
        {
            return database.deleteEmployee(id);
         
        }
        public bool SaveUser(string name,string phone,string email)
        {
            return database.SaveUser(name, phone, email);
        }
        public string AppRequest(int id,string purpose,DateTime reqdate)
        {
            return database.AppRequest(id, purpose, reqdate);
        }
        public object getEmployeeInfo(string name)
        {
          return database.getEmployeeInfo(name);
        
        }
        public string rejectRequest(int id)
        {
            return database.rejectRequest(id);
        }
        public object retAppData(int id)
        {
            return database.retAppData(id);
           
        }
        public object RetAllAppData(int id)
        {
            return database.RetAllAppData(id);

        }
        public object retAppData()
        {
            object x = database.retAppData();
            return x;
        }
        public object retAppInfo(int id)
        {
            return database.retAppInfo(id);
        }
        public bool deleteAppData(int id)
        {
           return database.deleteAppData(id);
        }
        public string acceptRequest(int id)
        {
            return database.AcceptRequest(id);
        }
            static void Main()
        {

        }
    }
}
