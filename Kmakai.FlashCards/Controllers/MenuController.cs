using Kmakai.FlashCards.Models;

namespace Kmakai.FlashCards.Controllers;

public class MenuController
{
    private FlashCardsApp App { get; set; }
    public MenuController(FlashCardsApp app)
    {
        App = app;
    }
    public void HandleMainMenu()
    {
        Console.Write("option: ");
        string? input = Console.ReadLine();

        switch (input)
        {
            case "1":
                CreateStack();
                break;
            case "2":
                if (App?.Stacks.Count == 0)
                {
                    Console.WriteLine("No stacks found");
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                    break;
                }
                if (App != null) DisplayController.DisplayStacksMenu(App.Stacks);
                HandleStacksMenu();
                break;
        }

    }

    public void HandleStacksMenu()
    {
        Console.Write("option: ");
        string? input = Console.ReadLine();

        switch (input)
        {
            case "1":
                DeleteStack();
                break;
            case "2":
                HandleStackMenu();
                break;
            case "3":
                break;
        }
    }

    public void HandleStackMenu()
    {
        Console.WriteLine("Enter the id of the stack you want to manage");
        Console.Write("Id: ");
        string? idInput = Console.ReadLine();
        int id = Convert.ToInt32(idInput);
        var stack = App?.Stacks.FirstOrDefault(x => x.Id == id);

        while (stack == null)
        {
            Console.WriteLine("Please enter a valid id");
            Console.Write("Id: ");
            idInput = Console.ReadLine();
            id = Convert.ToInt32(idInput);
            stack = App?.Stacks.FirstOrDefault(x => x.Id == id);
        }

        if (App != null)
        {
            App.CurrentStack = stack;
            App.StackFlashcards = FlashcardController.GetFlashcards(stack.Id);
        }


        DisplayController.DisplayStackMenu(stack);
        Console.Write("option: ");
        while (true)
        {
            string? input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    AddCardToStack();
                    break;
                case "2":
                    RemoveCardFromStack();
                    break;
                case "3":
                    DisplayController.DisplayFlashcards(App.StackFlashcards);
                    break;
                case "4":
                    break;
            }
        }


    }

    public void CreateStack()
    {
        Console.Write("Stack name: ");
        string? name = Console.ReadLine();

        while (string.IsNullOrEmpty(name) || App.Stacks.Any(x => x.Name == name))
        {
            Console.WriteLine("Please enter a valid name");
            Console.Write("Stack name: ");
            name = Console.ReadLine();
        }

        var stack = new Stack(name);
        StackController.CreateStack(name);

        stack.Id = App.Stacks.Count() + 1;
        App.Stacks.Add(new Stack(name));

        Console.WriteLine($"Stack {name} created!");
        Console.WriteLine("Press any key to continue");
        Console.ReadKey();
    }

    public void DeleteStack()
    {
        Console.WriteLine("Enter the id of the stack you want to delete");
        Console.Write("Id: ");
        string? input = Console.ReadLine();
        int id;

        while (!int.TryParse(input, out id) || !App.Stacks.Any(x => x.Id == id))
        {
            Console.WriteLine("Please enter a valid id");
            Console.Write("Id: ");
            input = Console.ReadLine();
        }

        char? confirm = null;
        while (confirm != 'y' && confirm != 'n')
        {
            Console.WriteLine("Are you sure you want to delete this stack? (y/n)");
            Console.Write("option: ");
            confirm = Console.ReadKey().KeyChar;
            Console.WriteLine();
        }

        if (confirm == 'y')
        {
            StackController.DeleteStack(id);
            App.Stacks.RemoveAll(x => x.Id == id);
            Console.WriteLine("Stack deleted");
            Thread.Sleep(1000);
        }
        else
        {
            Console.WriteLine("Stack not deleted");
        }

    }

    public void AddCardToStack()
    {
        Console.WriteLine("Please enter text for the front!");
        Console.Write("Front: ");
        string? front = Console.ReadLine();

        while (string.IsNullOrEmpty(front))
        {
            Console.WriteLine("Please enter a valid front");
            Console.Write("Front: ");
            front = Console.ReadLine();
        }

        Console.WriteLine("Please enter text for the back!");
        Console.Write("Back: ");
        string? back = Console.ReadLine();

        while (string.IsNullOrEmpty(back))
        {
            Console.WriteLine("Please enter a valid back");
            Console.Write("Back: ");
            back = Console.ReadLine();
        }


        var card = new Flashcard(App.CurrentStack.Id, front, back);

        FlashcardController.AddFlashcard(card);
        App.StackFlashcards.Add(card);

        Console.WriteLine("Card added!");
        Console.WriteLine("Press any key to continue");
        Console.ReadKey();

    }

    public void RemoveCardFromStack()
    {
        Console.Clear();
        DisplayController.DisplayFlashcards(App.StackFlashcards);


        Console.WriteLine("Enter the id of the card you want to remove");
        Console.Write("Id: ");
        string? input = Console.ReadLine();
        int id;

        while (!int.TryParse(input, out id) || !App.StackFlashcards.Any(x => x.Id == id))
        {
            Console.WriteLine("Please enter a valid id");
            Console.Write("Id: ");
            input = Console.ReadLine();
        }

        char? confirm = null;
        while (confirm != 'y' && confirm != 'n')
        {
            Console.WriteLine("Are you sure you want to delete this card? (y/n)");
            Console.Write("option: ");
            confirm = Console.ReadKey().KeyChar;
            Console.WriteLine();
        }

        if (confirm == 'y')
        {
            FlashcardController.DeleteFlashcard(id);
            App.StackFlashcards.RemoveAll(x => x.Id == id);
            Console.WriteLine("Card deleted");
            Thread.Sleep(1000);
        }
        else
        {
            Console.WriteLine("card not deleted");
        }
    }

}