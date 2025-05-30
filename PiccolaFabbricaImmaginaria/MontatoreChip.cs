using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiccolaFabbricaImmaginaria
{
    public class MontatoreChip
    {
        public event EventHandler<EventArgsRobot> ChipInstallato;
        public event EventHandler<EventArgsRobot> ErroreDiInstallazioneChip;
        public Robot RobotProntoPerInstallazione { get; set; } = null;

        public MontatoreChip()
        {
            
        }

        public void MontaggioChip(object sender, EventArgsRobot e)
        {
            Console.WriteLine("Sto iniziando il montaggio del chip");
            RobotProntoPerInstallazione = e.Robot;
            Random random = new Random();
            int numeroCasuale = random.Next(1, 6);
            Thread.Sleep(3000); // Installazione Chip
            if(numeroCasuale == 5)
            {
                Console.WriteLine("C'è stato un errore montando il chip");
                ErroreDiInstallazioneChip.Invoke(this, new EventArgsRobot(RobotProntoPerInstallazione));
            }
            else
            {
                Console.WriteLine("Il chip è stato montato con successo");
                RobotProntoPerInstallazione.StatoRobot = EnumStatoRobot.ChipInserito;
                ChipInstallato?.Invoke(this, new EventArgsRobot(RobotProntoPerInstallazione));
            }
        }
    }
}
