using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// 单例基类
/// </summary>
/// <typeparam name="T"></typeparam>
public class Singleton<T> : IDisposable where T : new()//约束,要求实例化
{
    private static T instance;

    public static T Instance
    {
        get
        {
            if(instance == null)
            {
                instance = new T();
            }
            return instance;
        }
    }

    public virtual void Dispose()
    {
        
    }
}
