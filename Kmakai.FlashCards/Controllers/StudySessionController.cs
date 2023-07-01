using Kmakai.FlashCards.Models;
using System.Configuration;
using System.Data.SqlClient;

namespace Kmakai.FlashCards.Controllers;

public class StudySessionController
{
    private static string? connectionString = ConfigurationManager.AppSettings.Get("connectionString");
    public static void AddSession(StudySession session)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = @$"
                INSERT INTO StudySessions (StackId, Score, Date)
                VALUES ('{session.StackId}', '{session.Score}', '{session.Date}')";
            command.ExecuteNonQuery();
            connection.Close();
        }

    }

    public static List<StudySession> GetSessions()
    {
        List<StudySession> sessions = new List<StudySession>();

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = @$"
                SELECT * FROM StudySessions";

            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                StudySession session = new StudySession();
                session.Id = reader.GetInt32(0);
                session.StackId = reader.GetInt32(1);
                session.Score = reader.GetInt32(2);
                session.Date = reader.GetDateTime(3);
                sessions.Add(session);
            }

            connection.Close();
        }

        return sessions;
    }
    
    //public static StudySession CreateSession()
    //{
    //     Console.WriteLine("What stack would you like to study?");
    //}
}
