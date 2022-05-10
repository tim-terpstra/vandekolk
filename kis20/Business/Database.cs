using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kis20.Business;
using System.Data.SqlClient;
using System.Data;
using System.Reflection;

namespace kis20.Business
{
    public class Database
    {
        public string ConnectionString { get; } = @"Data Source=SQL2019;Initial Catalog=kis21;User ID=;Password=";//hier moeten de inlog gegevens van de database komen 
        public SqlConnection cnn { get; set; }
        public string sql { get; set; } = "";
        public SqlCommand command { get; set; }
        public SqlDataReader dataReader { get; set; }

        public Gebruiker getuser(string naam)
        {
            var users = new List<Gebruiker>();
            cnn = new SqlConnection(ConnectionString);
            try
            {
                cnn.Open();
            }
            catch (SqlException)
            {
                //return error
            }

            sql = $"Select * from Gebruiker where Inlognaam = '{naam}'";
            command = new SqlCommand(sql, cnn);
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                users.Add(new Gebruiker(dataReader.GetInt32(0), dataReader.GetString(1), dataReader.GetString(2), dataReader.GetInt32(3), dataReader.GetString(4), dataReader.GetBoolean(5), dataReader.GetInt32(6), dataReader.GetInt32(7), dataReader.GetInt32(8), dataReader.GetInt32(9), dataReader.GetInt32(10), dataReader.GetInt32(11)));
            }
            if (users.Count == 0) return null;
            //hier moet ook nog error handeling bijv als users langer is dan 1 dan moet de gebruiker door woorden gestuurd naar een error pagina
            //hier moet nog meer error handling in geval dat de db niet berijkbaar is, verstuur dan door naar een 503 pagina
            return users[0];
        }
        public List<LijstProject> getProjectenlijst()
        {
            var projecten = new List<LijstProject>();
            cnn = new SqlConnection(ConnectionString);
            cnn.Open();
            sql = $"select p.ProjectNummer,p.ProjectNaam,p.ProjectPlaats,CONCAT(Bedrijf.Bedrijf, CONCAT(CP.Voorletters,' ',CP.Achternaam)) as opdrachtgever, p.WerkStart ,p.WerkEind, CONCAT(Personeel.Voornaam, ' ', Personeel.Achternaam) as uitvoerder, CONCAT(Personeel.Voornaam, ' ', Personeel.Achternaam) as werkvoorbereider, p.OpnemenWPI, ProjectStatus.ProjectStatus from Project as p left join Personeel on p.Uitvoerder = Personeel.Id or p.Werkvoorbereider = Personeel.Id left join Bedrijf on p.OGBedrijf = Bedrijf.BedrijfID AND p.OGBedrijf != 1 left join CP on p.OGCP = CP.CPId left join ProjectStatus on p.ProjectStatus = ProjectStatus.Id";
            command = new SqlCommand(sql, cnn);
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                LijstProject project = new LijstProject();
                foreach (var (value, i) in project.GetType().GetProperties().Select((value, i) => (value, i)))
                {
                    if (!dataReader.IsDBNull(dataReader.GetName(i)))
                    {
                        value.SetValue(project, dataReader.GetValue(i));
                    }
                }
                projecten.Add(project);
            }
            if (projecten.Count == 0) return null;
            //hier moet ook nog error handeling bijv als users langer is dan 1 dan moet de gebruiker door woorden gestuurd naar een error pagina
            return projecten;

        }
        public List<LijstTraject> getTrajectenlijst()
        {
            var trajecten = new List<LijstTraject>();
            cnn = new SqlConnection(ConnectionString);
            cnn.Open();
            sql = $"SELECT p.ProjectNummer, p.Calculator as Calcnummer, p.ProjectNaam, p.ProjectPlaats, CONCAT(Bedrijf.Bedrijf, CONCAT(CP.Voorletters,' ',CP.Achternaam)) as Opdrachtgever, ProjectStatus.ProjectStatus, p.AanvraagDatum, p.AanbiedingRetour, p.DatumCalculatieGereed, CONCAT(calc.Voornaam, ' ', calc.Achternaam) as Calculator, ProjectStatus.ProjectStatus, p.CalculatieGereed from Project as p left join Personeel as calc on p.Calculator = calc.Id left join Bedrijf on p.OGBedrijf = Bedrijf.BedrijfID AND p.OGBedrijf != 1 left join CP on p.OGCP = CP.CPId left join RelatieSoort on p.ProjectSoort = RelatieSoort.Id left join ProjectStatus on p.ProjectStatus = ProjectStatus.Id";
            command = new SqlCommand(sql, cnn);
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                LijstTraject traject = new LijstTraject();
                foreach (var (value, i) in traject.GetType().GetProperties().Select((value, i) => (value, i)))
                {
                    if (!dataReader.IsDBNull(dataReader.GetName(i)))
                    {
                        value.SetValue(traject, dataReader.GetValue(i));
                    }
                }
                trajecten.Add(traject);
            }
            if (trajecten.Count == 0) return null;
            //hier moet ook nog error handeling bijv als users langer is dan 1 dan moet de gebruiker door woorden gestuurd naar een error pagina
            return trajecten;

        }
        public List<Personeel> getCalculator()
        {
            var users = new List<Personeel>();
            cnn = new SqlConnection(ConnectionString);
            cnn.Open();
            sql = $"select Distinct Voornaam, Tussenvoegsel, Achternaam from Personeel inner join Project as p on p.Calculator = Personeel.Id";
            command = new SqlCommand(sql, cnn);
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                Personeel user = new Personeel();
                foreach (var (value, i) in user.GetType().GetProperties().Select((value, i) => (value, i)))
                {
                    if (!dataReader.IsDBNull(dataReader.GetName(i)))
                    {
                        value.SetValue(user, dataReader.GetValue(i));
                    }
                }
                users.Add(user);
            }
            if (users.Count == 0) return null;
            return users;

        }
        public int saveTraject(string naam, string plaats, string calc, DateTime AanbiedingRetour, DateTime DatumCalculatieGereed)// veranderen naar boolean zodat je kan checken of het inserten ook goed gaat. 
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = "INSERT INTO Project (AanvraagDatum,Calculator,ProjectNaam,ProjectPlaats,AanbiedingRetour,DatumCalculatieGereed,CalculatieGereed,ProjectStatus) VALUES (@AanvraagDatum,@Calculator,@ProjectNaam,@ProjectPlaats,@AanbiedingRetour,@DatumCalculatieGereed,@CalculatieGereed,@ProjectStatus)";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@AanvraagDatum", DateTime.Now);
            command.Parameters.AddWithValue("@Calculator", 0);
            command.Parameters.AddWithValue("@ProjectNaam", naam);
            command.Parameters.AddWithValue("@ProjectPlaats", plaats);
            command.Parameters.AddWithValue("@AanbiedingRetour", DateTime.Now);
            command.Parameters.AddWithValue("@DatumCalculatieGereed", DateTime.Now);
            command.Parameters.AddWithValue("@CalculatieGereed", 0);
            command.Parameters.AddWithValue("@ProjectStatus", 2);

            connection.Open();
            int result = command.ExecuteNonQuery();

            // geef het resultaat terug zodat er error handling gedaan kan worden bij het aanroepen van de method
            return result;
            
        }
    }
}
