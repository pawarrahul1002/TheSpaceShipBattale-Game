using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this is MonoSingletonGeneric class , i've used for creating generic singleton class
public class MonoSingletonGeneric<T> : MonoBehaviour where T : MonoSingletonGeneric<T>
{
    private static T Instance;
    public static T instance { get { return Instance; } }

    protected virtual void Awake()
    {
        if (Instance == null)
        {
            Instance = (T)this;
        }
        else
        {
            Debug.LogError(Instance + "is Tring to create another instance");
            Destroy(this);
        }
    }
}
