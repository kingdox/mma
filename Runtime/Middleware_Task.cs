#region
//using System;
using System.Threading.Tasks;
//using System.Threading;
//using System.Collections;
using System.Collections.Generic;
//using UnityEngine;
#endregion
public static partial class Middleware
{
    #region Variables
    private static readonly Dictionary<string, Task> _dic_task_ = new Dictionary<string, Task>();
    #endregion
    #region Methods
    public static void Subscribe_Task(bool condition, string key, Task request)
    {
        if (condition)
        {
            _dic_task_.Add(key, request);
        }
        else
        {
            _dic_task_.Remove(key);
        }
    }
    public static async Task Invoke_Task(string key)
    {
        if (_dic_task_.ContainsKey(key))
        {
             await _dic_task_[key];
        }
    }
    #endregion
}
