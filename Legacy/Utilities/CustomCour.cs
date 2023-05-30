using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class CustomCour
{
    Func<IEnumerator> func;
    Coroutine coroutine;
    MonoBehaviour mono;
    Action callback;
    public CustomCour(MonoBehaviour _mono, Func<IEnumerator> _func)
    {
        mono = _mono;
        func = _func;
    }
    public CustomCour(MonoBehaviour _mono, Func<IEnumerator> _func,Action callback)
    {
        mono = _mono;
        func = _func;
        this.callback = callback;
    }
    public void Run()
    {
        Stop();
        coroutine = mono.StartCoroutine(Process());
    }

    public void Stop()
    {
        if (IsActive)
        {
            mono.StopCoroutine(coroutine);
            coroutine = null;
        }
        Debug.Log("callback invoked");
        callback?.Invoke();
    }
    public bool IsActive { get => coroutine != null; }
    IEnumerator Process()
    {
        yield return mono.StartCoroutine(func.Invoke());
        coroutine = null;
        Debug.Log("callback invoked");
        callback?.Invoke();
    }
}
public class CustomCour<T>
{
    Func<T,IEnumerator> func;
    Coroutine coroutine, subCour;
    MonoBehaviour mono;
    public CustomCour(MonoBehaviour _mono,  Func<T,IEnumerator> _func)
    {
        mono = _mono;
        func = _func;
    }
    public void Run(T arg)
    {
        Stop();
        coroutine = mono.StartCoroutine(Process(arg));
    }

    public void Stop()
    {
        Debug.Log(coroutine);
        if (IsActive)
        {
            mono.StopCoroutine(coroutine);
            coroutine = null;
        }
        if(subCour!=null)
        {
            mono.StopCoroutine(subCour);
            subCour = null;
        }
    }
    public bool IsActive  => coroutine != null; 
    IEnumerator Process(T arg)
    {
        subCour= mono.StartCoroutine(func.Invoke(arg));
        yield return subCour;
        coroutine = null;
        Stop();
    }
}

