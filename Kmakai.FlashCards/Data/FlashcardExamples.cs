using Kmakai.FlashCards.Models;

public static class FlashcardExamples
{
    public static List<FlashcardDTO> GetSpanishExamples()
    {
        return new List<FlashcardDTO>
        {
            new FlashcardDTO
            {
                Front = "Como estas?",
                Back = "How are you?"
            },
            new FlashcardDTO
            {
                Front = "Hola!",
                Back = "Hello!"
            },
            new FlashcardDTO
            {
                Front = "Buenos dias!",
                Back = "Good morning!"
            },
            new FlashcardDTO
            {
                Front = "Adios!",
                Back = "Goodbye!"
            },
            new FlashcardDTO
            {
                Front = "Hasta luego!",
                Back = "See you later!"
            }
        };
    }

    public static List<FlashcardDTO> GetMathExamples()
    {
    return new List<FlashcardDTO>
    {
            new FlashcardDTO
            {
                Front = "2 + 2",
                Back = "4"
            },
            new FlashcardDTO
            {
                Front = "2 * 2",
                Back = "4"
            },
            new FlashcardDTO
            {
                Front = "2 / 2",
                Back = "1"
            },
            new FlashcardDTO
            {
                Front = "2 - 2",
                Back = "0"
            },
            new FlashcardDTO
            {
                Front = "2 ^ 2",
                Back = "4"
            }
        };
    }

}
