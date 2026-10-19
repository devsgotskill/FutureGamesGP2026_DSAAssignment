using UnityEngine;
using System.Collections.Generic;

public class Stackimp<T>
{
    public List<T> stack = new List<T>();
    private int top = -1;
    public void Push(T item)
    {
        stack.Add(item);
        top++;
    }
    public bool IsEmpty()
    {
        return top == -1;
    }
    public T Pop()
    {
        if(IsEmpty())
        {
            Debug.Log("Stack is empty");
            return default;
        }
        T item = stack[top];
        stack.RemoveAt(top);
        top--;

        return item;
    }
    public T Peek()
    {
        if(IsEmpty())
        {
            Debug.Log("Stack is empty");
            return default(T);
        }
        return stack[top];
    }
}
