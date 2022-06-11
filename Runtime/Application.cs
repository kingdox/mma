#region
using System;
using UnityEngine;
#endregion
[Obsolete("No Usar por temas de que usa un value como object...")]
public interface IApplication
{
    Action<string, object> OnSendMessage { get; set; }
}

[Serializable]
public abstract class ApplicationBase: MonoBehaviour,
    IApplication
{
    public Action<string, object> OnSendMessage { get; set; }
}
public abstract class Application<TReferences,TModel>: ApplicationBase,
    IApplication
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
        //TODO añadir el manejo recibir mensajes
        OnSubscription(condition);
    }
    protected abstract void OnSubscription(bool condition);
    #endregion
}
