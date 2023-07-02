using ConsoleTableExt;
using Kmakai.FlashCards.Models;

namespace Kmakai.FlashCards.Controllers;

public class DisplayController
{
    public static void DisplayMainMenu()
    {
        Console.Clear();
        Console.WriteLine("Welcome to FlashCards App!");
        Console.WriteLine("1. Create a new stack");
        Console.WriteLine("2. View all stacks");
        Console.WriteLine("3. Study a stack");
        Console.WriteLine("4. View study sessions");
        Console.WriteLine("5. Exit");
        Console.WriteLine("What would you like to do?");

    }

    public static void DisplayStackMenu(Stack stack)
    {
        Console.Clear();
        Console.WriteLine($"----------{stack.Name}------------");
        Console.WriteLine("What would you like to do?");
        Console.WriteLine("1. Add a card");
        Console.WriteLine("2. Remove a card");
        Console.WriteLine("3. View all cards");
        Console.WriteLine("4. Return to main menu");
    }

    public static void DisplayStudyMenu(Stack stack)
    {
        Console.Clear();
        Console.WriteLine($"----------{stack.Name}------------");
        Console.WriteLine("What would you like to do?");
        Console.WriteLine("1. Start a new study session");
        Console.WriteLine("2. View previous study sessions");
        Console.WriteLine("3. Return to main menu");
    }

    public static void DisplayStacksMenu(List<Stack> stacks)
    {
        Console.Clear();
        Console.WriteLine("----------Stacks------------");
        ConsoleTableBuilder.From(stacks)
            .WithColumn("Id", "Name")
            .ExportAndWriteLine();

        Console.WriteLine("What would you like to do?");
        Console.WriteLine("1.Delete a stack");
        Console.WriteLine("2.Manage Stack");
        Console.WriteLine("3.Return to main menu");
    }

    public static void DisplaySessions(List<StudySession> sessions)
    {
        Console.Clear();
        Console.WriteLine("----------Study Sessions------------");
        ConsoleTableBuilder.From(sessions)
            .WithColumn("Id", "Id")
            .WithColumn("StackId", "StackId")
            .WithColumn("Score", "Score")
            .WithColumn("Date", "Date")
            .ExportAndWriteLine();
    }

    public static void DisplayFlashcards(List<Flashcard> flashcards)
    {
        Console.Clear();
        Console.WriteLine("----------Flashcards------------");
        ConsoleTableBuilder.From(flashcards)
            .WithColumn("id","StackId","Front", "Back")
            .ExportAndWriteLine();
    }
}
