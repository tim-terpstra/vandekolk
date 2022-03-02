using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kis20.Business
{
    public class Personeel
    {
        public string Voornaam { get; set; } 
        public string Tussenvoegsel { get; set; } 
        public string Achternaam { get; set; }
        
        public Personeel(string voornaam = null, string tussenvoegsel = null, string achternaam = null)
        {
            this.Voornaam = voornaam;
            this.Tussenvoegsel = tussenvoegsel;
            this.Achternaam = achternaam;
        }
    }
}
