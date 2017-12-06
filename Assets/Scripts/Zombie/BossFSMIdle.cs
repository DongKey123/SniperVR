using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFSMIdle : Dongkey.FSMState<Boss> {

    static readonly BossFSMIdle instance = new BossFSMIdle();

    public static BossFSMIdle Instance
    {
        get
        {
            return instance;
        }
    }

    static BossFSMIdle() { }
    private BossFSMIdle() { }

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
