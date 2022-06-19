using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public static class AsyncExtensorUtils
{
    public static IEnumerator ToCoroutine(this Task _task)
    {
        while (!_task.IsCompleted) yield return null;
        if (_task.IsFaulted) throw _task.Exception;
    }
    
    public static IEnumerator<T> ToCoroutine<T>(this Task<T> _task)
    {
        while (!_task.IsCompleted) yield return default;
        if (_task.IsFaulted) throw _task.Exception;
        else yield return _task.Result;
    }
}
