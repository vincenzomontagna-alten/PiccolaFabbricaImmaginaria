using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiccolaFabbricaImmaginaria
{
    public class Collaudatore
    {
        public Robot RobotDaCollaudare { get; set; } = null;
        public event EventHandler<EventArgsRobot> CollaudoPositivo;
        public event EventHandler<EventArgsRobot> CollaudoNegativo;

        public Collaudatore() 
        {
            
        }

        public void Collaudo(object sender, EventArgsRobot e)
        {
            Console.WriteLine("Sto preparando il collaudo");
            RobotDaCollaudare = e.Robot;
            Random random = new Random();
            int numeroCasuale = random.Next(1, 11);
            Thread.Sleep(3000);
            if(numeroCasuale == 10)
            {
                Console.WriteLine("Il collaudo ha avuto esito negativo");
                CollaudoNegativo?.Invoke(this, new EventArgsRobot(RobotDaCollaudare));
            }
            else 
            {
                Console.WriteLine("Il collaudo ha avuto esito positivo");
                RobotDaCollaudare.StatoRobot = EnumStatoRobot.RobotCollaudato;
                CollaudoPositivo?.Invoke(this, new EventArgsRobot(RobotDaCollaudare));
            }
        }
    }
}
