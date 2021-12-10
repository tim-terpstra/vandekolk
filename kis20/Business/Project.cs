using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kis20.Business
{
    public class LijstProject
    {
        public string ProjectNaam { get; set; }
        public string WerkAdres { get; set; }
        public DateTime StartDatum { get; set; }
        public DateTime EindDatum { get; set; }
        public int Uitvoerder { get; set; }
        public int WerkVoorbereider { get; set; }
        public bool Wpi { get; set; }

        
        public LijstProject(string projectNaam, string werkAdres, DateTime startDatum, DateTime eindDatum, int uitvoerder, int werkVoorbereider, bool wpi)
        {
            this.ProjectNaam = projectNaam;
            this.WerkAdres = werkAdres;
            this.StartDatum = startDatum;
            this.EindDatum = eindDatum;
            this.Uitvoerder = uitvoerder;
            this.WerkVoorbereider = werkVoorbereider;
            this.Wpi = wpi;
        }

    }
}
