#region
//using System;
using System.Threading.Tasks;
//using System.Threading;
//using System.Collections;
using System.Collections.Generic;
//using UnityEngine;
#endregion
public static partial class Middleware<T>
{
    #region Variables
    private static readonly Dictionary<string, Task<T>> dic_task_request_response = new Dictionary<string, Task<T>>();
    #endregion
    #region Methods
    public static void Subscribe(bool condition, string key, Task<T> request)
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
    public static async Task<T> Invoke_Task(string key)
    {
        if (dic_task_request_param.ContainsKey(key))
        {
             return await dic_task_request_response[key];
        }
        return default;
    }
    #endregion
}