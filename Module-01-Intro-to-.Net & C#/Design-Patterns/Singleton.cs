using System; 

class Logger
{
    private static Logger instance;

    private Logger() { }

    public static Logger GetInstance()
    {
        if (instance == null)
            instance = new Logger();
        return instance;
    }

    public void Log(string message)
    { 
        Console.WriteLine(message); 
    }
}


class Program
{
    static void Main()
    {
        // This is how you use your Singleton
        Logger myLogger = Logger.GetInstance();
        myLogger.Log("Hello! The Singleton is working.");
    }
}
