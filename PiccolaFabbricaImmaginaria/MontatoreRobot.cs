using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiccolaFabbricaImmaginaria
{
    public class MontatoreRobot
    {
        public event EventHandler<EventArgsRobot> ErroreDiMontaggio;
        public event EventHandler<EventArgsRobot> MontaggioCompletato;
        public Robot RobotDaMontare {  get; set; }

        public MontatoreRobot() 
        {
            RobotDaMontare = new Robot();
        }
        public void MontaRobot(object sender, EventArgs e)
        {
            RobotDaMontare = new Robot();
            Random random = new Random();
            int numeroCasuale = random.Next(1, 6);
            Thread.Sleep(1000); // Montaggio
            if(numeroCasuale == 5)
            {
                ErroreDiMontaggio?.Invoke(this, new EventArgsRobot(RobotDaMontare));
                
            }
            else 
            {
                RobotDaMontare.StatoRobot = EnumStatoRobot.RobotMontato;
                MontaggioCompletato?.Invoke(this, new EventArgsRobot(RobotDaMontare)); 
                
            }
        }
    }
}
