using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kis20.Business
{
    public class LijstProject
    {
        public string ProjectNaam { get; }
        public string WerkAdres { get; }
        public string StartDatum { get; }
        public string EindDatum { get; }
        public string Uitvoerder { get; }
        public string WerkVoorbereider { get; }
        public bool Wpi { get; }

        
        public LijstProject(string projectNaam, string werkAdres, string startDatum, string eindDatum, string uitvoerder, string werkVoorbereider, bool wpi)
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
