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

    public override void EnterState(Boss owner)
    {

    }

    public override void UpdateState(Boss owner)
    {

    }

    public override void ExitState(Boss owner)
    {

    }
}
