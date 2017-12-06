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

    float time = 0;

    public override void EnterState(Boss owner)
    {
        time = 0;
        owner.anim.SetBool("Shoutting", false);
    }

    public override void UpdateState(Boss owner)
    {
        time += Time.deltaTime;
        if(time >= 10f)
        {
            owner.ChangeState(BossFSMShouting.Instance);
        }
    }

    public override void ExitState(Boss owner)
    {

    }
}
