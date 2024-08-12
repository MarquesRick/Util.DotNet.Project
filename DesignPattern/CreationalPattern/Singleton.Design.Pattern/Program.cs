using Singleton.Design.Pattern;

class Program
{
    static void Main(string[] args)
    {
        //It is not safe in Multi - Threaded services,
        //because it created different instances
        Parallel.Invoke(
            () => AccessThread1(),
            () => AccessThread2()
        );

        Console.WriteLine();

        //safe for multi-thread
        Parallel.Invoke(
            () => AccessMultiThreadSafe1(),
            () => AccessMultiThreadSafe2()
        );

        Console.ReadKey();
    }

    private static void AccessThread1()
    {
        var s1 = SingletonNotSafeMultiThread.Instance;
        Console.WriteLine("Thread 1");
    }

    private static void AccessThread2()
    {
        var s2 = SingletonNotSafeMultiThread.Instance;
        Console.WriteLine("Thread 2");
    }


    private static void AccessMultiThreadSafe1()
    {
        var s1 = SingletonSafeMultiThread.Instance;
        Console.WriteLine("Thread 1");
    }

    private static void AccessMultiThreadSafe2()
    {
        var s2 = SingletonSafeMultiThread.Instance;
        Console.WriteLine("Thread 2");
    }
}