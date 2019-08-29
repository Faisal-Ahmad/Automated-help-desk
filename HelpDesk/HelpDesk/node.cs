using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelpDesk
{
    public class node
    {
        public Button room;
        public List<Button> road;
        public node(Button room, List<Button> road)
        {
            this.room = room;
            this.road = road;
        }

    }
}
