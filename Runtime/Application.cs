#region
//using System;
using UnityEngine;
#endregion
public abstract class Application<TReferences,TModel>: MonoBehaviour
    where TReferences : struct
    where TModel: struct
{
    #region
    public TReferences reference;
    
    public TModel model;
    #endregion
    #region Events
    protected void OnEnable() => this.__Subscribe(true);
    protected void OnDisable() => this.__Subscribe(false);
    #endregion
    #region Methods
    private void __Subscribe(bool condition){
        OnSubscription(condition);
    }
    protected abstract void OnSubscription(bool condition);
    #endregion
}
