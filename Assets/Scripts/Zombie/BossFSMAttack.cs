using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFSMAttack : Dongkey.FSMState<Boss>
{

    static readonly BossFSMAttack instance = new BossFSMAttack();

    public static BossFSMAttack Instance
    {
        get
        {
            return instance;
        }
    }

    static BossFSMAttack() { }
    private BossFSMAttack() { }

    public override void EnterState(Boss owner)
    {
		owner.EnterStateMacineChanged( this );
    }

    public override void UpdateState(Boss owner)
    {

    }

    public override void ExitState(Boss owner)
    {

    }
}
