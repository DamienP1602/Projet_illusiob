using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Brain : MonoBehaviour
{
    [SerializeField] protected FSM fsm = null;
    protected abstract State StartingState { get; }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    protected virtual void Update()
    {
        fsm.UpdateFSM();
    }
}
