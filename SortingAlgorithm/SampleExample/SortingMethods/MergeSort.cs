using System;

using SampleExample.SortingMethods.Interfaces;

namespace SampleExample.SortingMethods;

public class MergeSort : ISorter
{
    public int[] Arr { get; set; }
    private MergeSort(int[] arr)
    {
        Arr = arr;
    }

    public static MergeSort Build(int[] arr)
    {
        return new MergeSort(arr);
    }
    public void Sort()
    {
        MergeSortRecursive(Arr, 0, Arr.Length - 1);
    }

    private void MergeSortRecursive(int[] array, int left, int right)
    {
        if (left < right)
        {
            int mid = (left + right) / 2;

            MergeSortRecursive(array, left, mid);
            MergeSortRecursive(array, mid + 1, right);
            Merge(array, left, mid, right);
        }
    }

    private void Merge(int[] array, int left, int mid, int right)
    {
        int n1 = mid - left + 1;
        int n2 = right - mid;

        int[] L = new int[n1];
        int[] R = new int[n2];

        Array.Copy(array, left, L, 0, n1);
        Array.Copy(array, mid + 1, R, 0, n2);

        int i = 0, j = 0, k = left;

        while (i < n1 && j < n2)
        {
            if (L[i] <= R[j])
                array[k++] = L[i++];
            else
                array[k++] = R[j++];
        }

        while (i < n1) array[k++] = L[i++];
        while (j < n2) array[k++] = R[j++];
    }
}
