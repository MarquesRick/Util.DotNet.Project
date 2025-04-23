using SampleExample.SortingMethods.Interfaces;

namespace SampleExample.SortingMethods;

public class BubbleSort : ISorter
{
    public int[] Arr { get; private set; }

    public BubbleSort(int[] arr)
    {
        Arr = arr;
    }

    public static BubbleSort Build(int[] arr)
    {
        return new BubbleSort(arr);
    }

    public void Sort()
    {
        int n = Arr.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (Arr[j] > Arr[j + 1])
                {
                    // Trocar elementos
                    int temp = Arr[j];
                    Arr[j] = Arr[j + 1];
                    Arr[j + 1] = temp;
                }
            }
        }
    }
}