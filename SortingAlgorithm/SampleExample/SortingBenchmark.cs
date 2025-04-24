using BenchmarkDotNet.Attributes;

namespace SortingBenchmarkApp;

[MemoryDiagnoser]
public class SortingBenchmark
{
    private int[] _data;
    private int[] _backup;

    [Params(1000, 5000)]
    public int Size;

    [GlobalSetup]
    public void Setup()
    {
        var rand = new Random();
        _backup = Enumerable.Range(1, Size).OrderBy(_ => rand.Next()).ToArray();
    }

    [IterationSetup]
    public void IterationSetup()
    {
        _data = (int[])_backup.Clone();
    }

    [Benchmark]
    public void BubbleSort() => SampleExample.SortingMethods.BubbleSort.Build(_data).Sort();

    [Benchmark]
    public void SelectionSort() => SampleExample.SortingMethods.SelectionSort.Build(_data).Sort();

    [Benchmark]
    public void QuickSort() => SampleExample.SortingMethods.QuickSort.Build(_data).Sort();

    [Benchmark]
    public void MergeSort() => SampleExample.SortingMethods.MergeSort.Build(_data).Sort();
}
