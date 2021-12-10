using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kis20.Business;
using System.Data.SqlClient;
using System.Data;

namespace kis20.Business
{
    public class Database
    {
        public string ConnectionString { get; } = @"Data Source=SQL2019;Initial Catalog=kis21;User ID=robbintim;Password=Oplader7#";
        public SqlConnection cnn { get; set; }
        public string sql { get; set; } = "";
        public SqlCommand command { get; set; }
        public SqlDataReader dataReader { get; set; }
        //hier nog dingen aan meegeven zoals iets van database gegevends

        public Gebruiker getuser(string naam)
        {
            var users = new List<Gebruiker>();
            cnn = new SqlConnection(ConnectionString);
            cnn.Open();
            sql = $"Select * from Gebruiker where Inlognaam = '{naam}'";
            command = new SqlCommand(sql, cnn);
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                users.Add(new Gebruiker(dataReader.GetInt32(0), dataReader.GetString(1), dataReader.GetString(2), dataReader.GetInt32(3), dataReader.GetString(4), dataReader.GetBoolean(5), dataReader.GetInt32(6), dataReader.GetInt32(7), dataReader.GetInt32(8), dataReader.GetInt32(9), dataReader.GetInt32(10), dataReader.GetInt32(11)));
            }
            if (users.Count == 0) return null;
            //hier moet ook nog error handeling bijv als users langer is dan 1 dan moet de gebruiker door woorden gestuurd naar een error pagina
            return users[0];
    }

        public List<LijstProject> getTrajectenlijst()
        {
            var trajecten = new List<LijstProject>();
            cnn = new SqlConnection(ConnectionString);
            cnn.Open();
            sql = $"select ProjectNaam, ProjectPlaats, WerkStart, WerkEind, Uitvoerder, Werkvoorbereider, OpnemenWPI from Project"; 
            command = new SqlCommand(sql, cnn);
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                LijstProject traject = new LijstProject(null, null, new DateTime(), new DateTime(), 0, 0, false);
                if (!dataReader.IsDBNull(dataReader.GetOrdinal("ProjectNaam")))
                {
                    traject.ProjectNaam = dataReader.GetString(0);
                }
                if (!dataReader.IsDBNull(dataReader.GetOrdinal("ProjectPlaats")))
                {
                    traject.WerkAdres = dataReader.GetString(1);
                }
                if (!dataReader.IsDBNull(dataReader.GetOrdinal("WerkStart")))
                {
                    traject.StartDatum = dataReader.GetDateTime(2);
                }
                if (!dataReader.IsDBNull(dataReader.GetOrdinal("WerkEind")))
                {
                    traject.EindDatum = dataReader.GetDateTime(3);
                }
                if (!dataReader.IsDBNull(dataReader.GetOrdinal("Uitvoerder")))
                {
                    traject.Uitvoerder = dataReader.GetInt32(4);
                }
                if (!dataReader.IsDBNull(dataReader.GetOrdinal("Werkvoorbereider")))
                {
                    traject.WerkVoorbereider = dataReader.GetInt32(5);
                }
                if (!dataReader.IsDBNull(dataReader.GetOrdinal("OpnemenWPI")))
                {
                    traject.Wpi = dataReader.GetBoolean(6);
                }
                trajecten.Add(traject);
            }
            if (trajecten.Count == 0) return null;
            //hier moet ook nog error handeling bijv als users langer is dan 1 dan moet de gebruiker door woorden gestuurd naar een error pagina
            return trajecten;

        }
    }
}
