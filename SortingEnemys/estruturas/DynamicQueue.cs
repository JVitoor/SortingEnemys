using System;
using SortingEnemys.enemys;

namespace SortingEnemys.estruturas
{
    public class DynamicQueue
    {
        private DynamicListNode front;
        private DynamicListNode rear;

        public bool IsEmpty()
        {
            return front == null;
        }

        public void Enqueue(Enemy data)
        {
            DynamicListNode newNode = new DynamicListNode(data);
            if (IsEmpty())
            {
                front = rear = newNode;
                return;
            }
            rear.Next = newNode;
            rear = newNode;
        }

        public Enemy Dequeue()
        {
            if (IsEmpty())
            {
                return null;
            }
            Enemy data = front.Data;
            front = front.Next;
            if (front == null)
            {
                rear = null;
            }
            return data;
        }

        public Enemy Peek()
        {
            return IsEmpty() ? null : front.Data;
        }

        public Enemy SearchByName(string name)
        {
            DynamicListNode current = front;
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
            Console.WriteLine("Fila dinâmica (Front -> Rear):");
            DynamicListNode current = front;
            while (current != null)
            {
                Console.WriteLine($"- {current.Data.GetName()}, Nível {current.Data.GetLevel()}");
                current = current.Next;
            }
        }
    }
}