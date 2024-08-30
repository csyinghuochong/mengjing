using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;

namespace ET
{
    internal class ThreadPoolScheduler: IScheduler
    {
        private readonly List<Thread> threads;

        private readonly ConcurrentQueue<int> idQueue = new();
        
        private readonly FiberManager fiberManager;

        public ThreadPoolScheduler(FiberManager fiberManager)
        {
            this.fiberManager = fiberManager;
            int threadCount = Environment.ProcessorCount;  //处理器，12核
            this.threads = new List<Thread>(threadCount);
            for (int i = 0; i < threadCount; ++i)
            {
                Thread thread = new(this.Loop);
                this.threads.Add(thread);
                thread.Start();
            }
        }

        private void Loop()
        {
            int count = 0;
            while (true)
            {
                if (count <= 0)
                {
                    Thread.Sleep(1);
                    
                    // count最小为1
                    count = this.fiberManager.Count() / this.threads.Count + 1;
                }

                --count;
                
                if (this.fiberManager.IsDisposed())
                {
                    return;
                }
                
                if (!this.idQueue.TryDequeue(out int id))
                {
                    Thread.Sleep(1);
                    continue;
                }

                Fiber fiber = this.fiberManager.Get(id);
                if (fiber == null)
                {
                    continue;
                }

                if (fiber.IsDisposed)
                {
                    continue;
                }

                Fiber.Instance = fiber;
                //当前线程抢到CPU时间片 有了执行的优先级  立马设置一下 fiber.ThreadSynchronizationContext 为可执行的上下文
                //考虑到优先级问题 ，线程会通过上下文切换在核心之间轮流执行 是同一个时刻 有几个 线程 抢得优先级 可以被执行指令
                //Loop的时候 是我线程去选择上下文 不是上下文 来设置线程 上下文存着线程栈内存和threadstatic数据等等东西 要确保同一个fiber使用的上下文是同一份
                //SynchronizationContext.SetSynchronizationContext 是说 让当前线程 跟某个上下文 进行绑定
                //是指这里面的回调队列都是对应的某一个Fiber，所以切换Fiber的时候如果不SetSynchronizationContext，那在当时那个Fiber中的消息回调可能放到了另一个Fiber对应的回调队列里面去了
                SynchronizationContext.SetSynchronizationContext(fiber.ThreadSynchronizationContext);
                fiber.Update();
                fiber.LateUpdate();
                SynchronizationContext.SetSynchronizationContext(null);
                Fiber.Instance = null;

                this.idQueue.Enqueue(id);
            }
        }

        public void Dispose()
        {
            foreach (Thread thread in this.threads)
            {
                thread.Join();
            }
        }

        public void Add(int fiberId)
        {
            this.idQueue.Enqueue(fiberId);
        }
    }
}