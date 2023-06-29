﻿namespace Kmakai.FlashCards.Models;

internal class StudySession
{
    public int Id { get; set; }
    public int StackId { get; set; }
    public List<FlashcardDTO> Flashcards { get; set; } = new List<FlashcardDTO>();
    public int Score { get; set; }
    public StudySession(int stackId)
    {
        StackId = stackId;
    }
}
