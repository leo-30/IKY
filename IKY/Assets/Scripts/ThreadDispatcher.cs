using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class ThreadDispatcher
{
    private int ownerThreadID;
    private System.Collections.Generic.Queue<System.Action> queue = new System.Collections.Generic.Queue<System.Action>();

    public ThreadDispatcher(){
        ownerThreadID = System.Threading.Thread.CurrentThread.ManagedThreadId;
    }

    private class CallbackStrage<TResult>{
        public TResult Result { get; set; }
        public System.Exception Exception { get; set; }
    }
    
    public TResult Run<TResult>(System.Func<TResult> callback){
        if (ManageThisThread()) {
            return callback();
        }
        

        var waitHandle = new System.Threading.EventWaitHandle(false, System.Threading.EventResetMode.ManualReset);
        var result = new CallbackStrage<TResult>();

        lock(queue) {
            queue.Enqueue(() => {
                try {
                    result.Result = callback();
                }
                catch (System.Exception e){
                    result.Exception = e;
                }
                finally {
                    waitHandle.Set();
                }
            });
        }
        waitHandle.WaitOne();
        
        if (result.Exception != null) {
            throw result.Exception;
        }
        return result.Result;
    }

    // Determines whether this thread is managed by this instance.
    internal bool ManageThisThread() {
        return System.Threading.Thread.CurrentThread.ManagedThreadId == ownerThreadID;
    }

    // This dispatches jobs queued up for the owning thread.
    // It must be called regularly or the threads waiting for job will be
    // blocked.
    public void Polljobs() {
        System.Diagnostics.Debug.Assert(ManageThisThread());

        System.Action job;
        while (true) {
            lock (queue) {
                if (queue.Count > 0) {
                    job = queue.Dequeue();
                } else {
                    break;
                }
            }
            job();
        }
    }

}

