using System;
using SortingEnemys.enemys;

namespace SortingEnemys.estruturas;

public class StaticStack
{
    private Enemy[] stack;
    private int top;
    private int capacity;

    public StaticStack(int size)
    {
        capacity = size;
        stack = new Enemy[capacity];
        top = -1;
    }

    public bool IsEmpty()
    {
        return top == -1;
    }

    public bool IsFull()
    {
        return top == capacity - 1;
    }

    public bool Push(Enemy enemy)
    {
        if (IsFull())
            return false;

        stack[++top] = enemy;
        return true;
    }

    public Enemy Pop()
    {
        if (IsEmpty())
            return null;

        return stack[top--];
    }

    public Enemy Peek()
    {
        if (IsEmpty())
            return null;

        return stack[top];
    }

    public Enemy SearchByName(string name)
    {
        for (int i = top; i >= 0; i--)
        {
            if (stack[i].GetName() == name)
                return stack[i];
        }

        return null;
    }

    public void Print()
    {
        Console.WriteLine("Pilha:");
        for (int i = top; i >= 0; i--)
        {
            Enemy e = stack[i];
            Console.WriteLine($"{e.GetName()}, Nível {e.GetLevel()}");
        }
    }
}
