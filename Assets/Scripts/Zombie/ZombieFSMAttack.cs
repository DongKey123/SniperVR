using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieFSMAttack : Dongkey.FSMState<Zombie> {

    static readonly ZombieFSMAttack instance = new ZombieFSMAttack();

    public static ZombieFSMAttack Instance
    {
        get
        {
            return instance;
        }
    }

    static ZombieFSMAttack() { }
    private ZombieFSMAttack() { }

    public override void EnterState(Zombie owner)
    {
		owner.m_navMeshAgent.isStopped = true;
        owner.anim.Play("Attack(1)");
		owner.KillHero();
    }

    public override void UpdateState(Zombie owner)
    {

    }

    public override void ExitState(Zombie owner)
    {

    }

}
