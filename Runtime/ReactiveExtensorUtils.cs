using System;
using UnityEngine.Events;
namespace X
{
    public static partial class ReactiveExtensorUtils 
    {
        /// <summary>
        /// Apply a subscription to a specified Action, that can be a method group
        /// </summary>
        public static void Subscribe<T>(this bool condition, ref UnityAction<T> del, UnityAction<T> action)
        {
            if (condition) del += action;
            else del -= action;
        }

        public static void Subscribe<T>(this bool condition, ref Action<T> del, Action<T> action)
        {
            if (condition) del += action;
            else del -= action;
        }

        /// <summary>
        /// Apply a subscription to a specified Action, that can be a method group
        /// </summary>
        public static void Subscribe(this bool condition, ref Action del, Action action)
        {
            if (condition) del += action;
            else del -= action;
        }


    }
}
