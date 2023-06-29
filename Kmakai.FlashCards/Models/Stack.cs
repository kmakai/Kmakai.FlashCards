namespace Kmakai.FlashCards.Models;

internal class Stack

{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Flashcard> Flashcards { get; set; } = new List<Flashcard>();
    public Stack(string name)
    {
        Name = name;
    }
}
