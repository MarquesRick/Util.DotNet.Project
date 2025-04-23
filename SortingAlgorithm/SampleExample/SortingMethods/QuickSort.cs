using SampleExample.SortingMethods.Interfaces;

namespace SampleExample.SortingMethods;

public class QuickSort : ISorter
{
    public int[] Arr { get; private set; }


    public QuickSort(int[] arr)
    {
        Arr = arr;
    }

    public static QuickSort Build(int[] arr)
    {
        return new QuickSort(arr);
    }

    public void Sort()
    {
        Sort(0, Arr.Length - 1);
    }

    private void Sort(int low, int high)
    {
        if (low < high)
        {
            int pivotIndex = Partition(Arr, low, high);
            Sort(low, pivotIndex - 1);
            Sort(pivotIndex + 1, high);
        }
    }

    private static int Partition(int[] array, int low, int high)
    {
        int pivot = array[high];
        int i = low - 1;

        for (int j = low; j < high; j++)
        {
            if (array[j] < pivot)
            {
                i++;
                Swap(array, i, j);
            }
        }

        Swap(array, i + 1, high);
        return i + 1;
    }

    private static void Swap(int[] array, int a, int b)
    {
        int temp = array[a];
        array[a] = array[b];
        array[b] = temp;
    }
}