#region
using System;
//using System.Collections;
using System.Collections.Generic;
//using UnityEngine;
#endregion
public static partial class Middleware
{
    #region Variables
    private static readonly Dictionary<int, Action> dic_publish = new Dictionary<int, Action>();
    #endregion
    #region Methods
    public static void Subscribe_Publish(in bool condition, in int key, Action action)
    {
        if (condition)
        {
            //Si NO existe se añade
            if (!dic_publish.ContainsKey(key))
            {
                dic_publish.Add(key, default);
            }
            dic_publish[key] += action;//(Action<object>)
        }
        else if (dic_publish.ContainsKey(key))
        {
            dic_publish[key] -= action;//(Action<object>)
            //Si no hay ninguno solicitando lo elimina del diccionario
            if (dic_publish[key] == null)
            {
                dic_publish.Remove(key);
            }
        }
    }

    public static void Invoke_Publish(in int key)
    {
        //Solo hace Invoke si hay una asignación...
        if (dic_publish.ContainsKey(key))
        {
            dic_publish[key]?.Invoke();
        }
    }
    #endregion
}
