namespace Kmakai.FlashCards.Models;

public class StudySession
{
    public int Id { get; set; }
    public int StackId { get; set; }
    public List<FlashcardDTO> Flashcards { get; set; } = new List<FlashcardDTO>();
    public int Score { get; set; }
    public DateOnly Date { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    public StudySession(int stackId)
    {
        StackId = stackId;
    }
}
