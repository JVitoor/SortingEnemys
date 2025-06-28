using System;
using SortingEnemys.enemys;

namespace SortingEnemys.estruturas;

public class StaticList
{
    private Enemy[] list;
    private int count;
    private int capacity;

    public StaticList(int size)
    {
        capacity = size;
        list = new Enemy[capacity];
        count = 0;
    }

    public bool IsEmpty()
    {
        return count == 0;
    }

    public bool IsFull()
    {
        return count == capacity;
    }

    public bool InsertAt(int position, Enemy enemy)
    {
        if (IsFull() || position < 0 || position > count)
            return false;

        for (int i = count; i > position; i--)
        {
            list[i] = list[i - 1];
        }

        list[position] = enemy;
        count++;
        return true;
    }

    public Enemy RemoveAt(int position)
    {
        if (IsEmpty() || position < 0 || position >= count)
            return null;

        Enemy removed = list[position];

        for (int i = position; i < count - 1; i++)
        {
            list[i] = list[i + 1];
        }

        list[count - 1] = null;
        count--;
        return removed;
    }

    public Enemy SearchByName(string name)
    {
        for (int i = 0; i < count; i++)
        {
            if (list[i].GetName() == name)
                return list[i];
        }

        return null;
    }

    public void Print()
    {
        Console.WriteLine("Lista:");
        for (int i = 0; i < count; i++)
        {
            Enemy e = list[i];
            Console.WriteLine($"{i}: {e.GetName()}, Nível {e.GetLevel()}");
        }
    }

    public int Size()
    {
        return count;
    }
}
