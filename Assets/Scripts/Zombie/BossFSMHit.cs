using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFSMHit : Dongkey.FSMState<Boss>
{

    static readonly BossFSMHit instance = new BossFSMHit();

    public static BossFSMHit Instance
    {
        get
        {
            return instance;
        }
    }

    static BossFSMHit() { }
    private BossFSMHit() { }

    float time = 0;

    public override void EnterState(Boss owner)
    {
        time = 0;
        owner.anim.Play("GetHit");
		owner.EnterStateMacineChanged( this );
	}

    public override void UpdateState(Boss owner)
    {
        time += Time.deltaTime;
        if (time > 2f)
        {
            owner.ChangeState(BossFSMIdle.Instance);
        }
    }

    public override void ExitState(Boss owner)
    {

    }
}
