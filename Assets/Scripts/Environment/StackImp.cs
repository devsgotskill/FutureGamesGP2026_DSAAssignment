using UnityEngine;
using System.Collections.Generic;
using Environment.Tasks;

public class Stackimp<T>
{
    [SerializeField]
    public List<T> stack;
    public T[] items;
    private int top;
    public void Push(T item)
    {
        top++;
        items[top] = item;
    }
    public T Pop()
    {
        T item = items[top];
        top--;
        return item;
    }

    public void Peek(T item)
    {
        if (top == -1)
        {
            Debug.Log("Stack is empty");
            return;
        }
        item = stack[top];
    }
    public bool IsEmpty()
    {
        return top == -1;
    }
}   
