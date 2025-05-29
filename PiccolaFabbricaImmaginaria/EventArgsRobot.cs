using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiccolaFabbricaImmaginaria
{
    public class EventArgsRobot
    {
        public Robot Robot { get; set; }

        public EventArgsRobot(Robot robot)
        {
            Robot = robot;
        }
    }
}
