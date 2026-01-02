using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EntityBehaviour : MonoBehaviour
{
    private void OnEnable() {
        EntityManager.entities.Add(this);
    }
    private void OnDisable() {
        EntityManager.entities.Remove(this);
    }
    public virtual void OnUpdate() {
    
    }

    public virtual void OnFixedUpdate() {
    
    }

    public virtual void OnLateUpdate() {

    }

#if UNITY_EDITOR
    [Obsolete]
    protected virtual object Update() {
        return null;
    }
    [Obsolete]
    protected virtual object LateUpdate() {
        return null;
    }
    [Obsolete]
    protected virtual object FixedUpdate() {
        return null;
    }
#endif
}
