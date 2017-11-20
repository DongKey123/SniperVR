using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dongkey;

public class ZombieFSMTrace : FSMState<Zombie> {


    static readonly ZombieFSMTrace instance = new ZombieFSMTrace();

    public static ZombieFSMTrace Instance
    {
        get
        {
            return instance;
        }
    }

    static ZombieFSMTrace() { }
    private ZombieFSMTrace() { }

    public override void EnterState(Zombie owner)
    {

    }

    public override void UpdateState(Zombie owner)
    {

    }

    public override void ExitState(Zombie owner)
    {

    }
}
