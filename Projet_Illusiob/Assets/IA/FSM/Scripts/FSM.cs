using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
public class FSM
{
    protected Brain owner = null;
    [SerializeField] State currentState = null;

    bool runFSM = false;
    public bool IsRunning { get => runFSM; set => runFSM = value; }

    public void InitFSM(Brain _owner, State _startingState)
    {
        owner = _owner;
        currentState = _startingState;
    }

    public void UpdateFSM()
    {
        runFSM = true;
        if (runFSM)
        {
            currentState.Enter(owner);
            currentState.Update(owner);

            foreach (Transition _transition in currentState.transitions)
            {
                if (_transition.condition())
                {
                    currentState.Exit(owner);
                    currentState = _transition.nextState;
                }
            }
        }
    }
}
