namespace Top.Interview._150.Stack;

/// <summary>
/// # 155
/// Design a stack that supports push, pop, top, and retrieving the minimum element in constant time.
/// Implement the MinStack class:
/// MinStack() initializes the stack object.
/// void push(int val) pushes the element val onto the stack.
/// void pop() removes the element on the top of the stack.
/// int top() gets the top element of the stack.
/// int getMin() retrieves the minimum element in the stack.
/// You must implement a solution with O(1) time complexity for each function.
/// </summary>
public class MinStack
{
    private readonly Stack<(int value, int min)> stack;

    public MinStack()
    {
        stack = new Stack<(int value, int min)>();
    }
    
    public void Push(int val)
    {
        int min = val;
        if (stack.Count > 0)
            min = Math.Min(min, stack.Peek().min);
        stack.Push(new(val, min));
    }
    
    public void Pop()
    {
        stack.Pop();
    }
    
    public int Top()
    {
        return stack.Peek().value;
    }
    
    public int GetMin()
    {
        return stack.Peek().min;
    }
}