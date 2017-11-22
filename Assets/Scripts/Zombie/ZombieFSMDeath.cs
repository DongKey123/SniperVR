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
		owner.m_navMeshAgent.isStopped = true;
		owner.anim.Play( "Death" );
		GameObject.Destroy( owner.gameObject, 2f );
	}

    public override void UpdateState(Zombie owner)
    {

    }

    public override void ExitState(Zombie owner)
    {

    }
}
