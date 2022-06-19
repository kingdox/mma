#region
using System;
//using System.Collections;
using System.Collections.Generic;
//using UnityEngine;
#endregion

public static partial class Middleware<TParameter,TReturn>
{
    #region Variables
    private static readonly Dictionary<string, Func<TParameter, IEnumerator<TReturn>>> dic_request = new Dictionary<string, Func<TParameter, IEnumerator<TReturn>>>();
    #endregion
    #region Methods
    public static void Subscribe_IEnumerator(bool condition, string key, Func<TParameter, IEnumerator<TReturn>> request)
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
    public static IEnumerator<TReturn> Invoke_IEnumerator(string key, TParameter value)
    {
        if (dic_request.ContainsKey(key))
        {
            return dic_request[key].Invoke(value);
        }
        //Debug.Log($"[{key}]: {dic_request.ContainsKey(key)}  ({value})");
        return null;
    }
    
    #endregion
}
