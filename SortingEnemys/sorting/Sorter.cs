using System;
using System.Collections.Generic;

namespace SortingEnemys.enemys;

public static class Sorter
{
    public enum SortAttribute
    {
        Name,
        Level,
        Health,
        Attack,
        Defense,
        Speed
    }

    public static int Compare(Enemy a, Enemy b, SortAttribute attribute)
    {
        return attribute switch
        {
            SortAttribute.Name => a.GetName().CompareTo(b.GetName()),
            SortAttribute.Level => a.GetLevel().CompareTo(b.GetLevel()),
            SortAttribute.Health => a.GetHealth().CompareTo(b.GetHealth()),
            SortAttribute.Attack => a.GetAttack().CompareTo(b.GetAttack()),
            SortAttribute.Defense => a.GetDefense().CompareTo(b.GetDefense()),
            SortAttribute.Speed => a.GetSpeed().CompareTo(b.GetSpeed()),
            _ => 0,
        };
    }

    public static void BubbleSort(List<Enemy> enemies, SortAttribute attribute)
    {
        for (int i = 0; i < enemies.Count - 1; i++)
        {
            for (int j = 0; j < enemies.Count - i - 1; j++)
            {
                if (Compare(enemies[j], enemies[j + 1], attribute) > 0)
                {
                    (enemies[j], enemies[j + 1]) = (enemies[j + 1], enemies[j]);
                }
            }
        }
    }

    public static void SelectionSort(List<Enemy> enemies, SortAttribute attribute)
    {
        for (int i = 0; i < enemies.Count - 1; i++)
        {
            int minIndex = i;
            for (int j = i + 1; j < enemies.Count; j++)
            {
                if (Compare(enemies[j], enemies[minIndex], attribute) < 0)
                {
                    minIndex = j;
                }
            }

            if (minIndex != i)
            {
                (enemies[i], enemies[minIndex]) = (enemies[minIndex], enemies[i]);
            }
        }
    }

    public static void InsertionSort(List<Enemy> enemies, SortAttribute attribute)
    {
        for (int i = 1; i < enemies.Count; i++)
        {
            Enemy key = enemies[i];
            int j = i - 1;

            while (j >= 0 && Compare(enemies[j], key, attribute) > 0)
            {
                enemies[j + 1] = enemies[j];
                j--;
            }
            enemies[j + 1] = key;
        }
    }

    public static void ShellSort(List<Enemy> enemies, SortAttribute attribute)
    {
        int n = enemies.Count;
        int gap = n / 2;

        while (gap > 0)
        {
            for (int i = gap; i < n; i++)
            {
                Enemy temp = enemies[i];
                int j = i;
                while (j >= gap && Compare(enemies[j - gap], temp, attribute) > 0)
                {
                    enemies[j] = enemies[j - gap];
                    j -= gap;
                }
                enemies[j] = temp;
            }
            gap /= 2;
        }
    }

    public static void QuickSort(List<Enemy> enemies, SortAttribute attribute)
    {
        QuickSortHelper(enemies, 0, enemies.Count - 1, attribute);
    }

    private static void QuickSortHelper(List<Enemy> enemies, int left, int right, SortAttribute attribute)
    {
        if (left < right)
        {
            int pivotIndex = Partition(enemies, left, right, attribute);
            QuickSortHelper(enemies, left, pivotIndex - 1, attribute);
            QuickSortHelper(enemies, pivotIndex + 1, right, attribute);
        }
    }

    private static int Partition(List<Enemy> enemies, int left, int right, SortAttribute attribute)
    {
        Enemy pivot = enemies[right];
        int i = left - 1;

        for (int j = left; j < right; j++)
        {
            if (Compare(enemies[j], pivot, attribute) <= 0)
            {
                i++;
                (enemies[i], enemies[j]) = (enemies[j], enemies[i]);
            }
        }

        (enemies[i + 1], enemies[right]) = (enemies[right], enemies[i + 1]);
        return i + 1;
    }

    public static void MergeSort(List<Enemy> enemies, SortAttribute attribute)
    {
        if (enemies.Count <= 1)
            return;

        List<Enemy> sorted = MergeSortRecursive(enemies, attribute);
        for (int i = 0; i < enemies.Count; i++)
        {
            enemies[i] = sorted[i];
        }
    }

    private static List<Enemy> MergeSortRecursive(List<Enemy> enemies, SortAttribute attribute)
    {
        if (enemies.Count <= 1)
            return enemies;

        int mid = enemies.Count / 2;
        var left = MergeSortRecursive(enemies.GetRange(0, mid), attribute);
        var right = MergeSortRecursive(enemies.GetRange(mid, enemies.Count - mid), attribute);

        return Merge(left, right, attribute);
    }

    private static List<Enemy> Merge(List<Enemy> left, List<Enemy> right, SortAttribute attribute)
    {
        List<Enemy> result = new List<Enemy>();
        int i = 0, j = 0;

        while (i < left.Count && j < right.Count)
        {
            if (Compare(left[i], right[j], attribute) <= 0)
            {
                result.Add(left[i]);
                i++;
            }
            else
            {
                result.Add(right[j]);
                j++;
            }
        }

        while (i < left.Count)
            result.Add(left[i++]);
        while (j < right.Count)
            result.Add(right[j++]);

        return result;
    }

    public static void HeapSort(List<Enemy> enemies, SortAttribute attribute)
    {
        int n = enemies.Count;

        for (int i = n / 2 - 1; i >= 0; i--)
            Heapify(enemies, n, i, attribute);

        for (int i = n - 1; i >= 0; i--)
        {
            (enemies[0], enemies[i]) = (enemies[i], enemies[0]);
            Heapify(enemies, i, 0, attribute);
        }
    }

    private static void Heapify(List<Enemy> enemies, int n, int i, SortAttribute attribute)
    {
        int largest = i;
        int left = 2 * i + 1;
        int right = 2 * i + 2;

        if (left < n && Compare(enemies[left], enemies[largest], attribute) > 0)
            largest = left;

        if (right < n && Compare(enemies[right], enemies[largest], attribute) > 0)
            largest = right;

        if (largest != i)
        {
            (enemies[i], enemies[largest]) = (enemies[largest], enemies[i]);
            Heapify(enemies, n, largest, attribute);
        }
    }


}
