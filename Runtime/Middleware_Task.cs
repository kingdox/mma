#region
using System;
using System.Threading.Tasks;
//using System.Threading;
//using System.Collections;
using System.Collections.Generic;
//using UnityEngine;
#endregion
public static partial class Middleware
{
    #region Variables
    private static readonly Dictionary<int, Func<Task>> _dic_task_ = new Dictionary<int, Func<Task>>();
    #endregion
    #region Methods
    public static void Subscribe_Task(in bool condition, in int key, Func<Task> request)
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
    public static async Task Invoke_Task(int key)
    {
        if (_dic_task_.ContainsKey(key))
        {
             await _dic_task_[key].Invoke();
        }
    }
    #endregion
}
