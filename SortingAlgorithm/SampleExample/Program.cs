using System.Diagnostics;

using SampleExample.SortingMethods;
using SampleExample.SortingMethods.Interfaces;
using SampleExample.Utils;
using BenchmarkDotNet.Running;

using SortingBenchmarkApp;

var random = new Random();
var arrExample = Enumerable.Range(1, 10)
                           .OrderBy(_ => random.Next())
                           .ToList();
Console.WriteLine($"Before ordination: [{string.Join(", ", arrExample)}]");
ExecuteSort("Bubble Sort", BubbleSort.Build, arrExample);
ExecuteSort("Selection Sort", SelectionSort.Build, arrExample);
ExecuteSort("Quick Sort", QuickSort.Build, arrExample);


static void ExecuteSort(string name, Func<int[], ISorter> sortBuilder, List<int> source)
{
    LogUtil.RunVoidMethodsWithLog(name, () =>
    {
        Stopwatch sw = Stopwatch.StartNew();
        int[] data = [.. source];
        sortBuilder(data).Sort();
        sw.Stop();
        Console.WriteLine($"==== [Result]: [{string.Join(", ", data)}]");
        Console.WriteLine($"==== [Execution Time]: {sw.ElapsedMilliseconds} ms");
    });
}

//to run this benchmark (dotnet run --project SortingAlgorithm/SampleExample/SampleExample.csproj -c Release)
// BenchmarkRunner.Run<SortingBenchmark>();