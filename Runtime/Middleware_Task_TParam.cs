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
    private static readonly Dictionary<int, Func<T, Task>> dic_task_request_param = new Dictionary<int, Func<T, Task>>();
    #endregion
    #region Methods
    public static void Subscribe_Task(in bool condition,in int key, Func<T, Task> request)
    {
        if (condition)
        {
            dic_task_request_param.Add(key, request);
        }
        else
        {
            dic_task_request_param.Remove(key);
        }
    }
    public static async Task Invoke_Task(int key, T value)
    {
        if (dic_task_request_param.ContainsKey(key))
        {
             await dic_task_request_param[key].Invoke(value);
        }
    }
    #endregion
}
