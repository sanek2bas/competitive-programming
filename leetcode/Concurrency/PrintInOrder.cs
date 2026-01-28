namespace Concurrency;

public class PrintInOrder
{
    private readonly ManualResetEventSlim firstDone;
    private readonly ManualResetEventSlim secondDone;

    public PrintInOrder() 
    {
        firstDone = new ManualResetEventSlim(false);
        secondDone = new ManualResetEventSlim(false);
    }

    public void First(Action printFirst) 
    {        
        printFirst();
        firstDone.Set();
    }

    public void Second(Action printSecond) 
    {
        firstDone.Wait();
        printSecond();
        secondDone.Set();
    }

    public void Third(Action printThird) 
    {
        secondDone.Wait();
        printThird();
    }
}
