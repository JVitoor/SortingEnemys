using System;
using SortingEnemys.enemys;

namespace SortingEnemys.estruturas;

public class DynamicList
{
    private DynamicListNode head;

    public void InsertAtBeginning(Enemy data)
    {
        DynamicListNode newNode = new DynamicListNode(data);
        newNode.Next = head;
        head = newNode;
    }

    public void InsertAtEnd(Enemy data)
    {
        DynamicListNode newNode = new DynamicListNode(data);

        if (head == null)
        {
            head = newNode;
            return;
        }

        DynamicListNode current = head;
        while (current.Next != null)
        {
            current = current.Next;
        }

        current.Next = newNode;
    }

    public bool RemoveByName(string name)
    {
        if (head == null) return false;

        if (head.Data.GetName() == name)
        {
            head = head.Next;
            return true;
        }

        DynamicListNode current = head;
        while (current.Next != null)
        {
            if (current.Next.Data.GetName() == name)
            {
                current.Next = current.Next.Next;
                return true;
            }
            current = current.Next;
        }

        return false;
    }

    public Enemy SearchByName(string name)
    {
        DynamicListNode current = head;

        while (current != null)
        {
            if (current.Data.GetName() == name)
                return current.Data;

            current = current.Next;
        }

        return null;
    }

    public void Print()
    {
        Console.WriteLine("Lista dinâmica:");
        DynamicListNode current = head;
        while (current != null)
        {
            Enemy e = current.Data;
            Console.WriteLine($"{e.GetName()}, Nível {e.GetLevel()}");
            current = current.Next;
        }
    }

    public DynamicListNode GetHead()
    {
        return head;
    }

    public void SetHead(DynamicListNode newHead)
    {
        head = newHead;
    }

    public void Clear()
    {
        head = null;
    }
}

public class DynamicListNode
{
    public Enemy Data;
    public DynamicListNode Next;

    public DynamicListNode(Enemy data)
    {
        Data = data;
        Next = null;
    }
}
