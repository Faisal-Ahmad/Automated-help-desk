using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace HelpDesk
{
   
    public partial class RoomMap : Form
    {
        List<node> n = new List<node>();
       
        public RoomMap(int room)
        {
            InitializeComponent();
            setRooms();
            findRoom(room.ToString());
        }
        void setRooms()
        {
            List<Button> roads = new List<Button>();

            roads.Add(road1);
            roads.Add(road2);
            roads.Add(road3);
            node room = new node(Room1, roads);
            n.Add(room);

            roads = new List<Button>();
            roads.Add(road1);
            roads.Add(road2);
            roads.Add(road3);
            roads.Add(road4);  
            room = new node(Room2, roads);
            n.Add(room);

            roads = new List<Button>();
            roads.Add(road1);
            roads.Add(road2);
            roads.Add(road3);
            roads.Add(road4);
            roads.Add(road5);
            room = new node(Room3, roads);
            n.Add(room);

            roads = new List<Button>();
            roads.Add(road1);
            roads.Add(road2);
            roads.Add(road3);
            roads.Add(road4);
            roads.Add(road5);
            roads.Add(road6);
            room = new node(Room4, roads);
            n.Add(room);

            room = new node(Room8, roads);
            n.Add(room);

            roads = new List<Button>();
            roads.Add(road1);
            roads.Add(road2);
            roads.Add(road3);
            roads.Add(road4);
            roads.Add(road5);
            room = new node(Room7, roads);
            n.Add(room);


            roads = new List<Button>();
            roads.Add(road1);
            roads.Add(road2);
            roads.Add(road3);
            roads.Add(road4);
            

            room = new node(Room6, roads);
            n.Add(room);


            roads = new List<Button>();
            roads.Add(road1);
            roads.Add(road2);
            roads.Add(road3);
         
            room = new node(Room5, roads);
            n.Add(room);


            roads = new List<Button>();
            roads.Add(road1);
            roads.Add(road2);
          
            roads.Add(road7);
            roads.Add(road8);
            room = new node(Room9, roads);
            n.Add(room);



            roads = new List<Button>();
            roads.Add(road1);
            roads.Add(road2);

            roads.Add(road7);
            roads.Add(road8);
            roads.Add(road9);
            room = new node(Room10, roads);
            n.Add(room);


            roads = new List<Button>();
            roads.Add(road1);
            roads.Add(road2);

            roads.Add(road7);
            roads.Add(road8);
            roads.Add(road9);

            roads.Add(road10);
            room = new node(Room11, roads);
            n.Add(room);


            roads = new List<Button>();
            roads.Add(road1);
            roads.Add(road2);

            roads.Add(road7);
            roads.Add(road8);
            roads.Add(road9);

            roads.Add(road10);
            roads.Add(road11);
            room = new node(Room12, roads);
            n.Add(room);
        }
        public void findRoom(string room)
        {
            foreach(node x in n)
            {
                if (x.room.Text.Equals(room))
                {

                    x.room.BackColor = Color.Green;
                    foreach(Button y in x.road)
                    {
                        //MessageBox.Show(y.Text);
                        y.BackColor = Color.Red;

                    }

                }
               
            }


        }


        private void Form1_Load(object sender, EventArgs e)
        {
 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
