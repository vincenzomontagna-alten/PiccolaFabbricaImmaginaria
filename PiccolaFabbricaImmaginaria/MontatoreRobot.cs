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
        public void MontaRobot(object sender, EventArgs e)
        {
            RobotDaMontare = new Robot();
            Console.WriteLine("Sto iniziando a montare un robot");
            RobotDaMontare = new Robot();
            Random random = new Random();
            int numeroCasuale = random.Next(1, 6);
            Thread.Sleep(3000); // Montaggio
            if(numeroCasuale == 5)
            {
                Console.WriteLine("C'è stato un errore montando un robot.");
                ErroreDiMontaggio?.Invoke(this, new EventArgsRobot(RobotDaMontare));    
            }
            else 
            {
                Console.WriteLine("Il montaggio è stato completato con successo");
                RobotDaMontare.StatoRobot = EnumStatoRobot.RobotMontato;
                MontaggioCompletato?.Invoke(this, new EventArgsRobot(RobotDaMontare)); 
            }
        }
    }
}
