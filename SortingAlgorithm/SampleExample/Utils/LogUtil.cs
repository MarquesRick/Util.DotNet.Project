namespace SampleExample.Utils;
public static class LogUtil
{
    public static void RunVoidMethodsWithLog(string name, Action action)
    {
        Console.WriteLine($"[Starting] {name}");
        action();
        Console.WriteLine($"[Finished] {name}\n");
    }
}