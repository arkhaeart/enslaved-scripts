using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class InputState<T>
{
    Action<T> action;
    Action<T> called;
    public InputState(Action<T> action,Action<T> called)
    {
        this.action = action;
        this.called = called;
        Run();
    }
    public void Run()
    {
        action += called;
    }
    public void Stop()
    {
        action -= called;
    }

}
