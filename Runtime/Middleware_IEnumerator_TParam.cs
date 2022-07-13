#region
using System;
using System.Collections;
using System.Collections.Generic;
//using UnityEngine;
#endregion

public static partial class Middleware<T>
{
    #region Variables
    private static readonly Dictionary<int, Func<T, IEnumerator>> dic_request = new Dictionary<int, Func<T, IEnumerator>>();
    #endregion
    #region Methods
    public static void Subscribe_IEnumerator(in bool condition,in int key, Func<T, IEnumerator> request)
    {
        if (condition)
        {
            dic_request.Add(key, request);
        }
        else
        {
            dic_request.Remove(key);
        }
    }
    public static IEnumerator Invoke_IEnumerator(int key, T value)
    {
        if (dic_request.ContainsKey(key))
        {
            yield return dic_request[key].Invoke(value);
        }
        //Debug.Log($"[{key}]: {dic_request.ContainsKey(key)}  ({value})");
        yield return null;
    }
    
    #endregion
}
