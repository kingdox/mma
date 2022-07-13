#region
using System;
using System.Collections;
using System.Collections.Generic;
//using UnityEngine;
#endregion

public static partial class Middleware
{
    #region Variables
    private static readonly Dictionary<int, Func<IEnumerator>> dic_request = new Dictionary<int, Func<IEnumerator>>();
    #endregion
    #region Methods
    public static void Subscribe_IEnumerator(in bool condition, in int key, Func<IEnumerator> request)
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
    public static IEnumerator Invoke_IEnumerator(in int key)
    {
        if (dic_request.ContainsKey(key))
        {
            return dic_request[key].Invoke();
        }
        return null;
    }
    #endregion
}
