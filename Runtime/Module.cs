#region
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#endregion
public abstract class Module: MonoBehaviour
{
#region Events
#if UNITY_EDITOR
    private void Awake()
    {
        if (transform.childCount > 0){
            Debug.LogWarning($"Ha quedado Apps basura en {transform.name}, Limpiando...");
            foreach (Transform child in transform) Destroy(child.gameObject);
        }
    }
#endif
    protected void OnEnable() => this.__Subscribe(true);
    protected void OnDisable() => this.__Subscribe(false);
#endregion
#region Methods
    private void __Subscribe(bool condition){
        OnSubscription(condition);
        OnExtendedSubscription(condition);
    }
    /// <summary>
    /// Specific Module Implementation
    /// </summary>
    protected abstract void OnSubscription(bool condition);
    /// <summary>
    /// Extended Module Implementation (by partials)
    /// </summary>
    protected virtual void OnExtendedSubscription(bool condition) { }

    #endregion
}
