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
    private static readonly Dictionary<string, Func<T, Task>> dic_task_request_param = new Dictionary<string, Func<T, Task>>();
    #endregion
    #region Methods
    public static void Subscribe(bool condition, string key, Func<T, Task> request)
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
    public static async Task Invoke_Task(string key, T value)
    {
        if (dic_task_request_param.ContainsKey(key))
        {
             await dic_task_request_param[key].Invoke(value);
        }
    }
    #endregion
}
