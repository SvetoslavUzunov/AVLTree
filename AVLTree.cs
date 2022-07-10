namespace AVLTree;

public class AVLTree<T>
{
    public Node<T> Insert(Node<T> node, int value)
    {
        if (node == null)
        {
            return new Node<T>(value);
        }

        if (value < node.Value)
        {
            node.Left = Insert(node.Left, value);
        }
        else
        {
            node.Right = Insert(node.Right, value);
        }

        UpdateFactors(node);

        return UpdateBalance(node);
    }

    public void DFS(Node<T> node, int indent)
    {
        if (node == null) return;

        DFS(node.Right, indent + 3);
        Console.Write(new String(' ', indent));
        Console.Write(node.Value);
        Console.WriteLine();
        DFS(node.Left, indent + 3);
    }

    private void UpdateFactors(Node<T> node)
    {
        int leftHeight = -1;
        int rightHeight = -1;

        if (node.Left != null)
        {
            leftHeight = node.Left.Height;
        }
        if (node.Right != null)
        {
            rightHeight = node.Right.Height;
        }

        node.Height = 1 + Math.Max(leftHeight, rightHeight);
        node.Balance = rightHeight - leftHeight;
    }

    private Node<T> UpdateBalance(Node<T> node)
    {
        if (node.Balance == -2)
        {
            if (node.Left.Balance > 0)
            {
                node = LeftRightRotation(node);
            }
            else
            {
                node = RightRightRotation(node);
            }
        }
        if (node.Balance == 2)
        {
            if (node.Right.Balance < 0)
            {
                node = RightLeftRotation(node);
            }
            else
            {
                node = LeftLeftRotation(node);
            }
        }

        return node;
    }

    private Node<T> RightRightRotation(Node<T> node)
    {
        return RightRotation(node);
    }

    private Node<T> RightRotation(Node<T> node)
    {
        var newNode = node.Left;
        node.Left = newNode.Right;
        newNode.Right = node;

        UpdateFactors(node);
        UpdateFactors(newNode);

        return newNode;
    }

    private Node<T> LeftLeftRotation(Node<T> node)
    {
        return LeftRotation(node);
    }

    private Node<T> LeftRotation(Node<T> node)
    {
        var newNode = node.Right;
        node.Right = newNode.Left;
        newNode.Left = node;

        UpdateFactors(node);
        UpdateFactors(newNode);

        return newNode;
    }

    private Node<T> RightLeftRotation(Node<T> node)
    {
        node.Right = RightRightRotation(node.Right);

        return LeftLeftRotation(node);
    }

    private Node<T> LeftRightRotation(Node<T> node)
    {
        node.Left = LeftLeftRotation(node.Left);

        return RightRightRotation(node);
    }
}
