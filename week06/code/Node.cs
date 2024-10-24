public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {

        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else if(value > Data)
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    public bool Contains(int value)
    {
        if (value < Data)
        {
            if (Left is null)
                return false;
            else
                return Left.Contains(value);
        }
        else if(value > Data)
        {
            if (Right is null)
                return false;
            else
                return Right.Contains(value);
        }else{
            return true;
        }
    }

    public int GetHeight()
    {
        var leftCount = Left?.GetHeight() ?? 0;
        var rightCount = Right?.GetHeight() ?? 0;

        if(leftCount <= rightCount){
            return rightCount += 1;
            
        }else{
            return leftCount += 1;
        }
    }
}