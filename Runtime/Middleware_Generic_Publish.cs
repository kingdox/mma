#region
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#endregion

public static partial class Middleware<TParameter>
{
    #region Variables
    private static readonly Dictionary<string, Action<TParameter>> dic_publish = new Dictionary<string, Action<TParameter>>();
    #endregion
    #region Methods
    public static void Subscribe_Publish(bool condition, string key, Action<TParameter> action)
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
    public static void Invoke_Publish(string key, TParameter value = default)
    {
        //Solo hace Invoke si hay una asignación...
        if (dic_publish.ContainsKey(key))
        {
            dic_publish[key]?.Invoke(value);
            //visualMediations.Find(v => v.id.Equals(key)).Invoke();
        }
    }
    #endregion
}
