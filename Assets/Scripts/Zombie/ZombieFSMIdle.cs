using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dongkey;

public class ZombieFSMIdle : FSMState<Zombie> {

    static readonly ZombieFSMIdle instance = new ZombieFSMIdle();

    public static ZombieFSMIdle Instance
    {
        get
        {
            return instance;
        }
    }

    static ZombieFSMIdle() { }
    private ZombieFSMIdle() { }

    public override void EnterState(Zombie owner)
    {
		owner.EnterStateMacineChanged( this );
	}

    public override void UpdateState(Zombie owner)
    {

    }

    public override void ExitState(Zombie owner)
    {

    }
}
