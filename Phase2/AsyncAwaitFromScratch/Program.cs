using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Concurrent;
using System.Runtime.ExceptionServices;

Console.Write("Hello");
MyTask.ContinueWith(delegate {
    Console.Write("World");
}).Wait();
//AsyncLocal<int> myValue = new AsyncLocal<int>();
//List<MyTask> myTasks = new List<MyTask>();
//for(int i=0; i<100; i++)
//{
//    //int capturedValue = i;
//    myValue.Value = i;
//    myTasks.Add(MyTask.Run(delegate
//    {
//        //Console.WriteLine(i);
//        //This will print 1000 cause at time of thread creating i have reached to 1000
        
//        Console.WriteLine(myValue.Value);
//        //Console.WriteLine(capturedValue);
//        // This will print 1 - 1000 may or may not in order 
//        Thread.Sleep(1000);
//    }));
//}

//MyTask.WhenAll(myTasks).Wait();
//foreach (var t in myTasks) t.Wait();
//Console.ReadLine();

class MyTask
{
    private bool _completed;
    private Exception? _exception;
    private Action? _continuation;
    private ExecutionContext? _context;
    public bool isCompleted
    {
        get
        {
            lock (this)
            {
                return _completed;
            }
        }
    }
    public void SetResult()
    {

    }

    public void SetException(Exception exception)
    {

    }

    public void Complete(Exception? exception)
    {
        lock (this)
        {
            if (_completed) throw new InvalidOperationException("Stop messing up my code");

            _completed = true;
            _exception = exception;

            if(_continuation is not null)
            {
                MyThreadPool.QueueUserWorkItem(delegate
                {
                    if (_context is null)
                    {
                        _continuation();
                    }
                    else
                    {
                        ExecutionContext.Run(_context, (object? state) => ((Action)state!).Invoke(), _continuation);
                    }
                });
            }
        }
    }
    public void Wait()
    {
        ManualResetEventSlim? mres = null;

        lock (this)
        {
            if (!_completed)
            {
                mres = new ManualResetEventSlim();
                ContinueWith(mres.Set);
            }
        }
        mres?.Wait();

        if(_exception is not null)
        {
            ExceptionDispatchInfo.Throw(_exception);
            //throw new AggregateException(_exception);
        }
    }
    public MyTask ContinueWith(Action action)
    {
        MyTask t = new MyTask();

        Action callback = () =>
        {
            try
            {
                action();
            }
            catch (Exception e)
            {
                t.SetException(e);
                return;
            }
            t.SetResult();
        };
        lock (this)
        {
            if (_completed)
            {
                MyThreadPool.QueueUserWorkItem(action);
            }
            else
            {
                _continuation = action;
                _context = ExecutionContext.Capture();
            }
        }
        return t;
    }
    public static MyTask Run(Action action)
    {
        MyTask t = new();
        MyThreadPool.QueueUserWorkItem(() =>
        {
            try
            {
                action();
            }
            catch (Exception e)
            {
                t.SetException(e);
                return;
            }
        });
        return t;
    }
    public static MyTask WhenAll(List<MyTask> tasks)
    {
        MyTask t = new();

        if(tasks.Count == 0)
        {
            t.SetResult();
        }
        else
        {
            int remaining = tasks.Count;

            Action continuation = () =>
            {
                if (Interlocked.Decrement(ref remaining) == 0)
                {
                    t.SetResult();
                }
            };

            foreach(var task in tasks)
            {
                task.ContinueWith(continuation);
            }
        }
        return t;
    }

    public static MyTask Delay(int timeout)
    {
        MyTask t = new MyTask();
        new Timer(_ => t.SetResult()).Change(timeout, -1);

        return t;
    }
}
static class MyThreadPool
{
    private static readonly BlockingCollection<(Action, ExecutionContext?)> s_workItems = new();

    public static void QueueUserWorkItem(Action action)
    {
        s_workItems.Add((action, ExecutionContext.Capture()));
    }

    static MyThreadPool()
    {
        for(int i=0; i<Environment.ProcessorCount; i++)
        {
            new Thread(() =>
            {
                while (true)
                {
                    (Action workItem, ExecutionContext? context )= s_workItems.Take();
                    if(context is null)
                    {
                        workItem();
                    }
                    else
                    {
                        ExecutionContext.Run(context, delegate { workItem(); }, null);

                        // same work is done 

                        //ExecutionContext.Run(context, state =>((Action)state!).Invoke(), workItem);
                    }
                }
            })
            { IsBackground = true}.Start();
        }
    }
}
/* System Thread Pool
for (int i = 0; i < 1000; i++)
{
    int capturedValue = i;
    ThreadPool.QueueUserWorkItem(delegate
    {
        //Console.WriteLine(i);
        //This will print 1000 cause at time of thread creating i have reached to 1000
        Console.WriteLine(capturedValue);
        // This will print 1 - 1000 may or may not in order 
        Thread.Sleep(1000);
    });
}
*/
