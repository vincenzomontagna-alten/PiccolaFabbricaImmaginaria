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

        public event EventHandler Avvio;

        public void AvvioFabbrica()
        {

            Console.WriteLine("Sono stati prodotti: " + RobotTerminati.Count + " robot");
            Console.WriteLine("Ci sono stati: " + RobotGuasti.Count + " incidenti");
        }

        public void AggiungiRobotAgliScarti(object sender, EventArgsRobot e)
        {
            RobotGuasti.Add(e.Robot);
        }
    }
}
