using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiccolaFabbricaImmaginaria
{
    public class Collaudatore
    {
        public Robot RobotDaCollaudare {  get; set; }
        public event EventHandler<EventArgsRobot> CollaudoPositivo;
        public event EventHandler<EventArgsRobot> CollaudoNegativo;

        public Collaudatore(Robot robotDaCollaudare) 
        {
            RobotDaCollaudare = robotDaCollaudare;
        }

        public void Collaudo()
        {
            Random random = new Random();
            int numeroCasuale = random.Next(1, 11);
            if(numeroCasuale == 10)
            {
                CollaudoNegativo?.Invoke(this, new EventArgsRobot(RobotDaCollaudare));
            }
            else 
            {
                RobotDaCollaudare.StatoRobot = EnumStatoRobot.RobotCollaudato;
                CollaudoPositivo?.Invoke(this, new EventArgsRobot(RobotDaCollaudare));
            }
        }
    }
}
