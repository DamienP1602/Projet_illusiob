using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayIABrain : Brain
{
    [SerializeField] IA_VerticalMoveComponent movement = null;

    protected override State StartingState => new VerticalIdleState();

    // Start is called before the first frame update
    void Start()
    {
        fsm.InitFSM(this,StartingState);
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
}
