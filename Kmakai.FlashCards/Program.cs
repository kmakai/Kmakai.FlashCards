using Kmakai.FlashCards.Data;

Console.WriteLine("Hello, World!");

DbContext db = new();

db.InitializeDatabase();

//Server=(localdb)\\mssqllocaldb;Database=BulkyWeb;Trusted_Connection=True;MultipleActiveResultSets=true