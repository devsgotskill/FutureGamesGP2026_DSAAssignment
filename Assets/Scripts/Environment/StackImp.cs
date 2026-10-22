using Environment.Tasks;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Stackimp<T>
{
    [SerializeField]
    public List<T> stack = new List<T>();
    public T[] items = new T[10];
    private int top = -1;
    public void Push(T item)
    {
        stack.Add(item);
        top++;
        items[top] = item;
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
