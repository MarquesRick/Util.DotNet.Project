/*
    The SortedDictionary<TKey, TValue> in C# internally uses a self-balancing binary search tree, 
    most likely an AVL Tree, to keep keys sorted in ascending order and provide efficient O(log n) time 
    for insertion, deletion, and lookup.
*/

class Leaderboard
{
    /*
        Instead of using a List<string> for player names, 
        use a HashSet<string> which automatically ignores duplicates 
        and ensures unique names per score.
    */
    private SortedDictionary<int, HashSet<string>> scores;
    private Dictionary<string, int> playerScores;

    public Leaderboard()
    {
        scores = new SortedDictionary<int, HashSet<string>>(Comparer<int>.Create((a, b) => b.CompareTo(a)));
        playerScores = [];
    }

    public void AddPlayer(string name, int score)
    {
        // Prevent duplicates: same player and score already exist
        if (playerScores.TryGetValue(name, out int existingScore) && existingScore == score)
        {
            Console.WriteLine($"Skipping duplicate: {name} already has score {score}");
            return;
        }

        // Remove old score if player already had a different score
        if (playerScores.TryGetValue(name, out int oldScore))
        {
            scores[oldScore].Remove(name);
            if (scores[oldScore].Count == 0)
            {
                scores.Remove(oldScore);
            }
        }

        if (!scores.TryGetValue(score, out HashSet<string>? value))
        {
            value = [];
            scores[score] = value;
        }

        value.Add(name);
        playerScores[name] = score;
    }

    public void PrintTopPlayers(int count)
    {
        Console.WriteLine($"Top {count} Players:");
        int printed = 0;

        foreach (var kvp in scores)
        {
            foreach (var name in kvp.Value)
            {
                Console.WriteLine($"{name} - {kvp.Key}");
                printed++;
                if (printed >= count)
                    return;
            }
        }
    }
}