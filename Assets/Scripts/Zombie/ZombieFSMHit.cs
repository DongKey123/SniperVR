using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieFSMHit : Dongkey.FSMState<Zombie>
{

    static readonly ZombieFSMHit instance = new ZombieFSMHit();

    public static ZombieFSMHit Instance
    {
        get
        {
            return instance;
        }
    }

    static ZombieFSMHit() { }
    private ZombieFSMHit() { }

    float time = 0;

    public override void EnterState(Zombie owner)
    {
		Debug.Log( "hit" );
		owner.m_navMeshAgent.isStopped = true;
        time = 0;
        owner.anim.Play("Hit");
    }

    public override void UpdateState(Zombie owner)
    {
        time += Time.deltaTime;
        if(time > 2f)
        {
            owner.ChangeState(ZombieFSMTrace.Instance);
        }
    }

    public override void ExitState(Zombie owner)
    {

    }
}
