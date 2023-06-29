namespace Kmakai.FlashCards.Models;

public class Flashcard
{
    public int Id { get; set; }
    public int StackId { get; set; }
    public string Question { get; set; }
    public string Answer { get; set; }
    public Flashcard(string question, string answer, int stackId)
    {
        Question = question;
        Answer = answer;
        StackId = stackId;
    }
}
