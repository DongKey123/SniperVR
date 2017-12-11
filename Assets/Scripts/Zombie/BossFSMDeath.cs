using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFSMDeath : Dongkey.FSMState<Boss>
{

    static readonly BossFSMDeath instance = new BossFSMDeath();

    public static BossFSMDeath Instance
    {
        get
        {
            return instance;
        }
    }

    static BossFSMDeath() { }
    private BossFSMDeath() { }

    public override void EnterState(Boss owner)
    {
        owner.anim.Play("Death");
		owner.EnterStateMacineChanged( this );
    }

    public override void UpdateState(Boss owner)
    {

    }

    public override void ExitState(Boss owner)
    {

    }
}
