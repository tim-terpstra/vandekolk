using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kis20.Business;
using System.Data.SqlClient;
namespace kis20.Business
{
    public class Database
    {
        //hier nog dingen aan meegeven zoals iets van database gegevends
        
        public Gebruiker getuser(string naam)
        {
            var users = new List<Gebruiker>();
            string connectionString;
            SqlConnection cnn;
            SqlCommand command;
            SqlDataReader dataReader;
            string sql, Output = "";
            connectionString = @"Data Source=SQL2019;Initial Catalog=kis21;User ID=robbintim;Password=Oplader7#";
            cnn = new SqlConnection(connectionString);
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
    }
}
