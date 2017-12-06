using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFSMTrace : Dongkey.FSMState<Boss>
{

    static readonly BossFSMTrace instance = new BossFSMTrace();

    public static BossFSMTrace Instance
    {
        get
        {
            return instance;
        }
    }

    static BossFSMTrace() { }
    private BossFSMTrace() { }

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
