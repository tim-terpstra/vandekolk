using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kis20.Business
{
    public class Gebruiker
    {
        public int GebruikId { get; } 
        public string Initiaal { get; } 
        public string Inlognaam { get;  }
        public int Persooneelsnummer { get;  }
        public string Wachtwoord { get; }

        // rechten nog niet geïmplementeerd
        public bool Super { get; }
        public int AClear { get; }
        public int PClear { get; }
        public int OClear { get; }
        public int KClear { get; }
        public int SClear { get; }
        public int FClear { get; }
        public int MClear { get; }
        
        public Gebruiker(int GebruikId, string Initiaal, string Inlognaam, int Persooneelsnummer, string Wachtwoord, bool Super,int AClear, int PClear, int OClear, int KClear, int SClear, int FClear)
        {
            this.GebruikId = GebruikId;
            this.Initiaal = Initiaal;
            this.Inlognaam = Inlognaam;
            this.Persooneelsnummer = Persooneelsnummer;
            this.Wachtwoord = Wachtwoord;
            this.Super = Super;
            this.AClear = AClear;
            this.PClear = PClear;
            this.OClear = OClear;
            this.KClear = KClear;
            this.SClear = SClear;
            this.FClear = FClear;
        }
    }
}
