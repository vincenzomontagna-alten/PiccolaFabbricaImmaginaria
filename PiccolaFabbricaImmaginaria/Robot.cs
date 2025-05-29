using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiccolaFabbricaImmaginaria
{
    public class Robot
    {
        public int Id { get; set; }

        private static int _idCounter = 1;
        public Chip Chip { get; set; }
        public EnumStatoRobot StatoRobot { get; set; }
        public Robot() 
        {
            Id = _idCounter;
            Chip = null;
            StatoRobot = EnumStatoRobot.RobotSmontato;
            _idCounter++;
        }
    }
}
