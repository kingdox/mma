#region
using System;
using System.Collections;
using System.Collections.Generic;
//using UnityEngine;
#endregion

public static partial class Middleware<T>
{
    #region Variables
    private static readonly Dictionary<string, Func<IEnumerator<T>>> dic_coroutine_treturn = new Dictionary<string, Func<IEnumerator<T>>>();
    #endregion
    #region Methods
    public static void Subscribe(bool condition, string key, Func<IEnumerator<T>> request)
    {
        if (condition)
        {
            dic_coroutine_treturn.Add(key, request);
        }
        else
        {
            dic_coroutine_treturn.Remove(key);
        }
    }
    public static IEnumerator<T> Invoke_IEnumerator(string key)
    {
        if (dic_coroutine_treturn.ContainsKey(key))
        {
            return dic_coroutine_treturn[key].Invoke();
        }
        return null;
    }
    
    #endregion
}
