using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dongkey;

public class ZombieFSMDeath : Dongkey.FSMState<Zombie>
{

    static readonly ZombieFSMDeath instance = new ZombieFSMDeath();

    public static ZombieFSMDeath Instance
    {
        get
        {
            return instance;
        }
    }

    static ZombieFSMDeath() { }
    private ZombieFSMDeath() { }

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
