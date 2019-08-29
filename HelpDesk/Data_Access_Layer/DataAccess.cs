using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Net.Mail;
using System.Net;
namespace Data_Access_Layer
{
    public class Emp_Data
    {
        int id;
        string name;
        string phone;
        string email;
        public Emp_Data(int id,string name, string phone, string email)
        {
            this.id = id;
            this.name = name;
            this.phone = phone;
            this.email = email;
        }
    }
    public class DataAccess
    {
        static DataConDataContext connection = new DataConDataContext(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Desktop\Final_Project_C#\CsharpProject1\HelpDesk\Data_Access_Layer\H_Desk_Database.mdf;Integrated Security=True;Connect Timeout=30");
        MailMessage message = new MailMessage();
        public string AddEmployee(string name, string phone, string email, string address, bool gender, string qualification, string img_path)
        {
            try
            {

                Emp_Table emp = new Emp_Table();
                emp.Name = name;
                emp.Phone = phone;
                emp.Email = email;
                emp.Address = address;
                emp.Gender = gender;
                emp.Qualification = qualification;
                FileStream fs = new FileStream(img_path, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                emp.Image = br.ReadBytes((int)fs.Length);
                emp.Password = "12345";
                emp.Admin = false;
                connection.Emp_Tables.InsertOnSubmit(emp);
                connection.SubmitChanges();
                var query = from a in connection.Emp_Tables where a.Id == connection.Emp_Tables.Max(ab => ab.Id) select a;
                Emp_Detail edt = new Emp_Detail();
                edt.Emp_Id = query.First().Id;
                edt.Curr_Status = (byte)1;
                connection.Emp_Details.InsertOnSubmit(edt);
                connection.SubmitChanges();
                return "Employee Information Saved!";
            }
            catch (Exception ex)
            {

                return ex.ToString();
            }

        }
        public string UpdateEmployee(int id,string name, string phone, string email, string address, bool gender, string qualification, string img_path)
        {
            try
            {
                var query = from a in connection.Emp_Tables where a.Id == id select a;
                if(query.Count() != 0)
                {
                    Emp_Table emp = query.First();
                    emp.Name = name;
                    emp.Phone = phone;
                    emp.Email = email;
                    emp.Address = address;
                    emp.Gender = gender;
                    emp.Qualification = qualification;
                    if (img_path != null)
                    {
                        FileStream fs = new FileStream(img_path, FileMode.Open, FileAccess.Read);
                        BinaryReader br = new BinaryReader(fs);
                        emp.Image = br.ReadBytes((int)fs.Length);
                    }
                    connection.SubmitChanges();

                    return "Employee Information Updated!";
                }
                else
                {
                    return "This Employee Is Not Exist";
                }
            }
            catch (Exception ex)
            {

                return ex.ToString();
            }

        }
        public object ReturnEmployee(int id)
        {
            var query = from a in connection.Emp_Tables where a.Id == id select a;
            object result = query.First();


            return result;

        }
        public List<int> Ret_all_Emp_Id()
        {
            List<int> allid = new List<int>();
            var query = from a in connection.Emp_Tables select a.Id;
            foreach (int id in query)
            {
                allid.Add(id);
            }
            return allid;

        }
        public List<int> Ret_Emp_Id()
        {
            List<int> allid = new List<int>();
            var query = from a in connection.Emp_Tables where a.Admin == false select a.Id;
            foreach (int id in query)
            {
                allid.Add(id);
            }
            return allid;

        }
        public List<int> ret_Empty_Room()
        {
            var query = from a in connection.Room_No_Tables where a.Reserved == false select a.Room_No;
            List<int> all_room = new List<int>();
            foreach (int room in query)
            {
                all_room.Add(room);
            }
            return all_room;
        }
        public int ret_Emp_Room(int id)
        {
            try
            {
                var query = from a in connection.Room_No_Tables where a.Emp_Id == id && a.Reserved==true select a.Room_No;
              
                int room = query.First();
                return room;
            }
            catch(Exception)
            {
                return 0;
            }
        }
        public bool setStatus(int id,int bit)
        {
            try
            {
                var query = from a in connection.Emp_Details where a.Emp_Id == id select a;
                Emp_Detail emp = query.First();
               emp.Curr_Status = (byte)bit;
               connection.SubmitChanges();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }
        public int retStatus(int id)
        {
            try
            {
                var query = from a in connection.Emp_Details where a.Emp_Id == id select a;
                int status = int.Parse(query.First().Curr_Status.ToString());
                return status;
            }
            catch(Exception)
            {
                return 0;
            }
        }
        public bool postNotice(int id,string Notice)
        {
            try
            {
                var query = from a in connection.Emp_Details where a.Emp_Id == id select a;
                Emp_Detail emp = query.First();
                emp.Notice = Notice;
                connection.SubmitChanges();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
            
        }
        public bool passcheck(int id, string password)
        {
            try
            {
                var query = from a in connection.Emp_Tables where a.Id == id select a;
                if (query.First().Password.Equals(password))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception)
            {
                return false;
            }
        }
        public bool UpdatePassword(int id, string password)
        {
            try
            {
                var query = from a in connection.Emp_Tables where a.Id == id select a;
                Emp_Table emp = query.First();
                emp.Password = password;
                connection.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public string retLastNotice(int id)
        {
            try
            {
                var query = from a in connection.Emp_Details where a.Emp_Id == id select a;
                return query.First().Notice;
            }
            catch(Exception)
            {
                return "No Notice Post Yet";
            }
        }

      
        public bool setEmpRoom(int id,int room)
        {
            try
            {
                var query = from a in connection.Room_No_Tables where a.Room_No == room select a;
              Room_No_Table roomtable = query.First();
               roomtable.Emp_Id = id;
                roomtable.Reserved = true;
               connection.SubmitChanges();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }
        public string UpdateEmpRoom(int id, int room)
        {
            try
            {
                var query2 = from a in connection.Room_No_Tables where a.Emp_Id == id select a;
                if (query2.Count() != 0)
                {
                    Room_No_Table roomtable2 = query2.First();
                    roomtable2.Reserved = false;
                    roomtable2.Emp_Id = 0000;

                    connection.SubmitChanges();
                    var query = from a in connection.Room_No_Tables where a.Room_No == room select a;
                    Room_No_Table roomtable = query.First();
                    roomtable.Emp_Id = id;
                    roomtable.Reserved = true;
                    connection.SubmitChanges();
                    return "Employee Information Updated";
                   
                }
                else {
                    return "Sorry! This Employee is not exist";
                }
            }
            catch (Exception )
            {
                return "Sorry Database ";
            }
        }
        public string deleteEmployee(int id)
        {
            try
            {
                var query1 = from a in connection.Emp_Tables where a.Id == id select a;
                foreach(var info in query1)
                {
                    connection.Emp_Tables.DeleteOnSubmit(info);
                }
                var query2 = from a in connection.Emp_Details where a.Emp_Id == id select a;
                if (query2.Count()!=0)
                {
                    foreach (var info in query2)
                    {
                        connection.Emp_Details.DeleteOnSubmit(info);
                    }
                }
                var query3 = from a in connection.Room_No_Tables where a.Emp_Id == id select a;
             
                if (query3.Count()!=0)
                {
                    Room_No_Table roomtable2 = query3.First();
                    roomtable2.Reserved = false;
                    roomtable2.Emp_Id = 0000;
                }
                connection.SubmitChanges();
                return "Employee Deleted";
            }
            catch(Exception ex)
            {
                return ex.ToString();
            }
        }
        public bool SaveUser(string name,string phone,string email)
        {
            try
            {
                Appointment_Table apt = new Appointment_Table();
                apt.Name = name;
                apt.Phone = phone;
                apt.Email = email;
                connection.Appointment_Tables.InsertOnSubmit(apt);
                connection.SubmitChanges();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }
        public string SaveFeedBack(string feedback)
        {
            try
            {
                var query = from a in connection.Appointment_Tables where a.A_Id == connection.Appointment_Tables.Max(ab => ab.A_Id) select a;
                Appointment_Table apt = query.First();
                apt.FeedBack = feedback;
                connection.SubmitChanges();

                return "Thanks For Your Kind of Information";
            }
            catch (Exception)
            {
                return "Sorry Database Has Problems";
            }
        }
        public string AppRequest(int empId,string pupose,DateTime reqDate)
        {
            try
            {
                var query = from a in connection.Appointment_Tables where a.A_Id == connection.Appointment_Tables.Max(ab => ab.A_Id) select a;
                Appointment_Table apt = query.First();
                apt.Emp_Id = empId;
                apt.Accept = false;
                apt.Purpose = pupose;
                apt.Date = reqDate.Date;
                apt.Req_Date = DateTime.Now;
                var query2 = from a in connection.Appointment_Tables where a.Emp_Id == empId && a.Date == reqDate.Date && a.Time == connection.Appointment_Tables.Max(at => at.Time) select a;
                DateTime date = DateTime.Now.Date.AddHours(10);
                if (reqDate==DateTime.Today)
                {
                    if (query2.Count() == 0)
                    {
                       
                        if (DateTime.Now > date)
                        {
                            apt.Time = DateTime.Now.AddMinutes(15).ToShortTimeString();
                            connection.SubmitChanges();
                            return "Your Request Sent ";
                        }
                        else
                        {
                            apt.Time = date.ToShortTimeString();
                            connection.SubmitChanges();
                            return "Your Request Sent";
                        }
                    }
                    else
                    {
                        DateTime time1 = Convert.ToDateTime(query2.First().Time);
                        if (time1.Hour == 20)
                        {
                            return "Sorry All Slot Are Filled Try Another Date";
                        }
                        else
                        {
                            time1 = time1.AddMinutes(15);
                            apt.Time = time1.ToShortTimeString();
                            connection.SubmitChanges();
                            return "Your Request Sent";
                        }
                    }
                }
                else
                {
                    if (query2.Count() == 0)
                    {
                            apt.Time = date.ToShortTimeString();
                            connection.SubmitChanges();
                            return "Your Request Sent ";    
                    }
                    else
                    {
                        DateTime time1 = Convert.ToDateTime(query2.First().Time);
                        if (time1.Hour == 20)
                        {
                            return "Sorry All Slot Are Filled Try Another Date";
                        }
                        else
                        {
                            time1 = time1.AddMinutes(15);
                            apt.Time = time1.ToShortTimeString();
                            connection.SubmitChanges();
                            return "Your Request Sent ";
                        }
                    }
                }
                connection.SubmitChanges();
                return "Your Request Sent";
            }
            catch(Exception ex)
            {
                return ex.ToString();
            }
        }
        public object getEmployeeInfo(string name)
        {

            var res = connection.Emp_Tables.Where(row => row.Name.Contains(name) && row.Admin == false).Select(row => new { row.Id, row.Name, row.Phone, row.Email });
           
            return res.ToList();
        }
        public object retAppData(int id)
        {
            var res = connection.Appointment_Tables.Where(row => row.Emp_Id == id && row.Accept==false).Select(row => new { row.A_Id, row.Name, row.Phone, row.Email });

            return res.ToList();
        }
        public object RetAllAppData(int id)
        {
            var res = connection.Appointment_Tables.Where(row => row.Emp_Id == id && row.Accept == true && row.Date==DateTime.Now.Date).Select(row => new { row.A_Id, row.Name, row.Phone, row.Email,row.Date,row.Time});

            return res.ToList();
        }
        public object retAppData()
        {
            var res = connection.Appointment_Tables.Where(row => row.A_Id == row.A_Id).Select(row=> new { row.A_Id , row.Name,row.Phone, row.Email,row.FeedBack } );
          
           
            return res.ToList();
        }
        public object retAppInfo(int id)
        {
            var res = from a in connection.Appointment_Tables where a.A_Id==id select a;
            return res.First();
        }
        public bool deleteAppData(int id)
        {
            try
            {
                var query1 = from a in connection.Appointment_Tables where a.A_Id == id select a;
                foreach (var info in query1)
                {
                    connection.Appointment_Tables.DeleteOnSubmit(info);
                }
                connection.SubmitChanges();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }
        public bool SendRejection(string mail)
        {
            try
            {
                SmtpClient server = new SmtpClient("smtp.gmail.com");
                server.Credentials = new NetworkCredential("oporijito@gmail.com", "iamastudentofszmc");
                server.EnableSsl = true;
                server.Port = 587;
                server.DeliveryMethod = SmtpDeliveryMethod.Network;
                message.From = new MailAddress("oporijito@gmail.com");
                message.To.Add(mail);
                message.Subject = "Appoinment Rejection";
                message.Body = " From : Bug Fix Software Farm . Your Appoinment Request Is Rejected";
                server.Send(message);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public string rejectRequest(int id)
        {
            try
            {
                
                var query = from a in connection.Appointment_Tables where a.A_Id == id select a;
                Appointment_Table apt = query.First();
                if(SendRejection(apt.Email)==true)
                {
                    apt.Accept = false;
                    connection.SubmitChanges();
                    return "Request Rejected";
                }
                else
                {
                    return "No InerNet Connection";
                }
               
            }
            catch(Exception)
            {
                return "No InerNet Connection";
            }
        }

        public bool CreatePdf(string pdfName,string uName,string eName,string appDate,string appTime)
        {
            try {
                Document doc = new Document(iTextSharp.text.PageSize.A4, 50, 50, 42, 35);
                PdfWriter pw = PdfWriter.GetInstance(doc, new FileStream("./AppinmentLetter/" + pdfName + ".pdf", FileMode.Create));
                doc.Open();
                var boldFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 20);
                var normal = FontFactory.GetFont(FontFactory.TIMES_ROMAN, 12);
                var phrase = new Phrase();
                phrase.Add(new Chunk("Bug Fix Software Farm", boldFont));
                phrase.Add(new Chunk(" \n Name : " + uName + " \nAppontmet To: " + eName + " \n Appointmnet Date: " + appDate + " \n Apponment Time : " + appTime + " \n \n Your Appointmnet Is Confirmed \n \n Thanks For Visiting Us \n", normal));
                Paragraph paragraph = new Paragraph();
                paragraph.Alignment = Element.ALIGN_CENTER;
                paragraph.Add(phrase);
                paragraph.Add(("Date:" + DateTime.Now.ToString("dd/MM/yyyy")).Replace('-', '/'));
                doc.Add(paragraph);
                doc.Close();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }
        public bool MessageSend(string mail,int pdfpath)
        {
            try
            {
                SmtpClient server = new SmtpClient("smtp.gmail.com");
                server.Credentials = new NetworkCredential("oporijito@gmail.com", "iamastudentofszmc");
                server.EnableSsl = true;
                server.Port = 587;
                server.DeliveryMethod = SmtpDeliveryMethod.Network;
                message.From = new MailAddress("oporijito@gmail.com");
                message.To.Add(mail);
                message.Subject = "Appoinment Confirmation";
                message.Body = " From : Bug Fix Software Farm . Your Appoinment Request Is Accepted";
                string path = "./AppinmentLetter/" + pdfpath + ".pdf";
                message.Attachments.Add(new Attachment(path));
                server.Send(message);
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }
        public string AcceptRequest(int id)
        {
                var query = from a in connection.Appointment_Tables
                           where a.A_Id == id select a;

                Appointment_Table apt = query.First();

                var q2 = from a in connection.Emp_Tables where a.Id == apt.Emp_Id select a.Name;
                string name = q2.First();
                string mail = query.First().Email;
                DateTime date = (DateTime)apt.Req_Date;
                var d = date.Date;
                string reqDate = d.Day.ToString() + "/" + d.Month.ToString() + "/" + d.Year.ToString();
                bool result1 =CreatePdf(apt.A_Id.ToString(), apt.Name, name,reqDate, apt.Time);
            if (result1 == true)
            {
                bool result2 = MessageSend(apt.Email, apt.A_Id);
                if (result2 == true)
                {
                    apt.Accept = true;
                    apt.Seen = true;
                    connection.SubmitChanges();
                    //return true;
                    return "Request Accepted";
                }
                else
                {
                    return "No Internet Connection";
                }
            }
            else
            {
                return "Pdf Creation Problem";
            }
           
        }
        public string RejectRequest(int id)
        {
            var query = from a in connection.Appointment_Tables
                        where a.A_Id == id
                        select a;

            Appointment_Table apt = query.First();

            var q2 = from a in connection.Emp_Tables where a.Id == apt.Emp_Id select a.Name;
            string name = q2.First();
            string mail = query.First().Email;
            DateTime date = (DateTime)apt.Req_Date;
            var d = date.Date;
            string reqDate = d.Day.ToString() + "/" + d.Month.ToString() + "/" + d.Year.ToString();
            bool result1 = CreatePdf(apt.A_Id.ToString(), apt.Name, name, reqDate, apt.Time);
            if (result1 == true)
            {
                bool result2 = MessageSend(apt.Email, apt.A_Id);
                if (result2 == true)
                {
                    apt.Seen = true;
                    connection.SubmitChanges();
                    //return true;
                    return "Request Accepted";
                }
                else
                {
                    return "No Internet Connection";
                }
            }
            else
            {
                return "Pdf Creation Problem";
            }

        }
        public static void Main()
        {
           
        }
    }
}
