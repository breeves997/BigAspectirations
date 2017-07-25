using System;
using System.Diagnostics;
using System.Reflection;

[module: Interceptor]

// Any attribute which provides OnEntry/OnExit/OnException with proper args
[AttributeUsage(AttributeTargets.Method | AttributeTargets.Constructor | AttributeTargets.Assembly | AttributeTargets.Module)]
public class InterceptorAttribute : Attribute
{
    private Stopwatch _sw;
    private string _someData;
    
    // instance, method and args can be captured here and stored in attribute instance fields
    // for future usage in OnEntry/OnExit/OnException
    public void Init(object instance, MethodBase method, object[] args)
    {
        Console.WriteLine("Method initialization begun!");
        _someData = DateTime.UtcNow.ToString("o");
        _sw = new Stopwatch();
    }
    public void OnEntry()
    {
        Console.WriteLine("running method oh boy. we started at " + _someData);
        _sw.Start();
    }

    public void OnExit()
    {
        _sw.Stop();
        Console.WriteLine($"finished running the method. It took us {_sw.ElapsedMilliseconds} ms" );
    }

    public void OnException(Exception exception)
    {
        Console.WriteLine($"Gee wiz an exception occured: {exception.GetType()} {exception.Message}");
        _sw.Stop();
    }
}

public class Sample
{
    [Interceptor]
    public void Method()
    {
        Console.WriteLine("Method invoked!");
    }
    [Interceptor]
    public void ExceptionMethod()
    {
        Console.WriteLine("Exception Method invoked!");
        throw new InvalidOperationException("This method is called exception method... what did you expect?");
    }
    [Interceptor]
    public void RandomException()
    {
        var r = new Random();
        var val = r.NextDouble();
        if (val < 0.5)
        {
            throw new InvalidOperationException("Today is not your lucky day kiddo!");
        }
        else
        {
            Console.WriteLine("You're luck this time...");

        }
    }
}
class Program
{
    static void Main(string[] args)
    {
        var s = new Sample();
        s.Method();
        try
        {
            s.ExceptionMethod();
        }
        catch
        {

        }
        try
        {

            s.RandomException();
        }
        catch
        {

        }
        Console.ReadLine();
    }
}