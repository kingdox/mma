#region
using System;
using System.Threading.Tasks;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#endregion
public static partial class Middleware<TParameter,TReturn>
{
    #region Variables
    private static readonly Dictionary<string, Func<TParameter, Task<TReturn>>> dic_task_request = new Dictionary<string, Func<TParameter, Task<TReturn>>>();
    #endregion
    #region Methods
    public static void Subscribe_Task(bool condition, string key, Func<TParameter, Task<TReturn>> request)
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
    //public static async Task InvokeTaskRequest(System.Enum key) => await InvokeTaskRequest(key, key);
    public static async Task<TReturn> Invoke_Task(string key, TParameter value=default)
    {
        if (dic_task_request.ContainsKey(key))
        {
            return await dic_task_request[key].Invoke(value);
        }
        return default;
    }
    #endregion
}
