#region
using System;
//using System.Collections;
using System.Collections.Generic;
//using UnityEngine;
#endregion

public static partial class Middleware<T>
{
    #region Variables
    private static readonly Dictionary<int, Func<T>> dic_publish_return = new Dictionary<int, Func<T>>();
    #endregion
    #region Methods
    public static void Subscribe_Publish(in bool condition, in int key, Func<T> action)
    {
        if (condition)
        {
            //Si NO existe se añade
            if (!dic_publish_return.ContainsKey(key))
            {
                dic_publish_return.Add(key, default);
            }
            dic_publish_return[key] += action;//(Action<object>)
        }
        else if (dic_publish_return.ContainsKey(key))
        {
            dic_publish_return[key] -= action;//(Action<object>)
            //Si no hay ninguno solicitando lo elimina del diccionario
            if (dic_publish_return[key] == null)
            {
                dic_publish_return.Remove(key);
            }
        }
        //Invoke(Invoke)
    }
    public static T Invoke_Publish(in int key)
    {
        //Solo hace Invoke si hay una asignación...
        if (dic_publish_return.ContainsKey(key))
        {
            return dic_publish_return[key].Invoke();
        }
        return default;
    }
    #endregion
}
