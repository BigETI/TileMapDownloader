using System;
using System.Collections.Generic;
using System.Threading;

/// <summary>
/// Tile map downloader namespace
/// </summary>
namespace TileMapDownloader
{
    /// <summary>
    /// Countable thread pool class
    /// </summary>
    public class CountableThreadPool : IDisposable
    {
        /// <summary>
        /// Observer sleep time
        /// </summary>
        private static readonly int observerSleepTime = 20;

        /// <summary>
        /// Threads
        /// </summary>
        private ParameterizedThread[] threads;

        /// <summary>
        /// Observer thread
        /// </summary>
        private Thread observerThread;

        /// <summary>
        /// Queue
        /// </summary>
        private Queue<ParameterizedThread> queue = new Queue<ParameterizedThread>();

        /// <summary>
        /// Observer running
        /// </summary>
        private bool observerRunning = true;

        /// <summary>
        /// Active thread count
        /// </summary>
        public int ActiveThreadCount
        {
            get
            {
                int ret = 0;
                lock (threads)
                {
                    for (int i = 0; i < threads.Length; i++)
                    {
                        ParameterizedThread thread = threads[i];
                        if (thread != null)
                        {
                            if (thread.Thread.ThreadState == ThreadState.Running)
                            {
                                ++ret;
                            }
                        }
                    }
                }
                return ret;
            }
        }

        /// <summary>
        /// Queue count
        /// </summary>
        public int QueueCount
        {
            get
            {
                int ret = 0;
                lock (queue)
                {
                    ret = queue.Count;
                }
                return ret;
            }
        }

        /// <summary>
        /// Overall count
        /// </summary>
        public int OverallCount
        {
            get
            {
                return ActiveThreadCount + QueueCount;
            }
        }

        /// <summary>
        /// Number of threads
        /// </summary>
        /// <param name="numOfThreads">Number of threads (smaller or equal 0 uses the processor count)</param>
        public CountableThreadPool(int numOfThreads = 0)
        {
            threads = new ParameterizedThread[(numOfThreads > 0) ? numOfThreads : Environment.ProcessorCount];
            observerThread = new Thread(new ParameterizedThreadStart((instance) =>
            {
                if (instance is CountableThreadPool)
                {
                    CountableThreadPool that = (CountableThreadPool)instance;
                    while (observerRunning)
                    {
                        lock (threads)
                        {
                            for (int i = 0; i < threads.Length; i++)
                            {
                                ParameterizedThread thread = threads[i];
                                if (thread == null)
                                {
                                    that.AssignWork(i);
                                }
                                else
                                {
                                    if (thread.Thread.ThreadState != ThreadState.Running)
                                    {
                                        try
                                        {
                                            thread.Thread.Join();
                                        }
                                        catch (Exception e)
                                        {
                                            Console.Error.WriteLine(e.Message);
                                        }
                                        threads[i] = null;
                                        that.AssignWork(i);
                                    }
                                }
                            }
                        }
                        Thread.Sleep(observerSleepTime);
                    }
                }
            }));
            observerThread.Start(this);
        }

        /// <summary>
        /// Assign work
        /// </summary>
        /// <param name="index">Index</param>
        private void AssignWork(int index)
        {
            lock (queue)
            {
                if (queue.Count > 0)
                {
                    ParameterizedThread thread = queue.Dequeue();
                    thread.Start();
                    threads[index] = thread;
                }
            }
        }

        /// <summary>
        /// Add thread to queue
        /// </summary>
        /// <param name="thread">Thread</param>
        private void AddThreadToQueue(ParameterizedThread thread)
        {
            lock (queue)
            {
                queue.Enqueue(thread);
            }
        }

        /// <summary>
        /// Add to queue
        /// </summary>
        /// <param name="start">Parameterized start</param>
        /// <param name="parameter">Parameter</param>
        public void AddToQueue(ParameterizedThreadStart start, object parameter)
        {
            AddThreadToQueue(new ParameterizedThread(new Thread(start), parameter));
        }

        /// <summary>
        /// Add to queue
        /// </summary>
        /// <param name="start">Start</param>
        public void AddToQueue(ThreadStart start)
        {
            AddThreadToQueue(new ParameterizedThread(new Thread(start)));
        }

        /// <summary>
        /// Add to queue
        /// </summary>
        /// <param name="start">Start</param>
        /// <param name="maxStackSize">Max stack size</param>
        /// <param name="parameter">Parameter</param>
        public void AddToQueue(ParameterizedThreadStart start, int maxStackSize, object parameter)
        {
            AddThreadToQueue(new ParameterizedThread(new Thread(start, maxStackSize), parameter));
        }

        /// <summary>
        /// Add to queue
        /// </summary>
        /// <param name="start">Start</param>
        /// <param name="maxStackSize">Max stack size</param>
        public void AddToQueue(ThreadStart start, int maxStackSize)
        {
            AddThreadToQueue(new ParameterizedThread(new Thread(start, maxStackSize)));
        }

        /// <summary>
        /// Abort
        /// </summary>
        public void Abort()
        {
            lock (queue)
            {
                queue.Clear();
            }
            lock (threads)
            {
                for (int i = 0; i < threads.Length; i++)
                {
                    ParameterizedThread thread = threads[i];
                    if (thread != null)
                    {
                        thread.Dispose();
                        threads[i] = null;
                    }
                }
            }
        }

        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose()
        {
            try
            {
                observerRunning = false;
                observerThread.Join();
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
            }
            Abort();
        }
    }
}
