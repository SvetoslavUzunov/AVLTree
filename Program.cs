namespace AVLTree;

public class Program
{
    static void Main()
    {
        var tree = new AVLTree<int>();
        var root = tree.Insert(null, 1);

        Random rnd = new Random();
        for (int i = 2; i <= 50; i++)
        {
            root = tree.Insert(root, rnd.Next(0, 100));
        }

        tree.DFS(root, 0);
    }
}