using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiccolaFabbricaImmaginaria
{
    public class Chip
    {
        public int Id { get; set; }

        private static int _idCounter = 0;

        public Chip() 
        {
            Id = _idCounter;
            _idCounter++;
        }
    }
}
