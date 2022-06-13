#region
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#endregion
 
public static partial class Middleware<TParameter, TReturn>
{
    #region Variables
    private static readonly Dictionary<string, Func<TParameter, TReturn>> dic_publish = new Dictionary<string, Func<TParameter, TReturn>>();
    #endregion
    #region Methods
    public static void Subscribe_Publish(bool condition, string key, Func<TParameter,TReturn> action)
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
    public static TReturn Invoke_Publish(string key, TParameter value)
    {
        //Solo hace Invoke si hay una asignación...
        if (dic_publish.ContainsKey(key))
        {
            return dic_publish[key].Invoke(value);
            //visualMediations.Find(v => v.id.Equals(key)).Invoke();
        }

        return default;
    }
    #endregion
}
