#region
using System;
using System.Threading.Tasks;
//using System.Threading;
//using System.Collections;
using System.Collections.Generic;
//using UnityEngine;
#endregion
public static partial class Middleware<T>
{
    #region Variables
    private static readonly Dictionary<int, Func<Task<T>>> dic_task_request_response = new Dictionary<int, Func<Task<T>>>();
    #endregion
    #region Methods
    public static void Subscribe_Task(in bool condition, in int key, Func<Task<T>> request)
    {
        if (condition)
        {
            dic_task_request_response.Add(key, request);
        }
        else
        {
            dic_task_request_response.Remove(key);
        }
    }
    public static async Task<T> Invoke_Task(int key)
    {
        if (dic_task_request_response.ContainsKey(key))
        {
            return await dic_task_request_response[key].Invoke();
        }
        else
        {
            return default;
        }
    }
    #endregion
}
