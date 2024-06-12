using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SingletonParent<T> : MonoBehaviour where T : SingletonParent<T>
{
    private static T _instance;
    public static T Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = FindObjectOfType<T>();
                if(_instance == null)
                {
                    _instance = new GameObject().AddComponent<T>();
                }
            }
            return _instance;
        }
    }
    protected virtual void Awake()
    {
        if(_instance != null)
        {
            Destroy(gameObject);
        }
        _instance = (T)this;
    }
}
