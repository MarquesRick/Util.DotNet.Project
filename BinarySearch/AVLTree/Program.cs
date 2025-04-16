Console.WriteLine($"{Environment.NewLine}<<----------------SortedDictionary Implementation---------------->>{Environment.NewLine}");
var leaderboard = new LeaderboardSortedDictionary();
leaderboard.AddPlayer("Alice", 1000);
leaderboard.AddPlayer("Bob", 1200);
leaderboard.AddPlayer("Alice", 1000); // Duplicate — will be skipped
leaderboard.AddPlayer("Alice", 1500); // New score — will replace old one
leaderboard.AddPlayer("Bob", 1200);   // Duplicate — will be skipped

leaderboard.PrintTopPlayers(5);

Console.WriteLine($"{Environment.NewLine}<<----------------Primitive Implementation---------------->>{Environment.NewLine}");

var leaderboardPrimitive = new LeaderboardPrimitiveImplementation();
leaderboardPrimitive.AddPlayer("Maria", 1500);
leaderboardPrimitive.AddPlayer("Jeff", 1200);
leaderboardPrimitive.AddPlayer("Rita", 1300);
leaderboardPrimitive.AddPlayer("Rob", 1500);     // Same score as Maria
leaderboardPrimitive.AddPlayer("Maria", 3000);    // Duplicate, ignored
leaderboardPrimitive.AddPlayer("Jade", 4400);

leaderboardPrimitive.PrintTopPlayers(5);