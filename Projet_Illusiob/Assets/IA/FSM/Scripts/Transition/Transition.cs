using System;

[Serializable]
public class Transition
{
    public Func<bool> condition = null;
    public State nextState = null;

    public Transition(Func<bool> _condition, State _nextState)
    {
        condition = _condition;
        nextState = _nextState;
    }

    public virtual void Enter(Brain owner) { }
    public virtual void Exit(Brain owner) { }
}
