using System;
using SortingEnemys.enemys;

namespace SortingEnemys.estruturas
{
    public class DynamicStack
    {
        private DynamicStackNode top;

        public void Push(Enemy data)
        {
            DynamicStackNode newNode = new DynamicStackNode(data);
            newNode.Next = top;
            top = newNode;
        }

        public Enemy Pop()
        {
            if (IsEmpty())
                return null;

            Enemy data = top.Data;
            top = top.Next;
            return data;
        }

        public Enemy Peek()
        {
            return IsEmpty() ? null : top.Data;
        }

        public bool IsEmpty()
        {
            return top == null;
        }

        public Enemy SearchByName(string name)
        {
            DynamicStackNode current = top;
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
            Console.WriteLine("Pilha dinâmica:");
            DynamicStackNode current = top;
            while (current != null)
            {
                Console.WriteLine($"{current.Data.GetName()}, Nível {current.Data.GetLevel()}");
                current = current.Next;
            }
        }
    }

    public class DynamicStackNode
    {
        public Enemy Data;
        public DynamicStackNode Next;

        public DynamicStackNode(Enemy data)
        {
            Data = data;
            Next = null;
        }
    }
}
