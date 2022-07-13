#region
using System;
using System.Threading.Tasks;
//using System.Threading;
//using System.Collections;
using System.Collections.Generic;
//using UnityEngine;
#endregion
public static partial class Middleware<TParameter,TReturn>
{
    #region Variables
    private static readonly Dictionary<int, Func<TParameter, Task<TReturn>>> dic_task_request = new Dictionary<int, Func<TParameter, Task<TReturn>>>();
    #endregion
    #region Methods
    public static void Subscribe_Task(in bool condition, in int key, Func<TParameter, Task<TReturn>> request)
    {
        if (condition)
        {
            dic_task_request.Add(key, request);
        }
        else
        {
            dic_task_request.Remove(key);
        }
    }
    public static async Task<TReturn> Invoke_Task(int key, TParameter value)
    {
        if (dic_task_request.ContainsKey(key))
        {
            return await dic_task_request[key].Invoke(value);
        }
        return default;
    }
    #endregion
}
