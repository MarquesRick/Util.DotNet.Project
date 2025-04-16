var leaderboard = new Leaderboard();

leaderboard.AddPlayer("Alice", 1000);
leaderboard.AddPlayer("Bob", 1200);
leaderboard.AddPlayer("Alice", 1000); // Duplicate — will be skipped
leaderboard.AddPlayer("Alice", 1500); // New score — will replace old one
leaderboard.AddPlayer("Bob", 1200);   // Duplicate — will be skipped

leaderboard.PrintTopPlayers(5);