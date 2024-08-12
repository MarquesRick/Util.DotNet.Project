namespace Singleton.Design.Pattern
{
    public class SingletonSafeMultiThread
    {
        private static int _counter = 0;
        private static SingletonSafeMultiThread instance = null;
        private static object lockObject = new object();
        private SingletonSafeMultiThread()
        {
            _counter++;
            Console.WriteLine("Instances: " + _counter);
        }

        public static SingletonSafeMultiThread Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockObject)
                    {
                        if (instance is null)
                            instance = new SingletonSafeMultiThread();
                    }
                }
                return instance;
            }
        }
    }
}
