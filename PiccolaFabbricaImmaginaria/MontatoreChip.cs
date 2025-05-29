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
        public Robot RobotProntoPerInstallazione {  get; set; }

        public MontatoreChip(Robot robotProntoPerInstallazione)
        {
            RobotProntoPerInstallazione = robotProntoPerInstallazione;
        }

        public void MontaggioChip()
        {
            Random random = new Random();
            int numeroCasuale = random.Next(1, 6);
            Thread.Sleep(1000); // Installazione Chip
            if(numeroCasuale == 5)
            {
                ErroreDiInstallazioneChip.Invoke(this, new EventArgsRobot(RobotProntoPerInstallazione));
            }
            else
            {
                RobotProntoPerInstallazione.StatoRobot = EnumStatoRobot.ChipInserito;
                ChipInstallato?.Invoke(this, new EventArgsRobot(RobotProntoPerInstallazione));
            }
        }
    }
}
