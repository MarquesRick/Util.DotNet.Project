namespace Singleton.Design.Pattern
{
    public class SingletonNotSafeMultiThread
    {
        private static int _counter = 0;
        private static SingletonNotSafeMultiThread instance = null;

        private SingletonNotSafeMultiThread()
        {
            _counter++;
            Console.WriteLine("Instances: " + _counter);
        }

        public static SingletonNotSafeMultiThread Instance
        {
            get
            {
                if (instance is null)
                    instance = new SingletonNotSafeMultiThread();

                return instance;
            }
        }
    }
}
