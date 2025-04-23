using SampleExample.SortingMethods.Interfaces;

namespace SampleExample.SortingMethods;

public class SelectionSort : ISorter
{
    public int[] Arr { get; private set; }

    public SelectionSort(int[] arr)
    {
        Arr = arr;
    }

    public static SelectionSort Build(int[] arr)
    {
        return new SelectionSort(arr);
    }

    public void Sort()
    {
        int n = Arr.Length;

        for (int i = 0; i < n - 1; i++)
        {
            int minIndex = i;

            for (int j = i + 1; j < n; j++)
            {
                if (Arr[j] < Arr[minIndex])
                {
                    minIndex = j;
                }
            }

            int temp = Arr[minIndex];
            Arr[minIndex] = Arr[i];
            Arr[i] = temp;
        }
    }
}