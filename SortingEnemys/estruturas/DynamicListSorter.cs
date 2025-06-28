using SortingEnemys.enemys;
using System.Collections.Generic;

namespace SortingEnemys.estruturas;

public static class DynamicListSorter
{
    private static List<Enemy> ToList(DynamicList dynamicList)
    {
        var list = new List<Enemy>();
        var current = dynamicList.GetHead();
        while (current != null)
        {
            list.Add(current.Data);
            current = current.Next;
        }
        return list;
    }

    private static void FromList(DynamicList dynamicList, List<Enemy> list)
    {
        dynamicList.Clear();
        foreach (var enemy in list)
        {
            dynamicList.InsertAtEnd(enemy);
        }
    }

    public static void BubbleSort(DynamicList list, Sorter.SortAttribute attribute)
    {
        var tempList = ToList(list);
        Sorter.BubbleSort(tempList, attribute);
        FromList(list, tempList);
    }

    public static void InsertionSort(DynamicList list, Sorter.SortAttribute attribute)
    {
        var tempList = ToList(list);
        Sorter.InsertionSort(tempList, attribute);
        FromList(list, tempList);
    }
}