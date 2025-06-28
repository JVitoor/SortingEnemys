using SortingEnemys.enemys;
using System.Collections.Generic;
using System.Linq;

namespace SortingEnemys.estruturas
{
    public static class BinarySearch
    {
        public static Enemy Search(DynamicList list, string name)
        {
            var sortedArray = list.AsEnumerable().ToArray();

            sortedArray = sortedArray.OrderBy(e => e.GetName()).ToArray();

            Console.WriteLine("\nLista ordenada para a Pesquisa Binária:");
            foreach (var e in sortedArray)
            {
                Console.WriteLine($"- {e.GetName()}");
            }
            Console.WriteLine();

            int left = 0;
            int right = sortedArray.Length - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                int comparison = name.CompareTo(sortedArray[mid].GetName());

                if (comparison == 0)
                    return sortedArray[mid];

                if (comparison > 0)
                    left = mid + 1;
                else
                    right = mid - 1;
            }

            return null;
        }

        public static IEnumerable<Enemy> AsEnumerable(this DynamicList list)
        {
            DynamicListNode current = list.GetHead();
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }
}