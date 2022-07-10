namespace AVLTree;

public class Node<T>
{
    public Node(int value, int height = 0, int balance = 0)
    {
        this.Value = value;
        this.Height = height;
        this.Balance = balance;
    }

    public int Height { get; set; }

    public int Balance { get; set; }

    public int Value { get; set; }

    public Node<T> Left { get; set; }

    public Node<T> Right { get; set; }
}
