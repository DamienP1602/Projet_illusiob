using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public abstract class State
{
    public List<Transition> transitions = new();

    public bool isEnter = false;

    public abstract void Enter(Brain owner);
    public abstract void Update(Brain owner);
    public abstract void Exit(Brain owner);
}
