using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kis20.Business
{
    public class LijstProject
    {
        public string ProjectNummer { get; set; }
        public string ProjectNaam { get; set; }
        public string WerkAdres { get; set; }
        public string Opdrachtgever { get; set; }
        public DateTime? StartDatum { get; set; }
        public DateTime? EindDatum { get; set; }
        public string Uitvoerder { get; set; }
        public string WerkVoorbereider { get; set; }
        public bool Wpi { get; set; }

        
        public LijstProject(string projectNummer = null, string projectNaam = null, string werkAdres = null, string opdrachtgever = null, DateTime? startDatum = null, DateTime? eindDatum = null, string uitvoerder = null, string werkVoorbereider = null, bool wpi = false)
        {
            this.ProjectNummer = projectNummer;
            this.ProjectNaam = projectNaam;
            this.WerkAdres = werkAdres;
            this.Opdrachtgever = opdrachtgever;
            this.StartDatum = startDatum;
            this.EindDatum = eindDatum;
            this.Uitvoerder = uitvoerder;
            this.WerkVoorbereider = werkVoorbereider;
            this.Wpi = wpi;
        }

    }
    public class LijstTraject
    {
        public string ProjectNummer { get; set; }
        public int CalculatieNummer { get; set; }
        public string ProjectNaam { get; set; }
        public string WerkAdres { get; set; }
        public string Opdrachtgever { get; set; }
        public string Soort { get; set; }
        public DateTime? AanvraagDatum { get; set; }
        public DateTime? AanbodDatum { get; set; }
        public DateTime? GereedDatum { get; set; }
        public string Calculator { get; set; }
        public string Status { get; set; }
        public bool Gereed { get; set; }


        public LijstTraject(string projectNummer = null, int calculatienummer = 0, string projectNaam = null, string werkAdres = null, string opdrachtgever = null, string soort = null, DateTime? aanvraagDatum = null, DateTime? aanbodDatum = null, DateTime? gereedDatum = null, string calculator = null, string status = null, bool gereed = false)
        {
            this.ProjectNummer = projectNummer;
            this.CalculatieNummer = calculatienummer;
            this.ProjectNaam = projectNaam;
            this.WerkAdres = werkAdres;
            this.Opdrachtgever = opdrachtgever;
            this.Soort = soort;
            this.AanvraagDatum = aanvraagDatum;
            this.AanbodDatum = aanbodDatum;
            this.GereedDatum = gereedDatum;
            this.Calculator = calculator;
            this.Status = status;
            this.Gereed = gereed;
        }

    }
}
