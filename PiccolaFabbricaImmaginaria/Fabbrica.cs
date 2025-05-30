using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiccolaFabbricaImmaginaria
{
    public class Fabbrica
    {

        public List<Robot> RobotTerminati = new List<Robot>();
        public List<Robot> RobotGuasti = new List<Robot>();
        MontatoreRobot montatoreRobot = new MontatoreRobot();
        MontatoreChip montatoreChip = new MontatoreChip();
        Collaudatore collaudatore = new Collaudatore();

        public event EventHandler AvvioEvento;

        public void Avvio() 
        {
            Console.WriteLine("Sto avviando la fabbrica");
            AvvioEvento?.Invoke(this, EventArgs.Empty);
        }

        public void PreparaFabbrica(Fabbrica fabbrica)
        {
            Console.WriteLine("Sto preparando la fabbrica");
            fabbrica.AvvioEvento += montatoreRobot.MontaRobot;
            montatoreRobot.ErroreDiMontaggio += AggiungiRobotAgliScarti;
            montatoreRobot.MontaggioCompletato += montatoreChip.MontaggioChip;
            montatoreChip.ErroreDiInstallazioneChip += AggiungiRobotAgliScarti;
            montatoreChip.ChipInstallato += collaudatore.Collaudo;
            collaudatore.CollaudoNegativo += AggiungiRobotAgliScarti;
            collaudatore.CollaudoPositivo += AggiungiRobotAiProdottiCompleti;
            Avvio();
            
        }
        //public void AvvioFabbrica(object sender, EventArgs e)
        //{

        //    Console.WriteLine("Sono stati prodotti: " + RobotTerminati.Count + " robot");
        //    Console.WriteLine("Ci sono stati: " + RobotGuasti.Count + " incidenti");
        //}

        public void AggiungiRobotAgliScarti(object sender, EventArgsRobot e)
        {
            RobotGuasti.Add(e.Robot);
            Console.WriteLine("Ho aggiunto il robot agli scarti. ROBOT SCARTATI: " + RobotGuasti.Count);
            Avvio();
        }

        public void AggiungiRobotAiProdottiCompleti(object sender, EventArgsRobot e)
        {
            RobotTerminati.Add(e.Robot);
            Console.WriteLine("Ho aggiunto il robot ai robot terminati. ROBOT COMPLETI: " + RobotTerminati.Count);
            Avvio();
        }
    }
}
