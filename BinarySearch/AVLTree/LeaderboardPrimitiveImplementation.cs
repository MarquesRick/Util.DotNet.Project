public class LeaderboardPrimitiveImplementation
{
    private AVLTree avlTree = new AVLTree();
    private Dictionary<string, int> playerScores = new Dictionary<string, int>();

    public void AddPlayer(string name, int score)
    {
        if (playerScores.TryGetValue(name, out int existingScore))
        {
            if (existingScore == score)
            {
                Console.WriteLine($"Skipping duplicate: {name} already has score {score}");
                return;
            }

            // Remove old score
            avlTree.Root = avlTree.Remove(avlTree.Root, new Player(name, existingScore));
        }

        playerScores[name] = score;
        avlTree.Root = avlTree.Insert(avlTree.Root, new Player(name, score));
    }

    public void PrintTopPlayers(int count)
    {
        Console.WriteLine($"Top {count} Players:");
        int printed = 0;
        avlTree.InOrder(avlTree.Root, ref printed, count);
    }
}
class Player
{
    public string Name;
    public int Score;

    public Player(string name, int score)
    {
        Name = name;
        Score = score;
    }
}

class AVLNode
{
    public Player Player;
    public AVLNode Left;
    public AVLNode Right;
    public int Height;

    public AVLNode(Player player)
    {
        Player = player;
        Height = 1;
    }
}

class AVLTree
{
    public AVLNode Root;
    private int Height(AVLNode node) => node?.Height ?? 0;
    private int GetBalance(AVLNode node) => node == null ? 0 : Height(node.Left) - Height(node.Right);

    private AVLNode RotateRight(AVLNode y)
    {
        AVLNode x = y.Left;
        AVLNode T2 = x.Right;

        x.Right = y;
        y.Left = T2;

        y.Height = Math.Max(Height(y.Left), Height(y.Right)) + 1;
        x.Height = Math.Max(Height(x.Left), Height(x.Right)) + 1;

        return x;
    }

    private AVLNode RotateLeft(AVLNode x)
    {
        AVLNode y = x.Right;
        AVLNode T2 = y.Left;

        y.Left = x;
        x.Right = T2;

        x.Height = Math.Max(Height(x.Left), Height(x.Right)) + 1;
        y.Height = Math.Max(Height(y.Left), Height(y.Right)) + 1;

        return y;
    }

    public AVLNode Insert(AVLNode node, Player player)
    {
        if (node == null)
            return new AVLNode(player);

        if (player.Score > node.Player.Score)
            node.Left = Insert(node.Left, player);
        else if (player.Score < node.Player.Score)
            node.Right = Insert(node.Right, player);
        else
        {
            // If scores are equal, sort by name to maintain uniqueness
            int nameCompare = string.Compare(player.Name, node.Player.Name, StringComparison.OrdinalIgnoreCase);
            if (nameCompare < 0)
                node.Left = Insert(node.Left, player);
            else if (nameCompare > 0)
                node.Right = Insert(node.Right, player);
            else
                return node; // duplicate name and score, ignore
        }

        node.Height = 1 + Math.Max(Height(node.Left), Height(node.Right));
        int balance = GetBalance(node);

        if (balance > 1 && player.Score > node.Left.Player.Score)
            return RotateRight(node);

        if (balance < -1 && player.Score < node.Right.Player.Score)
            return RotateLeft(node);

        if (balance > 1 && player.Score < node.Left.Player.Score)
        {
            node.Left = RotateLeft(node.Left);
            return RotateRight(node);
        }

        if (balance < -1 && player.Score > node.Right.Player.Score)
        {
            node.Right = RotateRight(node.Right);
            return RotateLeft(node);
        }

        return node;
    }

    public void InOrder(AVLNode node, ref int printed, int count)
    {
        if (node == null || printed >= count) return;

        InOrder(node.Left, ref printed, count);

        if (printed < count)
        {
            Console.WriteLine($"{node.Player.Name} - {node.Player.Score}");
            printed++;
        }

        InOrder(node.Right, ref printed, count);
    }

    public AVLNode Remove(AVLNode node, Player player)
    {
        if (node == null) return null;

        if (player.Score > node.Player.Score)
            node.Left = Remove(node.Left, player);
        else if (player.Score < node.Player.Score)
            node.Right = Remove(node.Right, player);
        else
        {
            int nameCompare = string.Compare(player.Name, node.Player.Name, StringComparison.OrdinalIgnoreCase);
            if (nameCompare < 0)
                node.Left = Remove(node.Left, player);
            else if (nameCompare > 0)
                node.Right = Remove(node.Right, player);
            else
            {
                // Found node to delete
                if (node.Left == null || node.Right == null)
                    return node.Left ?? node.Right;

                // Two children: get in-order predecessor (max from left subtree)
                AVLNode temp = GetMaxNode(node.Left);
                node.Player = temp.Player;
                node.Left = Remove(node.Left, temp.Player);
            }
        }

        node.Height = 1 + Math.Max(Height(node.Left), Height(node.Right));
        int balance = GetBalance(node);

        // Rebalance
        if (balance > 1 && GetBalance(node.Left) >= 0) return RotateRight(node);
        if (balance > 1 && GetBalance(node.Left) < 0)
        {
            node.Left = RotateLeft(node.Left);
            return RotateRight(node);
        }
        if (balance < -1 && GetBalance(node.Right) <= 0) return RotateLeft(node);
        if (balance < -1 && GetBalance(node.Right) > 0)
        {
            node.Right = RotateRight(node.Right);
            return RotateLeft(node);
        }

        return node;
    }

    private AVLNode GetMaxNode(AVLNode node)
    {
        while (node.Right != null) node = node.Right;
        return node;
    }

}