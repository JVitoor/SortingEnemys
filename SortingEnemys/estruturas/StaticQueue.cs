using System;
using SortingEnemys.enemys;

namespace SortingEnemys.estruturas;

public class StaticQueue
{
    private Enemy[] queue;
    private int front;
    private int rear;
    private int count;
    private int capacity;

    public StaticQueue(int size)
    {
        capacity = size;
        queue = new Enemy[capacity];
        front = 0;
        rear = -1;
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

    public bool Enqueue(Enemy enemy)
    {
        if (IsFull())
            return false;

        rear = (rear + 1) % capacity;
        queue[rear] = enemy;
        count++;
        return true;
    }

    public Enemy Dequeue()
    {
        if (IsEmpty())
            return null;

        Enemy removed = queue[front];
        front = (front + 1) % capacity;
        count--;
        return removed;
    }

    public Enemy Peek()
    {
        if (IsEmpty())
            return null;

        return queue[front];
    }

    public Enemy SearchByName(string name)
    {
        for (int i = 0; i < count; i++)
        {
            int index = (front + i) % capacity;
            if (queue[index].GetName() == name)
                return queue[index];
        }

        return null;
    }

    public void Print()
    {
        Console.WriteLine("Fila:");
        for (int i = 0; i < count; i++)
        {
            int index = (front + i) % capacity;
            Enemy e = queue[index];
            Console.WriteLine($"{e.GetName()}, Nível {e.GetLevel()}");
        }
    }
}
