using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFSMShouting : Dongkey.FSMState<Boss>
{

    static readonly BossFSMShouting instance = new BossFSMShouting();

    public static BossFSMShouting Instance
    {
        get
        {
            return instance;
        }
    }

    static BossFSMShouting() { }
    private BossFSMShouting() { }

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
