using Kmakai.FlashCards.Models;
using System.Configuration;
using System.Data.SqlClient;

namespace Kmakai.FlashCards.Controllers;

public class StackController
{
    private readonly string? ConnectionString = ConfigurationManager.AppSettings.Get("connectionString");

    public void CreateStack(string name)
    {
        using (SqlConnection connection = new SqlConnection(ConnectionString))
        {
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = @$" 
                INSERT INTO Stacks (Name)
                VALUES ('{name.ToLower()}')";


            command.ExecuteNonQuery();

            connection.Close();
        }

        Console.WriteLine("Stack created");
    }

    public Stack GetStack(string name)
    {
        if (name == null)
        {
            throw new Exception("Stack name is null");
        }

        Stack stack = new Stack(name.ToLower());

        using (SqlConnection connection = new SqlConnection(ConnectionString))
        {
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = @$"
                SELECT * FROM Stacks
                WHERE Name = '{name}'";

            var reader = command.ExecuteReader();

            if (reader.Read())
            {
                stack.Id = reader.GetInt32(0);
                stack.Flashcards = GetStacKFlashcards(stack.Id);
            }

            connection.Close();
        }
        return stack;
    }

    public List<Flashcard> GetStacKFlashcards(int stackId)
    {
        var flashcards = new List<Flashcard>();

        using (SqlConnection connection = new SqlConnection(ConnectionString))
        {
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = @$"
                SELECT * FROM Flashcards
                WHERE StackId = {stackId}";

            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                Flashcard flashcard = new Flashcard(reader.GetInt32(1), reader.GetString(2), reader.GetString(3))
                {
                    Id = reader.GetInt32(0)
                };
                flashcards.Add(flashcard);
            }

            connection.Close();
        }

        return flashcards;
    }

    public void AddFlashcardToStack(int stackId, string front, string back)
    {
        using (SqlConnection connection = new SqlConnection(ConnectionString))
        {
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = @$" 
                INSERT INTO Flashcards (StackId, front, back)
                VALUES ('{stackId}', '{front}', '{back}')";

            command.ExecuteNonQuery();

            connection.Close();
        }
    }

    public void DeleteStack(int stackId)
    {
        using (SqlConnection connection = new SqlConnection(ConnectionString))
        {
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = @$" 
                DELETE FROM Flashcards
                WHERE StackId = {stackId}";

            command.ExecuteNonQuery();

            command.CommandText = @$" 
                DELETE FROM Stacks
                WHERE Id = {stackId}";

            command.ExecuteNonQuery();

            connection.Close();
        }
    }
    
}
